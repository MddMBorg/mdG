<a name='T-Vsxmd-Units-ReturnsUnit'></a>
## ReturnsUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Returns unit.

<a name='M-Vsxmd-Units-ReturnsUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ReturnsUnit](#T-Vsxmd-Units-ReturnsUnit 'Vsxmd.Units.ReturnsUnit') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The returns XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `returns`. |

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the returns XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The returns XML element. |
