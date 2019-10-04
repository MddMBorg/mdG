//-----------------------------------------------------------------------
// <copyright file="MemberUnit.cs" company="Junle Li">
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
    /// Member unit.
    /// </summary>
    internal class MemberUnit : BaseUnit
    {
        private readonly MemberName name;

        internal readonly string AssemblyName;

        static MemberUnit()
        {
            Comparer = new MemberUnitComparer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberUnit"/> class.
        /// </summary>
        /// <param name="element">The member XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>member</c>.</exception>
        internal MemberUnit(XElement element)
            : base(element, "member")
        {
            AssemblyName = element.GetAssemblyName();
            this.name = new MemberName(
                this.GetAttribute("name"),
                this.GetChildren("param").Select(x => x.Attribute("name").Value));
        }

        /// <summary>
        /// Gets the member unit comparer.
        /// </summary>
        /// <value>The member unit comparer.</value>
        internal static IComparer<MemberUnit> Comparer { get; }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The the type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        internal string TypeName => this.name.TypeName;

        internal string TypeNamespace => name.Namespace;

        internal string FileName => name.FileName;

        internal string Caption => name.Caption;


        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        internal MemberKind Kind => this.name.Kind;

        /// <summary>
        /// Gets the link pointing to this member unit.
        /// </summary>
        /// <value>The link pointing to this member unit.</value>
        internal string Link => this.name.Link;

        internal IEnumerable<string> InheritDoc =>
            this.GetChild("inheritdoc") == null
                ? Enumerable.Empty<string>()
                : new[]
                {
                    "*Inherited from parent.*",
                };

        internal IEnumerable<string> Namespace =>
            this.Kind != MemberKind.Type
            ? Enumerable.Empty<string>()
            : new[]
            {
                $"###### Namespace:  {this.name.Namespace}"
            };

        internal IEnumerable<string> Assembly =>
            this.Kind != MemberKind.Type
            ? Enumerable.Empty<string>()
            : new[]
            {
                $"###### Assembly:  {this.AssemblyName}"
            };

        internal IEnumerable<string> Summary =>
            SummaryUnit.ToMarkdown(this.GetChild("summary"));

        internal IEnumerable<string> Returns =>
            ReturnsUnit.ToMarkdown(this.GetChild("returns"));

        internal IEnumerable<string> Params =>
            ParamUnit.ToMarkdown(
                this.GetChildren("param"),
                this.name.GetParamTypes(),
                this.Kind);

        internal IEnumerable<string> Typeparams =>
            TypeparamUnit.ToMarkdown(this.GetChildren("typeparam"));

        internal IEnumerable<string> Exceptions =>
            ExceptionUnit.ToMarkdown(this.GetChildren("exception"));

        internal IEnumerable<string> Permissions =>
            PermissionUnit.ToMarkdown(this.GetChildren("permission"));

        internal IEnumerable<string> Example =>
            ExampleUnit.ToMarkdown(this.GetChild("example"));

        internal IEnumerable<string> Remarks =>
            RemarksUnit.ToMarkdown(this.GetChild("remarks"));

        internal IEnumerable<string> Seealsos =>
            SeealsoUnit.ToMarkdown(this.GetChildren("seealso"));

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format)
        {
            if (format == FormatKind.MethodDetail || format == FormatKind.None || Kind == MemberKind.Type)
                return new[] { this.Caption }
                    .Concat(this.Namespace)
                    .Concat(this.Assembly)
                    .Concat(this.InheritDoc)
                    .Concat(this.Summary)
                    .Concat(this.Typeparams)
                    .Concat(this.Params)
                    .Concat(this.Exceptions)
                    .Concat(this.Returns)
                    .Concat(this.Permissions)
                    .Concat(this.Example)
                    .Concat(this.Remarks)
                    .Concat(this.Seealsos);
            else
            {
                if (Kind == MemberKind.Method ||
                    Kind == MemberKind.Constructor ||
                    Kind == MemberKind.Constants ||
                    Kind == MemberKind.Property)
                    return new[] { $"| {this.name.ToSummaryLink(true)} | {this.Summary.Join("").Replace('\n', ' ')} |" };
                else
                    return new[] { "|  |  |" };
            }
        }

        /// <summary>
        /// Complement a type unit if the member unit <paramref name="group"/> does not have one.
        /// One member unit group has the same <see cref="TypeName"/>.
        /// </summary>
        /// <param name="group">The member unit group.</param>
        /// <returns>The complemented member unit group.</returns>
        internal static IEnumerable<MemberUnit> ComplementType(
            IEnumerable<MemberUnit> group) =>
            group.Any(unit => unit.Kind == MemberKind.Type)
                ? group
                : group.Concat(new[] { Create(group.First().TypeName) });

        private static MemberUnit Create(string typeName) =>
            new MemberUnit(
                new XElement(
                    "member",
                    new XAttribute("name", $"T:{typeName}")));

        private class MemberUnitComparer : IComparer<MemberUnit>
        {
            /// <inheritdoc />
            public int Compare(MemberUnit x, MemberUnit y) =>
                x.name.CompareTo(y.name);
        }

    }

}
