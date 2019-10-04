<a name='T-Vsxmd-Units-ReturnsUnit'></a>
# ReturnsUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Returns unit.

<a name='M-Vsxmd-Units-ReturnsUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [ReturnsUnit](/Vsxmd.Units.ReturnsUnit.md/#T-Vsxmd-Units-ReturnsUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The returns XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `returns`.

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) method

Convert the returns XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The returns XML element.

#### Returns





The generated Markdown.
