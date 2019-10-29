rmdir /S /Q publish

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.0 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETCore2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.0 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCore2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.0 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCore2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.1 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETCore2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.1 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCore2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.1 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCore2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETCore2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETCore2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETCore2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net461\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.6.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net461\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net461\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.1\

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net462\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.6.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net462\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.6.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net462\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.6.2\

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net47\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.7\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net47\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net47\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7\

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net471\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.7.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net471\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.1\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net471\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.1\

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net472\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.7.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net472\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.7.2\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net472\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.7.2\

xcopy /Y src\bin\Nuclear.Test.Worker\AnyCPU\Release\net48\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\MSIL\NETFramework4.8\
xcopy /Y src\bin\Nuclear.Test.Worker\x64\Release\net48\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\Amd64\NETFramework4.8\
xcopy /Y src\bin\Nuclear.Test.Worker\x86\Release\net48\* publish\Nuclear.Test.Console\Nuclear.Test.Worker\X86\NETFramework4.8\

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Proxy\MSIL\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj
dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Proxy\Amd64\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\Nuclear.Test.Proxy\X86\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o ..\..\publish\Nuclear.Test.Console\ src\Nuclear.Test.Console\Nuclear.Test.Console.csproj

pause