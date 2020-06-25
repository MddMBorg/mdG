using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsxmd.Units;

namespace Vsxmd_Test
{
    [TestClass]
    public class TypeAndLinkTests
    {
        [TestMethod]
        public void TestConvertTypeToTypeLink()
        {
            string type = "System.Collections.Generic.Dictionary<System.Int32[], System.Collections.Generic.List<System.String>>";
            string ourType = "Vsxmd.Units.TestType";
            var norm = NormalType.CreateNormalType(type);
            var subTypes = norm.SubTypes.ToList();
            Assert.AreEqual(subTypes.Count, 2);
            Assert.AreEqual(norm.DisplayTypeName, "Dictionary");
            Assert.AreEqual(norm.ShortTypeName, "Dictionary-2");
            var subSub = subTypes.Last();
            Assert.AreEqual(subSub.SubTypes.Count(), 1);

            MemberName name = new MemberName("T:Vsxmd.Units.AssemblyUnit");
            Assert.AreEqual(norm.GetLink(name), "https://docs.microsoft.com/dotnet/api/System.Collections.Generic.Dictionary-2");
            var ourNorm = NormalType.CreateNormalType(ourType);
            Assert.AreEqual(ourNorm.GetLink(name), "./../TestType/TestType.md");
            //Assert.AreEqual(norm.ToMarkdownLink(name), "[Dictionary](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.Dictionary-2)<[Int32[]](https://docs.microsoft.com/dotnet/api/System.Int32), [List](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.List-1)<[String](https://docs.microsoft.com/dotnet/api/System.String)>>");

            string ret = norm.ToString("Ns.Tn --- Ns.Tn-Gc<Rs{, }>Am");
        }

    }

}
