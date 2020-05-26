set /p version=type in version:

echo push WebApiClient.JIT.%version%.nupkg to http://nuget.mistong.com

dotnet nuget push ..\WebApiClient\bin\JIT_Release\WebApiClient.JIT.%version%.nupkg -k fd13cd19-93fd-4fe7-b34d-89844e501ca3 -s http://nuget.mistong.com

pause