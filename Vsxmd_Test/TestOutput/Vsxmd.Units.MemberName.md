<a name='T-Vsxmd-Units-MemberName'></a>
## MemberName `type`

##### Namespace

Vsxmd.Units

##### Summary

Member name.

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String,System-Collections-Generic-IEnumerable{System-String}-'></a>
### #ctor(name,paramNames) `constructor`

##### Summary

Initializes a new instance of the [MemberName](#T-Vsxmd-Units-MemberName 'Vsxmd.Units.MemberName') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw member name. For example, `T:Vsxmd.Units.MemberName`. |
| paramNames | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | The parameter names. It is only used when member kind is [Constructor](#F-Vsxmd-Units-MemberKind-Constructor 'Vsxmd.Units.MemberKind.Constructor') or [Method](#F-Vsxmd-Units-MemberKind-Method 'Vsxmd.Units.MemberKind.Method'). |

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Initializes a new instance of the [MemberName](#T-Vsxmd-Units-MemberName 'Vsxmd.Units.MemberName') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw member name. For example, `T:Vsxmd.Units.MemberName`. |

<a name='P-Vsxmd-Units-MemberName-Caption'></a>
### Caption `property`

##### Summary

Gets the caption representation for this member name.

##### Example

For [Type](#F-Vsxmd-Units-MemberKind-Type 'Vsxmd.Units.MemberKind.Type'), show as `## Vsxmd.Units.MemberName [#](#here) [^](#contents)`.

For other kinds, show as `### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)`.

<a name='P-Vsxmd-Units-MemberName-Kind'></a>
### Kind `property`

##### Summary

Gets the member kind, one of [MemberKind](#T-Vsxmd-Units-MemberKind 'Vsxmd.Units.MemberKind').

<a name='P-Vsxmd-Units-MemberName-Link'></a>
### Link `property`

##### Summary

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberName-Namespace'></a>
### Namespace `property`

##### Summary

Gets the namespace name.

##### Example

`System`, `Vsxmd`, `Vsxmd.Units`.

<a name='P-Vsxmd-Units-MemberName-TypeName'></a>
### TypeName `property`

##### Summary

Gets the type name.

##### Example

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberName-CompareTo-Vsxmd-Units-MemberName-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Units-MemberName-GetParamTypes'></a>
### GetParamTypes() `method`

##### Summary

Gets the method parameter type names from the member name.

##### Returns

The method parameter type name list.

##### Parameters

This method has no parameters.

##### Example

It will prepend the type kind character (`T:`) to the type string.

For `(System.String,System.Int32)`, returns `["T:System.String","T:System.Int32"]`.

It also handle generic type.

For `(System.Collections.Generic.IEnumerable{System.String})`, returns `["T:System.Collections.Generic.IEnumerable{System.String}"]`.

<a name='M-Vsxmd-Units-MemberName-ToReferenceLink-System-Boolean-'></a>
### ToReferenceLink(useShortName) `method`

##### Summary

Convert the member name to Markdown reference link.

If then name is under `System` namespace, the link points to MSDN.

Otherwise, the link points to this page anchor.

##### Returns

The generated Markdown reference link.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| useShortName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicate if use short type name. |
