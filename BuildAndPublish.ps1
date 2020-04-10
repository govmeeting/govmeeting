Push-Location FrontEnd\ClientApp
.\PsScripts\SetIsAspServerRunning.ps1 ".\src\app\app.module.ts" $false
.\PsScripts\BuildProjectReadme.ps1
npm run build
.\PsScripts\SetIsAspServerRunning.ps1 ".\src\app\app.module.ts" $true
Pop-Location

Push-Location BackEnd\WebApp
.\PsScripts\Publish-WebApp.ps1
.\PsScripts\Copy-ClientAssets.ps1
Pop-Location