<a name='T-Vsxmd-Units-TypeparamUnit'></a>
## TypeparamUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Typeparam unit.

<a name='M-Vsxmd-Units-TypeparamUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [TypeparamUnit](/Vsxmd-Units-TypeparamUnit.md/#T-Vsxmd-Units-TypeparamUnit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The typeparam XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException) | Throw if XML element name is not `typeparam`. |

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the param XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable) | The param XML element list. |
