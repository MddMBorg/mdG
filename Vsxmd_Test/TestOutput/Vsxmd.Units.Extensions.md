<a name='T-Vsxmd-Units-Extensions'></a>
## Extensions `type`

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Extensions helper.

<a name='M-Vsxmd-Units-Extensions-AsCode-System-String-'></a>
### AsCode(code) `method`

Wrap the `code` into Markdown backtick safely.

The backtick characters inside the `code` reverse as it is.

#### Returns





The Markdown code span.

#### Parameters

`code`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The code span.

#### Remarks

Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code .

<a name='M-Vsxmd-Units-Extensions-Escape-System-String-'></a>
### Escape(content) `method`

Escape the content to keep it raw in Markdown syntax.

#### Returns





The escaped content.

#### Parameters

`content`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The content.

<a name='M-Vsxmd-Units-Extensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-'></a>
### Join(value,separator) `method`

Concatenates the `value`s with the `separator`.

#### Returns





The concatenated string.

#### Parameters

`value`  [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable)  

The string values.

`separator`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The separator.

<a name='M-Vsxmd-Units-Extensions-NthLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
### NthLast\`\`1(source,index) `method`

Gets the n-th last element from the `source`.

#### Returns





The element at the specified position in the `source` sequence.

#### Parameters

`source`  [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable)  

The source enumerable.

`index`  [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32)  

The index for the n-th last.

#### Type Parameters

`TSource`  

The type of the elements of `source`.

<a name='M-Vsxmd-Units-Extensions-Suffix-System-String,System-String-'></a>
### Suffix(value,suffix) `method`

Suffix the `suffix` to the `value`, and generate a new string.

#### Returns





The new string.

#### Parameters

`value`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The original string value.

`suffix`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The suffix string.

<a name='M-Vsxmd-Units-Extensions-TakeAllButLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
### TakeAllButLast\`\`1(source,count) `method`

Take all element except the last `count`.

#### Returns





The generated enumerable.

#### Parameters

`source`  [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable)  

The source enumerable.

`count`  [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32)  

The number to except.

#### Type Parameters

`TSource`  

The type of the elements of `source`.

<a name='M-Vsxmd-Units-Extensions-ToAnchor-System-String-'></a>
### ToAnchor(href) `method`

Generate an anchor for the `href`.

#### Returns





The anchor for the `href`.

#### Parameters

`href`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The href.

<a name='M-Vsxmd-Units-Extensions-ToHereLink-System-String-'></a>
### ToHereLink(href) `method`

Generate "to here" link for the `href`.

#### Returns





The "to here" link for the `href`.

#### Parameters

`href`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The href.

<a name='M-Vsxmd-Units-Extensions-ToLowerString-Vsxmd-Units-MemberKind-'></a>
### ToLowerString(memberKind) `method`

Convert the [MemberKind](/Vsxmd.Units.MemberKind.md/#T-Vsxmd-Units-MemberKind) to its lowercase name.

#### Returns





The member kind's lowercase name.

#### Parameters

`memberKind`  [Vsxmd.Units.MemberKind](/Vsxmd.Units.MemberKind.md/#T-Vsxmd-Units-MemberKind)  

The member kind.

<a name='M-Vsxmd-Units-Extensions-ToMarkdownText-System-Xml-Linq-XElement-'></a>
### ToMarkdownText(element) `method`

Convert the inline XML nodes to Markdown text.
For example, it works for `summary` and `returns` elements.

#### Returns





The generated Markdown content.

#### Parameters

`element`  [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement)  

The XML element.

# Examples

This method converts the following `summary` element.

```
<summary>The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="M:Vsxmd.Units.Extensions.ToMarkdownText(System.Xml.Linq.XElement)" />.</summary>
```

To the below Markdown content.

```
The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
```

<a name='M-Vsxmd-Units-Extensions-ToReferenceLink-System-String,System-Boolean-'></a>
### ToReferenceLink(memberName,useShortName) `method`

Generate the reference link for the `memberName`.

#### Returns





The generated reference link.

#### Parameters

`memberName`  [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)  

The member name.

`useShortName`  [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean)  

Indicate if use short type name.

# Examples

For `T:Vsxmd.Units.MemberUnit`, convert it to `[MemberUnit](#T-Vsxmd.Units.MemberUnit)`.

For `T:System.ArgumentException`, convert it to `[ArgumentException](http://msdn/path/to/System.ArgumentException)`.
