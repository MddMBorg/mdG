<a name='T-Vsxmd-Units-MemberUnit'></a>
# MemberUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Member unit.

<a name='M-Vsxmd-Units-MemberUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [MemberUnit](/Vsxmd.Units.MemberUnit.md/#T-Vsxmd-Units-MemberUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The member XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `member`.

<a name='P-Vsxmd-Units-MemberUnit-Comparer'></a>
### Comparer property

Gets the member unit comparer.

<a name='P-Vsxmd-Units-MemberUnit-Kind'></a>
### Kind property

Gets the member kind, one of [MemberKind](/Vsxmd.Units.MemberKind.md/#T-Vsxmd-Units-MemberKind).

<a name='P-Vsxmd-Units-MemberUnit-Link'></a>
### Link property

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberUnit-TypeName'></a>
### TypeName property

Gets the type name.

# Examples

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberUnit-ComplementType-System-Collections-Generic-IEnumerable{Vsxmd-Units-MemberUnit}-'></a>
### ComplementType(group) method

Complement a type unit if the member unit `group` does not have one.
One member unit group has the same [TypeName](/Vsxmd.Units.MemberUnit.md/#P-Vsxmd-Units-MemberUnit-TypeName).

#### Parameters

`group`  [MemberUnit}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The member unit group.

#### Returns





The complemented member unit group.

<a name='M-Vsxmd-Units-MemberUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*
