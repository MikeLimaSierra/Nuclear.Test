
# Nuclear.Test
Nuclear.Test is a unit testing platform for .Net libraries which was initially written out of curisosity in late 2012.
Since then it has matured and grown into a somewhat usable piece of software that will hopefully help or at least inspire others.

## Table of Contents
coming soon

## Supported Target Frameworks
Nuclear.Test currently supports test assemblies targeting **.NetFramework >= 4.6.1**, **.NetStandard >= 2.0** and **.NetCore >= 2.0**. Mono >= 5.4, Uwp 10.0.16299 and Unity >= 2018.1 might also work fine, however this has not been tested yet.

## Getting started
To get started quickly you can either check out the [documentation](docu/DOCUMENTATION.md) or go to [samples](samples) and load `Samples.sln` in Visual Studio.
To execute your test assemblies you can either download the latest [release](https://github.com/MikeLimaSierra/Nuclear.Test/releases) or build the software from source.

## Building from source
Building the software from source requires **Visual Studio 2017**. Other versions might work as well but this is what I'm using so I suggest to use that.
In Visual Studio go to `Build` > `Batch Build` and deselect all except:
* `Nuclear.Test.Server.Console` => `Release AnyCPU`
* `Nuclear.TestSite.Tests` => all `Release` configurations (If you intend to run unit tests on the solution right away)

Building the console based server will also build standalone configurations of the client and publish those into the publish directory. Open a command window and navigate to `src/publish/Nuclear.Test.Server.Console/`. Execute `Nuclear.Test.Server.Console.exe` without parameters or add `-h` or `--help` to get some helpful output. This is your manual until the real manual is done ;-)


## Roadmap
These features are planned for anytime in the future. However this project is a one man show so things will be slow.

* How to write tests using Nuclear.Test
* How to extend Nuclear.Test
* How to configure and use Nuclear.Test
* Running tests against multiple target frameworks at the same time
* Decent logging mechanism
* Installer packages
* WPF based test server with GUI
* Visual Studio integration
* MSBuild task



