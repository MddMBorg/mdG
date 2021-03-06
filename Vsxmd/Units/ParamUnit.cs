﻿//-----------------------------------------------------------------------
// <copyright file="ParamUnit.cs" company="Junle Li">
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
    /// Param unit.
    /// </summary>
    internal class ParamUnit : BaseTag
    {
        private readonly NormalType _ParamType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamUnit"/> class.
        /// </summary>
        /// <param name="element">The param XML element.</param>
        /// <param name="paramType">The parameter type corresponding to the param XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>param</c>.</exception>
        internal ParamUnit(XElement element, NormalType paramType, MemberName parentName) : base(element, "param", parentName)
        {
            _ParamType = paramType;
        }

        private string _Name => GetAttribute("name");

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName parentName) =>
            new[]
            {
                $"{_Name.AsCode()}  {_ParamType.ToMarkdownLink(parentName)}  ",
                Element.ToMarkdownText(parentName)
            };

        /// <summary>
        /// Convert the param XML element to Markdown safely.
        /// </summary>
        /// <param name="elements">The param XML element list.</param>
        /// <param name="paramTypes">The paramater type names.</param>
        /// <param name="parentName">The member kind of the parent element.</param>
        /// <returns>The generated Markdown.</returns>
        /// <remarks>
        /// When the parameter (a.k.a <paramref name="elements"/>) list is empty:
        /// <para>If parent element kind is <see cref="MemberKind.Constructor"/> or <see cref="MemberKind.Method"/>, it returns a hint about "no parameters".</para>
        /// <para>If parent element kind is not the value mentioned above, it returns an empty string.</para>
        /// </remarks>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements, IEnumerable<NormalType> paramTypes, MemberName parentName)
        {
            if (!elements.Any())
                return Enumerable.Empty<string>();

            var markdowns = elements
                .Zip(paramTypes, (element, type) => new ParamUnit(element, type, parentName))
                .SelectMany(unit => unit.ToMarkdown(FormatKind.None, parentName));

            return new[]
            {
                "#### Parameters",
                string.Join("\n\n", markdowns),
            };
        }

    }

}
