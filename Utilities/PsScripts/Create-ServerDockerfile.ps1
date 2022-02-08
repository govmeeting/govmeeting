$s = 'Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Configuration_Lib", "src/Application/Configuration_Lib/Configuration_Lib.csproj", "{3E3A57CA-F58A-40A3-A3C6-D8006D289EA6}"'
$s = $s -replace '^Project\(.*, \"src/', 'src/'

Get-Content  C:\tmp\govmeeting.sln | ForEach-Object {
    if ($_ -match '^Project') {
        $s = $_ -replace '[\\]', '/'
        $s = $s -replace '^Project\(.*, \"src/', 'src/'
        $s = $s -replace 'Project\(.*}\"', ''
        $s = $s -replace '\", \"{.*', ''
        if ($s -ne '') {
            "COPY ./$s ./$s"
        }
    }
} | Set-Content -path c:\tmp\names.txt


$s = $s

# $s = $s -replace '^', 'COPY'
