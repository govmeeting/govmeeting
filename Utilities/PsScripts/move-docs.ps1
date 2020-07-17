# Temporary script to move some files.


$docs = "C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp\src\assets\docs"
Set-Location $docs

# foreach ($lang in "AR","BN", "DE", "ES", "FI", "FR", "HI", "IT", "PT", "SW", "ZH") {
#     New-Item -Path $docs -Name $lang  -ItemType "directory"
# }

Get-Childitem $docs -File | ForEach-Object { 
    $name = $_.Name
    $parts = ($name).Split(".")
    $lan = $parts[1]
    if ($lan -ne "en") {
        $newname = $parts[0] + ".md"
        $dir = $lan.ToUpper()
        Move-Item $name ($dir + "/" + $newname)
    }
}