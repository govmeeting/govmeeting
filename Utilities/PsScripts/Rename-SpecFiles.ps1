$path = 'C:\GOVMEETING\_SOURCECODE\frontend\clientapp\src\app'

Get-ChildItem -Path $path -Filter *.spec.ts -Recurse | ForEach-Object {
    $oldname = $_.FullName
    $newname = $_.FullName + ".XX"
    Write-Host $oldname
    Rename-Item $oldname $newname
}

# Get-ChildItem -Path $path -Filter *.spec.ts -Recurse -File -Name| ForEach-Object {
