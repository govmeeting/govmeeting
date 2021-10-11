function Find-ParentFolderContaining($file)
{
    $directory = Get-Location
    Do {
        $filePath = [IO.Path]::Combine($directory, $file)
        if ([IO.File]::Exists($filePath))
        {
            return $directory
        }
        $directory = [IO.Path]::GetDirectoryName($directory)
        # Write-Host  ("filePath=" + $filePath + " directory=" + $directory)
        
    } while ($null -ne $directory)
    return $null
}

function CombinePaths($p1, $p2)
{
    $c = [IO.Path]::Combine($p1, $p2)
    $f = [IO.Path]::GetFullPath($c)
    return $f
}

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}
