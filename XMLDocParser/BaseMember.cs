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

        public BaseMember(XElement element)
        {
            _XML = element;
        }

        public virtual void Commit()
        {
        }

        public XElement ToXML() => _XML;

    }

}
