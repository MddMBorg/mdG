using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsxmd.Units
{
    public static class PageExtensions
    {
        public static string GetLink(this IPage page, IPage sourcePage)
        {
            //Use docs.microsoft for references to the System namespace
            if (page.Namespace.StartsWith("System.", StringComparison.Ordinal) || page.Namespace.Equals("System", StringComparison.Ordinal))
                return $"https://docs.microsoft.com/dotnet/api/{page.DocsName}";

            string fullFilePath = page.FullFilePath;
            string sourcePath = sourcePage.FullFilePath;
            string shortFilePath = Path.Combine(page.Kind.ToMemberKindString(), page.FileName);

            //if the LongName property is the same then the reference is to itself
            if (fullFilePath == sourcePath)
                return "#";

            //N.B. Type kinds are always (here) one level above methods/props/fields etc, and so require one less ../ to index to the upper level (Kind, Class, namespace)
            //If the namespace is different, go up to the top level and then index into the markdown file
            if (page.Namespace != sourcePage.Namespace)
            {
                //Need to replace the backslashes since Windows file system is \ vs the web /
                if (sourcePage.Kind == MemberKind.Type)
                    return $"./../../{fullFilePath}".Replace('\\', '/');
                else
                    return $"./../../../{fullFilePath}".Replace('\\', '/');
            }
            //If the type is different, go up to the namespace level
            else if (page.ShortTypeName != sourcePage.ShortTypeName)
            {
                if (sourcePage.Kind == MemberKind.Type)
                    return $"./../{page.ShortTypeName}/{shortFilePath}";
                else
                    return $"./../../{page.ShortTypeName}/{shortFilePath}";
            }
            //If using a different kind (method, ctor, class etc), go to the common type level
            else if (page.Kind != sourcePage.Kind)
            {
                if (sourcePage.Kind == MemberKind.Type)
                    return $"./{shortFilePath}";
                else
                    return $"./../{shortFilePath}";
            }
            //Else, index as if the markdown file is on the same level
            else
                return $"{page.FileName}";
        }

        /// <summary>
        /// Generate the reference link for the <paramref name="memberName"/>.
        /// </summary>
        /// <param name="memberName">The member name.</param>
        /// <param name="sorucePage">Source member to begin relative uri from.</param>
        /// <param name="useShortName">Indicate if use short type name.</param>
        /// <param name="alternateName">An override to use when generating the link description.</param>
        /// <returns>The generated reference link.</returns>
        /// <example>
        /// <para>For <c>T:Vsxmd.Units.MemberUnit</c>, convert it to <c>[MemberUnit](#T-Vsxmd.Units.MemberUnit)</c>.</para>
        /// <para>For <c>T:System.ArgumentException</c>, convert it to <c>[ArgumentException](http://msdn/path/to/System.ArgumentException)</c>.</para>
        /// </example>
        internal static string ToReferenceLink(this string memberName, IPage sorucePage, bool useShortName = false, string alternateName = null) =>
            new MemberName(memberName).ToReferenceLink(sorucePage, useShortName, alternateName);

    }

}
