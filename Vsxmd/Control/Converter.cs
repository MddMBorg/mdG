//-----------------------------------------------------------------------
// <copyright file="Converter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Vsxmd.Units;

    /// <inheritdoc/>
    public class Converter
    {
        private readonly XElement _Document;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="document">The XML document.</param>
        public Converter(XDocument document)
        {
            _Document = document.Root;
        }
        
        internal IEnumerable<IUnit> ToUnits()
        {
            // assembly unit
            var assemblyUnit = Assembly();

            // member units
            var memberUnits = MemberUnits();
            
            // table of contents
            var tableOfContents = new TableOfContents(memberUnits);

            return new IUnit[] { assemblyUnit }
                .Concat(new[] { tableOfContents })
                .Concat(memberUnits);
        }

        internal IOrderedEnumerable<MemberUnit> MemberUnits()
        {
            return _Document
                .Element("members")
                .Elements("member")
                .Select(element => new MemberUnit(element))
                .Where(member => member.Kind != MemberKind.NotSupported)
                .GroupBy(unit => unit.TypeName)
                .Select(MemberUnit.ComplementType)
                .SelectMany(group => group)
                .OrderBy(member => member, MemberUnit.Comparer);
        }
        
        internal AssemblyUnit Assembly()
        {
            return new AssemblyUnit(_Document.Element("assembly"));
        }

    }

}
