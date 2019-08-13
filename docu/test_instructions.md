
# Test Instructions
`Nuclear.Test` provides a range of test instructions that can be used to model unit tests.
Each test instruction is a `public static void` method that will yield one test result.
There are two parameters available (`String _file` and `String _method`) on every test instruction which are reserved for internal use only.
Do not use these parameters within test methods that are decorated with `[TestMethod]`.
Read [How to extend Nuclear.Test](how_to_extend.md) to learn how to use these instead.
For simplicity, both parameters are being omitted in the following document.

## Table of contents
* [Null](#null)
* [ReferencesEqual](#referencesequal)
* [OfType](#oftype)
* [OfExactType](#ofexacttype)
* [TypeImplements](#typeimplements)
* [TypeIsSubClass](#typeissubclass)
* [ThrowsException](#throwsexception)
* [RaisesPropertyChangedEvent](#raisespropertychangedevent)
* [RaisesEvent](#raisesevent)
* [True](#true)
* [False](#false)
* [ValuesEqual](#valuesequal)
* [StringIsNullOrEmpty](#stringisnullorempty)
* [StringIsNullOrWhiteSpace](#stringisnullorwhitespace)
* [StringContains](#stringcontains)
* [StringStartsWith](#stringstartswith)
* [StringEndsWith](#stringendswith)

---

## Null
Tests if `obj` is null.

```csharp
public void Null(Object obj);
```

### Parameters:
`Object obj`: The object to be checked.

### Example:
```csharp
Test.If.Null(obj);
```

---

## ReferencesEqual
Tests if references `obj` and `_other` are equal.

```csharp
public void ReferencesEqual(Object obj, Object _other);
```

### Parameters:
`Object obj`: The object to be checked against `_other`.

`Object _other`: The object to be checked against `obj`.

### Example:
```csharp
Test.If.ReferencesEqual(obj1, obj2);
```

---

## OfType
Tests if `_object` can be casted to `TType`.

```csharp
public void OfType<TType>(Object _object);
```

### Parameters:
`Object _object`: The object to be checked.

### Example:
```csharp
Test.If.OfType<MyClass>(obj);
```

---

## OfExactType
Tests if `_object` is exactly of type `TType` and not just assignable.

```csharp
public void OfExactType<TType>(Object _object);
```

### Parameters:
`Object _object`: The object to be checked.

### Example:
```csharp
Test.If.OfExactType<MyClass>(obj);
```

---

## TypeImplements
Tests if type `TType` implements interface `TInterface`.

```csharp
public void TypeImplements<TType, TInterface>();
```

### Example:
```csharp
Test.If.TypeImplements<MyClass, IDisposable>();
```

---

## TypeIsSubClass
Tests if type `TType` inherits from class `TBase`.

```csharp
public void TypeIsSubClass<TType, TBase>();
```

### Example:
```csharp
Test.If.TypeIsSubClass<MyClass, MyBaseClass>();
```

---

## ThrowsException
Tests if `action` throws a `System.Exception` when executed.

```csharp
public void ThrowsException(Action action, out Exception exception);
```

### Parameters:
`Action action`: The action to be executed.

`Exception exception`: Contains the exception if thrown.

### Example:
```csharp
Test.If.ThrowsException(() => obj.DoSomething(), out Exception exception);
```

---

Tests if `action` throws an `Exception` of type `TException` when executed.

```csharp
public void ThrowsException<TException>(Action action, out TException exception);
```

### Parameters:
`Action action`: The action to be executed.

`TException exception`: Contains the exception if thrown.

### Example:
```csharp
Test.If.ThrowsException<ArgumentException>(() => obj.DoSomething(), out ArgumentException exception);
```

---

## RaisesPropertyChangedEvent
Tests if `action` on `_object` raises `INotifyPropertyChanged`.

```csharp
public void RaisesPropertyChangedEvent(INotifyPropertyChanged _object, Action action, out Object sender, out PropertyChangedEventArgs e);
```

### Parameters:
`INotifyPropertyChanged _object`: The object to invoke `action` on.

`Action action`: The action to be invoked on `_object`.

`Object sender`: Contains the sender if event is raised.

`PropertyChangedEventArgs e`: Contains the `PropertyChangedEventArgs` if event is raised.

### Example:
```csharp
Test.If.RaisesPropertyChangedEvent(obj, () => obj.Title = "new content", out Object sender, out PropertyChangedEventArgs e);
```

---

## RaisesEvent
Tests if `action` on `_object` raises event with `TEventArgs`.

```csharp
public void RaisesEvent<TEventArgs>(Object _object, String eventName, Action action, out Object sender, out TEventArgs e);
```

### Parameters:
`INotifyPropertyChanged _object`: The object to invoke `action` on.

`String eventName`: The name of the event to be raised.

`Action action`: The action to be invoked on `_object`.

`Object sender`: Contains the sender if event is raised.

`TEventArgs e`: Contains the `TEventArgs` if event is raised.

### Example:
```csharp
Test.If.RaisesEvent(obj, "MyCustomEvent", () => obj.DoSomething(), out Object sender, out MyCustomEventArgs e);
```

---

## True
Tests if `value` is true.

```csharp
public void True(Boolean value);
```

### Parameters:
`Boolean value`: The value to be checked.

### Example:
```csharp
Test.If.True(1 + 1 == 2);
```

---

Tests if `value` is true.

```csharp
public void True(Boolean? value);
```

### Parameters:
`Boolean? value`: The value to be checked.

### Example:
```csharp
Test.If.True(someNullableBoolean);
```

---

## False
Tests if `value` is false.

```csharp
public void False(Boolean value);
```

### Parameters:
`Boolean value`: The value to be checked.

### Example:
```csharp
Test.If.False(1 + 1 == 2);
```

---

Tests if `value` is false.
```csharp
public void False(Boolean? value);
```

### Parameters:
`Boolean? value`: The value to be checked.

### Example:
```csharp
Test.If.False(someNullableBoolean);
```

---

## ValuesEqual
Tests if two objects are equal. Equality is determined by checking implementations of (in given order): `IEquatable<T>`, `IComparable<T>`, `IComparable`, `default IEqualityComparer<T>`

```csharp
public void ValuesEqual<T>(T left, T right);
```

### Parameters:
`T left`: The first object.

`T right`: The second object.

### Example:
```csharp
Test.If.ValuesEqual(obj1, obj2);
```

---

Tests if two objects are equal by using a supplied `IEqualityComparer{T}`.

```csharp
public void ValuesEqual<T>(T left, T right, IEqualityComparer<T> comparer);
```

### Parameters:
`T left`: The first object.

`T right`: The second object.

`IEqualityComparer<T> comparer`: The comparer to be used to determine equality.

### Example:
```csharp
Test.If.ValuesEqual(obj1, obj2, new MyEqualityComparer());
```

---

Tests if two `Single` values are equal by a margin of `1e-12`.

```csharp
public void ValuesEqual(Single left, Single right);
```

### Parameters:
`Single left`: The first value.

`Single right`: The second value.

### Example:
```csharp
Test.If.ValuesEqual(val1, val2);
```

---

Tests if two `Single` values are equal by a `margin`.

```csharp
public void ValuesEqual(Single left, Single right, Single margin);
```

### Parameters:
`Single left`: The first value.

`Single right`: The second value.

`Single margin`: The margin to use as tolerance.

### Example:
```csharp
Test.If.ValuesEqual(val1, val2, 1e-28f);
```

---

Tests if two `Double` values are equal by a margin of `1e-12`.

```csharp
public void ValuesEqual(Double left, Double right);
```

### Parameters:
`Double left`: The first value.

`Double right`: The second value.

### Example:
```csharp
Test.If.ValuesEqual(val1, val2);
```

---

Tests if two `Double` values are equal by a `margin`.

```csharp
public void ValuesEqual(Double left, Double right, Double margin);
```

### Parameters:
`Double left`: The first value.

`Double right`: The second value.

`Double margin`: The margin to use as tolerance.

### Example:
```csharp
Test.If.ValuesEqual(val1, val2, 1e-28d);
```

---

## StringIsNullOrEmpty
Tests if a `String` is null or empty.

```csharp
public void StringIsNullOrEmpty(String _string);
```

### Parameters:
`String _string`: The `String` to be checked.

### Example:
```csharp
Test.If.StringIsNullOrEmpty(someString);
```

---

## StringIsNullOrWhiteSpace
Tests if a `String` is null or white spaces.

```csharp
public void StringIsNullOrWhiteSpace(String _string);
```

### Parameters:
`String _string`: The `String` to be checked.

### Example:
```csharp
Test.If.StringIsNullOrWhiteSpace(someString);
```

---

## StringContains
Tests if a `String` contains a specific `String`.

```csharp
public void StringContains(String _string, String value);
```

### Parameters:
`String _string`: The `String` to be checked.

`String value`: The `String` to check for.

### Example:
```csharp
Test.If.Null(someString, "John Doe");
```

---

## StringStartsWith
Tests if a `String` starts with a specific `Char`.

```csharp
public void StringStartsWith(String _string, Char value);
```

### Parameters:
`String _string`: The `String` to be checked.

`Char value`: The `Char` to check for.

### Example:
```csharp
Test.If.Null(someString, '.');
```

---

Tests if a `String` starts with a specific `String`.

```csharp
public void StringStartsWith(String _string, String value);
```

### Parameters:
`String _string`: The `String` to be checked.

`String value`: The `String` to check for.

### Example:
```csharp
Test.If.Null(someString, "https://");
```

---

## StringEndsWith
Tests if a `String` ends with a specific `Char`.

```csharp
public void StringEndsWith(String _string, Char value);
```

### Parameters:
`String _string`: The `String` to be checked.

`Char value`: The `Char` to check for.

### Example:
```csharp
Test.If.Null(someString, '/');
```

---

Tests if a `String` ends with a specific `String`.

```csharp
public void StringEndsWith(String _string, String value);
```

### Parameters:
`String _string`: The `String` to be checked.

`String value`: The `String` to check for.

### Example:
```csharp
Test.If.Null(someString, ".xml");
```

---
