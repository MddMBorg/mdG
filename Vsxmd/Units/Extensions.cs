//-----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    /// <summary>
    /// Extensions helper.
    /// </summary>
    public static class Extensions
    {
        public static string ToXMLType(this string str)
        {
            string ret = "";
            bool isCtor = false;
            string type = "";
            if (!str.EndsWith(">"))         //if ends with > then either genericType or genericMethod, definitely not ctor
            {
                if (str.Contains('<'))      //if contians < then must be type<T>.method, with no method generic params and might be ctor
                    type = str.Split('<').First().Split('.').Last();
                isCtor = str.Split('.').Last() == type;
            }
            int parseLevel = 0;
            int genericCount = 0;
            bool methodGeneric = false;     //method generics have ``, generic types have `

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                switch (ch)
                {
                    case '<':
                        parseLevel++;
                        if (parseLevel == 1)
                            genericCount++;
                        break;
                    case '>':
                        parseLevel--;
                        if (parseLevel == 0)
                        {
                            if (methodGeneric)
                                ret += $"``{genericCount}";
                            else
                                ret += $"`{genericCount}";
                            genericCount = 0;           //reset for method generics
                        }
                        methodGeneric = true;
                        break;
                    case ',':
                        if (parseLevel == 1)
                            genericCount++;
                        break;
                    default:
                        if (parseLevel == 0)
                            ret += ch.ToString();
                        break;
                }
            }
            if (isCtor)
            {
                int index = ret.LastIndexOf(type);
                ret = ret.Remove(index, type.Length).Insert(index, "#ctor");
            }
            return ret;
        }
        
        /// <summary>
        /// Probably a lazy way to do this and more implementation should be moved to AssemblyUnit class
        /// </summary>
        /// <param name="xElement">The XElement to get the AssemblyUnit of.</param>
        /// <returns>Assembly unit for the current Xdoc.</returns>
        internal static string GetAssemblyName(this XElement xElement) =>
            xElement.Document.Root.Element("assembly").Element("name").Value;

        /// <summary>
        /// Convert the <see cref="MemberKind"/> to its lowercase name.
        /// </summary>
        /// <param name="memberKind">The member kind.</param>
        /// <returns>The member kind's lowercase name.</returns>
        internal static string ToLowerString(this MemberKind memberKind) =>
#pragma warning disable CA1308 // We use lower case in URL anchor.
            memberKind.ToString().ToLowerInvariant();
