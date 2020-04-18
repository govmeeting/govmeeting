function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $webapp
    )
    Write-Host "############################ Publish-WebApp.ps1 ############################"

    dotnet publish --configuration release $webapp
}

Main @args