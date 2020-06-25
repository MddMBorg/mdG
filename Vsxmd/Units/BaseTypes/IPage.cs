using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsxmd.Units;

namespace Vsxmd
{
    /// <summary>
    /// Interface to bridge differences in implementation between <see cref="NormalType"/> and <see cref="MemberName"/>
    /// Mainly used to find difference between two types/members, for instance.
    /// At the very least, any item that will be rendered as MD will have a namespace and type (directory), a subfolder (methods/props etc) and a filename.
    /// </summary>
    public interface IPage
    {
        MemberKind Kind { get; }

        string Namespace { get; }

        string ShortTypeName { get; }

        int GenericCount { get; }

        string SubFolder { get; }

        /// <summary>
        /// Typically concatenation of <see cref="Namespace"/>, <see cref="ShortTypeName"/> and <see cref="SubFolder"/>
        /// </summary>
        string FullDirectory { get; }

        /// <summary>
        /// For <see cref="MemberKind.Type"/>, this should equal <see cref="ShortTypeName"/> e.g. Type-1.Type-1.md
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Typically concatenation of <see cref="FullDirectory"/> and <see cref="FileName"/>
        /// </summary>
        string FullFilePath { get; }

        /// <summary>
        /// Types that point to anything in the System Namespace that can be referenced via docs.
        /// </summary>
        string DocsName { get; }
    }

}
