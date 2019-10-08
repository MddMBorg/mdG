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
    internal class MemberName : IComparable<MemberName>
    {
        private readonly string name;

        private readonly char type;

        private readonly IEnumerable<string> paramNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        /// <param name="paramNames">The parameter names. It is only used when member kind is <see cref="MemberKind.Constructor"/> or <see cref="MemberKind.Method"/>.</param>
        internal MemberName(string name, IEnumerable<string> paramNames)
        {
            this.name = name;
            this.type = name.First();
            this.paramNames = paramNames;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        internal MemberName(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        internal MemberKind Kind =>
            this.type == 'T'
            ? MemberKind.Type
            : this.type == 'F'
            ? MemberKind.Constants
            : this.type == 'P'
            ? MemberKind.Property
            : this.type == 'M' && this.name.Contains(".#ctor")
            ? MemberKind.Constructor
            : this.type == 'M' && !this.name.Contains(".#ctor")
            ? MemberKind.Method
            : MemberKind.NotSupported;

        /// <summary>
        /// Gets the link pointing to this member unit.
        /// </summary>
        /// <value>The link pointing to this member unit.</value>
        internal string Link =>
            this.Kind == MemberKind.Type ||
            this.Kind == MemberKind.Constants ||
            this.Kind == MemberKind.Property
            ? $"[{this.FriendlyName.Escape()}]({this.FormattedHyperLink})"
            : this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? $"[{this.FriendlyName.Escape()}({this.paramNames.Join(", ")})]({this.FormattedHyperLink})"
            : string.Empty;

        /// <summary>
        /// Gets the caption representation for this member name.
        /// </summary>
        /// <value>The caption.</value>
        /// <example>
        /// <para>For <see cref="MemberKind.Type"/>, show as <c>## Vsxmd.Units.MemberName [#](#here) [^](#contents)</c>.</para>
        /// <para>For other kinds, show as <c>### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)</c>.</para>
        /// </example>
        internal string Caption =>
            this.Kind == MemberKind.Type
            ? $"{this.Href.ToAnchor()}# {this.FriendlyName.Escape()} Type"
            : this.Kind == MemberKind.Constants 
            ? $"{this.Href.ToAnchor()}# {this.FriendlyName.Escape()} Field"
            : this.Kind == MemberKind.Property
            ? $"{this.Href.ToAnchor()}# {this.FriendlyName.Escape()} Property"
            : this.Kind == MemberKind.Constructor
            ? $"{this.Href.ToAnchor()}# {this.FriendlyName.Escape()}({this.paramNames.Join(",")}) Constructor"
            : this.Kind == MemberKind.Method
            ? $"{this.Href.ToAnchor()}# {this.FriendlyName.Escape()}({this.paramNames.Join(",")}) Method"
            : string.Empty;

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        internal string TypeName =>
            $"{this.Namespace}.{this.TypeShortName}";

        /// <summary>
        /// Gets the namespace name.
        /// </summary>
        /// <value>The namespace name.</value>
        /// <example><c>System</c>, <c>Vsxmd</c>, <c>Vsxmd.Units</c>.</example>
        internal string Namespace =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.TakeAllButLast(1).Join(".")
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.TakeAllButLast(2).Join(".")
            : string.Empty;

        private string TypeShortName =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.Last()
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.NthLast(2)
            : string.Empty;

        private string Href => this.name.ToMarkdownRef();

        private string StrippedName =>
            this.name.Substring(2);

        private string LongName =>
            this.StrippedName.Split('(').First();

        private string DocsName =>
            this.LongName.Split('{').First();

        private IEnumerable<string> NameSegments =>
            this.LongName.Split('.');

        private string FriendlyName =>
            this.Kind == MemberKind.Type
            ? this.TypeShortName
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.Last()
            : this.Kind == MemberKind.Constructor
            ? this.TypeShortName
            : string.Empty;

        /// <inheritdoc />
        public int CompareTo(MemberName other) =>
            this.TypeShortName != other.TypeShortName
            ? string.Compare(this.TypeShortName, other.TypeShortName, StringComparison.Ordinal)
            : this.Kind != other.Kind
            ? this.Kind.CompareTo(other.Kind)
            : string.Compare(this.LongName, other.LongName, StringComparison.Ordinal);

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
        internal IEnumerable<string> GetParamTypes()
        {
            if (!this.name.Contains('('))
                return Enumerable.Empty<string>();

            var paramString = this.name.Split('(').Last().Trim(')');

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
        /// <param name="useShortName">Indicate if use short type name.</param>
        /// <returns>The generated Markdown reference link.</returns>
        internal string ToReferenceLink(MemberName sourceMember, bool useShortName) =>
            $"[{this.GetReferenceName(useShortName).Escape()}]({this.MemberLink(sourceMember)})";

        internal string ToSummaryLink(bool useShortName) =>
            $"[{this.GetReferenceName(useShortName).Escape()}" +
            $"{(this.GetParamTypes().Count() > 0 ? $"({this.GetParamTypes().Select(x => x.Split('.').NthLast(1)).Join(", ")})" : "")}" +
            $"]({this.Kind.ToMemberKindString()}/{this.FileName})";

        internal string FormattedHyperLink =>
            $"/{this.Namespace}/{this.FileName}/#{this.Href}";

        internal string MemberLink(MemberName sourceMember)
        {
            //Use docs.microsoft for references to the System namespace
            if (this.Namespace.StartsWith("System.", StringComparison.Ordinal) || this.Namespace.Equals("System", StringComparison.Ordinal))
                return $"https://docs.microsoft.com/dotnet/api/{this.DocsName}";
            
            string shortFilePath = this.Kind.ToMemberKindString();
            shortFilePath = $"{shortFilePath}{(!string.IsNullOrWhiteSpace(shortFilePath) ? "/" : "")}{this.FileName}";

            //if the LongName property is the same then the reference is to itself
            if (this.LongName == sourceMember.LongName)
                return "#";
             /*
             * N.B. Type kinds are always (here) one level above methods/props/fields etc, and so require one less ../ to index to the upper level (Kind, Class, namespace)
             */
            //If the namespace is different, go up to the top level and then index into the markdown file
            if (this.Namespace != sourceMember.Namespace)
            {
                //Need to replace the backslashes since Windows file system is \ vs the web /
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../../{this.FullFilePath}".Replace('\\', '/');
                else
                    return $"./../../../{this.FullFilePath}".Replace('\\', '/');
            }
            //If the type is different, go up to the namespace level
            else if (this.TypeShortName != sourceMember.TypeShortName)
            {
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../{this.TypeShortName}/{shortFilePath}";
                else
                    return $"./../../{this.TypeShortName}/{shortFilePath}";
            }
            //If using a different kind (method, ctor, class etc), go to the common type level
            else if (this.Kind != sourceMember.Kind)
            {
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./{shortFilePath}";
                else
                    return $"./../{shortFilePath}";
            }
            //Else, index as if the markdown file is on the same level
            else
                return $"{this.FileName}";
        }

        internal string FileName =>
            Kind != MemberKind.Constructor
            ? $"{this.FriendlyName}.md"
            : "Constructors.md";

        internal string DirectoryName =>
            Kind == MemberKind.Type
            ? Path.Combine(this.Namespace, this.TypeShortName)
            : Path.Combine(this.Namespace, this.TypeShortName, this.Kind.ToMemberKindString());

        internal string FullFilePath =>
            Path.Combine(DirectoryName, FileName);

        private string GetReferenceName(bool useShortName) =>
            !useShortName
            ? this.LongName
            : this.Kind == MemberKind.Type ||
              this.Kind == MemberKind.Constructor
            ? this.TypeShortName
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Method
            ? this.FriendlyName
            : string.Empty;

    }

}
