<a name='T-Vsxmd-Units-MemberName'></a>
# MemberName type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Member name.

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String,System-Collections-Generic-IEnumerable{System-String}-'></a>
### #ctor(name,paramNames) constructor

Initializes a new instance of the [MemberName](/Vsxmd.Units/MemberName.md/#T-Vsxmd-Units-MemberName) class.

#### Parameters

`name`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The raw member name. For example, `T:Vsxmd.Units.MemberName`.

`paramNames`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The parameter names. It is only used when member kind is [Constructor](/Vsxmd.Units/MemberKind.md/#F-Vsxmd-Units-MemberKind-Constructor) or [Method](/Vsxmd.Units/MemberKind.md/#F-Vsxmd-Units-MemberKind-Method).

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String-'></a>
### #ctor(name) constructor

Initializes a new instance of the [MemberName](/Vsxmd.Units/MemberName.md/#T-Vsxmd-Units-MemberName) class.

#### Parameters

`name`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The raw member name. For example, `T:Vsxmd.Units.MemberName`.

<a name='P-Vsxmd-Units-MemberName-Caption'></a>
### Caption property

Gets the caption representation for this member name.

# Examples

For [Type](/Vsxmd.Units/MemberKind.md/#F-Vsxmd-Units-MemberKind-Type), show as `## Vsxmd.Units.MemberName [#](#here) [^](#contents)`.

For other kinds, show as `### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)`.

<a name='P-Vsxmd-Units-MemberName-Kind'></a>
### Kind property

Gets the member kind, one of [MemberKind](/Vsxmd.Units/MemberKind.md/#T-Vsxmd-Units-MemberKind).

<a name='P-Vsxmd-Units-MemberName-Link'></a>
### Link property

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberName-Namespace'></a>
### Namespace property

Gets the namespace name.

# Examples

`System`, `Vsxmd`, `Vsxmd.Units`.

<a name='P-Vsxmd-Units-MemberName-TypeName'></a>
### TypeName property

Gets the type name.

# Examples

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberName-CompareTo-Vsxmd-Units-MemberName-'></a>
### CompareTo() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-MemberName-GetParamTypes'></a>
### GetParamTypes() method

Gets the method parameter type names from the member name.

#### Returns





The method parameter type name list.

# Examples

It will prepend the type kind character (`T:`) to the type string.

For `(System.String,System.Int32)`, returns `["T:System.String","T:System.Int32"]`.

It also handle generic type.

For `(System.Collections.Generic.IEnumerable{System.String})`, returns `["T:System.Collections.Generic.IEnumerable{System.String}"]`.

<a name='M-Vsxmd-Units-MemberName-ToReferenceLink-System-Boolean-'></a>
### ToReferenceLink(useShortName) method

Convert the member name to Markdown reference link.

If then name is under `System` namespace, the link points to MSDN.

Otherwise, the link points to this page anchor.

#### Parameters

`useShortName`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Indicate if use short type name.

#### Returns





The generated Markdown reference link.
