# mdG

This is a fork of the [Vsxmd](README.md/#Vsxmd) project described below. The MIT license is preserved for all changes and additions introduced in this fork. The features supported are almost identical, except:

- Markdown is now output into separate folders on a namespace, class and member type basis.
- Each method, property, class, field and constructor outputs to a separate markdown file.
- Return types of methods are determined by looking for a "see" tag in the "returns" tag.
- Type (class) Markdown files contain a summary of all type members in a table.
- References to members are now resolved by relative links between folders/files.
- Namespace/Assembly are included on all member's markdown files.
- System namespace references now use docs.microsoft links instead of msdn links.

The intention of these changes was to mimic the format used by docs.microsoft, where each class has its own folder, with a page for constructors, and a folder for all methods, fields and properties, referred to by the main class page via a summary table.

Since the XML generated by VS does not provide information regarding the return type of a method, you should specify the return type to be displayed in the markdown by using a "see" tag in the "returns" tag". For example:

`<returns><see cref="System.String"/></returns>`

## Known issues (on roadmap)

- Constructors page only returns one constructor.

## To be added

- Extension project to include properties in property pages (C# projects only) to run in post-build.

# Vsxmd

A MSBuild task to convert [XML documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments) to Markdown syntax. Support both .Net Framework and .Net Core projects.

## Features

- Provide full information from the XML documentation file.
- Provide easy reading facilities - parameter table, link tooltip, etc.
- Provide table of contents to type and member links.
- Highlight code block through `<code lang="csharp">` tag.
- Reference `System` types to official MSDN pages.

## Get Started

If you are using Visual Studio:

- In Visual Studio, right click project name to open project properties window.
- Switch to **Build** tab, in **Output** section, check **XML documentation file** checkbox.
- Install [Vsxmd](https://www.nuget.org/packages/Vsxmd/) package from NuGet.
- Build the project, then a markdown file is generated next to the XML documentation file.

If you are using .Net Core CLI:

- Open project's CSPROJ file, declare [`DocumentationFile`](https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties) property in `PropertyGroup` section. The path is relative to the project directory. [MSBuild Reserved and Well-Known properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties) are also available for this property.
- Run `dotnet add package Vsxmd` to install the the package to the project.
- Run `dotnet build` to build the project and generate the XML documentation and Markdown files.

## Vsxmd Options

There are some properties to customize the Markdown file generation process. They are all optional. If you want to use them, declare them in CSPROJ file's `PropertyGroup` section.

### `DocumentationMarkdown`

It is used to specify the generated Markdown file path. It defaults to the XML documentation file name with `.md` extension, under the same folder as the XML file. Similar to `DocumentationFile` property, the path is relative to the project directory and [MSBuild properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties) are available.

#### Example

```xml
<PropertyGroup>
    <DocumentationMarkdown>$(MSBuildProjectDirectory)\API.md</DocumentationMarkdown>
</PropertyGroup>
```

### `VsxmdAutoDeleteXml`

A boolean flag to delete the XML documentation file after the Markdown file is generated.

#### Example

```xml
<PropertyGroup>
    <VsxmdAutoDeleteXml>True</VsxmdAutoDeleteXml>
</PropertyGroup>
```

## Extend XML documentation

There are some extended features based on XML documentation. They are not described in [XML recommended tags](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments), but they are worth to use.

### Highlight Code Block

To highlight code block in the Markdown file, declare the attribute `lang` in `<code>` tag and set it to a program language identifier.

#### Example

```xml
<code lang="javascript">
    function test() {
        console.log("notice the blank line before this function?");
    }
</code>
```

## Programmatic API

This library provides the following programmatic API to convert XML documentation file to Markdown syntax programmatically.

- [Converter](https://github.com/lijunle/Vsxmd/blob/master/Vsxmd/Vsxmd.md#T-Vsxmd-Converter) : [IConverter](https://github.com/lijunle/Vsxmd/blob/master/Vsxmd/Vsxmd.md#T-Vsxmd-IConverter)
  - [string ToMarkdown()](https://github.com/lijunle/Vsxmd/blob/master/Vsxmd/Vsxmd.md#M-Vsxmd-IConverter-ToMarkdown)
  - [static string ToMarkdown(XDocument document)](https://github.com/lijunle/Vsxmd/blob/master/Vsxmd/Vsxmd.md#M-Vsxmd-Converter-ToMarkdown-System-Xml-Linq-XDocument-)

## Markdown File Demo

The best demo is this project's documentation file, [Vsxmd.md](https://github.com/lijunle/Vsxmd/blob/master/Vsxmd/Vsxmd.md). It is generated by this project itself.

## Known Issue

The syntax for the [`list`](https://msdn.microsoft.com/en-us/library/y3ww3c7e.aspx) comment tag is not well defined. It will be skipped during render. If you have ideas, please [open an issue](https://github.com/lijunle/Vsxmd/issues).

## Credits

This project is initially inspired from a [gist](https://gist.github.com/formix/515d3d11ee7c1c252f92). But in the later releases, the implementation is rewritten.

## License

MIT License.
