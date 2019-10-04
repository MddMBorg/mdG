<a name='T-Vsxmd-Units-SummaryUnit'></a>
# SummaryUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Summary unit.

<a name='M-Vsxmd-Units-SummaryUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [SummaryUnit](/Vsxmd.Units.SummaryUnit.md/#T-Vsxmd-Units-SummaryUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The summary XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `summary`.

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) method

Convert the summary XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The summary XML element.

#### Returns





The generated Markdown.
