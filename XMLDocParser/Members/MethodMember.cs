using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Vsxmd.Units;

namespace XMLDocParser.Members
{
    public class MethodMember : BaseMember
    {
        public string ReturnType { get; private set; }

        internal MethodMember(XElement element, DocManager manager) : base(element, manager)
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

        public void SafeAddParams(Dictionary<string, string> paramNames)
        {
            XElement lastExist = null;
            foreach (var name in paramNames)
            {
                XElement exist = _XML.Elements().Where(x => x.Name == "param" && x.Attribute("name").Value == name.Key).FirstOrDefault();
                if (exist != null)
                {
                    exist.SetAttributeValue("properType", name.Value);
                    lastExist = exist;
                }
                else
                {
                    var xToAdd = new XElement("param",
                        new XAttribute("name", name.Key),
                        new XAttribute("properType", name.Value));

                    if (lastExist != null)
                        lastExist.AddAfterSelf(xToAdd);
                    else
                        _XML.AddFirst(xToAdd);

                    lastExist = xToAdd;
                }
            }
        }

        public void SafeAddTypeParams(List<string> paramNames)
        {
            XElement lastExist = null;
            foreach (var name in paramNames)
            {
                XElement exist = _XML.Elements().Where(x => x.Name == "typeparam" && x.Attribute("name").Value == name).FirstOrDefault();
                if (exist != null)
                    lastExist = exist;
                else
                {
                    var xToAdd = new XElement("typeparam", new XAttribute("name", name));

                    if (lastExist != null)
                        lastExist.AddAfterSelf(xToAdd);
                    else
                        _XML.AddFirst(xToAdd);

                    lastExist = xToAdd;
                }
            }
        }

    }

}
