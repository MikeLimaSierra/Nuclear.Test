
# Nuclear.Test
Nuclear.Test is a unit testing platform for .Net libraries which was initially written out of curisosity in late 2012.
Since then it has matured and grown into a somewhat usable piece of software that will hopefully help or at least inspire others.

## Supported Runtimes
`Nuclear.Test` currently supports test assemblies targeting `.NetFramework >= 4.6.1`, `.NetStandard >= 2.0` and `.NetCore >= 2.0.`.

---

## Getting started
To get started quickly you can check out the tutorials on [How to write tests](docu/how_to_write_tests.md) and [How to run tests](docu/how_to_use.md) using `Nuclear.Test`.
Some of these tutorials make use of code in the [samples](samples) so you might want to load `samples/Samples.sln` in Visual Studio.
Building the samples from source may require you to execute `dotnet restore` and `NuGet restore` on the samples solution.

To execute your test assemblies you can either download the latest [release](releases) or build the software from source.

A complete list of all available test instructions can be found [here](docu/test_instructions.md).

A detailed guide to writing test extensions and data driven tests can be found [here](docu/how-to-extend.md).

---

## Building from source
Building the software from source requires **Visual Studio 2017**.
Other versions might work as well but this is what I'm using so I suggest to use that.

1. In Visual Studio build the solution for all `release` configurations (`Any Cpu`, `x86` and `x64`). Do not use `Batch Build` as this will not currently work.
2. Execute `src/publish.bat` to publish all binaries to `src/publish/Nuclear.Test.Console/`.
3. Navigate to `src/publish/Nuclear.Test.Console/`.
4. Execute `Nuclear.Test.Console.exe` and configure with arguments (See [How to use Nuclear.Test](docu/configure_and_test.md))

### Running tests on `samples/Samples.sln`
```csharp
...\src\publish\Nuclear.Test.Console>Nuclear.Test.Console.exe -d ../../../samples -i Debug;obj
```

### Running tests on `src/Nuclear.Test.sln`
```csharp
...\src\publish\Nuclear.Test.Console>Nuclear.Test.Console.exe -d ../../bin -i Debug;obj
```

---

## Roadmap
These features are planned for anytime in the future.
However this project is a one man show so things will be slow.

* Decent logging mechanism
* Installer packages
* WPF based test server with GUI
* Visual Studio integration
* MSBuild task

---
