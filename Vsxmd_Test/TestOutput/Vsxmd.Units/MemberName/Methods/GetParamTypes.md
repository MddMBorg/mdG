<a name='M-Vsxmd-Units-MemberName-GetParamTypes'></a>
# GetParamTypes() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the method parameter type names from the member name.

#### Returns





The method parameter type name list.

# Examples

It will prepend the type kind character (`T:`) to the type string.

For `(System.String,System.Int32)`, returns `["T:System.String","T:System.Int32"]`.

It also handle generic type.

For `(System.Collections.Generic.IEnumerable{System.String})`, returns `["T:System.Collections.Generic.IEnumerable{System.String}"]`.
