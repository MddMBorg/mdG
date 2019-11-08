using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocParser
{
    public static class Extensions
    {

        //Type      = Type
        //Field     = Type.FieldName
        //Prop      = Type.PropName
        //Method    = Type.MethodName(Params Type)
        //Ctor      = Type.#ctor(Params Type)
        //Event     = Type.EventName

        //Type      = Namespace.TypeName<Generics>
        //Type<T, U>                                                        ---> T:Namespace.Type`2
        //List<T> Namespace.Type.Method<T>(IEnumerable<T> temp, T first)    ---> M:Namespace.Type.Method``1(IEnumerable{``0},``0)

        public static string ToXMLFormat(this string str)
        {
            return !str.Contains('(') ? ToXMLStandardFormat(str) : ToXMLMethodFormat(str);
        }

        private static string ToXMLStandardFormat(string str)
        {
            bool hasGeneric = false;
            int genericCount = 0;
            string typeName = "";
            foreach (var ch in str)
            {
                if (ch == '<')
                {
                    hasGeneric = true;
                    genericCount++;
                }
                else if (ch == '>')
                {
                    hasGeneric = false;
                    typeName += $"`{genericCount}";
                }
                else if (ch == ',' && hasGeneric)
                {
                    genericCount++;
                }
                else if (!hasGeneric)
                {
                    typeName += ch;
                }
            }
            return typeName;
        }

        private static string ToXMLMethodFormat(string str)
        {
            int recursion = 0;
            bool parsingName = false;
            string currentType = "";
            List<string> typeNames = new List<string>();
            string memberName = "";

            string first = str.Split('(').First();
            string last = str.Split('(').First();

            if (first.Contains('<'))
            {
                memberName = first.Split('<').First();
                typeNames = first.Split('<').Last().TrimEnd('>').Split(',').Select(x => x.Trim()).ToList();
                memberName += $"`{typeNames.Count}";
            }
            else
            {
                memberName = first;
            }
            memberName += '(';

            foreach (var ch in last)
            {
                if (ch == '<')
                {
                    recursion++;
                    memberName += $"{currentType}{{";
                    currentType = "";
                }
                else if (ch == '>')
                {
                    recursion--;
                    int index = typeNames.IndexOf(currentType);
                    memberName += (index != -1) ? $"``{index}}}" : $"{currentType}}}";

                    currentType = "";
                }
                else if (ch == ',' && recursion != 0)
                {
                    int index = typeNames.IndexOf(currentType);
                    memberName += (index != -1) ? $"``{index}," : $"{currentType},";

                    currentType = "";
                }
                else if (ch == ' ' && !parsingName && recursion == 0 && !string.IsNullOrWhiteSpace(currentType))
                {
                    parsingName = true;
                }
                else if (!parsingName && ch != ' ')
                {
                    currentType += ch;
                }
                else if (ch == ',' && recursion == 0)
                {
                    parsingName = false;
                    memberName += $"{currentType},";
                    currentType = "";
                }
            }
            
            return memberName;
        }

    }

}
