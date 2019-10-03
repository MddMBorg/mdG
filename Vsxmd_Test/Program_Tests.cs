using System;
using System.IO;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsxmd;

namespace Vsxmd_Test
{
    [TestClass]
    public class Program_Tests
    {
        [TestMethod]
        public void Main_Test()
        {
            string resourceDir = "TestResources";
            string outputDir = "..\\..\\TestOutput";

            if (Directory.Exists(outputDir))
                Directory.Delete(outputDir, true);

            Directory.CreateDirectory(outputDir);
            
            MarkdownWriter writer = new MarkdownWriter(XDocument.Load($"{resourceDir}\\vsxmd.xml"), Path.Combine(outputDir, "test.md"));

            writer.WriteSingleFile();

            writer.WriteMultipleFiles(true);
            Assert.IsTrue(Directory.Exists(outputDir));
            Assert.IsTrue(Directory.GetDirectories(outputDir).Length > 0);

            writer.WriteMultipleFiles(false);
            Assert.IsTrue(Directory.GetFiles(outputDir).Length > 0);
            Console.Write(1);
        }

    }

}
