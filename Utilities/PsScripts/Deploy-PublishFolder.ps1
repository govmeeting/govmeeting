# import utility functions for dealing with directory paths:
#    Find-ParentFolderContaining, CombinePaths & GetFullPath
Import-Module ./DirectoryUtils.psm1

# Load WinSCP .NET assembly
Add-Type -Path "./WinSCP/WinSCPnet.dll"
# The WinSCP .NET assembly winscpnet.dll is a .NET wrapper around WinSCP’s scripting interface
# that allows your code to connect to a remote machine and manipulate remote files over SFTP, FTP,
# WebDAV, S3 and SCP sessions from .NET languages, such as C#, VB.NET, and others, or from environments
# supporting .NET, such as PowerShell, SQL Server Integration Services (SSIS), ASP.NET and Microsoft Azure WebSite. 
# Also see: https://winscp.net/eng/docs/library_powershell#example
 
# Main script
function Main
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 1)] [string] $publish,
        [Parameter(Position = 2)] [string] $secrets
    )
	
	$WORKSPACE_ROOT = Find-ParentFolderContaining "Govmeeting.sln"

    # If no params passed
    if ($publish -eq "") { $publish = $WORKSPACE_ROOT + "\src\WebUI\WebApp\bin\release\netcoreapp3.1\publish" }
    if ($secrets -eq ""){ $secrets = $WORKSPACE_ROOT + "\SECRETS\" }

    $devSettings = GetFullPath ($secrets + "\appsettings.Development.json")
    $prodSettings = GetFullPath ($secrets + "\appsettings.Production.json")
    $localFolder = $publish
    $remoteFolder = "/httpdocs/"
    $webConfig = "/httpdocs/web.config"
  
    $s = Get-Content -Raw -Path $devSettings
    $appsettings = $s | ConvertFrom-Json

    $user = $appsettings.Ftp.username
    $pass = $appsettings.Ftp.password
    $domain = $appsettings.Ftp.domain

    try
    {
        $sessionOptions = New-Object WinSCP.SessionOptions -Property @{
            # Protocol = [WinSCP.Protocol]::Sftp
            Protocol = [WinSCP.Protocol]::ftp
            HostName = $domain
            UserName = $user
            Password = $pass
            # SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxx...="
        }
    
        $session = New-Object WinSCP.Session
        try
        {
            # Will continuously report progress of synchronization
            $session.add_FileTransferred( { FileTransferred($_) } )
    
            # Connect
            $session.Open($sessionOptions)
    
            # Removing web.config stops WebApp
            try {
            $session.RemoveFile($webConfig)
            } catch {}
            Start-Sleep -s 3        # give it time to stop

            # Delete all files in remote folder
            $session.RemoveFiles($remoteFolder + "*.*")

            # Upload all files in publish folder
            $putfilesResult = $session.PutFiles($localFolder + "\*", $remoteFolder)

            # Remove appsettings.Development.json
            try {
                $session.RemoveFile($remoteFolder + "/appsettings.Development.json")
            } catch {}

            # Upload appsettings.Production.json
            if (!$basicTest) {
                $session.PutFiles($prodSettings, $remoteFolder)
            }
    
            # Throw on any error
            $putfilesResult.Check()
        }
        finally
        {
            # Disconnect, clean up
            $session.Dispose()
        }
    
        exit 0
    }
    catch
    {
        Write-Host "Error: $($_.Exception.Message)"
        exit 1
    }
}

# Session.FileTransferred event handler
 
function FileTransferred
{
    param($e)
 
    if ($Null -eq $e.Error)
    {
        Write-Host "Upload of $($e.FileName) succeeded"
    }
    else
    {
        Write-Host "Upload of $($e.FileName) failed: $($e.Error)"
    }
 
    if ($Null -ne $e.Chmod)
    {
        if ($Null -eq $e.Chmod.Error)
        {
            Write-Host "Permissions of $($e.Chmod.FileName) set to $($e.Chmod.FilePermissions)"
        }
        else
        {
            Write-Host "Setting permissions of $($e.Chmod.FileName) failed: $($e.Chmod.Error)"
        }
 
    }
    else
    {
        Write-Host "Permissions of $($e.Destination) kept with their defaults"
    }
 
    if ($Null -ne $e.Touch)
    {
        if ($Null -eq $e.Touch.Error)
        {
            Write-Host "Timestamp of $($e.Touch.FileName) set to $($e.Touch.LastWriteTime)"
        }
        else
        {
            Write-Host "Setting timestamp of $($e.Touch.FileName) failed: $($e.Touch.Error)"
        }
 
    }
    else
    {
        # This should never happen during "local to remote" synchronization
        Write-Host "Timestamp of $($e.Destination) kept with its default (current time)"
    }
}
 
Main @args