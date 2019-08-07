
# Nuclear.Test
Nuclear.Test is a unit testing platform for .Net libraries which was initially written out of curisosity in late 2012.
Since then it has matured and grown into a somewhat usable piece of software that will hopefully help or at least inspire others.

## Table of Contents
coming soon

## Supported Runtimes
`Nuclear.Test` currently supports test assemblies targeting `.NetFramework >= 4.6.1`, `.NetStandard >= 2.0` and `.NetCore >= 2.0.`.

---

## Getting started
To get started quickly you can either check out the [documentation](docu/DOCUMENTATION.md) or go to [samples](samples) and load `Samples.sln` in Visual Studio.
To execute your test assemblies you can either download the latest [release](https://github.com/MikeLimaSierra/Nuclear.Test/releases) or build the software from source.

---

## Building from source
Building the software from source requires **Visual Studio 2017**.
Other versions might work as well but this is what I'm using so I suggest to use that.

1. In Visual Studio build the solution for all `release` configurations (`Any Cpu`, `x86` and `x64`). Do not use `Batch Build` as this will not currently work.
2. Execute `src/publish.bat` to publish all binaries to `src/publish/Nuclear.Test.Console/`.
3. Navigate to `src/publish/Nuclear.Test.Console/`.
4. Execute `Nuclear.Test.Console.exe` and configure with arguments (See [How to use Nuclear.Test](docu/configure_and_test.md))
---

## Roadmap
These features are planned for anytime in the future. However this project is a one man show so things will be slow.

* How to write tests using Nuclear.Test
* Decent logging mechanism
* Installer packages
* WPF based test server with GUI
* Visual Studio integration
* MSBuild task
---
