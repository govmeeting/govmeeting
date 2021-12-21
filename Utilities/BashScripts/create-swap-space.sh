# When we create a new VM in GCP Compute Engine, we need to create a swapfile
# There is a powershell script, "Create-SwapSpace.ps1" that copies this Bash
#   Shell script to the VM and executes it.

sudo fallocate -l 1G /swapfile       # pre-allocate space for a swapfile
sudo dd if=/dev/zero of=/swapfile bs=1024 count=1048576   # write zeros to swapfile
sudo chmod 600 /swapfile             # make swapfile readable only by root
sudo mkswap /swapfile                # set up a Linux swap area
sudo swapon /swapfile                # turn on swapfile

