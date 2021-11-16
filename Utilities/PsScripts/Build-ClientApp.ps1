# Build-ClientApp.ps1
# The location of the ClientApp relative to the WebApp is passed as "$source".

Function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 1)] [string] $clientapp
    )

    Write-Host "############################ Build-ClientApp.ps1 ############################"

    $usage = "@
    Usage: Build-ClientApp <CLientApp folder>
@"
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

