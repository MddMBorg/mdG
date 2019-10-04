<a name='T-Vsxmd-Units-BaseUnit'></a>
## BaseUnit `type`

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

The base unit.

<a name='M-Vsxmd-Units-BaseUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
### #ctor(element,elementName) `constructor`

Initializes a new instance of the [BaseUnit](/Vsxmd.Units/BaseUnit.md/#T-Vsxmd-Units-BaseUnit) class.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The XML element.

`elementName`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The expected XML element name.

#### Exceptions

`[System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException)`  

Throw if XML `element` name not matches the expected `elementName`.

<a name='P-Vsxmd-Units-BaseUnit-Element'></a>
### Element `property`

Gets the XML element.

<a name='P-Vsxmd-Units-BaseUnit-ElementContent'></a>
### ElementContent `property`

Gets the Markdown content representing the element.

<a name='M-Vsxmd-Units-BaseUnit-GetAttribute-System-Xml-Linq-XName-'></a>
### GetAttribute(name) `method`

Returns the [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute) value of this [XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) that has the specified `name`.

#### Returns

[XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute)



An [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute) value that has the specified `name`; `null` if there is no attribute with the specified `name`.

#### Parameters

`name`  [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName)  

The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName) of the [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute) to get.

<a name='M-Vsxmd-Units-BaseUnit-GetChild-System-Xml-Linq-XName-'></a>
### GetChild(name) `method`

Gets the first (in document order) child element with the specified `name`.

#### Returns

[XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName)



A [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName) that matches the specified `name`, or `null`.

#### Parameters

`name`  [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName)  

The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName) to match.

<a name='M-Vsxmd-Units-BaseUnit-GetChildren-System-Xml-Linq-XName-'></a>
### GetChildren(name) `method`

Returns a collection of the child elements of this element or document, in document order.
Only elements that have a matching [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName) are included in the collection.

#### Returns

[IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1)



An [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1) of [XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) containing the children that have a matching [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName), in document order.

#### Parameters

`name`  [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName)  

The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName) to match.

<a name='M-Vsxmd-Units-BaseUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*
