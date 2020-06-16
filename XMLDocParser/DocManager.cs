using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vsxmd.Units;
using XMLDocParser.Members;

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
                .GroupBy(x => x.TypeName)
                .Select(x => AssureTypeMember(x, memberElements))
                .SelectMany(x => x);

            //Remove previously cached members with the same names as the ones just generated, then add again.
            _Members.RemoveAll(x => members.Any(y => y.ID.TypeName == x.ID.TypeName));
            _Members.AddRange(members);

            return members;
        }

        public void SafeAddProperty(XDocument doc, string propName)
        {
            if (!_Members.OfType<PropertyMember>().Any(x => x.ID.LongName.Equals(propName.ToXMLType())))
            {
                XElement memberElement = new XElement("member", new XAttribute("name", $"P:{propName.ToXMLType()}"));
                memberElement.Add(new XElement("Inheritdoc"));
                doc.Root.Element("members").Add(memberElement);
                _Members.Add(new PropertyMember(memberElement, this) );
            }
        }

        public void SafeAddField(XDocument doc, string propName)
        {
            if (!_Members.OfType<PropertyMember>().Any(x => x.ID.LongName.Equals(propName.ToXMLType())))
            {
                XElement memberElement = new XElement("member", new XAttribute("name", $"F:{propName.ToXMLType()}"));
                memberElement.Add(new XElement("Inheritdoc"));
                doc.Root.Element("members").Add(memberElement);
                _Members.Add(new PropertyMember(memberElement, this));
            }
        }

        public void SafeAddMethod(XDocument doc, string methodName)
        {
            if (!_Members.OfType<MethodMember>().Any(x => x.ID.LongName.Equals(methodName.ToXMLType())))
            {
                XElement memberElement = new XElement("member", new XAttribute("name", $"M:{methodName.ToXMLType()}"));
                memberElement.Add(new XElement("Inheritdoc"));
                doc.Root.Element("members").Add(memberElement);
                _Members.Add(new MethodMember(memberElement, this));
            }
        }

        public void SafeAddType(XDocument doc, string typeName)
        {
            if (!_Members.OfType<TypeMember>().Any(x => x.ID.LongName.Equals(typeName.ToXMLType())))
            {
                XElement memberElement = new XElement("member", new XAttribute("name", $"T:{typeName.ToXMLType()}"));
                memberElement.Add(new XElement("Inheritdoc"));
                doc.Root.Element("members").Add(memberElement);
                _Members.Add(new PropertyMember(memberElement, this));
            }
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

        internal TypeMember GetTypeMember(BaseMember member) => _Members.OfType<TypeMember>().FirstOrDefault(x => x.TypeName == member.TypeName);

        //ToDo : Correct
        internal BaseMember GetBase(BaseMember member)
        {
            //Get a list of all members of this type
            TypeMember typeMem = _Members.OfType<TypeMember>().FirstOrDefault(x => x.TypeName == member.TypeName);
            List<string> bases = typeMem.Implements;
            bases.Add(typeMem.Base);
            IEnumerable<BaseMember> potentials = _Members.Where(x => bases.Any(y => x.ID.TypeName == NormalType.CreateNormalType(y).ShortLinkName
                && x.ID.FriendlyName == NormalType.CreateNormalType(y).ShortLinkName));

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
                case 'P':
                case 'F':
                    return new PropertyMember(element, this);
                case 'M':
                    return new MethodMember(element, this);
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
                XElement memberElement = new XElement("member", new XAttribute("name", $"T:{members.First().TypeName}"));
                memberElement.Add(new XElement("Inheritdoc"));
                elements.Add(memberElement);
                members = members.Concat(new[] { new TypeMember(memberElement, this) });
            }
            return members;
        }
        #endregion

    }

}
