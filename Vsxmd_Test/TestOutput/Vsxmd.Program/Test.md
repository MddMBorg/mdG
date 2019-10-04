<a name='T-Vsxmd-Program-Test'></a>
# Test type

###### Namespace:  Vsxmd.Program

###### Assembly:  Vsxmd

<a name='M-Vsxmd-Program-Test-#ctor'></a>
### #ctor() constructor

Initializes a new instance of the [Test](/Vsxmd.Program/Test.md/#T-Vsxmd-Program-Test) class.

Test constructor without parameters.

See [Test.#ctor](/Vsxmd.Program/Test.md/#M-Vsxmd-Program-Test-#ctor).

#### Permissions

| [Vsxmd.Program](/Vsxmd/Program.md/#T-Vsxmd-Program) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestBacktickInSummary'></a>
### TestBacktickInSummary() method

Test backtick characters in summary comment.

See \`should not inside code block\`.

See `` `backtick inside code block` ``.

See \``code block inside backtick`\`.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestGenericException'></a>
### TestGenericException() method

Test generic exception type.

#### Exceptions

[Vsxmd.Program.Test.TestGenericParameter\`\`2](/Vsxmd.Program/Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-)  

Just for test.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-'></a>
### TestGenericParameter\`\`2(expression) method

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
### TestGenericPermission() method

Test generic exception type.

#### Returns





Nothing.

#### Permissions

| [Vsxmd.Program.Test.TestGenericParameter\`\`2](/Vsxmd.Program/Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestGenericReference'></a>
### TestGenericReference() method

Test generic reference type.

See [TestGenericParameter\`\`2](/Vsxmd.Program/Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-).

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestParamWithoutDescription-System-String-'></a>
### TestParamWithoutDescription(p) method

Test a param tag without description.

#### Parameters

`p`  [String](https://docs.microsoft.com/dotnet/api/System.String)  



#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestSeeLangword'></a>
### TestSeeLangword() method

Test see tag with langword attribute. See `true`.

#### Returns





Nothing.

<a name='M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-'></a>
### TestSpaceAfterInlineElements\`\`1() method

Test space after inline elements.

See `code block` should follow a space.

See a value at the end of a `sentence`.

See [TestSpaceAfterInlineElements\`\`1](/Vsxmd.Program/Test.md/#M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-) as a link.

See `space` after a param ref.

See `T` after a type param ref.

#### Returns





Nothing.
