using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDocParser
{
    public class BaseMember : IMember
    {
        protected readonly XElement _XML;

        public readonly MemberID ID;

        public readonly DocManager Manager;

        public string Assembly => Manager.GetAssembly(_XML);


        public BaseMember(XElement element, DocManager manager)
        {
            Manager = manager;
            _XML = element;
            ID = new MemberID(_XML.Attribute("name").Value);
        }

        public virtual void Commit()
        {
        }

        public XElement ToXML() => _XML;

        public virtual string ToMarkdown(bool summary = false) => ID.ToMarkdown();

    }

}
