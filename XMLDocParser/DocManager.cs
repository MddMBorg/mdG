using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDocParser
{
    public class DocManager
    {
        #region Mapping
        private readonly List<XDocument> _Documents = new List<XDocument>();
        private readonly Dictionary<XDocument, string> _DocAssemblies = new Dictionary<XDocument, string>();

        private readonly List<BaseMember> _Members = new List<BaseMember>();
        #endregion

        public void LoadDoc(XDocument document)
        {
            if (!_Documents.Contains(document) && document != null)
                _Documents.Add(document);
        }

        /// <summary>
        /// Extracts the members from specified document, making sure all members have a corresponding TypeMember.
        /// Adds generated members to internal cache where appropriate
        /// </summary>
        /// <param name="document">Document to parse for member information.</param>
        public IEnumerable<BaseMember> GenerateMembers(XDocument document)
        {
            LoadDoc(document);

            var memberElements = document
                .Root
                .Element("members");

            var members = memberElements
                .Elements("member")
                .Select(x => CreateMember(x))
                .GroupBy(x => x.Type)
                .Select(x => AssureTypeMember(x, memberElements))
                .SelectMany(x => x);

            //Remove previously cached members with the same names as the ones just generated, then add again.
            _Members.RemoveAll(x => members.Any(y => y.ID.ProperName == x.ID.ProperName));
            _Members.AddRange(members);

            return members;
        }


        internal string GetAssemblyName(XDocument document)
        {
            string name = "";
            if (document != null && !_DocAssemblies.TryGetValue(document, out name))
            {
                name = document.Root.Element("assembly").Element("name").Value;
                _DocAssemblies[document] = name;
            }
            return name;
        }

        internal string GetAssemblyName(XElement element) => GetAssemblyName(element?.Document);

        internal TypeMember GetTypeMember(BaseMember member) => _Members.OfType<TypeMember>().FirstOrDefault(x => x.Type == member.Type);

        internal BaseMember GetBase(BaseMember member)
        {
            //Get a list of all members of this type
            TypeMember typeMem = _Members.OfType<TypeMember>().FirstOrDefault(x => x.Type == member.Type);
            IEnumerable<MemberID> bases = typeMem.Inherits.Concat(typeMem.Implements);
            IEnumerable<BaseMember> potentials = _Members.Where(x => bases.Any(y => x.Type == y.Type && x.ID.Defintion == y.Defintion));

            //If can't find any members of same type with same defintion (method, prop, field etc.), return null and allow calling member to handle.
            if (potentials.Count() == 0)
                return null;

            // To do : resolve this for multi returns.
            return potentials.First();
        }


        #region Helpers
        private BaseMember CreateMember(XElement element)
        {
            switch (element.Attribute("name").Value.First())
            {
                case 'T':
                    return new TypeMember(element, this);
                default:
                    return new BaseMember(element, this);
            }
        }

        /// <summary>
        /// Mutates a list of Members to check there is always an entry for the underlying Type.
        /// Also needs to be added to the underlying XDocument for purposes of <see cref="GetAssemblyName(XDocument)"/>
        /// </summary>
        /// <param name="members">List of members (of same Type) to check.</param>
        /// <param name="elements">The "members" element from the XML Documentation to add to.</param>
        /// <returns></returns>
        private IEnumerable<BaseMember> AssureTypeMember(IEnumerable<BaseMember> members, XElement elements)
        {
            if (!members.Any(x => x is TypeMember))
            {
                XElement memberElement = new XElement("element", new XAttribute("name", $"T:{members.First().Type}"));

                elements.Add(memberElement);

                members = members.Concat(new[] { new TypeMember(memberElement, this) });
            }
            return members;
        }
        #endregion

    }

}
