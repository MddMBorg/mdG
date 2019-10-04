<a name='T-Vsxmd-Program'></a>
## Program `type`

##### Namespace

Vsxmd

##### Summary

Program entry.

##### Remarks

Usage syntax:

```
Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]
```

The `input-XML-path` argument is required. It references to the VS generated XML documentation file.

The `output-Markdown-path` argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a `.md` file with same file name as the XML documentation file, path at the XML documentation folder.

<a name='M-Vsxmd-Program-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

Program main function entry.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[]) | Program arguments. |

##### See Also

- [Vsxmd.Program](./Vsxmd.Program.md/#T-Vsxmd-Program)
