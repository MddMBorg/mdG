using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vsxmd.Units;

namespace XMLDocParser.Members
{
    public class PropertyMember : BaseMember
    {
        public string ReturnType { get; private set; }

        internal PropertyMember(XElement element, DocManager manager) : base(element, manager)
        {
            ReturnType = _XML.Attribute(nameof(ReturnType))?.Value;
        }


        public override void Commit()
        {
            _XML.SetAttributeValue(nameof(ReturnType), ReturnType);
        }


        public void ChangeReturnType(string returnType)
        {
            ReturnType = returnType;
            Commit();
        }

    }

}
