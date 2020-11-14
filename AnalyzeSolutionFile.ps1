function Main
{
    Set-Location C:/GOVMEETING/_SOURCECODE
    Get-Location | Write-Host

    CreateSolutionSummaries
}

function CreateSolutionSummaries
{
    # In the following, we analyse the solution file "govmeeting.sln" and write two summaries:
    #   summary of all projects with their references and packages.
    #   summary of unique packages. 

    $solutionSummary = "Utilities/PsScripts/tmp/SolutionSummary.txt"
    $uniquePackages = "Utilities/PsScripts/tmp/SolutionSummary-UniquePackages.txt"

    Write-SolutionSummary $solutionSummary
    AnalyseSolutionSummary $solutionSummary $uniquePackages
}

# Write-SolutionSummary reads the solution file (.sln file) and writes
# a summary of projects, references and packages
function Write-SolutionSummary($solutionSummary) {

    $solutionPath = (Get-Location).ToString()
    $solutionFile = "govmeeting.sln"

    $sb = [System.Text.StringBuilder]::new()

    dotnet sln $solutionFile list | ForEach-Object {
        $slnLine = $_
        if (!$slnLine.StartsWith("---" )-and 
                !$slnLine.StartsWith("Project(s)") -and 
                !$slnLine.EndsWith("ClientApp\")) {
            $projectFile = [IO.Path]::Combine($solutionPath, $slnLine)
            [void]$sb.AppendLine($projectFile)

            dotnet list $projectFile reference | ForEach-Object {
                $refLine = $_
                if ((!$refLine.Contains("---" ) -and (!$refLine.Contains("Project reference")))) {
                    [void]$sb.AppendLine("        $refLineb")
                }
            }
            dotnet list $projectFile package | ForEach-Object {
                $prjLine = $_
                if ($prjLine.Contains(" > ")) {
                    $prjLine = $prjLine -replace "^ *> ", ""
                    [void]$sb.AppendLine("        $prjLine")
                }
            }
        }
    }
    $sb.ToString() | set-content $solutionSummary
}

# AnalyseSolutionSummary read the SolutionSummary.txt file and 
# analyses the results
function AnalyseSolutionSummary($solutionSummary, $uniquePackages)
{
    $summary = get-content $solutionSummary
    $packages = $summary | Where-Object {$_ -match '    > '}
    $edited= $packages -replace "^ *> ", "" -replace " +$", ""  -replace "\(A\)", "" -replace " \)", ")" -replace "  +", " | "
    $unique = $edited | Sort-Object | Get-Unique
    $unique | set-content $uniquePackages
}  

Main @args
