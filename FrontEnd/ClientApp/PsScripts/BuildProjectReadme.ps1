# BuildProjectReadme.ps1
# Build the project's Readme.md from tpurpose.md and startup.md in ClientApp/src/assets/docs.

Function BuildReadme
{
    $me = "BuildProjectReadme: "

$preSetup =
@"
`n# Developer Setup `n
"@

$postSetup =
@"
`nWhen you install and run ClientApp, you will find additional setup instructions on its Setup documentation page.`n
"@

    $loc = Get-Location
    $location = $loc.ToString()
    Write-Host "$me My location is $location"
    $pushedLocation = $false

    # We want the location to be ClientApp
    if (!($location.EndsWith('ClientApp'))) {
      $index = $location.IndexOf('ClientApp')
      if ($index -lt 0) {
        Write-Host Location is "$location It should be in ClientApp"
        exit
      }
      $location = $location.SubString(0, $index + 9)
      push-location $location
      $pushedLocation = $true
    }

    $purposeDoc = "src/assets/docs/overview.md"
    $setupDoc = "src/assets/docs/setup.md"

    $purpose = get-content -Raw $purposeDoc
    $index = $purpose.IndexOf('<!-- END OF README SECTION -->')
    if ($index -gt 0) {
      $purpose = $purpose.Substring(0, $index)
    }

    $setup = get-content -Raw $setupDoc
    $index = $setup.IndexOf('<!-- END OF README SECTION -->')
    if ($index -gt 0) {
      $setup = $preSetup + $setup.Substring(0, $index) + $postSetup
    }

    $purpose + $setup | set-content ../../README.MD

    if ($pushedLocation){
      pop-location
    }
}

BuildReadme @args
