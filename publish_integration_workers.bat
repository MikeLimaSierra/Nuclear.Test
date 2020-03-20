dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.1 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.1 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.2 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.2 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp3.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp3.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp3.0 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp3.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish -r win-x64 -c Integration -f net461 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net461 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
			   
dotnet publish -r win-x64 -c Integration -f net462 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net462 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
			   
dotnet publish -r win-x64 -c Integration -f net47 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net47 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
			   
dotnet publish -r win-x64 -c Integration -f net471 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net471 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
			   
dotnet publish -r win-x64 -c Integration -f net472 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net472 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
			   
dotnet publish -r win-x64 -c Integration -f net48 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.8\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish -r win-x86 -c Integration -f net48 -o publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.8\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

pause