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
        private string _OutputPath { get; set; }
        private Converter _Converter { get; set; }
        private XDocument _Document { get; set; }

        /// <summary>
        /// Ctor for Markdown Writer
        /// </summary>
        /// <param name="document">The XDocument to be converted to Markdown and output.</param>
        /// <param name="outputPath">Path to output Markdown to.</param>
        public MarkdownWriter(XDocument document, string outputPath)
        {
            _OutputPath = outputPath;
            _Document = document;
            _Converter = new Converter(document);
        }

        /// <summary>
        /// Converts the XML to one Markdown file and writes to the output file
        /// </summary>
        public void WriteSingleFile()
        {
            MemberName.SplitFiles = false;
            MemberName.SubFolder = false;

            File.WriteAllText(Path.ChangeExtension(_OutputPath, "md"), _Converter.ToMarkdown());
        }

        /// <summary>
        /// Converts the XML to multiple Markdown files (one per type) and writes to the output directory
        /// </summary>
        /// <param name="useSubDirectories">Use subdirectories for each namespace.</param>
        public void WriteMultipleFiles(bool useSubDirectories)
        {
            MemberName.SplitFiles = true;
            MemberName.SubFolder = useSubDirectories;

            string directory = Path.GetDirectoryName(_OutputPath);

            //Create output directory in case
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var types = _Converter.MemberUnits();

            if (useSubDirectories)
            {
                foreach (var x in types.GroupBy(z => z.TypeNamespace))
                {
                    if (!Directory.Exists(Path.Combine(directory, x.Key)))
                        Directory.CreateDirectory(Path.Combine(directory, x.Key));
                }
            }

            foreach (var n in types.GroupBy(x => x.TypeNamespace))
            {
                foreach (var t in n.GroupBy(x => x.FileName))
                    File.WriteAllText(
                        Path.Combine(
                            Path.Combine(directory, useSubDirectories ? n.Key : ""), t.Key),
                        t.SelectMany(x => x.ToMarkdown()).Join("\n\n").Suffix("\n"));
            }

        }

    }

}
