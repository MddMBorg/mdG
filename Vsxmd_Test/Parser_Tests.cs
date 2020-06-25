using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLDocParser;

namespace Vsxmd_Test
{
    [TestClass]
    public class Parser_Tests
    {
        [TestMethod]
        public void TestDocManager()
        {
            string resourceDir = "TestResources";
            string outputDir = "..\\..\\TestOutput";

            DocManager docManager = new DocManager();
            XDocument doc = XDocument.Load($"{resourceDir}\\vsxmd.xml");
            var m = docManager.GenerateMembers(doc).OfType<TypeMember>().ToList();
            //
        }

    }

}
