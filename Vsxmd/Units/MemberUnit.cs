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

        internal readonly string ReturnTypeBase;

        static MemberUnit()
        {
            Comparer = new MemberUnitComparer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberUnit"/> class.
        /// </summary>
        /// <param name="element">The member XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>member</c>.</exception>
        internal MemberUnit(XElement element) : base(element, "member")
        {
            AssemblyName = element.GetAssemblyName();
            Name = new MemberName(
                GetAttribute("name"),
                GetChildren("param").Select(x => x.Attribute("name").Value),
                GetChildren("param").Select(x => x.Attribute("properType")?.Value).Where(x => x != null),
                GetChildren("typeparam").Select(x => x.Attribute("name")?.Value ?? ""),
                element.Attribute("ClassType")?.Value ?? "Class");
            ReturnTypeBase = GetAttribute("ReturnType");
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
        internal string TypeName => Name.TypeName;

        internal string TypeNamespace => Name.Namespace;

        internal string FileName => Name.FileName;

        internal string DirectoryName => Name.DirectoryName;

        internal string FullFilePath => Name.FullFilePath;

        internal string Caption => Name.Caption;

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        internal MemberKind Kind => Name.Kind;

        internal IEnumerable<string> InheritDoc =>
            GetChild("inheritdoc") == null
                ? Enumerable.Empty<string>()
                : new[]
                {
                    "*Inherited from parent.*",
                };

        internal IEnumerable<string> Namespace =>
            new[]
            {
                $"###### Namespace:  {Name.Namespace}"
            };

        internal IEnumerable<string> Assembly =>
            new[]
            {
                $"###### Assembly:  {AssemblyName}"
            };

        internal IEnumerable<string> Summary =>
            SummaryUnit.ToMarkdown(GetChild("summary"), Name);

        internal IEnumerable<string> SummarySummary =>
            SummaryUnit.ToMarkdown(GetChild("summary"), new MemberName($"T:{TypeName}"));

        internal IEnumerable<string> ReturnType =>
            Kind == MemberKind.Property ?
                new string[] { "#### Property Value", ReturnTypeBase?.ToReferenceLink(this.Name, true) ?? "" } :
            Kind == MemberKind.Constants ?
                new string[] { "#### Field Value", ReturnTypeBase?.ToReferenceLink(this.Name, true) ?? "" } :
            Kind == MemberKind.Method ?
                new string[] { "#### Returns", ReturnTypeBase?.ToReferenceLink(this.Name, true) ?? "" } :
            Enumerable.Empty<string>();

        internal IEnumerable<string> Returns =>
            ReturnsUnit.ToMarkdown(GetChild("returns"), Name);

        internal IEnumerable<string> Params =>
            ParamUnit.ToMarkdown(GetChildren("param"), Name.GetParamTypes(), Name);

        internal IEnumerable<string> Typeparams =>
            TypeparamUnit.ToMarkdown(GetChildren("typeparam"), Name);

        internal IEnumerable<string> Exceptions =>
            ExceptionUnit.ToMarkdown(GetChildren("exception"), Name);

        internal IEnumerable<string> Permissions =>
            PermissionUnit.ToMarkdown(GetChildren("permission"), Name);

        internal IEnumerable<string> Example =>
            ExampleUnit.ToMarkdown(GetChild("example"), Name);

        internal IEnumerable<string> Remarks =>
            RemarksUnit.ToMarkdown(GetChild("remarks"), Name);

        internal IEnumerable<string> Seealsos =>
            SeealsoUnit.ToMarkdown(GetChildren("seealso"), Name);

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown(FormatKind format, MemberName sourceMember)
        {
            if (format == FormatKind.Detail || format == FormatKind.None || Kind == MemberKind.Type)
                return new[] { Caption }
                    .Concat(Namespace)
                    .Concat(Assembly)
                    .Concat(InheritDoc)
                    .Concat(Summary)
                    .Concat(Typeparams)
                    .Concat(Params)
                    .Concat(ReturnType)
                    .Concat(Returns)
                    .Concat(Exceptions)
                    .Concat(Permissions)
                    .Concat(Example)
                    .Concat(Remarks)
                    .Concat(Seealsos);
            else if (format == FormatKind.MultiDetail)
                return new[] { Caption }
                    .Concat(InheritDoc)
                    .Concat(Summary)
                    .Concat(Typeparams)
                    .Concat(Params)
                    .Concat(ReturnType)
                    .Concat(Returns)
                    .Concat(Exceptions)
                    .Concat(Permissions)
                    .Concat(Example)
                    .Concat(Remarks)
                    .Concat(Seealsos);
            else
            {
                if (Kind == MemberKind.Method ||
                    Kind == MemberKind.Constructor ||
                    Kind == MemberKind.Constants ||
                    Kind == MemberKind.Property)
                    return new[] { $"| {Name.ToSummaryLink(true)} | {SummarySummary.Join("").Replace("\n", "<br/>")} |" };
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
                : group.Concat(new[] { _Create(group.First().TypeName) });

        private static MemberUnit _Create(string typeName) =>
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
