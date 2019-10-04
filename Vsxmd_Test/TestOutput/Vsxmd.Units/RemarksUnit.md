<a name='T-Vsxmd-Units-RemarksUnit'></a>
## RemarksUnit `type`

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Remarks unit.

<a name='M-Vsxmd-Units-RemarksUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

Initializes a new instance of the [RemarksUnit](/Vsxmd.Units/RemarksUnit.md/#T-Vsxmd-Units-RemarksUnit) class.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The remarks XML element.

#### Exceptions

`[System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException)`  

Throw if XML element name is not `remarks`.

<a name='M-Vsxmd-Units-RemarksUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

<a name='M-Vsxmd-Units-RemarksUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) `method`

Convert the remarks XML element to Markdown safely.
If element is `null`, return empty string.

#### Returns





The generated Markdown.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The remarks XML element.
