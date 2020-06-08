using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vsxmd.Units;

namespace XMLDocParser
{
    public class BaseMember : IMember
    {
        protected readonly XElement _XML;

        public readonly MemberName ID;

        public readonly DocManager Manager;


        protected string Assembly => Manager.GetAssemblyName(_XML);

        public string TypeName => ID.TypeName;


        public BaseMember(XElement element, DocManager manager)
        {
            Manager = manager;
            _XML = element;
            ID = new MemberName(_XML.Attribute("name").Value);
        }

        public virtual void Commit()
        {
        }

        public XElement ToXML() => _XML;

        public virtual string ToMarkdown(bool summary = false) => ID.ToString();

    }

}
