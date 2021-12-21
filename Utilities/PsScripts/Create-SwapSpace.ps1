# Create-SwapSpace.ps1 - create a swap space on a Compute Engine VM
# This copies a bash script to the VM and executes it.

# This PS script assumes that the bin folder of the Google Cloud SDK is in our path.
# On Windows, this should be:
#   ~\AppData\Local\Google\Cloud SDK\google-cloud-sdk\bin

# import utility functions for dealing with directory paths:
Import-Module ./DirectoryUtils.psm1

function Main
{
    # ======== Set the GCP project, zone and VM names =========
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $GCP_VM
    )
    # If no params passed
    if ($GCP_VM -eq "") {
        $GCP_VM = "govmeeting-webapp"
    }
    $GCP_PROJECT = "deploy-dotnet-angular-02"
    $GCP_ZONE = "us-east1-b"
	# ==========================================================

    # Get the location of the bash script
	$WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"
     $bash_cmd = $WORKSPACE_ROOT + "/Utilities/BashScripts/create-swap-space.sh"
    $dest = $GCP_VM + ":"

    # Set the GCP project in GCP config
    gcloud config set project $GCP_PROJECT
    # Copy the bash script to the VM
    gcloud compute scp --zone $GCP_ZONE $bash_cmd $dest
    # Set execute property on script
    gcloud compute ssh --zone $GCP_ZONE $GCP_VM --command "chmod ug+x create-swap-space.sh"
    # Execute script on VM
    gcloud compute ssh --zone $GCP_ZONE $GCP_VM --command "sudo ./create-swap-space.sh"
    # Change config to mount the swap space on re-boots. Edit /etc/fstab.
    # Note that we need to use "sudo tee -a" instead of ">>" to append to the file, because
    #  redirecting streams is done with the same permissions as the original caller. 
    gcloud compute ssh --zone $GCP_ZONE $GCP_VM --command "sudo echo '/swapfile swap swap defaults 0 0' | sudo tee -a /etc/fstab"
    # Mount all filesystems in fstab
    gcloud compute ssh --zone $GCP_ZONE $GCP_VM --command "sudo mount -a"

    # You can run "htop" to check that the swap space is available
}


Main @args
