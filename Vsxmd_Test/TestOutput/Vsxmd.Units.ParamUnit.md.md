<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberKind-'></a>
# ToMarkdown(elements,paramTypes,memberKind) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the param XML element to Markdown safely.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

`paramTypes`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The paramater type names.

`memberKind`  [MemberKind](/Vsxmd.Units.MemberKind.md/#T-Vsxmd-Units-MemberKind)  

The member kind of the parent element.

#### Returns





The generated Markdown.

#### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [Constructor](/Vsxmd.Units.MemberKind.md/#F-Vsxmd-Units-MemberKind-Constructor) or [Method](/Vsxmd.Units.MemberKind.md/#F-Vsxmd-Units-MemberKind-Method), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.
