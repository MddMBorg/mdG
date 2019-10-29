using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDocParser
{
    public class DocManager
    {
        List<XDocument> _Documents = new List<XDocument>();

        public void LoadDoc(XDocument document)
        {
            _Documents.Add(document);
        }



    }

}
