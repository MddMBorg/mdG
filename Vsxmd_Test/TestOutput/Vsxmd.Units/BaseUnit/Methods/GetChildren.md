<a name='M-Vsxmd-Units-BaseUnit-GetChildren-System-Xml-Linq-XName-'></a>
# GetChildren(name) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Returns a collection of the child elements of this element or document, in document order.
Only elements that have a matching [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) are included in the collection.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) to match.

#### Returns

[IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1)



An [IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1) of [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement) containing the children that have a matching [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName), in document order.
