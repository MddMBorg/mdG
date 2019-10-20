<a name='M-Vsxmd-Units-Extensions-ToReferenceLink-System-String,Vsxmd-Units-MemberName,System-Boolean,System-String-'></a>
# ToReferenceLink(memberName,sourceMember,useShortName,alternateName) Method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Generate the reference link for the `memberName`.

#### Parameters

`memberName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The member name.

`sourceMember`  [MemberName](./../../MemberName/MemberName.md)  

Source member to begin relative uri from.

`useShortName`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Indicate if use short type name.

`alternateName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

An override to use when generating the link description.

#### Returns





The generated reference link.

# Examples

For `T:Vsxmd.Units.MemberUnit`, convert it to `[MemberUnit](#T-Vsxmd.Units.MemberUnit)`.

For `T:System.ArgumentException`, convert it to `[ArgumentException](http://msdn/path/to/System.ArgumentException)`.
