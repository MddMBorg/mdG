<a name='T-Vsxmd-Program'></a>
# Program type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Program entry.

#### Remarks

Usage syntax:

```
Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]
```

The `input-XML-path` argument is required. It references to the VS generated XML documentation file.

The `output-Markdown-path` argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a `.md` file with same file name as the XML documentation file, path at the XML documentation folder.

# Methods

| Definition | Description |
|-|-|
| [Main(String[])](/Vsxmd.Program.md/#M-Vsxmd-Program-Main-System-String[]-) | Program main function entry. |
