# BuildProjectReadme.ps1
# Build the project's Readme.md from overview.md and setup.md in ClientApp/src/assets/docs.

Function BuildReadme
{
    $me = "BuildProjectReadme: "
    $useAllofSetup = $true

$preSetup =
@"
`n# Developer Setup `n
"@

$postSetup =
@"
`n<a href="http://www.govmeeting.org/about?id=setup#continue">Setup Continued</a>`n
"@

$postOverview =
@"
`n<a href="http://www.govmeeting.org/overview#continue">Overview Continued</a>`n
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

    $overviewDoc = "src/assets/docs/overview.md"
    $setupDoc = "src/assets/docs/setup.md"

    $overview = get-content -Raw $overviewDoc
    $index = $overview.IndexOf('<!-- END OF README SECTION -->')
    if ($index -gt 0) {
      $overview = $overview.Substring(0, $index) + $postOverview
    }

    $setup = get-content -Raw $setupDoc
    if ($useAllOfSetup){
      $setup = $preSetup + $setup
    } else {
      $index = $setup.IndexOf('<!-- END OF README SECTION -->')
      if ($index -gt 0) {
        $setup = $preSetup + $setup.Substring(0, $index) + $postSetup
      }
    }

    $overview + $setup | set-content ../../README.MD

    if ($pushedLocation){
      pop-location
    }
}

BuildReadme @args
