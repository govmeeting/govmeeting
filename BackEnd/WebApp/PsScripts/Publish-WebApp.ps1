Write-Host "############################ Publish-WebApp.ps1 ############################"

$location = Get-Location
Write-Host "$me My location is $location"
dotnet publish --configuration release