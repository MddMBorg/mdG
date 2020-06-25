using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vsxmd.Units
{
    public class NormalType : IPage
    {
        #region Generation
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
        #endregion

        private readonly string _TypeString;
        public MemberKind Kind => MemberKind.Type;

        /// <summary>
        /// Construct the MemberType class.
        /// </summary>
        /// <param name="typeString">String representing the CLR type.</param>
        /// <remarks>typeString may be of XML format I.e. namespace.type`x{namespace1.type1, ``x}, or normal format 
        /// I.e. namespace.type&lt;T&gt;&lt;namespace1.type1, T&gt;</remarks>
        protected NormalType(string typeString)
        {
            _TypeString = typeString;
        }

        #region NameParts
        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => System.Collections.Generic.IEnumerable
        /// </summary>
        internal string RawTypeName => _TypeString.Split('<').First();

        /// <summary>
        /// System.Collections.Generic.IEnumerable => System.Collections.Generic
        /// </summary>
        public string Namespace => RawTypeName.Split('.').TakeAllButLast(1).Join(".");

        /// <summary>
        /// System.Collections.Generic.IEnumerable => IEnumerable, System.String[] => String
        /// </summary>
        public string DisplayTypeName => RawTypeName.Split('.').Last().Split('[').First();

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
                int last = _TypeString.LastIndexOf('>');
                return _TypeString.Substring(index + 1, last - (index + 1));
            }
        }

        /// <summary>
        /// If there's a [] or [][], return this as a string
        /// </summary>
        internal string ArrayModifiers
        {
            get
            {
                string postGenerics = _TypeString.Split('>').Last();
                int index = postGenerics.IndexOf('[');
                return index > 0 ? postGenerics.Substring(index) : "";
            }
        }
        #endregion

        #region PathProperties
        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => IEnumerable-1
        /// </summary>
        public string ShortTypeName => SubTypes.Any() ? $"{DisplayTypeName}-{SubTypes.Count()}" : DisplayTypeName;
        public string SubFolder => "";
        public string FileName => ShortTypeName;

        public string FullDirectory => Path.Combine(Namespace, ShortTypeName);

        /// <summary>
        /// System.Collections.Generic.IEnumerable&lt;Vsxmd.Units.MemberUnit&gt; => System.Collections.Generic.IEnumerable-1
        /// System.String => System.String
        /// </summary>
        public string FullFilePath => Path.Combine(FullDirectory, $"{FileName}.md");

        public string DocsName => $"{RawTypeName}{(SubTypes.Any() ? $"-{SubTypes.Count()}" : "")}";
        #endregion

        public int GenericCount => SubTypes.Count();

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
        /// Converts a generic type to a list of links for each type
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public string ToMarkdownLink(MemberName sourceMember)
        {
            var link = this.GetLink(sourceMember);
            if (link == null)
                return DisplayTypeName;

            string ret = $"[{DisplayTypeName}]({link})";
            if (SubTypes.Any())
                ret += $"<{string.Join(", ", SubTypes.Select(x => x.ToMarkdownLink(sourceMember)))}>";
            return ret;
        }

        private static Dictionary<string, IEnumerable<string>> _FormatCache = new Dictionary<string, IEnumerable<string>>();
        private static Regex toStringRegex = new Regex("(Ns|Tn|Gc|Am|Sg{.*})");
        /// <summary>
        /// Returns this type object as a formatted string
        /// </summary>
        /// <param name="format">
        /// For example types System.Collections.Generic.Dictionary&lt;System.Int32, System.Collections.Generic.List&lt;System.String&gt;&gt;
        /// System.String[]
        /// Ns => NameSpace => System.Collections.Generic | System
        /// Tn => Type Name => Dictionary | String[]
        /// Gc => Generic Count => 2 | ""
        /// Am => Array Modifiers => n.a. | []
        /// Sg{,,,} => Spool Genrics => System.Int32.ToString(format),,,System.Collections.Generic.List&lt;System.String&gt;.ToString(format)
        /// Spool Genrics calls the <see cref="ToString(string)"/> method on each of the generic parameter types in <see cref="SubTypes"/>
        /// and joins with the subsequent characters, so Sg{,,,} will join each subcomponent with ,,,
        /// </param>
        public string ToString(string format)
        {
            IEnumerable<string> parts;
            _FormatCache.TryGetValue(format, out parts);
            if (parts == null)
            {
                parts = toStringRegex.Split(format);
                _FormatCache[format] = parts;
            }

            return _ToString(parts);
        }

        //Wrapper to make easier re. recalculating format string parts
        private string _ToString(IEnumerable<string> parts)
        {
            string returnString = "";

            foreach (var part in parts)
            {
                if (part == "Ns")
                    returnString += Namespace;
                else if (part == "Tn")
                    returnString += DisplayTypeName;
                else if (part == "Gc")
                    returnString += SubTypes.Any() ? SubTypes.Count().ToString() : "";
                else if (part == "Am")
                    returnString += ArrayModifiers;
                else if (part.StartsWith("Sg{") && part.EndsWith("}"))
                    returnString += SubTypes.Select(x => x._ToString(parts)).Join(part.Remove(0, 3).TrimEnd('}'));
                else
                    returnString += part;
            }
            return returnString;
        }

    }

}
