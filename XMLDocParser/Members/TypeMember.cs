using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDocParser
{
    public class TypeMember : BaseMember
    {
        public List<MemberID> Implements { get; private set; }
        public List<MemberID> Inherits { get; private set; }
        public string ClassType { get; private set; }


        public TypeMember(XElement element, DocManager manager) : base(element, manager)
        {
            Implements = _XML.Attribute("Implements")?.Value?.Split(';')?.Select(x => new MemberID(x)).ToList() ?? new List<MemberID>();
            Inherits = _XML.Attribute("Inherits")?.Value?.Split(';')?.Select(x => new MemberID(x)).ToList() ?? new List<MemberID>();
            ClassType = _XML.Attribute("ClassType")?.Value ?? "Class";
        }

        public override void Commit()
        {
            string impStr = string.Join(";", Implements.Select(x => $"T:{x}"));
            if (_XML.Attribute("Implements")?.Value != impStr)
                _XML.SetAttributeValue("Implements", string.IsNullOrWhiteSpace(impStr) ? null : impStr);

            string inheritStr = string.Join(";", Inherits.Select(x => $"T:{x}"));
            if (_XML.Attribute("Inherits")?.Value != inheritStr)
                _XML.SetAttributeValue("Inherits", string.IsNullOrWhiteSpace(inheritStr) ? null : inheritStr);

            _XML.SetAttributeValue("ClassType", string.IsNullOrWhiteSpace(ClassType) ? null : ClassType);
        }

        #region SafeAdd
        public void AddImplementor(string implementor)
        {
            if (implementor != typeof(object).FullName && !Implements.Select(x => x.ToString()).Contains(implementor))
            {
                Implements.Add($"T:{implementor}");
                Commit();
            }
        }
        
        public void AddInheritor(string inheritor)
        {
            if (inheritor != typeof(object).FullName && !Implements.Select(x => x.ToString()).Contains(inheritor))
            {
                Implements.Add($"T:{inheritor}");
                Commit();
            }
        }

        public void AddClassType(string type)
        {
            if (ClassType != type)
            {
                ClassType = type;
                Commit();
            }
        }
        #endregion

    }

}
