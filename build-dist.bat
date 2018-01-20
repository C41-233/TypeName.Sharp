cd project\TypeName
msbuild TypeName.csproj /t:Rebuild /p:Configuration=Release
copy ..\bin\Release\TypeName.dll ..\..\dist\TypeName.dll
cd ..\..