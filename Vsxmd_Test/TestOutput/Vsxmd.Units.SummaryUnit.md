<a name='T-Vsxmd-Units-SummaryUnit'></a>
## SummaryUnit `type`

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Summary unit.

<a name='M-Vsxmd-Units-SummaryUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

Initializes a new instance of the [SummaryUnit](/Vsxmd.Units.SummaryUnit.md/#T-Vsxmd-Units-SummaryUnit) class.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The summary XML element.

#### Exceptions

`[System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException)`  

Throw if XML element name is not `summary`.

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) `method`

Convert the summary XML element to Markdown safely.
If element is `null`, return empty string.

#### Returns





The generated Markdown.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The summary XML element.
