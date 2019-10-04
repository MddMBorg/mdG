<a name='T-Vsxmd-Units-TypeparamUnit'></a>
# TypeparamUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Typeparam unit.

<a name='M-Vsxmd-Units-TypeparamUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [TypeparamUnit](/Vsxmd.Units/TypeparamUnit.md/#T-Vsxmd-Units-TypeparamUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The typeparam XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `typeparam`.

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) method

Convert the param XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

#### Returns





The generated Markdown.
