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
            Implements = _XML.Attribute("Implements")?.Value?.Split(';')?.Select(x => new MemberID($"T:{x}")).ToList() ?? new List<MemberID>();
            Inherits = _XML.Attribute("Inherits")?.Value?.Split(';')?.Select(x => new MemberID($"T:{x}")).ToList() ?? new List<MemberID>();
            ClassType = _XML.Attribute("ClassType")?.Value ?? "Class";
        }

        public override void Commit()
        {
            string impStr = string.Join(";", Implements);
            if (_XML.Attribute("Implements")?.Value != impStr)
                _XML.SetAttributeValue("Implements", impStr);

            string inheritStr = string.Join(";", Inherits);
            if (_XML.Attribute("Inherits")?.Value != inheritStr)
                _XML.SetAttributeValue("Inherits", inheritStr);

            _XML.SetAttributeValue("ClassType", ClassType);
        }

        #region SafeAdd
        public void AddImplementor(string implementor)
        {
            if (!Implements.Select(x => x.ToString()).Contains(implementor))
            {
                Implements.Add(implementor);
                Commit();
            }
        }
        
        public void AddInheritor(string inheritor)
        {
            if (!Implements.Select(x => x.ToString()).Contains(inheritor))
            {
                Implements.Add(inheritor);
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
