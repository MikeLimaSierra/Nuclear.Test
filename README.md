
# Nuclear.Test
`Nuclear.Test` is a unit testing platform for `.NET` initially written some time in late 2012.
The main motivation behind it was curiosity and finding out how it can be done.
There have been many changes and improvements to it over the last years and I have used it to unit test my own projects ever since.

My own experience with the established unit testing platforms is very limited.
This has resulted in a very different concept of writing and running unit tests.
It may not be as refined and as solid as the others but it has done its job well so far.

By publishing this code I hope to help or inspire others to think outside the box and break new ground.

~~If~~ When you run into bugs and other problems, please open up an issue to help me fix it.

## Supported target frameworks
`Nuclear.Test` can run unit tests targeting the following frameworks.
Tests targeting .NETStandard will run on matching runtimes that implement the targeted version of .NETStandard.

* .NETFramework 4.6.1 or higher
* .NETCore 2.0 or higher
* .NETStandard 2.0 or higher

---

## Why you should (not) use Nuclear.Test
`Nuclear.Test` offers both advantages and disadvantages over other unit test platforms.
There are good reasons to use it or not.
This depends very much on your priorities and on which of the following two lists you feel more at home.

### Good reasons to use Nuclear.Test

* Unit testing functionality for .NETStandard libraries.
* Processor architecture independent (Any CPU, x86, x64).
* No more 'One assertion per test' rules. Test as much as you like.
* Don't know about you but using command line tools with colored output always makes me feel super smart.

### Good reasons to go with something else

* Requires to have no more than one test class per file where both need to have the exact same name.
* Command line only at the moment without any integration into Visual Studio.
* Not as sophisticated and will have bugs and stability issues which will take longer to fix.
* No community to help you with issues other than this place right here.

## Getting started
To get started quickly you can check out the tutorials on [How to write tests](docu/how_to_write_tests.md) and [How to run tests](docu/how_to_use.md) using `Nuclear.Test`.
Some of these tutorials make use of code in the [samples](samples) so you might want to load `samples/Samples.sln` in Visual Studio.
Building the samples from source may require you to execute `dotnet restore` and `NuGet restore` on the samples solution.

To execute your test assemblies you can either download the latest [release](https://github.com/MikeLimaSierra/Nuclear.Test/releases) or build the software from source.

A complete list of all available test instructions can be found [here](docu/test_instructions.md).

A detailed guide to writing test extensions and data driven tests can be found [here](docu/how_to_extend.md).

---

## Building from source
Building the software from source requires **Visual Studio 2017**.
Other versions might work as well but this is what I'm using so I suggest to use that.

1. In Visual Studio build the solution for all `release` configurations (`Any Cpu`, `x86` and `x64`). Do not use `Batch Build` as this will not currently work.
2. Execute `src/publish.bat` to publish all binaries to `src/publish/Nuclear.Test.Console/`.
3. Navigate to `src/publish/Nuclear.Test.Console/`.
4. Execute `Nuclear.Test.Console.exe` and configure with arguments (See [How to use Nuclear.Test](docu/how_to_use.md))

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
