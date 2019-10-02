using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsxmd_Test
{
    [TestClass]
    public class Program_Tests
    {
        [TestMethod]
        public void Main_Test()
        {
            Vsxmd.Converter converter = new Vsxmd.Converter(System.Xml.Linq.XDocument.Load("TestResources\\vsxmd.xml"));
            Console.Write(1);
        }
    }
}
