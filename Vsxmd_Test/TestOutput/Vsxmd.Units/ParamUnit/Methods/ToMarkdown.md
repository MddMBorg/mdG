<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberName-'></a>
# ToMarkdown(elements,paramTypes,parentName) Method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the param XML element to Markdown safely.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

`paramTypes`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The paramater type names.

`parentName`  [MemberName](./../../MemberName/MemberName.md)  

The member kind of the parent element.

#### Returns





The generated Markdown.

#### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [](./../../MemberKind/Fields/Constructor.md) or [](./../../MemberKind/Fields/Method.md), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.
