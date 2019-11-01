using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocParser
{
    public interface IMarkdown
    {
        string ToMarkdown(bool summary);

    }

}
