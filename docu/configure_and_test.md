# Using Nuclear.Test.Console
`Nuclear.Test.Console` is a command line tool used for running tests in one or more test assemblies.
`Nuclear.Test.Console` makes use of three different programs that can have visible windows.
Each program will therefore print a large visible header to help with orientation.
Test results are collected and printed to console when finished in every visible window.
Visibility of child processes can be configured.

## Configuration options
`Nuclear.Test.Console` is configured by providing arguments with its call.
A list of available options is printed when calling the program without any arguments or by giving `-h` or `--help`

| Argument | Description |
|:--|:--|
| `-h`                           | Display this help context.
| `--help`                       | Same as `-h`.
| `-d path`                      | The directory to search for test assemblies in.<br />Defaults to the current location.
| `--search-dir path`            | Same as `-d path`
| `-r num`                       | The depth of recursion to use for sub level directories.<br />Defaults to `-r 0` <br />Use `0` to search all available sub directories recursively.<br />Use `positive value` to search the first <num> levels of directories.
| `--search-recursion num`       | Same as `-r num`
| `-p pattern`                   | The search pattern to find files with.<br />Defaults to `-p *Tests.dll`
| `--search-pattern pattern`     | Same as `-p pattern`
| `-i name1;name2;...`           | Ignore directories with these names separated by `;` .
| `--ignore-dir name1;name2;...` | Same as `-i name1;name2;...`
| `--force-sequential`           | Execute one test at a time for each assembly.
| `--force-asm-sequential`       | Execute one assembly at a time.
| `--test-all-versions`          | Execute tests on all matching runtimes.
| `--worker-base-dir path`       | The directory containing all worker executables.<br />Defaults to `--worker-base-dir ./Nuclear.Test.Worker/`
| `--proxy-base-dir path`        | The directory containing all proxy executables.<br />Defaults to `--proxy-base-dir ./Nuclear.Test.Proxy/`
| `--show-clients`               | Start client process as visible windows.
| `--clients-await-input`        | Let client process await key input before exit.
| `--diagnostic-output`          | Show diagnostic output.
| `-v num`                       | Set the minimum verbosity level for a 100% success case. Failing tests will unfold the relevant test tree nodes.<br />Defaults to `-v 0`<br />Use `0` to print all results combined.<br />Use `1` to print results for individual test assemblies.<br />Use `2` to print results for individual architectures.<br />Use `3` to print results for individual runtime versions.<br />Use `4` to print results for individual test classes.<br />Use `5` to print results for individual test methods.<br />Use `6` to print results for individual test instructions.
| `--verbose num`                | Same as `-v num`

## Running tests
Running unit tests using `Nuclear.Test.Console` is done by executing the command in a console.

```
Some\Path\To\Nuclear.Test.Console>Nuclear.Test.Console.exe [OPTIONS]
╔══════════════════════════════════════════════════════════════════════╗
║     _   _               _                    _____           _       ║
║    | \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_     ║
║    |  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|    ║
║    | |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_     ║
║    |_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|    ║
║      ____                           _                                ║
║     / ___| ___   _ __   ___   ___  | |  ___                          ║
║    | |    / _ \ | '_ \ / __| / _ \ | | / _ \                         ║
║    | |___| (_) || | | |\__ \| (_) || ||  __/                         ║
║     \____|\___/ |_| |_||___/ \___/ |_| \___|                         ║
║                                                                      ║
╠══════════════════════════════════════════════════════════════════════╣
║        Platform: NETCore                                             ║
║         Version: 2.0                                                 ║
║    Architecture: MSIL                                                ║
╚══════════════════════════════════════════════════════════════════════╝
```

## Nuclear.Test.Proxy
For every test assembly that is found according to the supplied configuration, `Nuclear.Test.Proxy` is started as a child process.
If the parameter `--show-clients` is provided, `Nuclear.Test.Proxy` will print out information about itself and the test assembly.
This will also give information about on what platform in what version the test assembly can be loaded.

