using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vsxmd.Units;

namespace XMLDocParser
{
    public class TypeMember : BaseMember
    {
        public List<MemberName> Implements { get; private set; }
        public MemberName Base { get; private set; }
        public string ClassType { get; private set; }


        internal TypeMember(XElement element, DocManager manager) : base(element, manager)
        {
            string baseAttr = _XML.Attribute(nameof(Base))?.Value;
            if (!string.IsNullOrEmpty(baseAttr))
                Base = new MemberName(baseAttr);
            Implements = _XML.Attribute(nameof(Implements))?.Value?.Split(';')?.Select(x => new MemberName(x)).ToList() ?? new List<MemberName>();
            ClassType = _XML.Attribute(nameof(ClassType))?.Value ?? "Class";
        }

        public override void Commit()
        {
            string impStr = string.Join(";", Implements.Select(x => $"T:{x}"));
            if (_XML.Attribute(nameof(Implements))?.Value != impStr)
                _XML.SetAttributeValue(nameof(Implements), string.IsNullOrWhiteSpace(impStr) ? null : impStr);

            _XML.SetAttributeValue(nameof(Base), Base == null ? null : $"T:{Base}");

            _XML.SetAttributeValue(nameof(ClassType), string.IsNullOrWhiteSpace(ClassType ?? "") ? null : ClassType);
        }

        #region SafeAdd
        public void AddImplementor(string implementor)
        {
            if (implementor != typeof(object).FullName && !Implements.Select(x => x.TypeName).Contains(implementor))
            {
                Implements.Add(new MemberName($"T:{implementor}"));
                Commit();
            }
        }

        public void ChangeBaseClass(string baseClass)
        {
            if (baseClass != typeof(object).FullName)
            {
                Base = new MemberName($"T:{baseClass}");
                Commit();
            }
        }

        public void ChangeClassType(string type)
        {
            ClassType = type;
            Commit();
        }
        #endregion

    }

}
