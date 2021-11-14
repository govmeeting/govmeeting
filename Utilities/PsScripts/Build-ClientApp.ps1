# Build-ClientApp.ps1 clientapp
# The location of the ClientApp relative to the WebApp can be passed as 1st arg.
# If not, it defaults to $WORKSPACE_ROOT + "\src\WebUI\WebApp\clientapp\dist"

# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1

Function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $clientapp
    )

      # If no params passed
    if ($clientapp -eq "") {
      $WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"
      $clientapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\clientapp" 
    }

    Write-Host "############################ Build-ClientApp.ps1 ############################"

    $me = "Build-ClientApp: "
    Write-Host "$me Running build script Build-ClientApp.ps1 " -NoNewline
    Write-Host @args

    if ($clientapp -ne "") {
      Push-Location $clientapp
    }

    npm install
    npm run build:prod

    if ($clientapp -ne "") {
      Pop-Location
    }

    # Uncomment the notice you want to get.
    #[void][Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
    #[void][System.Windows.Forms.MessageBox]::Show("It works.")
    #[Console]::Beep(600, 800)
}

Main $clientapp

