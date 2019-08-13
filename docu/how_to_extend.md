# How to extend Nuclear.Test
`Nuclear.Test` can be extended in several ways by any user.
This allows for data driven testing as well as increasing the usablility of `Nuclear.Test` with all kinds of environments or requirements.

## Table of contents
* [Data driven test methods (DDT)](#data-driven-test-methods-ddt)
* [Custom test instructions](#custom-test-instructions)

---

## Data driven test methods (DDT)
Multiple repeating lines of test instructions can be bundled into data driven test methods or generic test methods.
DDT methods allow for testing of functionality with varying input parameters without having to copy & paste code.

Please note that every DDT method is required to provide the two parameters `[CallerFilePath] String _file = null` and `[CallerMemberName] String _method = null`.
The parameters `_file` and `_method` must be forwarded to any test instruction called within DDT methods.

When using DDT methods within test methods, the parameters `_file` and `_method` need to be omitted as values are supplied by the compiler at compile time.

### Example:
```csharp

// DDT method declaration
void TestMultiplicatorMultiply(MyMultiplicator mul, Double left, Double right, Double expected,
    [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
    
    Double result = Double.Nan;
    
    Test.IfNot.ThrowsException(() => result = mul.Multiply(left, right), out Exception ex, _file, _method);
    Test.If.ValuesEqual(result, expected, _file, _method);
    Test.IfNot.ThrowsException(() => result = mul.Multiply(right, left), out ex, _file, _method);
    Test.If.ValuesEqual(result, expected, _file, _method);
    
}

// using DDT methods
[TestMethod]
void TestMultiplicator() {

    var mul = new MyMultiplicator();
    
    TestMultiplicatorMultiply(mul, 2, 6, 12);
    TestMultiplicatorMultiply(mul, 1, 9, 9);
    TestMultiplicatorMultiply(mul, -42, 42, -1764);
    ...

}
```

---

## Custom test instructions
Custom test instructions are created by declaring `extension methods` for `Nuclear.TestSite.Tests.ConditionalTest`.
The extended class `ConditionalTest` provides a hidden method `public void InternalTest(Boolean, String, String, String, String, String)` which is responsible for both inverting and collecting the test result.

Please note that every custom test instruction is required to provide the two parameters `[CallerFilePath] String _file = null` and `[CallerMemberName] String _method = null`.
The parameters `_file` and `_method` must be forwarded to `ConditionalTest.InternalTest`.
There may only be one call to `InternalTest` at any time during execution of custom test instructions.

When using custom test instructions within test methods, the parameters `_file` and `_method` need to be omitted as values are supplied by the compiler at compile time.

### Parameters of InternalTest (internal only omitted):
`Boolean condition`: The condition to check.

`String message`: The message.

`String _file`: The file name where the test method is located.

`String _method`: The test method name.

### Example:
```csharp

// custom test instruction declaration
static void IsOddNumber(this ConditionalTest _this, Int32 number,
    [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

    Boolean result = number % 2 != 0;
    _this.InternalTest(result, String.Format("{0} is {1}", number, result ? "odd" : "even"),
        _file, _method);
}

// using custom test instructions
[TestMethod]
void TestOddNumberGenerator() {

    var oddGen = new MyOddNumberGenerator();
    
    Test.If.IsOddNumber(oddGen.Generate(DateTime.Now));

}
```

---
