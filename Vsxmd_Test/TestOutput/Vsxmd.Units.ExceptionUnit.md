<a name='T-Vsxmd-Units-ExceptionUnit'></a>
## ExceptionUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Exception unit.

<a name='M-Vsxmd-Units-ExceptionUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ExceptionUnit](/Vsxmd-Units-ExceptionUnit.md/#T-Vsxmd-Units-ExceptionUnit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The exception XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException) | Throw if XML element name is not `exception`. |

<a name='M-Vsxmd-Units-ExceptionUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-ExceptionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the exception XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable) | The exception XML element list. |
