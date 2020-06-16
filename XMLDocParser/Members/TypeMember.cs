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
        public List<string> Implements { get; private set; }
        public string Base { get; private set; }
        public string ClassType { get; private set; }


        internal TypeMember(XElement element, DocManager manager) : base(element, manager)
        {
            Base = _XML.Attribute(nameof(Base))?.Value;
            Implements = _XML.Attribute(nameof(Implements))?.Value?.Split(';')?.ToList() ?? new List<string>();
            ClassType = _XML.Attribute(nameof(ClassType))?.Value ?? "Class";
        }

        public override void Commit()
        {
            string impStr = string.Join(";", Implements.Select(x => x));
            if (_XML.Attribute(nameof(Implements))?.Value != impStr)
                _XML.SetAttributeValue(nameof(Implements), string.IsNullOrWhiteSpace(impStr) ? null : impStr);

            _XML.SetAttributeValue(nameof(Base), Base == null ? null : Base);

            _XML.SetAttributeValue(nameof(ClassType), string.IsNullOrWhiteSpace(ClassType ?? "") ? null : ClassType);
        }

        #region SafeAdd
        public void AddImplementor(string implementor)
        {
            if (implementor != typeof(object).FullName && !Implements.Contains(implementor))
            {
                Implements.Add(implementor);
                Commit();
            }
        }

        public void ChangeBaseClass(string baseClass)
        {
            if (baseClass != typeof(object).FullName)
            {
                Base = baseClass;
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
