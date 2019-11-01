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
        List<XDocument> _Documents = new List<XDocument>();

        Dictionary<XDocument, string> _DocAssemblies = new Dictionary<XDocument, string>();

        List<TypeMember> Types = new List<TypeMember>();


        public void LoadDoc(XDocument document)
        {
            if (!_Documents.Contains(document) && document != null)
                _Documents.Add(document);
        }

        public IEnumerable<BaseMember> GetMembers(XDocument document)
        {
            LoadDoc(document);

            return document
                .Root
                .Element("members")
                .Elements("member")
                .Select(x => CreateMember(x));
        }

        internal BaseMember CreateMember(XElement element)
        {
            switch (element.Attribute("name").Value.First())
            {
                case 'T':
                    return new TypeMember(element, this);
                default:
                    return new BaseMember(element, this);
            }
        }

        internal IEnumerable<BaseMember> AssureTypeMember(IEnumerable<BaseMember> members, XElement elements)
        {
            if (!members.Any(x => x is TypeMember))
            {
                string typeName = members.First().ID.ToString();

            }
        }

        internal string GetAssembly(XDocument document)
        {
            string name = "";
            if (document != null && !_DocAssemblies.TryGetValue(document, out name))
            {
                name = document.Root.Element("assembly").Element("name").Value;
                _DocAssemblies[document] = name;
            }
            return name;
        }

        internal string GetAssembly(XElement element) => GetAssembly(element?.Document);

    }

}
