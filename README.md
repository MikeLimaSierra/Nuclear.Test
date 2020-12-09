# Nuclear.Test

This is a quick and dirty readme with very little information due to the current pre-release state.
There is going to be more in the near future along with a proper release.

## Visual Studio integration

`Nuclear.Test` can be used by registering the console executor (`Nuclear.Test.Console`) as an external tool in `Visual Studio`.
Go to `Tools` > `External Tools...` > `Add` and configure the external tool like so:

* Title: `Run Tests`
* Command: `%APPDATA%\Nuclear.Test.Console\Nuclear.Test.Console.exe`
* Arguments: `--dir $(BinDir)`
* Initial directory: `%APPDATA%\Nuclear.Test.Console\`
* Check `Use Output window`

Selecting `Tools` > `Run Tests` in `Visual Studio` will then attempt to locate the binaries for the currently selected project and run all available tests.
Don't forget to close all popped up windows and then manually stop the test process by selecting `Tools` > `Stop (Run Tests)`.
This is going to make you nuts and I want apologize for it.
All test results can be seen in the output window.
A proper extension for `Visual Studio` is planned for the future where magic happens, unicorns dance and things go a lot smoother in general.

---

## Configuration

`Nuclear.Test` has a configuration file located at `%APPDATA%/Nuclear.Test.Console/default.json`. 
If missing, the file will be created at startup using default values.
A useful help output can be displayed using the `--help` switch (short switches are currently out of order because I fucked up ...).

```
C:\Users\MyAccount\AppData\Roaming\Nuclear.Test.Console>Nuclear.Test.Console.exe --help
Usage: Nuclear.Test.Console.exe [OPTIONS]

  -h                                       Display this help context.
  --help                                   Same as -h.

  -c path                                  The configuration file path.
  --config path                            Same as -c.

  -f path                                  Override to specify one specific test assembly.
  --file path                              Same as -f.

  -d path                                  Override to specify a search directory.
  --dir path                               Same as -d.
```

The configuration file can be adapted your local system if required.
Specific test scenarios can use their own configuration files in combination with the `--config <path>` switch.
The value for `Locator`.`SearchDirectory` can be overridden using the `--dir <path>` switch, which is handy for `Visual Studio` integration.
Giving a specific file path using the `--file <path>` switch will ignore the `Locator` section and attempt to load the given file instead.

```json
{
    "Locator": {
        "SearchDirectory": "D:/Dev/GitHub/Nuclear.Net/bin",
        "SearchDepth": -1,
        "SearchPattern": "*Tests.dll",
        "IgnoredDirectoryNames": [
            "obj",
            ".vs",
            "Debug",
            "Integration"
        ]
    },
    "Clients": {
        "ProxyDirectory": "%APPDATA%/Nuclear.Test.Proxy/",
        "ProxyExecutableName": "Nuclear.Test.Proxy.exe",
        "WorkerDirectory": "%APPDATA%/Nuclear.Test.Worker/",
        "WorkerExecutableName": "Nuclear.Test.Worker.exe",
        "StartClientVisible": true,
        "AutoShutdown": false
    },
    "Execution": {
        "AssembliesInSequence": true,
        "TestsInSequence": false,
        "SelectedRuntimes": "All"
    }
}
```

Possible values for `SelectedRuntimes` are `Lowest`, `Highest`, `All`.
These will execute the workers with the lowest version, the highest version or all available workers for a specific platform.
There is going to be more documentation in the future along with pretty pictures to clarify the matter.