dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.0 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.0 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

xcopy /Y bin\Nuclear.Test.Worker\x64\Integration\net461\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\
xcopy /Y bin\Nuclear.Test.Worker\x86\Integration\net461\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.6.1\

pause
