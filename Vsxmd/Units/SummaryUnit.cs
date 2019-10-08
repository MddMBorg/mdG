//-----------------------------------------------------------------------
// <copyright file="SummaryUnit.cs" company="Junle Li">
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
    /// Summary unit.
    /// </summary>
    internal class SummaryUnit : BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryUnit"/> class.
        /// </summary>
        /// <param name="element">The summary XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>summary</c>.</exception>
        internal SummaryUnit(XElement element, MemberName parentName) : base(element, "summary", parentName)
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName parentName) =>
            new[]
            {
                this.ElementContent(parentName)
            };

        /// <summary>
        /// Convert the summary XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The summary XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element, MemberName parentName) =>
            element != null
                ? new SummaryUnit(element, parentName).ToMarkdown(FormatKind.None, parentName)
                : Enumerable.Empty<string>();

    }

}
