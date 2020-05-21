function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $webapp
    )
    Write-Host "############################ Publish-WebApp.ps1 ############################"
   
    # If no params passed and repo is installed in C:\GOVMEETING|_SOURCECODE
    if ($webapp -eq "") { $webapp = "C:\GOVMEETING\_SOURCECODE\BackEnd\WebApp\WebApp.csproj" }

    dotnet publish --configuration release $webapp
}

Main @args

# dotnet publish --configuration release C:\GOVMEETING\_SOURCECODE\BackEnd\WebApp\WebApp.csproj