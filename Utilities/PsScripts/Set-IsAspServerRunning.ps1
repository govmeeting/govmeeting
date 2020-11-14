Function ChangeisAspServerRunning
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 1)] [string] $file,
        [Parameter(Mandatory = $true, Position = 2)] [bool] $setTrue
    )

#     $usage = "@
#     Usage: .ps1 <file> <setTrue>
#     #    <file> - file to edit SetIsAspServerRunning- app.module.ts
#     #    <setTrue> - if true, set to true; false otherwise
# @"
    $me = "SetIsAspServerRunning: "

    $location = Get-Location
    Write-Host "$me My location is $location"

    $content = get-content $file
    if ($setTrue)
    {
        $content = $content -replace 'isAspServerRunning = false','isAspServerRunning = true'
    } else {
        $content = $content -replace 'isAspServerRunning = true','isAspServerRunning = false'
    }
    $content | set-content $file
}

ChangeisAspServerRunning @args
# ChangeisAspServerRunning ".\src\WebUI\WebApp\clientapp\src\app\app.module.ts" $false
