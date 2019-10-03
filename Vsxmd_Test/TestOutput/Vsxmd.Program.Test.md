<a name='T-Vsxmd-Program-Test'></a>
## Test `type`

##### Namespace

Vsxmd.Program

<a name='M-Vsxmd-Program-Test-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [Test](/Vsxmd-Program-Test.md/#T-Vsxmd-Program-Test) class.

Test constructor without parameters.

See [Test.#ctor](/Vsxmd-Program-Test.md/#M-Vsxmd-Program-Test-#ctor).

##### Parameters

This constructor has no parameters.

##### Permissions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program](/Vsxmd-Program.md/#T-Vsxmd-Program) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestBacktickInSummary'></a>
### TestBacktickInSummary() `method`

##### Summary

Test backtick characters in summary comment.

See \`should not inside code block\`.

See `` `backtick inside code block` ``.

See \``code block inside backtick`\`.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Program-Test-TestGenericException'></a>
### TestGenericException() `method`

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program.Test.TestGenericParameter\`\`2](/Vsxmd-Program-Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-'></a>
### TestGenericParameter\`\`2(expression) `method`

##### Summary

Test generic parameter type.

See `T1` and `T2`.

##### Returns

Nothing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1,System.String}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression) | The linq expression. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | Generic type 1. |
| T2 | Generic type 2. |

<a name='M-Vsxmd-Program-Test-TestGenericPermission'></a>
### TestGenericPermission() `method`

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Permissions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program.Test.TestGenericParameter\`\`2](/Vsxmd-Program-Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-) | Just for test. |

<a name='M-Vsxmd-Program-Test-TestGenericReference'></a>
### TestGenericReference() `method`

##### Summary

Test generic reference type.

See [TestGenericParameter\`\`2](/Vsxmd-Program-Test.md/#M-Vsxmd-Program-Test-TestGenericParameter``2-System-Linq-Expressions-Expression{System-Func{``0,``1,System-String}}-).

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Program-Test-TestParamWithoutDescription-System-String-'></a>
### TestParamWithoutDescription(p) `method`

##### Summary

Test a param tag without description.

##### Returns

Nothing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| p | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String) |  |

<a name='M-Vsxmd-Program-Test-TestSeeLangword'></a>
### TestSeeLangword() `method`

##### Summary

Test see tag with langword attribute. See `true`.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-'></a>
### TestSpaceAfterInlineElements\`\`1() `method`

##### Summary

Test space after inline elements.

See `code block` should follow a space.

See a value at the end of a `sentence`.

See [TestSpaceAfterInlineElements\`\`1](/Vsxmd-Program-Test.md/#M-Vsxmd-Program-Test-TestSpaceAfterInlineElements``1-System-Boolean-) as a link.

See `space` after a param ref.

See `T` after a type param ref.

##### Returns

Nothing.

##### Parameters

This method has no parameters.
