<a name='M-Vsxmd-Units-Extensions-ToMarkdownText-System-Xml-Linq-XElement-'></a>
# ToMarkdownText(element) Method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the inline XML nodes to Markdown text.
For example, it works for `summary` and `returns` elements.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The XML element.

#### Returns





The generated Markdown content.

# Examples

This method converts the following `summary` element.

```
<summary>The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="M:Vsxmd.Units.Extensions.ToMarkdownText(System.Xml.Linq.XElement)" />.</summary>
```

To the below Markdown content.

```
The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
```
