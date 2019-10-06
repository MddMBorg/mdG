<a name='assembly'></a>
# Vsxmd

# Contents

- [AssemblyUnit](#T-Vsxmd-Units-AssemblyUnit)
  - [#ctor(element)](#M-Vsxmd-Units-AssemblyUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-AssemblyUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
- [BaseUnit](#T-Vsxmd-Units-BaseUnit)
  - [#ctor(element, elementName)](#M-Vsxmd-Units-BaseUnit-#ctor-System-Xml-Linq-XElement,System-String-)
  - [Element](#P-Vsxmd-Units-BaseUnit-Element)
  - [ElementContent](#P-Vsxmd-Units-BaseUnit-ElementContent)
  - [GetAttribute(name)](#M-Vsxmd-Units-BaseUnit-GetAttribute-System-Xml-Linq-XName-)
  - [GetChild(name)](#M-Vsxmd-Units-BaseUnit-GetChild-System-Xml-Linq-XName-)
  - [GetChildren(name)](#M-Vsxmd-Units-BaseUnit-GetChildren-System-Xml-Linq-XName-)
  - [ToMarkdown()](#M-Vsxmd-Units-BaseUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
- [Converter](#T-Vsxmd-Converter)
  - [#ctor(document)](#M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument-)
  - [ToMarkdown()](#M-Vsxmd-Converter-ToMarkdown)
- [ExampleUnit](#T-Vsxmd-Units-ExampleUnit)
  - [#ctor(element)](#M-Vsxmd-Units-ExampleUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-ExampleUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(element)](#M-Vsxmd-Units-ExampleUnit-ToMarkdown-System-Xml-Linq-XElement-)
- [ExceptionUnit](#T-Vsxmd-Units-ExceptionUnit)
  - [#ctor(element)](#M-Vsxmd-Units-ExceptionUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-ExceptionUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(elements)](#M-Vsxmd-Units-ExceptionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-)
- [Extensions](#T-Vsxmd-Units-Extensions)
  - [AsCode(code)](#M-Vsxmd-Units-Extensions-AsCode-System-String-)
  - [Escape(content)](#M-Vsxmd-Units-Extensions-Escape-System-String-)
  - [GetAssemblyName(xElement)](#M-Vsxmd-Units-Extensions-GetAssemblyName-System-Xml-Linq-XElement-)
  - [Join(value, separator)](#M-Vsxmd-Units-Extensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-)
  - [NthLast\`\`1(source, index)](#M-Vsxmd-Units-Extensions-NthLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-)
  - [Suffix(value, suffix)](#M-Vsxmd-Units-Extensions-Suffix-System-String,System-String-)
  - [TakeAllButLast\`\`1(source, count)](#M-Vsxmd-Units-Extensions-TakeAllButLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-)
  - [ToAnchor(href)](#M-Vsxmd-Units-Extensions-ToAnchor-System-String-)
  - [ToHereLink(href)](#M-Vsxmd-Units-Extensions-ToHereLink-System-String-)
  - [ToLowerString(memberKind)](#M-Vsxmd-Units-Extensions-ToLowerString-Vsxmd-Units-MemberKind-)
  - [ToMarkdownRef(href)](#M-Vsxmd-Units-Extensions-ToMarkdownRef-System-String-)
  - [ToMarkdownText(element)](#M-Vsxmd-Units-Extensions-ToMarkdownText-System-Xml-Linq-XElement-)
  - [ToReferenceLink(memberName, useShortName)](#M-Vsxmd-Units-Extensions-ToReferenceLink-System-String,System-Boolean-)
- [FormatKind](#T-Vsxmd-Units-FormatKind)
- [IConverter](#T-Vsxmd-IConverter)
  - [ToMarkdown()](#M-Vsxmd-IConverter-ToMarkdown)
- [IUnit](#T-Vsxmd-Units-IUnit)
  - [ToMarkdown()](#M-Vsxmd-Units-IUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
- [MarkdownWriter](#T-Vsxmd-MarkdownWriter)
  - [#ctor(document, outputPath)](#M-Vsxmd-MarkdownWriter-#ctor-System-Xml-Linq-XDocument,System-String-)
  - [WriteMultipleFiles(useSubDirectories)](#M-Vsxmd-MarkdownWriter-WriteMultipleFiles-System-Boolean-)
  - [WriteSingleFile()](#M-Vsxmd-MarkdownWriter-WriteSingleFile)
- [MemberKind](#T-Vsxmd-Units-MemberKind)
  - [Constants](#F-Vsxmd-Units-MemberKind-Constants)
  - [Constructor](#F-Vsxmd-Units-MemberKind-Constructor)
  - [Method](#F-Vsxmd-Units-MemberKind-Method)
  - [NotSupported](#F-Vsxmd-Units-MemberKind-NotSupported)
  - [Property](#F-Vsxmd-Units-MemberKind-Property)
  - [Type](#F-Vsxmd-Units-MemberKind-Type)
- [MemberName](#T-Vsxmd-Units-MemberName)
  - [#ctor(name, paramNames)](#M-Vsxmd-Units-MemberName-#ctor-System-String,System-Collections-Generic-IEnumerable{System-String}-)
  - [#ctor(name)](#M-Vsxmd-Units-MemberName-#ctor-System-String-)
  - [Caption](#P-Vsxmd-Units-MemberName-Caption)
  - [Kind](#P-Vsxmd-Units-MemberName-Kind)
  - [Link](#P-Vsxmd-Units-MemberName-Link)
  - [Namespace](#P-Vsxmd-Units-MemberName-Namespace)
  - [TypeName](#P-Vsxmd-Units-MemberName-TypeName)
  - [CompareTo()](#M-Vsxmd-Units-MemberName-CompareTo-Vsxmd-Units-MemberName-)
  - [GetParamTypes()](#M-Vsxmd-Units-MemberName-GetParamTypes)
  - [ToReferenceLink(useShortName)](#M-Vsxmd-Units-MemberName-ToReferenceLink-System-Boolean-)
- [MemberUnit](#T-Vsxmd-Units-MemberUnit)
  - [#ctor(element)](#M-Vsxmd-Units-MemberUnit-#ctor-System-Xml-Linq-XElement-)
  - [Comparer](#P-Vsxmd-Units-MemberUnit-Comparer)
  - [Kind](#P-Vsxmd-Units-MemberUnit-Kind)
  - [Link](#P-Vsxmd-Units-MemberUnit-Link)
  - [TypeName](#P-Vsxmd-Units-MemberUnit-TypeName)
  - [ComplementType(group)](#M-Vsxmd-Units-MemberUnit-ComplementType-System-Collections-Generic-IEnumerable{Vsxmd-Units-MemberUnit}-)
  - [ToMarkdown()](#M-Vsxmd-Units-MemberUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
- [MemberUnitComparer](#T-Vsxmd-Units-MemberUnit-MemberUnitComparer)
  - [Compare()](#M-Vsxmd-Units-MemberUnit-MemberUnitComparer-Compare-Vsxmd-Units-MemberUnit,Vsxmd-Units-MemberUnit-)
- [PageFormatter](#T-Vsxmd-PageFormatter)
  - [test](#F-Vsxmd-PageFormatter-test)
  - [GetUnits(units)](#M-Vsxmd-PageFormatter-GetUnits-System-Collections-Generic-IEnumerable{Vsxmd-Units-BaseUnit}-)
- [ParamUnit](#T-Vsxmd-Units-ParamUnit)
  - [#ctor(element, paramType)](#M-Vsxmd-Units-ParamUnit-#ctor-System-Xml-Linq-XElement,System-String-)
  - [ToMarkdown()](#M-Vsxmd-Units-ParamUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(elements, paramTypes, memberKind)](#M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberKind-)
- [PermissionUnit](#T-Vsxmd-Units-PermissionUnit)
  - [#ctor(element)](#M-Vsxmd-Units-PermissionUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-PermissionUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(elements)](#M-Vsxmd-Units-PermissionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-)
- [Program](#T-Vsxmd-Program)
  - [Main(args)](#M-Vsxmd-Program-Main-System-String[]-)
- [RemarksUnit](#T-Vsxmd-Units-RemarksUnit)
  - [#ctor(element)](#M-Vsxmd-Units-RemarksUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-RemarksUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(element)](#M-Vsxmd-Units-RemarksUnit-ToMarkdown-System-Xml-Linq-XElement-)
- [ReturnsUnit](#T-Vsxmd-Units-ReturnsUnit)
  - [#ctor(element)](#M-Vsxmd-Units-ReturnsUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-ReturnsUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(element)](#M-Vsxmd-Units-ReturnsUnit-ToMarkdown-System-Xml-Linq-XElement-)
- [SeealsoUnit](#T-Vsxmd-Units-SeealsoUnit)
  - [#ctor(element)](#M-Vsxmd-Units-SeealsoUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-SeealsoUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(elements)](#M-Vsxmd-Units-SeealsoUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-)
- [SummaryUnit](#T-Vsxmd-Units-SummaryUnit)
  - [#ctor(element)](#M-Vsxmd-Units-SummaryUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-SummaryUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(element)](#M-Vsxmd-Units-SummaryUnit-ToMarkdown-System-Xml-Linq-XElement-)
- [TableOfContents](#T-Vsxmd-TableOfContents)
  - [#ctor(memberUnits)](#M-Vsxmd-TableOfContents-#ctor-System-Linq-IOrderedEnumerable{Vsxmd-Units-MemberUnit}-)
  - [Link](#P-Vsxmd-TableOfContents-Link)
  - [ToMarkdown()](#M-Vsxmd-TableOfContents-ToMarkdown-Vsxmd-Units-FormatKind-)
- [Test](#T-Vsxmd-Program-Test)
  - [#ctor()](#M-Vsxmd-Program-Test-#ctor)
  - [TestBacktickInSummary()](#M-Vsxmd-Program-Test-TestBacktickInSummary)
  - [TestGenericException()](#M-Vsxmd-Program-Test-TestGenericException)
  - [TestGenericParameter\`\`2(expression)](#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-)
  - [TestGenericPermission()](#M-Vsxmd-Program-Test-TestGenericPermission)
  - [TestGenericReference()](#M-Vsxmd-Program-Test-TestGenericReference)
  - [TestParamWithoutDescription(p)](#M-Vsxmd-Program-Test-TestParamWithoutDescription-System-String-)
  - [TestSeeLangword()](#M-Vsxmd-Program-Test-TestSeeLangword)
  - [TestSpaceAfterInlineElements\`\`1()](#M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-)
- [TestGenericType\`2](#T-Vsxmd-Program-TestGenericType`2)
  - [TestGenericMethod\`\`2()](#M-Vsxmd-Program-TestGenericType`2-TestGenericMethod``2)
- [TypeparamUnit](#T-Vsxmd-Units-TypeparamUnit)
  - [#ctor(element)](#M-Vsxmd-Units-TypeparamUnit-#ctor-System-Xml-Linq-XElement-)
  - [ToMarkdown()](#M-Vsxmd-Units-TypeparamUnit-ToMarkdown-Vsxmd-Units-FormatKind-)
  - [ToMarkdown(elements)](#M-Vsxmd-Units-TypeparamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-)

<a name='T-Vsxmd-Units-AssemblyUnit'></a>
# AssemblyUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Assembly unit.

<a name='M-Vsxmd-Units-AssemblyUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [AssemblyUnit](#T-Vsxmd-Units-AssemblyUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The assembly XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `assembly`.

<a name='M-Vsxmd-Units-AssemblyUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='T-Vsxmd-Units-BaseUnit'></a>
# BaseUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

The base unit.

<a name='M-Vsxmd-Units-BaseUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
# #ctor(element,elementName) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [BaseUnit](#T-Vsxmd-Units-BaseUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The XML element.

`elementName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The expected XML element name.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML `element` name not matches the expected `elementName`.

<a name='P-Vsxmd-Units-BaseUnit-Element'></a>
# Element property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the XML element.

<a name='P-Vsxmd-Units-BaseUnit-ElementContent'></a>
# ElementContent property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the Markdown content representing the element.

<a name='M-Vsxmd-Units-BaseUnit-GetAttribute-System-Xml-Linq-XName-'></a>
# GetAttribute(name) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Returns the [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) value of this [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement) that has the specified `name`.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) of the [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) to get.

#### Returns

[XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute)



An [XAttribute](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XAttribute) value that has the specified `name`; `null` if there is no attribute with the specified `name`.

<a name='M-Vsxmd-Units-BaseUnit-GetChild-System-Xml-Linq-XName-'></a>
# GetChild(name) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the first (in document order) child element with the specified `name`.

#### Parameters

`name`  [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)  

The [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) to match.

#### Returns

[XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName)



A [XName](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XName) that matches the specified `name`, or `null`.

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

<a name='M-Vsxmd-Units-BaseUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='T-Vsxmd-Converter'></a>
# Converter type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument-'></a>
# #ctor(document) constructor

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Initializes a new instance of the [Converter](#T-Vsxmd-Converter) class.

#### Parameters

`document`  [XDocument](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XDocument)  

The XML document.

<a name='M-Vsxmd-Converter-ToMarkdown'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='T-Vsxmd-Units-ExampleUnit'></a>
# ExampleUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Example unit.

<a name='M-Vsxmd-Units-ExampleUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [ExampleUnit](#T-Vsxmd-Units-ExampleUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The example XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `example`.

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-ExampleUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
# ToMarkdown(element) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the example XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The example XML element.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Units-ExceptionUnit'></a>
# ExceptionUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Exception unit.

<a name='M-Vsxmd-Units-ExceptionUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [ExceptionUnit](#T-Vsxmd-Units-ExceptionUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The exception XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `exception`.

<a name='M-Vsxmd-Units-ExceptionUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-ExceptionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
# ToMarkdown(elements) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the exception XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The exception XML element list.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Units-Extensions'></a>
# Extensions type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Extensions helper.

<a name='M-Vsxmd-Units-Extensions-AsCode-System-String-'></a>
# AsCode(code) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Wrap the `code` into Markdown backtick safely.

The backtick characters inside the `code` reverse as it is.

#### Parameters

`code`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The code span.

#### Returns





The Markdown code span.

#### Remarks

Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code .

<a name='M-Vsxmd-Units-Extensions-Escape-System-String-'></a>
# Escape(content) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Escape the content to keep it raw in Markdown syntax.

#### Parameters

`content`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The content.

#### Returns





The escaped content.

<a name='M-Vsxmd-Units-Extensions-GetAssemblyName-System-Xml-Linq-XElement-'></a>
# GetAssemblyName(xElement) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Probably a lazy way to do this and more implementation should be moved to AssemblyUnit class

#### Parameters

`xElement`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The XElement to get the AssemblyUnit of.

#### Returns





Assembly unit for the current Xdoc.

<a name='M-Vsxmd-Units-Extensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-'></a>
# Join(value,separator) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Concatenates the `value`s with the `separator`.

#### Parameters

`value`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The string values.

`separator`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The separator.

#### Returns





The concatenated string.

<a name='M-Vsxmd-Units-Extensions-NthLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
# NthLast\`\`1(source,index) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the n-th last element from the `source`.

#### Type Parameters

`TSource`  

The type of the elements of `source`.

#### Parameters

`source`  [IEnumerable{\`\`0}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The source enumerable.

`index`  [Int32](https://docs.microsoft.com/dotnet/api/System.Int32)  

The index for the n-th last.

#### Returns





The element at the specified position in the `source` sequence.

<a name='M-Vsxmd-Units-Extensions-Suffix-System-String,System-String-'></a>
# Suffix(value,suffix) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Suffix the `suffix` to the `value`, and generate a new string.

#### Parameters

`value`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The original string value.

`suffix`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The suffix string.

#### Returns





The new string.

<a name='M-Vsxmd-Units-Extensions-TakeAllButLast``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
# TakeAllButLast\`\`1(source,count) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Take all element except the last `count`.

#### Type Parameters

`TSource`  

The type of the elements of `source`.

#### Parameters

`source`  [IEnumerable{\`\`0}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The source enumerable.

`count`  [Int32](https://docs.microsoft.com/dotnet/api/System.Int32)  

The number to except.

#### Returns





The generated enumerable.

<a name='M-Vsxmd-Units-Extensions-ToAnchor-System-String-'></a>
# ToAnchor(href) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Generate an anchor for the `href`.

#### Parameters

`href`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The href.

#### Returns





The anchor for the `href`.

<a name='M-Vsxmd-Units-Extensions-ToHereLink-System-String-'></a>
# ToHereLink(href) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Generate "to here" link for the `href`.

#### Parameters

`href`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The href.

#### Returns





The "to here" link for the `href`.

<a name='M-Vsxmd-Units-Extensions-ToLowerString-Vsxmd-Units-MemberKind-'></a>
# ToLowerString(memberKind) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the [MemberKind](#T-Vsxmd-Units-MemberKind) to its lowercase name.

#### Parameters

`memberKind`  [MemberKind](#T-Vsxmd-Units-MemberKind)  

The member kind.

#### Returns





The member kind's lowercase name.

<a name='M-Vsxmd-Units-Extensions-ToMarkdownRef-System-String-'></a>
# ToMarkdownRef(href) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Escape a reference to an anchor, file or folder by replacing special characters with '-'.

#### Parameters

`href`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The href.

#### Returns





An escaped href for Markdown files.

<a name='M-Vsxmd-Units-Extensions-ToMarkdownText-System-Xml-Linq-XElement-'></a>
# ToMarkdownText(element) method

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

<a name='M-Vsxmd-Units-Extensions-ToReferenceLink-System-String,System-Boolean-'></a>
# ToReferenceLink(memberName,useShortName) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Generate the reference link for the `memberName`.

#### Parameters

`memberName`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The member name.

`useShortName`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Indicate if use short type name.

#### Returns





The generated reference link.

# Examples

For `T:Vsxmd.Units.MemberUnit`, convert it to `[MemberUnit](#T-Vsxmd.Units.MemberUnit)`.

For `T:System.ArgumentException`, convert it to `[ArgumentException](http://msdn/path/to/System.ArgumentException)`.

<a name='T-Vsxmd-Units-FormatKind'></a>
# FormatKind type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

The formatting kind to use when generating markup.

<a name='T-Vsxmd-IConverter'></a>
# IConverter type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Converter for XML document to Markdown syntax conversion.

<a name='M-Vsxmd-IConverter-ToMarkdown'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Convert to Markdown syntax.

#### Returns





The generated Markdown content.

<a name='T-Vsxmd-Units-IUnit'></a>
# IUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

[IUnit](#T-Vsxmd-Units-IUnit) is wrapper to handle XML elements.

<a name='M-Vsxmd-Units-IUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Represent the XML element content as Markdown syntax.

#### Returns





The generated Markdown content.

<a name='T-Vsxmd-MarkdownWriter'></a>
# MarkdownWriter type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

<a name='M-Vsxmd-MarkdownWriter-#ctor-System-Xml-Linq-XDocument,System-String-'></a>
# #ctor(document,outputPath) constructor

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Ctor for Markdown Writer

#### Parameters

`document`  [XDocument](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XDocument)  

The XDocument to be converted to Markdown and output.

`outputPath`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

Path to output Markdown to.

<a name='M-Vsxmd-MarkdownWriter-WriteMultipleFiles-System-Boolean-'></a>
# WriteMultipleFiles(useSubDirectories) method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Converts the XML to multiple Markdown files (one per type) and writes to the output directory

#### Parameters

`useSubDirectories`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Use subdirectories for each namespace.

<a name='M-Vsxmd-MarkdownWriter-WriteSingleFile'></a>
# WriteSingleFile() method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Converts the XML to one Markdown file and writes to the output file

<a name='T-Vsxmd-Units-MemberKind'></a>
# MemberKind type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

The member kind.

<a name='F-Vsxmd-Units-MemberKind-Constants'></a>
# Constants constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Constants

<a name='F-Vsxmd-Units-MemberKind-Constructor'></a>
# Constructor constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Constructor.

<a name='F-Vsxmd-Units-MemberKind-Method'></a>
# Method constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Method.

<a name='F-Vsxmd-Units-MemberKind-NotSupported'></a>
# NotSupported constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Not supported member kind.

<a name='F-Vsxmd-Units-MemberKind-Property'></a>
# Property constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Property.

<a name='F-Vsxmd-Units-MemberKind-Type'></a>
# Type constants

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Type.

<a name='T-Vsxmd-Units-MemberName'></a>
# MemberName type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Member name.

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String,System-Collections-Generic-IEnumerable{System-String}-'></a>
# #ctor(name,paramNames) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [MemberName](#T-Vsxmd-Units-MemberName) class.

#### Parameters

`name`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The raw member name. For example, `T:Vsxmd.Units.MemberName`.

`paramNames`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The parameter names. It is only used when member kind is [Constructor](#F-Vsxmd-Units-MemberKind-Constructor) or [Method](#F-Vsxmd-Units-MemberKind-Method).

<a name='M-Vsxmd-Units-MemberName-#ctor-System-String-'></a>
# #ctor(name) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [MemberName](#T-Vsxmd-Units-MemberName) class.

#### Parameters

`name`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The raw member name. For example, `T:Vsxmd.Units.MemberName`.

<a name='P-Vsxmd-Units-MemberName-Caption'></a>
# Caption property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the caption representation for this member name.

# Examples

For [Type](#F-Vsxmd-Units-MemberKind-Type), show as `## Vsxmd.Units.MemberName [#](#here) [^](#contents)`.

For other kinds, show as `### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)`.

<a name='P-Vsxmd-Units-MemberName-Kind'></a>
# Kind property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the member kind, one of [MemberKind](#T-Vsxmd-Units-MemberKind).

<a name='P-Vsxmd-Units-MemberName-Link'></a>
# Link property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberName-Namespace'></a>
# Namespace property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the namespace name.

# Examples

`System`, `Vsxmd`, `Vsxmd.Units`.

<a name='P-Vsxmd-Units-MemberName-TypeName'></a>
# TypeName property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the type name.

# Examples

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberName-CompareTo-Vsxmd-Units-MemberName-'></a>
# CompareTo() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

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

<a name='M-Vsxmd-Units-MemberName-ToReferenceLink-System-Boolean-'></a>
# ToReferenceLink(useShortName) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the member name to Markdown reference link.

If then name is under `System` namespace, the link points to MSDN.

Otherwise, the link points to this page anchor.

#### Parameters

`useShortName`  [Boolean](https://docs.microsoft.com/dotnet/api/System.Boolean)  

Indicate if use short type name.

#### Returns





The generated Markdown reference link.

<a name='T-Vsxmd-Units-MemberUnit'></a>
# MemberUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Member unit.

<a name='M-Vsxmd-Units-MemberUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [MemberUnit](#T-Vsxmd-Units-MemberUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The member XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `member`.

<a name='P-Vsxmd-Units-MemberUnit-Comparer'></a>
# Comparer property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the member unit comparer.

<a name='P-Vsxmd-Units-MemberUnit-Kind'></a>
# Kind property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the member kind, one of [MemberKind](#T-Vsxmd-Units-MemberKind).

<a name='P-Vsxmd-Units-MemberUnit-Link'></a>
# Link property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the link pointing to this member unit.

<a name='P-Vsxmd-Units-MemberUnit-TypeName'></a>
# TypeName property

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Gets the type name.

# Examples

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd-Units-MemberUnit-ComplementType-System-Collections-Generic-IEnumerable{Vsxmd-Units-MemberUnit}-'></a>
# ComplementType(group) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Complement a type unit if the member unit `group` does not have one.
One member unit group has the same [TypeName](#P-Vsxmd-Units-MemberUnit-TypeName).

#### Parameters

`group`  [MemberUnit}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The member unit group.

#### Returns





The complemented member unit group.

<a name='M-Vsxmd-Units-MemberUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='T-Vsxmd-Units-MemberUnit-MemberUnitComparer'></a>
# MemberUnitComparer type

###### Namespace:  Vsxmd.Units.MemberUnit

###### Assembly:  Vsxmd

<a name='M-Vsxmd-Units-MemberUnit-MemberUnitComparer-Compare-Vsxmd-Units-MemberUnit,Vsxmd-Units-MemberUnit-'></a>
# Compare() method

###### Namespace:  Vsxmd.Units.MemberUnit

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='T-Vsxmd-PageFormatter'></a>
# PageFormatter type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

<a name='F-Vsxmd-PageFormatter-test'></a>
# test constants

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Test string

<a name='M-Vsxmd-PageFormatter-GetUnits-System-Collections-Generic-IEnumerable{Vsxmd-Units-BaseUnit}-'></a>
# GetUnits(units) method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Takes several base units of same type and organises them on page in the specified way according to the formatter.

#### Parameters

`units`  [BaseUnit}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The units of the same type.

#### Returns

[IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1)



[IEnumerable\`1](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable`1)

<a name='T-Vsxmd-Units-ParamUnit'></a>
# ParamUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Param unit.

<a name='M-Vsxmd-Units-ParamUnit-#ctor-System-Xml-Linq-XElement,System-String-'></a>
# #ctor(element,paramType) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [ParamUnit](#T-Vsxmd-Units-ParamUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The param XML element.

`paramType`  [String](https://docs.microsoft.com/dotnet/api/System.String)  

The parameter type corresponding to the param XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `param`.

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-ParamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement},System-Collections-Generic-IEnumerable{System-String},Vsxmd-Units-MemberKind-'></a>
# ToMarkdown(elements,paramTypes,memberKind) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the param XML element to Markdown safely.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

`paramTypes`  [String}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The paramater type names.

`memberKind`  [MemberKind](#T-Vsxmd-Units-MemberKind)  

The member kind of the parent element.

#### Returns





The generated Markdown.

#### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [Constructor](#F-Vsxmd-Units-MemberKind-Constructor) or [Method](#F-Vsxmd-Units-MemberKind-Method), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.

<a name='T-Vsxmd-Units-PermissionUnit'></a>
# PermissionUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Permission unit.

<a name='M-Vsxmd-Units-PermissionUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [PermissionUnit](#T-Vsxmd-Units-PermissionUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The permission XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `permission`.

<a name='M-Vsxmd-Units-PermissionUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-PermissionUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
# ToMarkdown(elements) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the permission XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The permission XML element list.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Program'></a>
# Program type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Program entry.

#### Remarks

Usage syntax:

```
Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]
```

The `input-XML-path` argument is required. It references to the VS generated XML documentation file.

The `output-Markdown-path` argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a `.md` file with same file name as the XML documentation file, path at the XML documentation folder.

<a name='M-Vsxmd-Program-Main-System-String[]-'></a>
# Main(args) method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Program main function entry.

#### Parameters

`args`  [String[]](https://docs.microsoft.com/dotnet/api/System.String[])  

Program arguments.

# See Also

- [Vsxmd.Program](#T-Vsxmd-Program)

<a name='T-Vsxmd-Units-RemarksUnit'></a>
# RemarksUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Remarks unit.

<a name='M-Vsxmd-Units-RemarksUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [RemarksUnit](#T-Vsxmd-Units-RemarksUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The remarks XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `remarks`.

<a name='M-Vsxmd-Units-RemarksUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-RemarksUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
# ToMarkdown(element) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the remarks XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The remarks XML element.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Units-ReturnsUnit'></a>
# ReturnsUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Returns unit.

<a name='M-Vsxmd-Units-ReturnsUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [ReturnsUnit](#T-Vsxmd-Units-ReturnsUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The returns XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `returns`.

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-ReturnsUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
# ToMarkdown(element) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the returns XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The returns XML element.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Units-SeealsoUnit'></a>
# SeealsoUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Seealso unit.

<a name='M-Vsxmd-Units-SeealsoUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [SeealsoUnit](#T-Vsxmd-Units-SeealsoUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The seealso XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `seealso`.

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-SeealsoUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
# ToMarkdown(elements) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the seealso XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The seealso XML element list.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-Units-SummaryUnit'></a>
# SummaryUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Summary unit.

<a name='M-Vsxmd-Units-SummaryUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [SummaryUnit](#T-Vsxmd-Units-SummaryUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The summary XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `summary`.

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-SummaryUnit-ToMarkdown-System-Xml-Linq-XElement-'></a>
# ToMarkdown(element) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the summary XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The summary XML element.

#### Returns





The generated Markdown.

<a name='T-Vsxmd-TableOfContents'></a>
# TableOfContents type

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Table of contents.

<a name='M-Vsxmd-TableOfContents-#ctor-System-Linq-IOrderedEnumerable{Vsxmd-Units-MemberUnit}-'></a>
# #ctor(memberUnits) constructor

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Initializes a new instance of the [TableOfContents](#T-Vsxmd-TableOfContents) class.

It convert the table of contents from the `memberUnits`.

#### Parameters

`memberUnits`  [MemberUnit}](https://docs.microsoft.com/dotnet/api/System.Linq.IOrderedEnumerable)  

The member unit list.

<a name='P-Vsxmd-TableOfContents-Link'></a>
# Link property

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Gets the link pointing to the table of contents.

<a name='M-Vsxmd-TableOfContents-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd

###### Assembly:  Vsxmd

Convert the table of contents to Markdown syntax.

#### Returns





The table of contents in Markdown syntax.

<a name='T-Vsxmd-Program-Test'></a>
# Test type

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

<a name='M-Vsxmd-Program-Test-#ctor'></a>
# #ctor() constructor

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Initializes a new instance of the [Test](#T-Vsxmd-Program-Test) class.

Test constructor without parameters.

See [Test](#M-Vsxmd-Program-Test-#ctor).

#### Permissions

| [Vsxmd.Program](#T-Vsxmd-Program) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestBacktickInSummary'></a>
# TestBacktickInSummary() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test backtick characters in summary comment.

See \`should not inside code block\`.

See `` `backtick inside code block` ``.

See \``code block inside backtick`\`.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestGenericException'></a>
# TestGenericException() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic exception type.

#### Exceptions

[Vsxmd.Program.Test.TestGenericParameter\`\`2](#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-)  

Just for test.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-'></a>
# TestGenericParameter\`\`2(expression) method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic parameter type.

See `T1` and `T2`.

#### Type Parameters

`T1`  

Generic type 1.

`T2`  

Generic type 2.

#### Parameters

`expression`  [String}}](https://docs.microsoft.com/dotnet/api/System.Linq.Expressions.Expression)  

The linq expression.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestGenericPermission'></a>
# TestGenericPermission() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic exception type.

#### Returns





Nothing.

#### Permissions

| [Vsxmd.Program.Test.TestGenericParameter\`\`2](#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestGenericReference'></a>
# TestGenericReference() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic reference type.

See [TestGenericParameter\`\`2](#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-).

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestParamWithoutDescription-System-String-'></a>
# TestParamWithoutDescription(p) method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test a param tag without description.

#### Parameters

`p`  [String](https://docs.microsoft.com/dotnet/api/System.String)  



#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestSeeLangword'></a>
# TestSeeLangword() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test see tag with langword attribute. See `true`.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-'></a>
# TestSpaceAfterInlineElements\`\`1() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test space after inline elements.

See `code block` should follow a space.

See a value at the end of a `sentence`.

See [TestSpaceAfterInlineElements\`\`1](#M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-) as a link.

See `space` after a param ref.

See `T` after a type param ref.

#### Returns





Nothing.

<a name='T-Vsxmd-Program-TestGenericType`2'></a>
# TestGenericType\`2 type

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic type.

See [TestGenericType\`2](#T-Vsxmd-Program-TestGenericType`2).

#### Type Parameters

`T1`  

Generic type 1.

`T2`  

Generic type 2.

<a name='M-Vsxmd-Program-TestGenericType`2-TestGenericMethod``2'></a>
# TestGenericMethod\`\`2() method

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

Test generic method.

See [TestGenericMethod\`\`2](#M-Vsxmd-Program-TestGenericType`2-TestGenericMethod``2).

#### Type Parameters

`T3`  

Generic type 3.

`T4`  

Generic type 4.

#### Returns





Nothing.

<a name='T-Vsxmd-Units-TypeparamUnit'></a>
# TypeparamUnit type

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Typeparam unit.

<a name='M-Vsxmd-Units-TypeparamUnit-#ctor-System-Xml-Linq-XElement-'></a>
# #ctor(element) constructor

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Initializes a new instance of the [TypeparamUnit](#T-Vsxmd-Units-TypeparamUnit) class.

#### Parameters

`element`  [XElement](https://docs.microsoft.com/dotnet/api/System.Xml.Linq.XElement)  

The typeparam XML element.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/dotnet/api/System.ArgumentException)  

Throw if XML element name is not `typeparam`.

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown-Vsxmd-Units-FormatKind-'></a>
# ToMarkdown() method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

*Inherited from parent.*

<a name='M-Vsxmd-Units-TypeparamUnit-ToMarkdown-System-Collections-Generic-IEnumerable{System-Xml-Linq-XElement}-'></a>
# ToMarkdown(elements) method

###### Namespace:  Vsxmd.Units

###### Assembly:  Vsxmd

Convert the param XML element to Markdown safely.
If element is `null`, return empty string.

#### Parameters

`elements`  [XElement}](https://docs.microsoft.com/dotnet/api/System.Collections.Generic.IEnumerable)  

The param XML element list.

#### Returns





The generated Markdown.
