# BuildProjectReadme.ps1
# Build the project's Readme.md from overview.md and setup.md in ClientApp/src/assets/docs.

Function BuildReadme
{

  [CmdletBinding()]
  param (
      [Parameter(Position = 1)] [string] $clientapp,
      [Parameter(Position = 2)] [string] $readme
  )
  Write-Host "############################ Build-ProjectReadme.ps1 ############################"

    $me = "BuildProjectReadme: "
    $useAllofSetup = $true

  if ($clientapp -eq "") {
    $clientapp = GetFullPath "..\..\FrontEnd\ClientApp"
    $readme = GetFullPath "..\..\README.md"
  }

$preSetup =
@"
`n# Developer Setup `n
"@

$postSetup =
@"
`n<a href="http://www.govmeeting.org/about?id=setup#continue">Setup Continued</a>`n
"@

$preOverview =
@"
`n# Overview `n
"@

$postOverview =
@"
<!-- `n<a href="http://www.govmeeting.org/overview#continue">Overview Continued</a>`n -->

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

Enough with the jibber-jabber, fool!
Show me how it works!

Well, the work is in progress. But here you can find [Demos of some working parts](http://govmeeting.org/dashboard) and more documentation.

<img src="images/GovmeetingEmail 75p.png" alt="Govmeeting Email">


"@

    $overviewDoc = $clientapp + "\src\assets\docs\overview.md"
    $setupDoc = $clientapp + "\src\assets\docs\setup.md"

    $overview = get-content -Raw $overviewDoc

    $starttext = '<!-- START OF README SECTION -->'
    $index = $overview.IndexOf($starttext)
    if ($index -gt 0) {
      $overview = $overview.Substring($index + $starttext.Length)
    }
    $overview = $preOverview + $overview

    $index = $overview.IndexOf('<!-- END OF README SECTION -->')
    if ($index -gt 0) {
      $overview = $overview.Substring(0, $index) + $postOverview
    }

    $setup = get-content -Raw $setupDoc
    # $starttext = '<!-- START OF README SECTION -->'
    # $index = $setup.IndexOf($starttext)
    # if ($index -gt 0) {
    #   $setup = $setup.Substring($index + $starttext.Length)
    # }

    $setup = ModifyContentLinks $setup

    $setup = $preSetup + $setup + $postSetup

    $overview + $setup | set-content $readme
}

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}

function ModifyContentLinks($setup)
{
  $contentLink = "about?id=setup"
  # $setup = $setup -replace $contentLink, ""
  $setup = $setup.Replace($contentLink, "")
  return $setup
}

BuildReadme @args