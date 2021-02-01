function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $webapp
    )
    Write-Host "############################ Publish-WebApp.ps1 ############################"
   
    $WORKSPACE_ROOT = "C:\GOVMEETING\_SOURCECODE"

    # If no params passed and repo is installed in C:\GOVMEETING|_SOURCECODE
    if ($webapp -eq "") { $webapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\WebApp.csproj" }

    dotnet publish --configuration release $webapp
}

Main @args

# dotnet publish --configuration release $WORKSPACE_ROOT + "\src\WebUI\WebApp\WebApp.csproj"