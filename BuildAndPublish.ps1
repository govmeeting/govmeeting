function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}

$clientapp = GetFullPath "FrontEnd\ClientApp"
$webapp = GetFullPath "BackEnd\WebApp"
$secrets = GetFullPath "..\_SECRETS"
$publish = GetFullPath ($webapp + "\bin\release\netcoreapp2.2\publish")

Push-Location $clientapp
.\PsScripts\SetIsAspServerRunning.ps1 ".\src\app\app.module.ts" $false
.\PsScripts\BuildProjectReadme.ps1
npm run build
.\PsScripts\SetIsAspServerRunning.ps1 ".\src\app\app.module.ts" $true
Pop-Location

Push-Location $webapp
.\PsScripts\Publish-WebApp.ps1
Pop-Location

BackEnd\WebApp\PsScripts\Copy-ClientAssets.ps1 $clientapp $webapp
# BackEnd\WebApp\PsScripts\Upload-PublishFolder.ps1 $webapp $publish $secrets 

