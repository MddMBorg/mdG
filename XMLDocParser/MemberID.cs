using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocParser
{
    public class MemberID
    {
        private readonly string _Name;

        public MemberID(string memberName)
        {
            _Name = memberName;
        }

        public override string ToString() => _Name;

        public static implicit operator string(MemberID x) => x._Name;
        public static implicit operator MemberID(string x) => new MemberID(x);

    }

}
