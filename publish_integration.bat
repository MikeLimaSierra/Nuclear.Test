rmdir /S /Q publish

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.0 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.0 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.1 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.1 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net461\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net461\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.1\

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net462\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net462\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.2\

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net47\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net47\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7\

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net471\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net471\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.1\

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net472\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net472\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.2\

xcopy /Y src\bin\Nuclear.Test.Worker\x64\Integration\net48\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.8\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Integration\net48\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.8\

dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Proxy\Amd64\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Proxy\X86\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj

dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\ src\Nuclear.Test.Console\Nuclear.Test.Console.csproj

pause