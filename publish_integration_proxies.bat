dotnet publish --self-contained true -r win-x64 -c Integration -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Proxy\Amd64\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj
dotnet publish --self-contained true -r win-x86 -c Integration -f netcoreapp3.1 -o %APPDATA%\Nuclear.Test.Proxy\X86\ src\Nuclear.Test.Proxy\Nuclear.Test.Proxy.csproj

pause