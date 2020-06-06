//-----------------------------------------------------------------------
// <copyright file="ExceptionUnit.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Exception unit.
    /// </summary>
    internal class ExceptionUnit : BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionUnit"/> class.
        /// </summary>
        /// <param name="element">The exception XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>exception</c>.</exception>
        internal ExceptionUnit(XElement element, MemberName parentName) : base(element, "exception", parentName)
        {
        }

        private string _Name => GetAttribute("cref").ToReferenceLink(_ParentName);

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName sourceMember) =>
            new[]
            {
                $"{_Name}  ",
                Element.ToMarkdownText(sourceMember)
            };

        /// <summary>
        /// Convert the exception XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The exception XML element list.</param>
        /// <param name="parentName">The parent member that this tag is a part of.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements, MemberName parentName)
        {
            if (!elements.Any())
                return Enumerable.Empty<string>();

            var markdowns = elements
                .Select(element => new ExceptionUnit(element, parentName))
                .SelectMany(unit => unit.ToMarkdown(FormatKind.None, parentName));

            return new[]
            {
                "#### Exceptions",
                string.Join("\n\n", markdowns),
            };
        }

    }

}
