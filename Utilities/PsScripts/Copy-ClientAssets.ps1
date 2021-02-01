# Copy-ClientAssets.ps1

Function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $clientapp,
        [Parameter(Position = 2)] [string] $publish
    )

    $me = "Copy-ClientAssets: "
    Write-Host "$me Running pre-build script Copy-ClientAssets.ps1 " -NoNewline
    Write-Host @args

    $WORKSPACE_ROOT = "C:\GOVMEETING\_SOURCECODE"

    # If no params passed and repo is installed in C:\GOVMEETING|_SOURCECODE
    if ($clientapp -eq "") { $clientapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\clientapp" }
    if ($publish -eq ""){ $publish = $WORKSPACE_ROOT + "\src\WebUI\WebApp\bin\release\netcoreapp2.2\publish" }

    $sourceAssets = [IO.Path]::Combine($clientapp, "dist\ClientApp")
    $destAssets = [IO.Path]::Combine($publish, "wwwroot") 

    ##################   test assets destination   ########################


    Write-Output "$me destAssets is $destAssets"
    if (!(Test-Path $destAssets -pathType container))
    {
        Write-Output "$me ERROR $destAssets does not exist"
        exit
    } 

    ##################   test assets source   ########################
    
    Write-Output "$me sourceAssets is $sourceAssets"
    if (!(Test-Path $sourceAssets -pathType container))
    {
        Write-Output "$me ERROR $sourceAssets does not exist"
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


   Write-Output "$me Deleting existing files in $folder"
   Get-Childitem $folder -File | ForEach-Object { 
        Remove-Item $_.FullName
    }

    $assetsFolder = $folder + "\assets"

    if ((Test-Path $assetsFolder -pathType container))
    {
        Write-Output "$me Deleting existing files in $assetsFolder"
        Get-Childitem $assetsFolder -File -Recurse| ForEach-Object { 
            Remove-Item $_.FullName-Force
        }
        Write-Output "$me Deleting existing folders in $assetsFolder"
        Get-Childitem $assetsFolder -Directory -Recurse| ForEach-Object { 
            Remove-Item $_.FullName-Force
        }
        Write-Output "$me Deleting $assetsFolder"
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
        Write-Output "ERROR  $me There are $count items in $folder. Are you sure you want to delete it?"
        exit
    }

    Get-Childitem $folder -Recurse | ForEach-Object { 
        Remove-Item $_.FullName -Recurse -Force
    }
}

Function CopyFolderContents($source, $destination)
{
    Write-Output "$me Copying $source to $destination"
    $sourceContents = $source + "\*"
    Copy-item -Recurse $sourceContents -Destination $destination
}

Write-Host "############################ Copy-ClientAssets.ps1 ############################"

# Execute Main function. This is excecuted first.

Main @args

