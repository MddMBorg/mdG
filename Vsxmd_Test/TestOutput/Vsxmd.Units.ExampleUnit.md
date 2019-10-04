<a name='T-Vsxmd-Units-ExampleUnit'></a>
# ExampleUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Example unit.

<a name='M-Vsxmd-Units-ExampleUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [ExampleUnit](/Vsxmd.Units.ExampleUnit.md/#T-Vsxmd-Units-ExampleUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The example XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `example`.

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) method

Convert the example XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The example XML element.

#### Returns





The generated Markdown.
