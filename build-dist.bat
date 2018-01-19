cd project
msbuild TypeName.sln /t:Rebuild /p:Configuration=Release
copy bin\Release\TypeName.dll ..\dist\TypeName.dll
cd ..