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
    public class MemberName : IComparable<MemberName>, IPage
    {
        private readonly string _Name;

        private readonly char _Type;

        private readonly IEnumerable<string> _ParamNames;

        private readonly IEnumerable<string> _ParamTypes;
        private readonly IEnumerable<string> _TypeParamTypes;

        private readonly string _ClassType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        /// <param name="paramNames">The parameter names. It is only used when member kind is <see cref="MemberKind.Constructor"/> or <see cref="MemberKind.Method"/>.</param>
        /// <param name="classType">The class type for Type elements, i.e. Interface,Class,Enum etc.</param>
        public MemberName(string name,
            IEnumerable<string> paramNames, IEnumerable<string> paramTypes, IEnumerable<string> typeparamNames,
            string classType)
        {
            _Name = name;
            _Type = name.First();
            _ParamNames = paramNames;
            _ParamTypes = paramTypes;
            _TypeParamTypes = typeparamNames;
            _ClassType = classType ?? "Class";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        public MemberName(string name) : this(name, null, null, null, null)
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
                int index = name.IndexOf('-');
                if (index > 0)
                    name = name.Substring(0, index);
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
                    : "";
            }
        }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        public string TypeName =>
            $"{Namespace}.{ShortTypeName}";

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
            : "";

        public string ShortTypeName =>
            Kind == MemberKind.Type
            ? NameSegments.Last().Replace('`', '-')
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Constructor ||
              Kind == MemberKind.Method
            ? NameSegments.NthLast(2).Replace('`', '-')
            : "";

        public int GenericCount
        {
            get
            {
                string name = ShortTypeName;
                int index = name.IndexOf('-');
                if (index > 0)
                    try
                    {
                        return Convert.ToInt32(name.Substring(index + 1));
                    }
                    catch
                    { return 0; }
                return 0;
            }
        }

        private string Href => _Name.ToMarkdownRef();

        private string StrippedName =>
            _Name.Substring(2);

        public string LongName =>
            StrippedName.Split('(').First();

        public string DocsName =>
            LongName.Split('{').First();

        private IEnumerable<string> NameSegments =>
            LongName.Split('.');

        public string FriendlyName =>
            Kind == MemberKind.Type ||
            Kind == MemberKind.Constructor
            ? ShortTypeName
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Method
            ? NameSegments.Last().Replace('`', '-')     //ToDo this is wrong e.g. GetBool``2(...) => GetBool--2(...), should just be GetBool
            : "";

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
        public IEnumerable<NormalType> GetParamTypes()
        {
            if (_ParamTypes.Any())              //using the "new" stuff, get the parameter types from the param tags
                return _ParamTypes.Select(x => NormalType.CreateNormalType(x));
            else if (!_Name.Contains('('))      //if there's no parameters (non method/constructor)
                return Enumerable.Empty<NormalType>();
            else
            {
                string paramString = _Name.Split('(').Last().Trim(')');

                int delta = 0;
                string ret = "";
                var list = new List<string>();

                foreach (var ch in paramString)
                {
                    if (ch == '{')
                        delta++;
                    else if (ch == '}')
                        delta--;
                    else if (ch != ',' || delta != 0)
                        ret += ch.ToString();
                    else if (delta == 0 && ch == ',')
                    {
                        list.Add(ret);
                        ret = "";
                    }
                }

                return list.Select(x => NormalType.CreateNormalType(x));
            }
        }

        /// <summary>
        /// Convert the member name to Markdown reference link.
        /// <para>If then name is under <c>System</c> namespace, the link points to MSDN.</para>
        /// <para>Otherwise, the link points to this page anchor.</para>
        /// </summary>
        /// <param name="sourcePage">Originating member to begin relative reference from e.g. another namespace, class or member type.</param>
        /// <param name="useShortName">Indicate if use short type name.</param>
        /// <param name="alternateName">An override to use for instance when using see tags for the link description.</param>
        /// <returns>The generated Markdown reference link.</returns>
        public string ToReferenceLink(IPage sourcePage, bool useShortName, string alternateName = null)
        {
            string displayName = alternateName ?? GetReferenceName(useShortName);
            int index = displayName.IndexOf('`');
            if (index > 0)
                displayName = displayName.Substring(0, index);
            return $"[{displayName}]({this.GetLink(sourcePage).Replace('`', '-')})";
        }

        public string ToSummaryLink(bool useShortName) =>
            $"[{GetReferenceName(useShortName).Escape()}" +
            $"{(_TypeParamTypes.Any() ? $"<{_TypeParamTypes.Join(", ")}>" : "")}" +         //<T, U>
            $"{(GetParamTypes().Any() ? $"({GetParamTypes().Select(x => x.ShortTypeName).Join(", ")})" : "")}" +         //(string, int, bool)
            $"]({Kind.ToMemberKindString()}/{FileName})";                                   //Methods/file.md etc.

        public string FormattedHyperLink =>
            $"/{Namespace}/{FileName}/#{Href}";

        public string SubFolder => Kind.ToMemberKindString();

        public string FullDirectory =>
            Path.Combine(Namespace, ShortTypeName, SubFolder);

        public string FileName =>
            Kind == MemberKind.Constructor
            ? "Constructors.md"
            : Kind == MemberKind.Method
            ? $"{NameSegments.Last().Split('`').First()}.md"
            : Kind == MemberKind.Property
            || Kind == MemberKind.Constants
            ? $"{NameSegments.Last()}.md"
            : $"{ShortTypeName}.md";

        public string FullFilePath =>
            Path.Combine(FullDirectory, FileName);

        private string GetReferenceName(bool useShortName) =>
            !useShortName
            ? LongName
            : Kind == MemberKind.Type ||
              Kind == MemberKind.Constructor
            ? ShortTypeName
            : Kind == MemberKind.Constants ||
              Kind == MemberKind.Property ||
              Kind == MemberKind.Method
            ? FriendlyName
            : "";

        /// <inheritdoc />
        public int CompareTo(MemberName other) =>
            ShortTypeName != other.ShortTypeName
            ? string.Compare(ShortTypeName, other.ShortTypeName, StringComparison.Ordinal)
            : Kind != other.Kind
            ? Kind.CompareTo(other.Kind)
            : string.Compare(LongName, other.LongName, StringComparison.Ordinal);

    }

}
