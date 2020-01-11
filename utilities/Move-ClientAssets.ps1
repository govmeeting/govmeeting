# move-client-assets.ps1

function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, Position = 1)] [string] $source,
        [Parameter(Mandatory = $true, Position = 2)] [string] $destination,
        [Parameter(Mandatory = $true, Position = 3)] [string] $layout,
        [Parameter(Mandatory = $true, Position = 4)] [string] $homeview
    )

    $usage = "@
    Usage: move-client-assets <source-folder> <destination-folder> <index-page>
    #    <source-folder> - Angular ClientApp folder
    #    <destination-folder> - Asp.Net WebApp folder
    #    <layout> - relative path in WebApp to _layout.cshtml
    #    <homeview> - relative path in WebApp to index.cshtml of HomeController.
    # Move assets from ClientApp to Web_App.
    # Step 1: Move files from dist folder in ClientApp to wwwroot folder in WebApp.
    # Step 2: Edit _layout.cshtml file to match index.html in ClientApp (with slight modifications).
@"

    if (!(Test-Path $source -pathType container))
    {
        echo "$source does not exist"
        echo $usage
        exit
    }

    $oDir = Get-Item $source
    $DirName = $oDir.Name
    $sourceAssets = $source + "\dist\" + $DirName
    $destAssets = $destination + "\wwwroot"

    CheckFolderLocations $sourceAssets $destAssets

    DeleteFolderContentsMax100 $destAssets

    CopyFolderContents $sourceAssets $destAssets

    $indexpage = $destAssets + "\index.html"
    $layoutpage = $destination + "\" + $layout
    $homepage = $destination + "\" + $homeview

    CheckFileLocations $indexpage $layoutpage $homepage

    # $content = (EditLayoutPage $indexpage, $homepage)

    EditLayoutPage $indexpage | set-content $layoutpage

    "<app-root></app-root>"  | set-content $homepage

}


Function CheckFolderLocations
{
    param($sourceAssets, $destAssets, $indexpage, $layoutpage)

    if (!(Test-Path $sourceAssets -pathType container))
    {
        echo "$sourceAssets does not exist"
        echo $usage
        exit
    }
    if (!(Test-Path $destAssets -pathType container))
    {
        echo "$destAssets does not exist"
        echo $usage
        exit
    } 
}

Function CheckFileLocations
{
    param($indexpage, $layoutpage, $homepage)

    if (!(Test-Path $indexpage -pathType leaf))
    {
        echo "$indexpage does not exist"
        echo $usage
        exit
    }

    if (!(Test-Path $layoutpage -pathType leaf))
    {
        echo "$layoutpage does not exist"
        echo $usage
        exit
    }

    if (!(Test-Path $homepage -pathType leaf))
    {
        echo "$homepage does not exist"
        echo $usage
        exit
    }
}

# Delete folder contents, but not if it contains > 100 items.
Function DeleteFolderContentsMax100($folder)
{
    # deleting everything in a user-supplied folder is dangerous.
    # Count the items that we will delete and abort if over 100.
    $count = ( Get-ChildItem $folder -Recurse | Measure-Object ).Count
    if ($count -gt 100)
    {
        echo "There are $count items in $folder."
        echo "Are you sure you want to delete it?"
        exit
    }

    Get-Childitem $folder -Recurse | ForEach-Object { 
        Remove-Item $_.FullName -Recurse -Force
    }
}

Function CopyFolderContents($source, $destination)
{
    $sourceContents = $source + "\*"
    Copy-item -Recurse $sourceContents -Destination $destination
}

Function EditLayoutPage($page)
{
    # No, this is not the fastest nor the most compact way to do this.
    # But it is a lot more readable than doing it in one command line.
    # And there is no reason to care about speed.
    $content = get-content $page
    $content = $content -replace '<app-root></app-root>','@RenderBody()'
    $content = $content -replace 'script src="(?!http)', 'script src="~/'
    $content = $content -replace 'rel="stylesheet" href="(?!http)', 'rel="stylesheet" href="~/'
    $content = $content -replace 'link rel="icon" type="image/x-icon" href="', 'link rel="icon" type="image/x-icon" href="~/'
    return $content
}


# Execute Main function. This is excecuted first.
# Main @args

#$source = "C:\GOVMEETING\_WORKAREA\WORK\aspnet-barebone\mvc\ClientApp"
#$destination = "C:\GOVMEETING\_WORKAREA\WORK\aspnet-barebone\mvc\Web_App"
#$layout = "Views\shared\_layout.cshtml"
#$homeview = "Views\Home\index.cshtml"

$source = "C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp"
$destination = "C:\GOVMEETING\_WORKAREA\WORK\aspnet-barebone\mvc\Web_App"
$layout = "Views\shared\_layout.cshtml"
$homeview = "Views\Home\index.cshtml"


Main $source $destination $layout $homeview
