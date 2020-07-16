# BuildPublishAndUpload.ps1
# Build ClientApp, publish WebApp and upload to production.
function Main
{
    $me = "BuildPublishAndUpload.ps1"

    $solutionFolder = Find-ParentFolderContaining "Govmeeting.sln"
    if ($null -eq $solutionFolder)
    {
        Write-Host "ERROR: $me Cannot find Govmeeting.sln in a parent folder"
        exit
    }

    $clientapp = CombinePaths $solutionFolder "FrontEnd\ClientApp"
    $webapp = CombinePaths $solutionFolder  "BackEnd\WebApp"
    $secrets = CombinePaths $solutionFolder  "..\SECRETS"
    $readme = CombinePaths $solutionFolder  "README.md"
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

function Find-ParentFolderContaining($file)
{
    $directory = Get-Location
    Do {
        $filePath = [IO.Path]::Combine($directory, $file)
        if ([IO.File]::Exists($filePath))
        {
            return $directory
        }
        $directory = [IO.Path]::GetDirectoryName($directory)
        Write-Host  ("filePath=" + $filePath + " directory=" + $directory)
        
    } while ($null -ne $directory)
    return $null
}

function CombinePaths($p1, $p2)
{
    $c = [IO.Path]::Combine($p1, $p2)
    $f = [IO.Path]::GetFullPath($c)
    return $f
}

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}


Main

# Uncomment the notice(s) you want to get.
#[void][Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
[Console]::Beep(600, 800)
# [void][System.Windows.Forms.MessageBox]::Show("BuildPublishAndSeploy completed.")


