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
        public MemberName ReturnType { get; private set; }

        public PropertyMember(XElement element, DocManager manager) : base(element, manager)
        {
            string retAttr = _XML.Attribute(nameof(ReturnType))?.Value;
            if (!string.IsNullOrEmpty(retAttr))
                ReturnType = new MemberName(retAttr);
        }


        public override void Commit()
        {
            _XML.SetAttributeValue(nameof(ReturnType), ReturnType == null ? null : $"T:{ReturnType.TypeName}");
        }


        public void ChangeReturnType(string returnType)
        {
            ReturnType = new MemberName($"T:{returnType}");
            Commit();
        }

    }

}
