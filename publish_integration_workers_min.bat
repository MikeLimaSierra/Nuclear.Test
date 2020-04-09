dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish -r win-x64 -c Integration -f net461 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net461 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

pause