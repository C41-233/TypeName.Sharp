cd project\TypeName.Sharp
msbuild TypeName.Sharp.csproj /t:Rebuild /p:Configuration=Release
copy ..\bin\Release\TypeName.Sharp.dll ..\..\dist\TypeName.Sharp.dll
cd ..\..