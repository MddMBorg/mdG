using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDocParser.Members
{
    public class PropertyMember : BaseMember
    {
        public MemberID ReturnType { get; private set; }

        public PropertyMember(XElement element, DocManager manager) : base(element, manager)
        {
            ReturnType = _XML.Attribute(nameof(ReturnType))?.Value;
        }


        public override void Commit()
        {
            _XML.SetAttributeValue(nameof(ReturnType), ReturnType == null ? null : $"T:{ReturnType}");
        }


        public void ChangeReturnType(string returnType)
        {
            ReturnType = $"T:{returnType}";
            Commit();
        }

    }

}