#pragma warning restore CA1308

        /// <summary>
        /// Concatenates the <paramref name="value"/>s with the <paramref name="separator"/>.
        /// </summary>
        /// <param name="value">The string values.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The concatenated string.</returns>
        internal static string Join(this IEnumerable<string> value, string separator) =>
            string.Join(separator, value);

        /// <summary>
        /// Suffix the <paramref name="suffix"/> to the <paramref name="value"/>, and generate a new string.
        /// </summary>
        /// <param name="value">The original string value.</param>
        /// <param name="suffix">The suffix string.</param>
        /// <returns>The new string.</returns>
        internal static string Suffix(this string value, string suffix) =>
            string.Concat(value, suffix);

        /// <summary>
        /// Escape the content to keep it raw in Markdown syntax.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>The escaped content.</returns>
        internal static string Escape(this string content) =>
            content.Replace("`", @"\`");

        /// <summary>
        /// Generate an anchor for the <paramref name="href"/>.
        /// </summary>
        /// <param name="href">The href.</param>
        /// <returns>The anchor for the <paramref name="href"/>.</returns>
        internal static string ToAnchor(this string href) =>
            $"<a name='{href}'></a>\n";

        internal static string ToMemberKindString(this MemberKind kind)
        {
            switch (kind)
            {
                case MemberKind.Constants:
                    return "Fields";
                case MemberKind.Constructor:
                    return "Constructors";
                case MemberKind.Method:
                    return "Methods";
                case MemberKind.Property:
                    return "Properties";
                case MemberKind.Type:
                    return "";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Wrap the <paramref name="code"/> into Markdown backtick safely.
        /// <para>The backtick characters inside the <paramref name="code"/> reverse as it is.</para>
        /// </summary>
        /// <param name="code">The code span.</param>
        /// <returns>The Markdown code span.</returns>
        /// <remarks>Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code .</remarks>
        internal static string AsCode(this string code)
        {
            string backticks = "`";
            while (code.Contains(backticks))
            {
                backticks += "`";
            }

            return code.StartsWith("`", StringComparison.Ordinal) || code.EndsWith("`", StringComparison.Ordinal)
                ? $"{backticks} {code} {backticks}"
                : $"{backticks}{code}{backticks}";
        }

        /// <summary>
        /// Escape a reference to an anchor, file or folder by replacing special characters with '-'.
        /// </summary>
        /// <param name="href">The href.</param>
        /// <returns>An escaped href for Markdown files.</returns>
        internal static string ToMarkdownRef(this string href)
        {
            return href.Replace('.', '-')
            .Replace(':', '-')
            .Replace('(', '-')
            .Replace(')', '-');
        }

        /// <summary>
        /// Gets the n-th last element from the <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <param name="index">The index for the n-th last.</param>
        /// <returns>The element at the specified position in the <paramref name="source"/> sequence.</returns>
        internal static TSource NthLast<TSource>(this IEnumerable<TSource> source, int index) =>
            source.Reverse().ElementAt(index - 1);

        /// <summary>
        /// Take all element except the last <paramref name="count"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <param name="count">The number to except.</param>
        /// <returns>The generated enumerable.</returns>
        internal static IEnumerable<TSource> TakeAllButLast<TSource>(this IEnumerable<TSource> source, int count) =>
            source.Reverse().Skip(count).Reverse();

        /// <summary>
        /// Convert the inline XML nodes to Markdown text.
        /// For example, it works for <c>summary</c> and <c>returns</c> elements.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>The generated Markdown content.</returns>
        /// <example>
        /// This method converts the following <c>summary</c> element.
        /// <code>
        /// <summary>
        /// The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="ToMarkdownText(XElement, IPage)"/>.
        /// </summary>
        /// </code>
        /// To the below Markdown content.
        /// <code>
        /// The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
        /// </code>
        /// </example>
        internal static string ToMarkdownText(this XElement element, IPage sourcePage) =>
            element.Nodes()
                .Select(x => ToMarkdownSpan(x, sourcePage))
                .Aggregate(string.Empty, JoinMarkdownSpan)
                .Trim();

        private static string ToMarkdownSpan(XNode node, IPage sourcePage)
        {
            var text = node as XText;
            if (text != null)
            {
                return text.Value.Escape().TrimStart(' ').Replace("            ", "");
            }

            var child = node as XElement;
            if (child != null)
            {
                switch (child.Name.ToString())
                {
                    case "see":
                        return $"{child.ToSeeTagMarkdownSpan(sourcePage)}{child.NextNode.AsSpanMargin()}";
                    case "paramref":
                    case "typeparamref":
                        return $"{child.Attribute("name")?.Value?.AsCode()}{child.NextNode.AsSpanMargin()}";
                    case "c":
                    case "value":
                        return $"{child.Value.AsCode()}{child.NextNode.AsSpanMargin()}";
                    case "code":
                        var lang = child.Attribute("lang")?.Value ?? "";

                        string value = child.Nodes().First().ToString().Replace("\t", "    ");
                        var indexOf = FindIndexOf(value);

                        var codeblockLines = value.Split(Environment.NewLine.ToCharArray())
                            .Where(t => t.Length > indexOf)
                            .Select(t => t.Substring(indexOf));
                        var codeblock = string.Join("\n", codeblockLines);

                        return $"\n\n```{lang}\n{codeblock}\n```\n\n";
                    case "example":
                    case "para":
                        return $"\n\n{child.ToMarkdownText(sourcePage)}\n\n";
                    default:
                        return "";
                }
            }

            return "";
        }

        private static int FindIndexOf(string node)
        {
            List<int> result = new List<int>();

            foreach (var item in node.Split(Environment.NewLine.ToCharArray()).Where(t => t.Length > 0))
            {
                result.Add(0);

                for (int i = 0; i < item.Length; i++)
                {
                    if (item.ToCharArray()[i] != ' ')
                        break;

                    result[result.Count - 1] += 1;
                }
            }

            return result.Min();
        }

        private static string JoinMarkdownSpan(string x, string y) =>
            x.EndsWith("\n\n", StringComparison.Ordinal)
                ? $"{x}{y.TrimStart()}"
                : y.StartsWith("\n\n", StringComparison.Ordinal)
                ? $"{x.TrimEnd()}{y}"
                : $"{x}{y}";

        private static string ToSeeTagMarkdownSpan(this XElement seeTag, IPage sourcePage) =>
            seeTag.Attribute("cref")?.Value?.ToReferenceLink(sourcePage, true, seeTag.Value) ??
            seeTag.Attribute("langword")?.Value?.AsCode();

        private static string AsSpanMargin(this XNode node)
        {
            var text = node as XText;
            if (text != null && text.Value.StartsWith(" ", StringComparison.Ordinal))
                return " ";

            return "";
        }

    }

}
