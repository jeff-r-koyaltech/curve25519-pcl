REM MSBuild EXE path
SET MSBuildPath="C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
SET NuGetPath="C:\Program Files (x86)\NuGet\nuget.exe"
set StagingPath=deploy\staging

REM change to the source root directory
pushd ..


REM ======================= clean =======================================

REM ensure any previously created package is deleted
del *.nupkg

REM ======================= build =======================================

REM build AnyCPU
%MSBuildPath% curve25519.csproj /property:Configuration=Release

REM create NuGet package
%NuGetPath% pack deploy\curve25519-pcl.nuspec -outputdirectory ..


REM ============================ done ==================================


REM go back to the build dir
popd
