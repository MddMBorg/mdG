<a name='T-Vsxmd-Units-Extensions'></a>
# Extensions type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Extensions helper.

# Methods

| Definition | Description |
|-|-|
| [AsCode(String)](/Vsxmd.Units/AsCode.md/#M-Vsxmd-Units-Extensions-AsCode-System-String-) | Wrap the `code` into Markdown backtick safely.  The backtick characters inside the `code` reverse as it is. |
| [Escape(String)](/Vsxmd.Units/Escape.md/#M-Vsxmd-Units-Extensions-Escape-System-String-) | Escape the content to keep it raw in Markdown syntax. |
| [GetAssemblyName(XElement)](/Vsxmd.Units/GetAssemblyName.md/#M-Vsxmd-Units-Extensions-GetAssemblyName-System-Xml-Linq-XElement-) | Probably a lazy way to do this and more implementation should be moved to AssemblyUnit class |
| [Join(String}, String)](/Vsxmd.Units/Join.md/#M-Vsxmd-Units-Extensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-) | Concatenates the `value`s with the `separator`. |
| [NthLast\`\`1(IEnumerable{``0}, Int32)](/Vsxmd.Units/NthLast``1.md/#M-Vsxmd-Units-Extensions-NthLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-) | Gets the n-th last element from the `source`. |
| [Suffix(String, String)](/Vsxmd.Units/Suffix.md/#M-Vsxmd-Units-Extensions-Suffix-System-String,System-String-) | Suffix the `suffix` to the `value`, and generate a new string. |
| [TakeAllButLast\`\`1(IEnumerable{``0}, Int32)](/Vsxmd.Units/TakeAllButLast``1.md/#M-Vsxmd-Units-Extensions-TakeAllButLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-) | Take all element except the last `count`. |
| [ToAnchor(String)](/Vsxmd.Units/ToAnchor.md/#M-Vsxmd-Units-Extensions-ToAnchor-System-String-) | Generate an anchor for the `href`. |
| [ToHereLink(String)](/Vsxmd.Units/ToHereLink.md/#M-Vsxmd-Units-Extensions-ToHereLink-System-String-) | Generate "to here" link for the `href`. |
| [ToLowerString(MemberKind)](/Vsxmd.Units/ToLowerString.md/#M-Vsxmd-Units-Extensions-ToLowerString-Vsxmd-Units-MemberKind-) | Convert the [MemberKind](/Vsxmd.Units/MemberKind.md/#T-Vsxmd-Units-MemberKind) to its lowercase name. |
| [ToMarkdownRef(String)](/Vsxmd.Units/ToMarkdownRef.md/#M-Vsxmd-Units-Extensions-ToMarkdownRef-System-String-) | Escape a reference to an anchor, file or folder by replacing special characters with '-'. |
| [ToMarkdownText(XElement)](/Vsxmd.Units/ToMarkdownText.md/#M-Vsxmd-Units-Extensions-ToMarkdownText-System-Xml-Linq-XElement-) | Convert the inline XML nodes to Markdown text. For example, it works for `summary` and `returns` elements. |
| [ToReferenceLink(String, Boolean)](/Vsxmd.Units/ToReferenceLink.md/#M-Vsxmd-Units-Extensions-ToReferenceLink-System-String,System-Boolean-) | Generate the reference link for the `memberName`. |
