using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocParser
{
    public class MemberID : IMarkdown
    {
        private readonly string _Name;
        private readonly char _Kind;
        public readonly string ProperName;

        public string Type;

        public string Defintion => ProperName.Split('(').First().Split('.').Last();

        public MemberID(string memberName)
        {
            _Name = memberName;
            _Kind = _Name.First();
            ProperName = _Name.Substring(2);
        }


        public string ToMarkdown(bool summary = false)
        {
            return _Name;
        }

        public static implicit operator string(MemberID x) => x._Name;
        public static implicit operator MemberID(string x) => new MemberID(x);

        public override string ToString() => ProperName;

    }

}
