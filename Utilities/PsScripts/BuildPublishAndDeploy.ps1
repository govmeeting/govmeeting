# BuildPublishAndUpload.ps1
# Build ClientApp, publish WebApp and upload to production.

# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1

function Main
{
    $me = "BuildPublishAndUpload.ps1"

    $WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"
    if ($null -eq $WORKSPACE_ROOT)
    {
        Write-Host "ERROR: $me Cannot find Govmeeting.sln in a parent folder"
        exit
    }

    $clientapp = CombinePaths $WORKSPACE_ROOT "src\WebUI\WebApp\clientapp"
    $webapp = CombinePaths $WORKSPACE_ROOT  "src\WebUI\WebApp"
    $secrets = CombinePaths $WORKSPACE_ROOT  "..\SECRETS"
    $readme = CombinePaths $WORKSPACE_ROOT  "README.md"
    $publish = $webapp + "\bin\release\netcoreapp2.2\publish"
    $appmodule = $clientapp + "\src\app\app.module.ts"

    .\Build-ProjectReadme.ps1 $clientapp $readme

    # Set IsAspServerRunnning to false.
    # The demo at govmeeting.org will use the client stubs for data
    .\Set-IsAspServerRunning.ps1 $appmodule $false
    .\Build-ClientApp.ps1 $clientapp
    # .\Set-IsAspServerRunning.ps1 $appmodule $true

    .\Publish-WebApp.ps1 $webapp

    .\Copy-ClientAssets.ps1 $clientapp $publish
    
    .\Deploy-PublishFolder.ps1 $publish $secrets 
}

Main

# Uncomment the notice(s) you want to get.
#[void][Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
[Console]::Beep(600, 800)
# [void][System.Windows.Forms.MessageBox]::Show("BuildPublishAndSeploy completed.")


