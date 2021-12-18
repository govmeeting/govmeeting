# This PS script assumes that the bin folder of the Google Cloud SDK is in our path.
# On Windows, this should be:
#   ~\AppData\Local\Google\Cloud SDK\google-cloud-sdk\bin

# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1

function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $clientapp
    )
	
	$WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"

      # If no params passed
    if ($clientapp -eq "") {
        $clientapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\clientapp" 
    }
    .\Build-ClientApp.ps1 $clientapp


    # Get the path to gcloud.bat in bin
    $gcloudcmd = (get-command gcloud.cmd).Path
    # Get the path to the "Cloud SDK" folder
    $CloudSdk = Get-ParentPath $gcloudcmd 3
    cd $CloudSdk

    # for debugging:
    # gcloud compute scp c:\TMP\y.txt govmeeting-clientapp:y.txt

    # Copy the client distribution files to the "staging" folder in the VM.
    # First delete the contents of "staging".
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo rm -r staging/*"
    $clientdist = "C:\GOVMEETING\_SOURCECODE\src\WebUI\WebApp\clientapp\dist"
    gcloud compute scp --recurse $clientdist/* govmeeting-clientapp:staging/
    # Change the ownership of the files to "www-data" for the Apache server.
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo chown -R www-data:www-data staging/*"

    # Deploy to the Apache server
    # Remove the old
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo rm -r /var/www/html/*"
    # install the new
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo cp -r staging/* /var/www/html"
    # Change ownership
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo chown -R www-data:www-data /var/www/html/*"
    # restart the server
    gcloud compute ssh --zone us-east1-b govmeeting-clientapp --command "sudo systemctl reload apache2"
   }

function Get-ParentPath($path, [int]$gen) {
    while ( 1 -eq 1 ) {
        $parent = Split-Path -Path $path
            if (--$gen -lt 1 ) {
                return $parent
            }
            return Get-ParentPath $parent $gen

    }
    return $path
}

Main
transcribeaudi