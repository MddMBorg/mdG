<a name='M-Vsxmd-Units-MemberName-ToReferenceLink-Vsxmd-Units-MemberName,System-Boolean,System-String-'></a>
# ToReferenceLink(sourceMember,useShortName,alternateName) Method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the member name to Markdown reference link.

If then name is under `System` namespace, the link points to MSDN.

Otherwise, the link points to this page anchor.

#### Parameters

`sourceMember`  [MemberName](./../MemberName.md)  

Originating member to begin relative reference from e.g. another namespace, class or member type.

`useShortName`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Indicate if use short type name.

`alternateName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

An override to use for instance when using see tags for the link description.

#### Returns





The generated Markdown reference link.
