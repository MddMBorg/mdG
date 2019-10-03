<a name='T-Vsxmd-Units-ParamUnit'></a>
## ParamUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Param unit.

<a name='M-Vsxmd-Units-ParamUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
### #ctor(element,paramType) `constructor`

##### Summary

Initializes a new instance of the [ParamUnit](/Vsxmd-Units/Vsxmd-Units-ParamUnit.md/#T-Vsxmd-Units-ParamUnit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The param XML element. |
| paramType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String) | The parameter type corresponding to the param XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException) | Throw if XML element name is not `param`. |

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberKind-'></a>
### ToMarkdown(elements,paramTypes,memberKind) `method`

##### Summary

Convert the param XML element to Markdown safely.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable) | The param XML element list. |
| paramTypes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable) | The paramater type names. |
| memberKind | [Vsxmd.Units.MemberKind](/Vsxmd-Units/Vsxmd-Units-MemberKind.md/#T-Vsxmd-Units-MemberKind) | The member kind of the parent element. |

##### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [Constructor](/Vsxmd-Units/Vsxmd-Units-MemberKind.md/#F-Vsxmd-Units-MemberKind-Constructor) or [Method](/Vsxmd-Units/Vsxmd-Units-MemberKind.md/#F-Vsxmd-Units-MemberKind-Method), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.
