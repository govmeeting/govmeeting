# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1
function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $webapp
    )
    Write-Host "############################ Publish-WebApp.ps1 ############################"
   
    $WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"

    # If no params passed
    if ($webapp -eq "") { $webapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\WebApp.csproj" }

    dotnet publish --configuration release $webapp
}

Main @args

# dotnet publish --configuration release $WORKSPACE_ROOT + "\src\WebUI\WebApp\WebApp.csproj"