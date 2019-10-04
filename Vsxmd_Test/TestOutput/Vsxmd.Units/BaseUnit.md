<a name='T-Vsxmd-Units-BaseUnit'></a>
# BaseUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

The base unit.

<a name='M-Vsxmd-Units-BaseUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
### #ctor(element,elementName) constructor

Initializes a new instance of the [BaseUnit](/Vsxmd.Units/BaseUnit.md/#T-Vsxmd-Units-BaseUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The XML element.

`elementName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The expected XML element name.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML `element` name not matches the expected `elementName`.

<a name='P-Vsxmd-Units-BaseUnit-Element'></a>
### Element property

Gets the XML element.

<a name='P-Vsxmd-Units-BaseUnit-ElementContent'></a>
### ElementContent property

Gets the Markdown content representing the element.

<a name='M-Vsxmd-Units-BaseUnit-GetAttribute-System-Xml-Linq-XName-'></a>
### GetAttribute(name) method

Returns the [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) value of this [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement) that has the specified `name`.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) of the [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) to get.

#### Returns

[XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute)



An [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) value that has the specified `name`; `null` if there is no attribute with the specified `name`.

<a name='M-Vsxmd-Units-BaseUnit-GetChild-System-Xml-Linq-XName-'></a>
### GetChild(name) method

Gets the first (in document order) child element with the specified `name`.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) to match.

#### Returns

[XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)



A [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) that matches the specified `name`, or `null`.

<a name='M-Vsxmd-Units-BaseUnit-GetChildren-System-Xml-Linq-XName-'></a>
### GetChildren(name) method

Returns a collection of the child elements of this element or document, in document order.
Only elements that have a matching [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) are included in the collection.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) to match.

#### Returns

[IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1)



An [IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1) of [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement) containing the children that have a matching [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName), in document order.

<a name='M-Vsxmd-Units-BaseUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*
