using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsxmd.Units
{
    /// <summary>
    /// The formatting kind to use when generating markup.
    /// </summary>
    internal enum FormatKind
    {
        Summary,            //The summary in the class page e.g. the list of properties, methods etc and descriptions
        Detail,             //The detail page for a method, property etc
        MultiDetail,        //When a method/ctor has multiple overloads, for printing on a page
        None
    }

}
