<a name='T-Vsxmd-Units-PermissionUnit'></a>
# PermissionUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Permission unit.

<a name='M-Vsxmd-Units-PermissionUnit-#ctor-System-Xml-Linq-XElement-'></a>
### #ctor(element) constructor

Initializes a new instance of the [PermissionUnit](/Vsxmd.Units.PermissionUnit.md/#T-Vsxmd-Units-PermissionUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The permission XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `permission`.

<a name='M-Vsxmd-Units-PermissionUnit-ToMarkdown'></a>
### ToMarkdown() method

*Inherited from parent.*

<a name='M-Vsxmd-Units-PermissionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
### ToMarkdown(elements) method

Convert the permission XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The permission XML element list.

#### Returns





The generated Markdown.
