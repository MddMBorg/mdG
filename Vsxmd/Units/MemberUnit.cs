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
        internal readonly string AssemblyName;

        internal readonly MemberName Name;

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
            this.Name = new MemberName(
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
        internal string TypeName => this.Name.TypeName;

        internal string TypeNamespace => Name.Namespace;

        internal string FileName => Name.FileName;

        internal string DirectoryName => Name.DirectoryName;

        internal string FullFilePath => Name.FullFilePath;

        internal string Caption => Name.Caption;


        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        internal MemberKind Kind => this.Name.Kind;

        /// <summary>
        /// Gets the link pointing to this member unit.
        /// </summary>
        /// <value>The link pointing to this member unit.</value>
        internal string Link => this.Name.Link;

        internal IEnumerable<string> InheritDoc =>
            this.GetChild("inheritdoc") == null
                ? Enumerable.Empty<string>()
                : new[]
                {
                    "*Inherited from parent.*",
                };

        internal IEnumerable<string> Namespace =>
            new[]
            {
                $"###### Namespace:  {this.Name.Namespace}"
            };

        internal IEnumerable<string> Assembly =>
            new[]
            {
                $"###### Assembly:  {this.AssemblyName}"
            };

        internal IEnumerable<string> Summary =>
            SummaryUnit.ToMarkdown(this.GetChild("summary"), Name);

        internal IEnumerable<string> Returns =>
            ReturnsUnit.ToMarkdown(this.GetChild("returns"), this.Name);

        internal IEnumerable<string> Params =>
            ParamUnit.ToMarkdown(
                this.GetChildren("param"),
                this.Name.GetParamTypes(),
                this.Name);

        internal IEnumerable<string> Typeparams =>
            TypeparamUnit.ToMarkdown(this.GetChildren("typeparam"), Name);

        internal IEnumerable<string> Exceptions =>
            ExceptionUnit.ToMarkdown(this.GetChildren("exception"), Name);

        internal IEnumerable<string> Permissions =>
            PermissionUnit.ToMarkdown(this.GetChildren("permission"), Name);

        internal IEnumerable<string> Example =>
            ExampleUnit.ToMarkdown(this.GetChild("example"), Name);

        internal IEnumerable<string> Remarks =>
            RemarksUnit.ToMarkdown(this.GetChild("remarks"), Name);

        internal IEnumerable<string> Seealsos =>
            SeealsoUnit.ToMarkdown(this.GetChildren("seealso"), Name);

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName sourceMember)
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
                    return new[] { $"| {this.Name.ToSummaryLink(true)} | {this.Summary.Join("").Replace('\n', ' ')} |" };
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
                x.Name.CompareTo(y.Name);
        }

    }

}
