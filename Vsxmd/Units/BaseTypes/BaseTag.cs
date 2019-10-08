using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vsxmd.Units
{
    internal class BaseTag : BaseUnit
    {
        protected readonly MemberName _ParentName;

        public BaseTag(XElement element, string elementName, MemberName parentName) : base(element, elementName)
        {
            _ParentName = parentName;
        }

    }

}
