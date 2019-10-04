<a name='T-Vsxmd-Units-SeealsoUnit'></a>
# SeealsoUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Seealso unit.

<a name='M-Vsxmd-Units-SeealsoUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [SeealsoUnit](/Vsxmd.Units.SeealsoUnit.md/#T-Vsxmd-Units-SeealsoUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The seealso XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `seealso`.

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) method

Convert the seealso XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The seealso XML element list.

#### Returns





The generated Markdown.
