<a name='T-Vsxmd-Units-ParamUnit'></a>
# ParamUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Param unit.

<a name='M-Vsxmd-Units-ParamUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
### #ctor(element,paramType) constructor

Initializes a new instance of the [ParamUnit](/Vsxmd.Units/ParamUnit.md/#T-Vsxmd-Units-ParamUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The param XML element.

`paramType`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The parameter type corresponding to the param XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `param`.

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberKind-'></a>
### ToMarkdown(elements,paramTypes,memberKind) method

Convert the param XML element to Markdown safely.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

`paramTypes`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The paramater type names.

`memberKind`  [MemberKind](/Vsxmd.Units/MemberKind.md/#T-Vsxmd-Units-MemberKind)  

The member kind of the parent element.

#### Returns





The generated Markdown.

#### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [Constructor](/Vsxmd.Units/MemberKind.md/#F-Vsxmd-Units-MemberKind-Constructor) or [Method](/Vsxmd.Units/MemberKind.md/#F-Vsxmd-Units-MemberKind-Method), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.
