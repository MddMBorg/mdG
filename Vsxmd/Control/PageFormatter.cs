using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsxmd.Units;

namespace Vsxmd
{
    internal class PageFormatter
    {

        /// <summary>
        /// Test string
        /// </summary>
        public string test;

        public PageFormatter()
        {
        }

        /// <summary>
        /// Takes several base units of same type and organises them on page in the specified way.
        /// </summary>
        /// <param name="units">The units of the same type.</param>
        /// <returns><see cref="IEnumerable{String}"/></returns>
        public IEnumerable<string> GetMarkdownByType(IEnumerable<MemberUnit> units)
        {
            var classUnit = units.OfType<MemberUnit>().Where(x => x.Kind == MemberKind.Type).FirstOrDefault();
            var properties = units.OfType<MemberUnit>().Where(x => x.Kind == MemberKind.Property);
            var methods = units.OfType<MemberUnit>().Where(x => x.Kind == MemberKind.Method);
            var constructors = units.OfType<MemberUnit>().Where(x => x.Kind == MemberKind.Constructor);
            var constants = units.OfType<MemberUnit>().Where(x => x.Kind == MemberKind.Constants);

            IEnumerable<string> formats = new[] { "" };

            formats = classUnit.ToMarkdown(FormatKind.MethodSummary, classUnit.Name);

            if (constructors.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Constructors" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            constructors.Select(x => x.ToMarkdown(FormatKind.MethodSummary, x.Name).Join("")).Join("\n")
                    });
            }

            if (constants.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Fields" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            constants.Select(x => x.ToMarkdown(FormatKind.MethodSummary, x.Name).Join("")).Join("\n")
                    });
            }

            if (properties.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Properties" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            properties.Select(x => x.ToMarkdown(FormatKind.MethodSummary, x.Name).Join("")).Join("\n")
                    });

            }

            if (methods.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Methods" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            methods.Select(x => x.ToMarkdown(FormatKind.MethodSummary, x.Name).Join("")).Join("\n")
                    });
            }
            return formats;
        }

        /// <summary>
        /// Takes one Member Unit (non class type) and organises it in markdown format as series of strings.
        /// </summary>
        /// <param name="unit">The unit to format.</param>
        /// <returns><see cref="IEnumerable{String}">IEnumerable&lt;string&gt;</see></returns>
        public IEnumerable<string> GetMarkdownByMember(MemberUnit unit)
        {
            return unit.ToMarkdown(FormatKind.MethodDetail, unit.Name);
        }

    }

}
