<a name='T-Vsxmd-Units-SeealsoUnit'></a>
## SeealsoUnit `type`

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Seealso unit.

<a name='M-Vsxmd-Units-SeealsoUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

Initializes a new instance of the [SeealsoUnit](/Vsxmd.Units.SeealsoUnit.md/#T-Vsxmd-Units-SeealsoUnit) class.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The seealso XML element.

#### Exceptions

`[System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException)`  

Throw if XML element name is not `seealso`.

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) `method`

Convert the seealso XML element to Markdown safely.
If element is `null`, return empty string.

#### Returns





The generated Markdown.

#### Parameters

`elements`  [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable)  

The seealso XML element list.
