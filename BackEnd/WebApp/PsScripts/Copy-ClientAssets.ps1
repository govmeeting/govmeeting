# Copy-ClientAssets.ps1
# This script is meant to be run from the WebApp folder as a pre-build step.
# The location of the ClientApp relative to the WebApp is passed as "$source".

Function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 1)] [string] $source
    )

    $usage = "@
    Usage: Copy-ClientAssets <source-folder>
    #    <source-folder> - Angular ClientApp folder relative to the WebApp
    # Copy contents of ClientApp/dist/ClientApp to WebApp/wwwroot.
@"
    $me = "Copy-ClientAssets: "

    $GOVMEETING = $true

    # Uncomment the notice you want to get.
    #[void][Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
    #[void][System.Windows.Forms.MessageBox]::Show("It works.")
    #[Console]::Beep(600, 800)

    Write-Host "$me Running pre-build script Copy-ClientAssets.ps1 " -NoNewline
    Write-Host @args

    $location = Get-Location
    Write-Host "$me My location is $location"

    $destination = $location.Path
    $_sourceAssets = "dist\ClientApp"
    $_destAssets = "wwwroot"


    if ($GOVMEETING)
    {
        $webapp = "BackEnd\WebApp".ToLower()
        $source = join-path $destination $source

    } else {
        $webapp = "WebApp".ToLower()
        $source = "C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp"
    }

    ##################   Check Web App location   ########################

    # When this command is run, we should already be in Backend\WebApp
    # But we want to make absolutely sure. We will be deleting the contents of this folder.
    if (!($destination.ToLower().EndsWith($webapp)))
    {
        echo "$me ERROR Current location should end with $webapp"
        exit
    }


    ##################   set assets destination   ########################


    $destAssets = join-path $destination $_destAssets
    echo "$me destAssets is $destAssets"
    if (!(Test-Path $destAssets -pathType container))
    {
        echo "$me ERROR $destAssets does not exist"
        exit
    } 

    ##################   set assets source   ########################
    
    $sourceAssets = [IO.Path]::GetFullPath( (join-path $source $_sourceAssets) )
    echo "$me sourceAssets is $sourceAssets"
    if (!(Test-Path $sourceAssets -pathType container))
    {
        echo "$me ERROR $sourceAssets does not exist"
        exit
    }


    ##################  Copy Assets   ########################

    CopyClientAssets $sourceAssets $destAssets

}


Function CopyClientAssets
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 1)] [string] $sourceAssets,
        [Parameter(Mandatory = $true, Position = 2)] [string] $destAssets
    )

    DeleteClientAssets $destAssets

    # DeleteFolderContentsMax100 $destAssets

    CopyFolderContents $sourceAssets $destAssets

}


Function DeleteClientAssets($folder)
{
# The client assets consist of the files in ClientApp/dist/ClientApp and
# the single "assets" folder in that location.
# Deleting the files in WebApp/wwwroot is easy. But, I tried all of the solutions for quietly deleting
# the assets folder and its contents, that I found at:
# https://stackoverflow.com/questions/7909167/how-to-quietly-remove-a-directory-with-content-in-powershell
# All of them randomly failed, depending on where I ran the commands (in the ISE, as a pre-build task, etc).
# This seems to be because of the asynchronous way Windows executes Remove-Item.
# See: https://stackoverflow.com/a/53561052/1978840
# The easiest way around this for deleting the assets folder is to:
#   1. First delete all files recursively.
#   2. Then delete all folders (non-recursively).
#   3. Then delete the assets folder.
# This solution depends on the fact that the folders in wwwroot/assets are only one level deep.


   echo "$me Deleting existing files in $folder"
   Get-Childitem $folder -File | ForEach-Object { 
        Remove-Item $_.FullName
    }

    $assetsFolder = $folder + "\assets"

    if ((Test-Path $assetsFolder -pathType container))
    {
        echo "$me Deleting existing files in $assetsFolder"
        Get-Childitem $assetsFolder -File -Recurse| ForEach-Object { 
            Remove-Item $_.FullName-Force
        }
        echo "$me Deleting existing folders in $assetsFolder"
        Get-Childitem $assetsFolder -Directory -Recurse| ForEach-Object { 
            Remove-Item $_.FullName-Force
        }
        echo "$me Deleting $assetsFolder"
        Remove-Item $assetsFolder
    }
}


# Delete folder contents, but not if it contains > 100 items.
Function DeleteFolderContentsMax100($folder)
{
    # deleting everything in a user-supplied folder name is dangerous.
    # Count the items that we will delete and abort if over 100.
    $count = ( Get-ChildItem $folder -Recurse | Measure-Object ).Count
    if ($count -gt 100)
    {
        echo "ERROR  $me There are $count items in $folder. Are you sure you want to delete it?"
        exit
    }

    Get-Childitem $folder -Recurse | ForEach-Object { 
        Remove-Item $_.FullName -Recurse -Force
    }
}

Function CopyFolderContents($source, $destination)
{
    echo "$me Copying $source to $destination"
    $sourceContents = $source + "\*"
    Copy-item -Recurse $sourceContents -Destination $destination
}


# Execute Main function. This is excecuted first.
# Main @args

# Pass location of ClientApp relative to the WebApp
$source = "..\..\FrontEnd\ClientApp"

Main $source


#DeleteClientAssets c:\tmp\wwwroot