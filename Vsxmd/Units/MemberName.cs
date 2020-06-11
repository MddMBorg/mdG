//-----------------------------------------------------------------------
// <copyright file="MemberName.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Member name.
    /// </summary>
    public class MemberName : IComparable<MemberName>
    {
        private readonly string _Name;

        private readonly char _Type;

        private readonly IEnumerable<string> _ParamNames;

        private readonly string _ClassType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        /// <param name="paramNames">The parameter names. It is only used when member kind is <see cref="MemberKind.Constructor"/> or <see cref="MemberKind.Method"/>.</param>
        /// <param name="classType">The class type for Type elements, i.e. Interface,Class,Enum etc.</param>
        public MemberName(string name, IEnumerable<string> paramNames, string classType)
        {
            _Name = name;
            _Type = name.First();
            _ParamNames = paramNames;
            _ClassType = classType ?? "Class";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        public MemberName(string name) : this(name, null, null)
        {
        }

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        public MemberKind Kind =>
            _Type == 'T'
            ? MemberKind.Type
            : _Type == 'F'
            ? MemberKind.Constants
            : _Type == 'P'
            ? MemberKind.Property
            : _Type == 'M' && _Name.Contains(".#ctor")
            ? MemberKind.Constructor
            : _Type == 'M' && !_Name.Contains(".#ctor")
            ? MemberKind.Method
            : MemberKind.NotSupported;

        /// <summary>
        /// Gets the link pointing to this member unit.
        /// </summary>
        /// <value>The link pointing to this member unit.</value>
        public string Link =>
            Kind == MemberKind.Type ||
            Kind == MemberKind.Constants ||
            Kind == MemberKind.Property
            ? $"[{FriendlyName.Escape()}]({FormattedHyperLink})"
            : Kind == MemberKind.Constructor ||
              Kind == MemberKind.Method
            ? $"[{FriendlyName.Escape()}({_ParamNames.Join(", ")})]({FormattedHyperLink})"
            : string.Empty;


        /// <summary>
        /// Gets the caption representation for this member name.
        /// </summary>
        /// <value>The caption.</value>
        /// <example>
        /// <para>For <see cref="MemberKind.Type"/>, show as <c>## Vsxmd.Units.MemberName [#](#here) [^](#contents)</c>.</para>
        /// <para>For other kinds, show as <c>### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)</c>.</para>
        /// </example>
        public string Caption
        {
            get
            {
                string name = FriendlyName.Escape();
                return
                    Kind == MemberKind.Type
                    ? $"{Href.ToAnchor()}# {name} {_ClassType}"
                    : Kind == MemberKind.Constants
                    ? $"{Href.ToAnchor()}# {name} Field"
                    : Kind == MemberKind.Property
                    ? $"{Href.ToAnchor()}# {name} Property"
                    : Kind == MemberKind.Constructor
                    ? $"{Href.ToAnchor()}# {name}({_ParamNames.Join(",")}) Constructor"
                    : Kind == MemberKind.Method
                    ? $"{Href.ToAnchor()}# {name}({_ParamNames.Join(",")}) Method"
                    : string.Empty;
            }
        }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        public string TypeName =>
            $"{Namespace}.{TypeShortName}";

        /// <summary>
        /// Gets the namespace name.
        /// </summary>
        /// <value>The namespace name.</value>
        /// <example><c>System</c>, <c>Vsxmd</c>, <c>Vsxmd.Units</c>.</example>
        public string Namespace =>
            Kind == MemberKind.Type
            ? NameSegments.TakeAllButLast(1).Join(".")
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Constructor ||
              Kind == MemberKind.Method
            ? NameSegments.TakeAllButLast(2).Join(".")
            : string.Empty;

        public string TypeShortName =>
            Kind == MemberKind.Type
            ? NameSegments.Last()
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Constructor ||
              Kind == MemberKind.Method
            ? NameSegments.NthLast(2)
            : string.Empty;

        private string Href => _Name.ToMarkdownRef();

        private string StrippedName =>
            _Name.Substring(2);

        public string LongName =>
            StrippedName.Split('(').First();

        private string DocsName =>
            LongName.Split('{').First();

        private IEnumerable<string> NameSegments =>
            LongName.Split('.');

        public string FriendlyName =>
            Kind == MemberKind.Type ||
            Kind == MemberKind.Constructor
            ? TypeShortName.Replace('`', '-')
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Method
            ? NameSegments.Last().Replace('`', '-')
            : string.Empty;

        /// <inheritdoc />
        public int CompareTo(MemberName other) =>
            TypeShortName != other.TypeShortName
            ? string.Compare(TypeShortName, other.TypeShortName, StringComparison.Ordinal)
            : Kind != other.Kind
            ? Kind.CompareTo(other.Kind)
            : string.Compare(LongName, other.LongName, StringComparison.Ordinal);

        /// <summary>
        /// Gets the method parameter type names from the member name.
        /// </summary>
        /// <returns>The method parameter type name list.</returns>
        /// <example>
        /// It will prepend the type kind character (<c>T:</c>) to the type string.
        /// <para>For <c>(System.String,System.Int32)</c>, returns <c>["T:System.String","T:System.Int32"]</c>.</para>
        /// It also handle generic type.
        /// <para>For <c>(System.Collections.Generic.IEnumerable{System.String})</c>, returns <c>["T:System.Collections.Generic.IEnumerable{System.String}"]</c>.</para>
        /// </example>
        public IEnumerable<string> GetParamTypes()
        {
            if (!_Name.Contains('('))
                return Enumerable.Empty<string>();

            var paramString = _Name.Split('(').Last().Trim(')');

            var delta = 0;
            var list = new List<StringBuilder>()
            {
                new StringBuilder("T:"),
            };

            foreach (var character in paramString)
            {
                if (character == '{')
                    delta++;
                else if (character == '}')
                    delta--;
                else if (character == ',' && delta == 0)
                    list.Add(new StringBuilder("T:"));

                if (character != ',' || delta != 0)
                    list.Last().Append(character);
            }

            return list.Select(x => x.ToString());
        }


        /// <summary>
        /// Convert the member name to Markdown reference link.
        /// <para>If then name is under <c>System</c> namespace, the link points to MSDN.</para>
        /// <para>Otherwise, the link points to this page anchor.</para>
        /// </summary>
        /// <param name="sourceMember">Originating member to begin relative reference from e.g. another namespace, class or member type.</param>
        /// <param name="useShortName">Indicate if use short type name.</param>
        /// <param name="alternateName">An override to use for instance when using see tags for the link description.</param>
        /// <returns>The generated Markdown reference link.</returns>
        public string ToReferenceLink(MemberName sourceMember, bool useShortName, string alternateName = null)
        {
            string displayName = alternateName ?? GetReferenceName(useShortName);
            int index = displayName.IndexOf('`');
            if (index > 0)
                displayName = displayName.Substring(0, index);
            return $"[{displayName}]({MemberLink(sourceMember).Replace('`', '-')})";
        }

        public string ToSummaryLink(bool useShortName) =>
            $"[{GetReferenceName(useShortName).Escape()}" +
            $"{(GetParamTypes().Count() > 0 ? $"({GetParamTypes().Select(x => x.Split('.').NthLast(1)).Join(", ")})" : "")}" +
            $"]({Kind.ToMemberKindString()}/{FileName})";

        public string FormattedHyperLink =>
            $"/{Namespace}/{FileName}/#{Href}";

        public string MemberLink(MemberName sourceMember)
        {
            //Use docs.microsoft for references to the System namespace
            if (Namespace.StartsWith("System.", StringComparison.Ordinal) || Namespace.Equals("System", StringComparison.Ordinal))
                return $"https://docs.microsoft.com/dotnet/api/{DocsName}";

            string shortFilePath = Kind.ToMemberKindString();
            shortFilePath = $"{shortFilePath}{(!string.IsNullOrWhiteSpace(shortFilePath) ? "/" : "")}{FileName}";

            //if the LongName property is the same then the reference is to itself
            if (LongName == sourceMember.LongName)
                return "#";
            /*
            * N.B. Type kinds are always (here) one level above methods/props/fields etc, and so require one less ../ to index to the upper level (Kind, Class, namespace)
            */
            //If the namespace is different, go up to the top level and then index into the markdown file
            if (Namespace != sourceMember.Namespace)
            {
                //Need to replace the backslashes since Windows file system is \ vs the web /
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../../{FullFilePath}".Replace('\\', '/');
                else
                    return $"./../../../{FullFilePath}".Replace('\\', '/');
            }
            //If the type is different, go up to the namespace level
            else if (TypeShortName != sourceMember.TypeShortName)
            {
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../{TypeShortName}/{shortFilePath}";
                else
                    return $"./../../{TypeShortName}/{shortFilePath}";
            }
            //If using a different kind (method, ctor, class etc), go to the common type level
            else if (Kind != sourceMember.Kind)
            {
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./{shortFilePath}";
                else
                    return $"./../{shortFilePath}";
            }
            //Else, index as if the markdown file is on the same level
            else
                return $"{FileName}";
        }

        public string FileName =>
            Kind != MemberKind.Constructor
            ? $"{FriendlyName}.md"
            : "Constructors.md";

        public string DirectoryName =>
            Kind == MemberKind.Type
            ? Path.Combine(Namespace, TypeShortName)
            : Path.Combine(Namespace, TypeShortName, Kind.ToMemberKindString());

        public string FullFilePath =>
            Path.Combine(DirectoryName, FileName);

        private string GetReferenceName(bool useShortName) =>
            !useShortName
            ? LongName
            : Kind == MemberKind.Type ||
              Kind == MemberKind.Constructor
            ? TypeShortName
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Method
            ? FriendlyName
            : string.Empty;

    }

}
