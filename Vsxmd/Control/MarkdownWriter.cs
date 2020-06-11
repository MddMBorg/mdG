using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Vsxmd.Units;

namespace Vsxmd
{
    public class MarkdownWriter
    {
        private readonly string _OutputPath;
        private readonly Converter _Converter;

        /// <summary>
        /// Ctor for Markdown Writer
        /// </summary>
        /// <param name="document">The XDocument to be converted to Markdown and output.</param>
        /// <param name="outputPath">Path to output Markdown to.</param>
        public MarkdownWriter(XDocument document, string outputPath)
        {
            _OutputPath = outputPath;
            _Converter = new Converter(document);
        }

        /// <summary>
        /// Converts the XML to multiple Markdown files (one per type) and writes to the output directory
        /// </summary>
        public void WriteFiles()
        {
            string directory = Path.GetDirectoryName(_OutputPath);

            //Create output directory in case
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var types = _Converter.MemberUnits();

            foreach (var dirs in types.GroupBy(x => x.DirectoryName))
            {
                if (!Directory.Exists(Path.Combine(directory, dirs.Key)))
                    Directory.CreateDirectory(Path.Combine(directory, dirs.Key));
            }

            PageFormatter formatter = new PageFormatter();

            foreach (var n in types.GroupBy(x => x.TypeNamespace))
            {
                foreach (var t in n.GroupBy(x => x.TypeName))
                {
                    var markdown = formatter.GetMarkdownByType(t.Select(x => x));
                    File.WriteAllText(Path.Combine(directory, t.Where(x => x.Kind == MemberKind.Type).FirstOrDefault().FullFilePath),
                        markdown.Join("\n\n").Suffix("\n"));
                }

                foreach (var m in n.Where(x => (x as MemberUnit).Kind != MemberKind.Type && (x as MemberUnit).Kind != MemberKind.NotSupported)
                    .GroupBy(x => x.FullFilePath))
                {
                    var markdown = formatter.GetMarkdownByMember(m);
                    File.WriteAllText(Path.Combine(directory, m.First().FullFilePath),
                        markdown.Join("\n\n").Suffix("\n"));
                }

            }

        }

    }

}
