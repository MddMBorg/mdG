//-----------------------------------------------------------------------
// <copyright file="RemarksUnit.cs" company="Junle Li">
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
    /// Remarks unit.
    /// </summary>
    internal class RemarksUnit : BaseTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemarksUnit"/> class.
        /// </summary>
        /// <param name="element">The remarks XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>remarks</c>.</exception>
        internal RemarksUnit(XElement element, MemberName parentName) : base(element, "remarks", parentName)
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName parentName) =>
            new[]
            {
                "#### Remarks",
                this.ElementContent(parentName)
            };

        /// <summary>
        /// Convert the remarks XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The remarks XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element, MemberName parentName) =>
            element != null
                ? new RemarksUnit(element, parentName).ToMarkdown(FormatKind.None, parentName)
                : Enumerable.Empty<string>();

    }

}
