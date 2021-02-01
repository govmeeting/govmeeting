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

  $WORKSPACE_ROOT = "C:\GOVMEETING\_SOURCECODE"

  # If no params passed and repo is installed in $WORKSPACE_ROOT
  if ($clientapp -eq "") { $clientapp = $WORKSPACE_ROOT + "\src\WebUI\WebApp\clientapp" }
  if ($readme -eq ""){ $readme = $WORKSPACE_ROOT + "\README.md" }
    
# This text is inserted before the overview doc.
$preOverview =
@"
<!-- Do not edit README.md. This file is built by Utilities/PsScripts/Build-ProjectReadme.ps1 -->
`n# Overview `n
![Build frontend](https://github.com/govmeeting/govmeeting/workflows/Build%20frontend/badge.svg)
![Build Backend](https://github.com/govmeeting/govmeeting/workflows/Build%20Backend/badge.svg)
"@

# This text is inserted after the overview doc
$postOverview =
@"
<!-- `n<a href="https://www.govmeeting.org/overview#continue">Overview Continued</a>`n -->

<img src="images/mr-t-mrt-36834265-320-254-24kb.png" alt="Photo of Mr.T">
<!--This also works: ![Photo of Mr.T](images/mr-t-mrt-36834265-320-254-24kb.png) -->

Enough with the jibber-jabber, fool!
Show me how it works!

Well, the work is in progress. But click here for:  [Demos of some working code](https://govmeeting.org/dashboard) and more documentation.

<h4>
<div  style="float:left;">  
 Information or help: &nbsp; &nbsp;  <a href="https://join.slack.com/t/govmeeting/shared_invite/zt-gbuwp0tf-kqIOAeXqOTgzoauhSsqtNg"> Govmeeting Slack <img src="images/logo_slack25p.png"> </a> &nbsp; &nbsp; &nbsp;  </div>
 <div> <img style="vertical-align:middle; pointer-events: none; cursor: none;" src="images/GovmeetingEmail - crop 75p.png" alt="Govmeeting Email"> </div>
 <div style="clear: left;"/>
</h4><br/>

"@

# This text is inserted before the setup doc.
$preSetup =
@"
`n# Developer Setup `n
"@

# This text is inserted after the setup doc.
$postSetup =
@"
`n<a href="https://www.govmeeting.org/about?id=setup#continue">Setup Continued</a>`n
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