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

  # If no params passed and repo is installed in C:\GOVMEETING|_SOURCECODE
  if ($clientapp -eq "") { $clientapp = "C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp" }
  if ($readme -eq ""){ $readme = "C:\GOVMEETING\_SOURCECODE\README.md" }
    
  # $me = "BuildProjectReadme: "
  # $useAllofSetup = $true

  ## If we are not passed the locations of ClientApp and README.md,
  ## assume we are running this script from Utilities\PsScripts and we know their relative locations.
  # if ($clientapp -eq "") {
  #   $clientapp = GetFullPath "..\..\FrontEnd\ClientApp"
  #   $readme = GetFullPath "..\..\README.md"
  # }

# Put this before the overview doc.
$preOverview =
@"
<!-- Do not edit README.md. This file is built by Utilities/PsScripts/Build-ProjectReadme.ps1 -->
`n# Overview `n
"@

# Put this after the overview doc
$postOverview =
@"
<!-- `n<a href="http://www.govmeeting.org/overview#continue">Overview Continued</a>`n -->

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

Enough with the jibber-jabber, fool!
Show me how it works!

Well, the work is in progress. But click here for:  [Demos of some working parts](http://govmeeting.org/dashboard) and more documentation.

<div> <img style="pointer-events: none; cursor: default;" src="images/GovmeetingEmail 75p.png" alt="Govmeeting Email"> </div>
<div style="font-size: 125%">  
 <a href="https://join.slack.com/t/govmeeting/shared_invite/zt-eavi8zwh-4t900JzP~WJCo2Z7Z2tk0A"> Govmeeting Slack <img src="images/logo_slack25p.png"> </a> </div>

"@

# Put this before the setup doc.
$preSetup =
@"
`n# Developer Setup `n
"@

# Put this after the setup doc.
$postSetup =
@"
`n<a href="http://www.govmeeting.org/about?id=setup#continue">Setup Continued</a>`n
"@


    ###### Create overview portion of README.md

    # Read the overview doc
    $overviewDoc = $clientapp + "\src\assets\docs\overview1.md"
    $overview = get-content -Raw $overviewDoc

    # Take from start of readme section
    $starttext = '<!-- START OF README SECTION -->'
    $index = $overview.IndexOf($starttext)
    if ($index -gt 0) {
      $overview = $overview.Substring($index + $starttext.Length)
    }

    # to the end of readme section
    $index = $overview.IndexOf('<!-- END OF README SECTION -->')
    if ($index -gt 0) {
      $overview = $overview.Substring(0, $index)
    }

    # Combine with pre and post sections
    $overview = $preOverview + $overview + $postOverview


    ###### Create setup portion of README.md

    # read the setup doc
    $setupDoc = $clientapp + "\src\assets\docs\setup.md"
    $setup = get-content -Raw $setupDoc

    # $index = $setup.IndexOf('<!-- START OF README SECTION -->')
    # if ($index -gt 0) {
    #   $setup = $setup.Substring($index + $starttext.Length)
    # }

    # modify some content
    $setup = ModifyContent $setup
    $setup = $preSetup + $setup + $postSetup

    # Write both portions to README.md
    $overview + $setup | set-content $readme
}

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}

function ModifyContent($setup)
{
  $contentLink = "about?id=setup"
  # $setup = $setup -replace $contentLink, ""
  $setup = $setup.Replace($contentLink, "")

  return $setup
}

BuildReadme @args