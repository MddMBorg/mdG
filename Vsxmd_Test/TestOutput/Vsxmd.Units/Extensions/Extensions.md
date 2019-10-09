<a name='T-Vsxmd-Units-Extensions'></a>
# Extensions Type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Extensions helper.

# Methods

| Definition | Description |
|-|-|
| [AsCode(String)](Methods/AsCode.md) | Wrap the `code` into Markdown backtick safely.<br/><br/>The backtick characters inside the `code` reverse as it is. |
| [Escape(String)](Methods/Escape.md) | Escape the content to keep it raw in Markdown syntax. |
| [GetAssemblyName(XElement)](Methods/GetAssemblyName.md) | Probably a lazy way to do this and more implementation should be moved to AssemblyUnit class |
| [Join(String}, String)](Methods/Join.md) | Concatenates the `value`s with the `separator`. |
| [NthLast\`\`1(IEnumerable{``0}, Int32)](Methods/NthLast``1.md) | Gets the n-th last element from the `source`. |
| [Suffix(String, String)](Methods/Suffix.md) | Suffix the `suffix` to the `value`, and generate a new string. |
| [TakeAllButLast\`\`1(IEnumerable{``0}, Int32)](Methods/TakeAllButLast``1.md) | Take all element except the last `count`. |
| [ToAnchor(String)](Methods/ToAnchor.md) | Generate an anchor for the `href`. |
| [ToHereLink(String)](Methods/ToHereLink.md) | Generate "to here" link for the `href`. |
| [ToLowerString(MemberKind)](Methods/ToLowerString.md) | Convert the [MemberKind](./../MemberKind/MemberKind.md) to its lowercase name. |
| [ToMarkdownRef(String)](Methods/ToMarkdownRef.md) | Escape a reference to an anchor, file or folder by replacing special characters with '-'. |
| [ToMarkdownText(XElement)](Methods/ToMarkdownText.md) | Convert the inline XML nodes to Markdown text.<br/>For example, it works for `summary` and `returns` elements. |
| [ToReferenceLink(String, Boolean)](Methods/ToReferenceLink.md) | Generate the reference link for the `memberName`. |
