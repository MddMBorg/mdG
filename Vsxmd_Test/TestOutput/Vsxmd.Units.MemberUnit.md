<a name='T-Vsxmd-Units-MemberUnit'></a>
## MemberUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Member unit.

<a name='M-Vsxmd-Units-MemberUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [MemberUnit](./Vsxmd.Units.MemberUnit.md/#T-Vsxmd-Units-MemberUnit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement) | The member XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException) | Throw if XML element name is not `member`. |

<a name='P-Vsxmd-Units-MemberUnit-Comparer'></a>
### Comparer `property`

##### Summary

Gets the member unit comparer.

<a name='P-Vsxmd-Units-MemberUnit-Kind'></a>
### Kind `property`

##### Summary

Gets the member kind, one of [MemberKind](./Vsxmd.Units.MemberKind.md/#T-Vsxmd-Units-MemberKind).

<a name='P-Vsxmd-Units-MemberUnit-Link'></a>
### Link `property`

##### Summary

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberUnit-TypeName'></a>
### TypeName `property`

##### Summary

Gets the type name.

##### Example

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberUnit-ComplementType-System-Collections-Generic-IEnumerable{Vsxmd-Units-MemberUnit}-'></a>
### ComplementType(group) `method`

##### Summary

Complement a type unit if the member unit `group` does not have one.
One member unit group has the same [TypeName](./Vsxmd.Units.MemberUnit.md/#P-Vsxmd-Units-MemberUnit-TypeName).

##### Returns

The complemented member unit group.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| group | [System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable) | The member unit group. |

<a name='M-Vsxmd-Units-MemberUnit-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
