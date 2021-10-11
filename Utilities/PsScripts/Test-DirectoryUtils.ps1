# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1


$WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"
if ($null -eq $WORKSPACE_ROOT)
{
	Write-Host "ERROR: $me Cannot find Govmeeting.sln in a parent folder"
	exit
}

$clientapp = CombinePaths $WORKSPACE_ROOT "src\WebUI\WebApp\clientapp"

Write-Host "solution = " $WORKSPACE_ROOT
Write-Host "client = " $clientapp