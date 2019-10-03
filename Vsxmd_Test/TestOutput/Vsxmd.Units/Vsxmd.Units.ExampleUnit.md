<a name='T-Vsxmd-Units-ExampleUnit'></a>
## ExampleUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Example unit.

<a name='M-Vsxmd-Units-ExampleUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ExampleUnit](/Vsxmd-Units/Vsxmd-Units-ExampleUnit.md/#T-Vsxmd-Units-ExampleUnit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The example XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException) | Throw if XML element name is not `example`. |

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the example XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The example XML element. |
