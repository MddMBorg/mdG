using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Vsxmd.Units;

namespace Vsxmd
{
    internal class PageFormatter
    {
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

            formats = classUnit.ToMarkdown(FormatKind.Summary, classUnit.Name);

            if (constructors.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Constructors" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            constructors.Select(x => x.ToMarkdown(FormatKind.Summary, x.Name).Join("")).Join("\n")
                    });
            }

            if (constants.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Fields" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            constants.Select(x => x.ToMarkdown(FormatKind.Summary, x.Name).Join("")).Join("\n")
                    });
            }

            if (properties.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Properties" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            properties.Select(x => x.ToMarkdown(FormatKind.Summary, x.Name).Join("")).Join("\n")
                    });

            }

            if (methods.Count() > 0)
            {
                formats = formats.Concat(new[] { "# Methods" })
                    .Concat(new[]
                    {
                            "| Definition | Description |\n" +
                            "|-|-|\n" +
                            methods.Select(x => x.ToMarkdown(FormatKind.Summary, x.Name).Join("")).Join("\n")
                    });
            }
            return formats;
        }

        /// <summary>
        /// Takes one Member Unit (non class type) and organises it in markdown format as series of strings.
        /// </summary>
        /// <param name="unit">The unit to format.</param>
        /// <returns><see cref="IEnumerable{String}">IEnumerable&lt;string&gt;</see></returns>
        public IEnumerable<string> GetMarkdownByMember(IEnumerable<MemberUnit> unit)
        {
            var items = unit.ToList();
            if (items.Count == 1)
                return items[0].ToMarkdown(FormatKind.Detail, unit.First().Name);
            else
            {
                return new[] { items[0].Caption }
                    .Concat(items[0].Namespace)
                    .Concat(items[0].Assembly)
                    .Concat(items[0].Summary)
                    .Concat(new[] { "# Overloads" })
                    .Concat(new[]
                    {
                        "| Signature | Description |\n" +
                        "|-|-|\n" +
                        items.Select(x => x.ToMarkdown(FormatKind.Summary, x.Name).Join("")).Join("\n")
                    })
                    .Concat(items.SelectMany(x => x.ToMarkdown(FormatKind.MultiDetail, x.Name)));
            }
        }

    }

}
