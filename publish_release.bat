rmdir /S /Q %APPDATA%\Nuclear.Test.Worker
rmdir /S /Q %APPDATA%\Nuclear.Test.Proxy
rmdir /S /Q %APPDATA%\Nuclear.Test.Console

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.0 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.0 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp2.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.1 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.1 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp2.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp2.2 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp2.2 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp2.2\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp3.0 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp3.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp3.0 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp3.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp3.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp3.1\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

dotnet publish --self-contained true -r win-x64 -c Release -f net5.0 -o %APPDATA%\Nuclear.Test.Worker\Amd64\NETCoreApp5.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f net5.0 -o %APPDATA%\Nuclear.Test.Worker\X86\NETCoreApp5.0\ src\Nuclear.Test.Worker\Nuclear.Test.Worker.csproj

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net461\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.6.1\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net461\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.6.1\

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net462\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.6.2\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net462\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.6.2\

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net47\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.7\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net47\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.7\

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net471\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.7.1\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net471\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.7.1\

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net472\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.7.2\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net472\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.7.2\

xcopy /Y bin\Nuclear.Test.Worker\x64\Release\net48\* %APPDATA%\Nuclear.Test.Worker\Amd64\NETFramework4.8\
xcopy /Y bin\Nuclear.Test.Worker\x86\Release\net48\* %APPDATA%\Nuclear.Test.Worker\X86\NETFramework4.8\

dotnet publish --self-contained true -r win-x64 -c Release -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Proxy\Amd64\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj
dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Proxy\X86\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj

dotnet publish --self-contained true -r win-x86 -c Release -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Console\ src\Nuclear.Test.Console\Nuclear.Test.Console.csproj

pause
