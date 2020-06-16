using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsxmd.Units
{
    public class NormalType
    {
        private static readonly Dictionary<string, NormalType> CachedTypes = new Dictionary<string, NormalType>();

        /// <summary>
        /// Used to create a NormalType to take advantage of caching (avoid parsing more than once)
        /// </summary>
        /// <param name="typeString">String representing the CLR type.</param>
        /// <returns>A NormalType instance</returns>
        public static NormalType CreateNormalType(string typeString)
        {
            if (string.IsNullOrEmpty(typeString))
                return null;
            typeString = typeString.Replace('{', '<').Replace('}', '>').Replace("``", "");
            if (CachedTypes.TryGetValue(typeString, out var val))
                return val;
            else
            {
                NormalType ret = new NormalType(typeString);
                CachedTypes[typeString] = ret;
                return ret;
            }
        }


        private readonly string _TypeString;

        /// <summary>
        /// Construct the MemberType class.
        /// </summary>
        /// <param name="typeString">String representing the CLR type.</param>
        /// <remarks>typeString may be of XML format I.e. namespace.type`x{namespace1.type1, ``x}, or normal format 
        /// I.e. namespace.type&lt;T&gt;&lt;namespace1.type1, T&gt;</remarks>
        protected NormalType(string typeString)
        {
            _TypeString = typeString.Replace('{', '<').Replace('}', '>').Replace("``", "");
        }

        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => System.Collections.Generic.IEnumerable
        /// </summary>
        internal string RawTypeName => _TypeString.Split('<').First();

        /// <summary>
        /// System.Collections.Generic.IEnumerable => System.Collections.Generic
        /// </summary>
        public string Namespace => RawTypeName.Split('.').TakeAllButLast(1).Join(".");

        /// <summary>
        /// System.Collections.Generic.IEnumerable => IEnumerable
        /// </summary>
        public string ShortTypeName => RawTypeName.Split('.').Last();

        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => IEnumerable-1
        /// </summary>
        public string ShortLinkName => SubTypes.Any() ? $"{ShortTypeName}-{SubTypes.Count()}" : ShortTypeName;

        private string DocsName => $"{RawTypeName}{(SubTypes.Any() ? $"-{SubTypes.Count()}" : "")}";

        internal string TypePath => Path.Combine(Namespace, ShortLinkName);

        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => System.Collections.Generic.IEnumerable-1
        /// System.String => System.String
        /// </summary>
        internal string FullPath => Path.Combine(TypePath, $"{ShortLinkName}.md");

        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => Vsxmd.Units.MemberUnit, Vsxmd.Units.MemberUnit => ""
        /// </summary>
        private string _GenericTypeString
        {
            get
            {
                int index = _TypeString.IndexOf('<');
                if (index <= 0)
                    return "";
                return _TypeString.Substring(index + 1, (_TypeString.Length - 1) - (index + 1));
            }
        }

        private IEnumerable<NormalType> _SubTypes;
        public IEnumerable<NormalType> SubTypes
        {
            get
            {
                if (_SubTypes == null)
                    _SubTypes = _GetSubTypes();
                return _SubTypes;
            }
        }

        private IEnumerable<NormalType> _GetSubTypes()
        {
            if (string.IsNullOrWhiteSpace(_GenericTypeString))
                yield break;

            string genericString = _GenericTypeString;
            string nestStr = "";
            int nestLevel = 0;

            for (int i = 0; i < genericString.Length; i++)
            {
                char ch = genericString[i];
                if (ch == '<')
                {
                    nestLevel++;
                    nestStr += "<";         //if we're in a sub-nest, keep the < ie, the second < in "List<List<int>>" but not the first <
                }
                else if (ch == '>')
                {
                    nestLevel--;
                    nestStr += ">";
                }
                else if (ch == ',' && nestLevel == 0)
                {
                    yield return NormalType.CreateNormalType(nestStr);          //generate our generic type link
                    nestStr = "";
                }
                else if (ch == ' ')
                { //do nothing, ignore spaces
                }
                else
                    nestStr += ch.ToString();
            }
            if (!string.IsNullOrEmpty(nestStr))
                yield return NormalType.CreateNormalType(nestStr);
        }

        /// <summary>
        /// For a type with generics, gives a link to the base type e.g. Dictionary&lt;int, string&gt; => Dictionary-2
        /// </summary>
        /// <param name="sourceMember">the source to generate the relative link from.</param>
        public string GetBaseUri(MemberName sourceMember)
        {
            //if we're dealing with a generic type i.e. T, Key, etc, then we can't generate a link, so return null
            if (!_TypeString.Contains("."))
                return null;

            //Use docs.microsoft for references to the System namespace
            if (RawTypeName.StartsWith("System.", StringComparison.Ordinal))
                return $"https://docs.microsoft.com/dotnet/api/{DocsName}";

            string fullFilePath = FullPath;
            string sourcePath = sourceMember.FullFilePath;
            string shortTypeLinkName = ShortLinkName;

            //if we're in the same path
            if (fullFilePath == sourcePath)
                return "#";

            //We're always a Type kind "T:"
            //If the namespace is different, go up to the top level and then index into the markdown file
            if (Namespace != sourceMember.Namespace)
            {
                //Need to replace the backslashes since Windows file system is \ vs the web /
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../../{fullFilePath}".Replace('\\', '/');
                else
                    return $"./../../../{fullFilePath}".Replace('\\', '/');
            }
            //If the type is different, go up to the namespace level
            else if (shortTypeLinkName != sourceMember.FriendlyName)
            {
                if (sourceMember.Kind == MemberKind.Type)
                    return $"./../{shortTypeLinkName}/{shortTypeLinkName}.md";
                else
                    return $"./../../{shortTypeLinkName}/{shortTypeLinkName}.md";
            }
            //If using a different kind (method, ctor, class etc), go to the common type level
            else //if (sourceMember.Kind != MemberKind.Type)
                return $"./../{shortTypeLinkName}.md";
        }

        /// <summary>
        /// Converts a generic type to a list of links for each type
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public string ToMarkdownLink(MemberName sourceMember)
        {
            var link = GetBaseUri(sourceMember);
            if (link == null)
                return ShortTypeName;

            string ret = $"[{ShortTypeName}]({link})";
            if (SubTypes.Any())
                ret += $"<{string.Join(", ", SubTypes.Select(x => x.ToMarkdownLink(sourceMember)))}>";
            return ret;
        }

    }

}