By default the lowest possible version of any platform will be used to run tests on.
This can be configured by giving the argument `--test-all-versions` which will result in running tests on all matching runtimes.
* Runtimes marked with `[Y]` will be used.
* Runtimes marked with `[Y]` will not be used.
* Runtimes marked with `[?]` do not have a worker.

```
╔══════════════════════════════════════════════════════════════════════╗
║     _   _               _                    _____           _       ║
║    | \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_     ║
║    |  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|    ║
║    | |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_     ║
║    |_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|    ║
║     ____                                                             ║
║    |  _ \  _ __  ___ __  __ _   _                                    ║
║    | |_) || '__|/ _ \\ \/ /| | | |                                   ║
║    |  __/ | |  | (_) |>  < | |_| |                                   ║
║    |_|    |_|   \___//_/\_\ \__, |                                   ║
║                             |___/                                    ║
║                                                                      ║
╠══════════════════════════════════════════════════════════════════════╣
║        Platform: NETCore                                             ║
║         Version: 2.0                                                 ║
║    Architecture: MSIL                                                ║
╚══════════════════════════════════════════════════════════════════════╝
╔══════════════════════════════════════════════════════════════════════╗
║                             Test Assembly                            ║
╠══════════════════════════════════════════════════════════════════════╣
║            Name: SampleNetStandardTests                              ║
║        Platform: NETStandard                                         ║
║         Version: 2.0                                                 ║
║    Architecture: Amd64                                               ║
╚══════════════════════════════════════════════════════════════════════╝
╔══════════════════════════════════════════════════════════════════════╗
║                       Matching Target Runtimes                       ║
╠══════════════════════════════════════════════════════════════════════╣
║    [Y] NETFramework 4.6.1                                            ║
║    [N] NETFramework 4.6.2                                            ║
║    [N] NETFramework 4.7                                              ║
║    [N] NETFramework 4.7.1                                            ║
║    [N] NETFramework 4.7.2                                            ║
║    [?] NETFramework 4.8                                              ║
║    [Y] NETCore 2.0                                                   ║
║    [N] NETCore 2.1                                                   ║
║    [?] NETCore 2.2                                                   ║
║    [?] NETCore 3.0                                                   ║
║    [?] Mono 5.4                                                      ║
║    [?] XamarinIOS 10.14                                              ║
║    [?] XamarinMac 3.8                                                ║
║    [?] XamarinAndroid 8.0                                            ║
║    [?] UWP 10.0.16299                                                ║
║    [?] Unity 2018.1                                                  ║
╚══════════════════════════════════════════════════════════════════════╝
```

## Nuclear.Test.Worker
For every matching [Y] marked runtime, `Nuclear.Test.Worker` is started as a child process.
If the parameter `--show-clients` is provided, `Nuclear.Test.Worker` will print out information about itself and the test assembly.
```
╔══════════════════════════════════════════════════════════════════════╗
║     _   _               _                    _____           _       ║
║    | \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_     ║
║    |  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|    ║
║    | |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_     ║
║    |_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|    ║
║    __        __            _                                         ║
║    \ \      / /___   _ __ | | __ ___  _ __                           ║
║     \ \ /\ / // _ \ | '__|| |/ // _ \| '__|                          ║
║      \ V  V /| (_) || |   |   <|  __/| |                             ║
║       \_/\_/  \___/ |_|   |_|\_\\___||_|                             ║
║                                                                      ║
╠══════════════════════════════════════════════════════════════════════╣
║        Platform: NETFramework                                        ║
║         Version: 4.6.1                                               ║
║    Architecture: Amd64                                               ║
╚══════════════════════════════════════════════════════════════════════╝
╔══════════════════════════════════════════════════════════════════════╗
║                             Test Assembly                            ║
╠══════════════════════════════════════════════════════════════════════╣
║            Name: SampleNetStandardTests                              ║
║        Platform: NETStandard                                         ║
║         Version: 2.0                                                 ║
║    Architecture: Amd64                                               ║
╚══════════════════════════════════════════════════════════════════════╝
```
