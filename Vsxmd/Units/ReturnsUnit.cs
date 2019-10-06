﻿//-----------------------------------------------------------------------
// <copyright file="ReturnsUnit.cs" company="Junle Li">
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
    /// Returns unit.
    /// </summary>
    internal class ReturnsUnit : BaseUnit
    {

        private XElement _ReturnType =>
            Element.Elements("see").FirstOrDefault();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnsUnit"/> class.
        /// </summary>
        /// <param name="element">The returns XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>returns</c>.</exception>
        internal ReturnsUnit(XElement element)
            : base(element, "returns")
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName sourceMember) =>
            new[]
            {
                "#### Returns",
                _ReturnType != null
                ? $"{_ReturnType.Attribute("cref").Value.ToReferenceLink(sourceMember, true)}\n\n"
                : "\n\n",
                this.ElementContent(sourceMember)
            };

        /// <summary>
        /// Convert the returns XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The returns XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element, MemberName sourceMember) =>
            element != null
                ? new ReturnsUnit(element).ToMarkdown(FormatKind.None, sourceMember)
                : Enumerable.Empty<string>();

    }

}
