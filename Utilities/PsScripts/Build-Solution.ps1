# This is the start of a script to build the projects and solution
# from scratch using the dotnet commands.
# The solution and projects were originally built using the UI of Visual Studio.
# But now that the solution has grown, problems are emerging with 
# doing it this way.
# Recently I hit a problem where the Visual Studio build process could not find an assembly that was referenced.
# I could not figure out why. See stackoverflow: 
# https://stackoverflow.com/questions/61858404/could-not-load-file-or-assembly-errors-each-time-i-need-to-remove-re-add-th
# The problem came and went by just removing the project from VS and re-adding it.
# Another weird problem emerged of a library working in one app but not another.
# Problems like these are easier to solve when using the command line to build projects.


function Main
{

    Set-Location C:/GOVMEETING/_SOURCECODE
    Get-Location | Write-Host

    ### Choose what to run by un-commenting one of these lines. ###
    #CreateWorkflowApp2
    #CreateSolutionSummaries

    ### Some miscellaneous commands ###
    # AddPackage $googleCloudLibProject "Google.Cloud.Translation.V2" "2.0.0"
    # BuildProject $googleCloudLibProject
    # dotnet remove "BackEnd\Online\GoogleCloud_Lib2\GoogleCloud_Lib2.csproj"  package "Google.Cloud.Translation.V2"
    # dotnet remove Backend\WorkflowApp3\WorkflowApp3.csproj package "Google.Cloud.Storage.V1"
    # AddReference $workflowAppProject "BackEnd\ProcessMeetings\ProcessRecording_Lib\ProcessRecording_Lib.csproj"
    # AddPackage $workflowAppProject "Google.Cloud.Storage.V1" "2.1.0"
    # BuildProject $workflowAppProject
}

function CreateWorkflowApp2
{
    # The following was useful in solving a package conflict in WorkflowApp
    # We create a new WorkflowApp called WorkflowApp2 and we:
    #   install the same references as the original
    #   install the same packages as the orginal except for GoogleCloud_Lib.
    #   copy the source files from the original
    # We create a new GoogleCLoud_Lib called GoogleCLoud2_Lib and we:
    #   install a subset of the original packages.
    # We add GoogleCLoud2_Lib as a reference to WorkflowApp2.

    $workflowAppProject = "BackEnd\WorkflowApp3\WorkflowApp3.csproj"
    $oldProjectFolder = "BackEnd/WorkflowApp2"
    $googleCloudLibProject = "BackEnd\Online\GoogleCloud_Lib2\GoogleCloud_Lib2.csproj"

    $solutionSummary = "utilities/PsScripts/SolutionSummary.txt"
    $uniquePackages = "utilities/PsScripts/SolutionSummary-UniquePackages.txt"

    CreateWorkflowAppProject $workflowAppProject $oldProjectFolder
    CreateGoogleCloudLibProject $googleCloudLibProject
    AddReference $workflowAppProject $googleCloudLibProject
}

function CreateSolutionSummaries
{
    # In the following, we analyse the solution file "govmeeting.sln" and write two summaries:
    #   summary of all projects with their references and packages.
    #   summary of unique packages. 

    Write-SolutionSummary $solutionSummary
    AnalyseSolutionSummary $solutionSummary $uniquePackages
}



function CreateGoogleCloudLibProject($projectFile)
{
    $projectFolder = [IO.Path]::GetDirectoryName($projectFile)
    $projectName  = [IO.Path]::GetFileName($projectFolder)

    CreateProject "classlib" $projectName $projectFolder
    AddPackage $projectFile "Google.Cloud.Storage.V1" "2.1.0"

}

function CreateWorkflowAppProject($projectFile, $oldProjectFolder)
{
    $projectFolder = [IO.Path]::GetDirectoryName($projectFile)
    $projectName  = [IO.Path]::GetFileName($projectFolder)

    CreateProject "console" $projectName $projectFolder
    ConvertToNet20 $projectFile
    AddWorkflowAppReferences $projectFile
    AddWorkflowAppPackages $projectFile
    CopyFilesToNewProjectFolder $oldProjectFolder $projectFolder
    BuildProject $projectFile

}

function CreateProject($template, $projectName, $projectFolder) {
    dotnet new $template -lang "C#" -n $projectName -o $projectFolder --type project
}

function BuildProject($projectFile) {
    dotnet build $projectFile
}

function ConvertToNet20($projectFile)
{
    $content = get-content $projectFile
    $content = $content -replace 'netcoreapp3.1','netcoreapp2.2'
    $content | set-content $projectFile
}

function CopyFilesToNewProjectFolder($oldFolder, $newFolder)
{
    Copy-Item "$oldFolder/*.cs" $newFolder
    Copy-Item "$oldFolder/appsettings.json" $newFolder
}

function AddReference($project, $reference) {
    dotnet add $project reference $reference
}

function AddPackage($project, $package, $version)
{
    dotnet add $project package $package -v $version
}

function AddWorkflowAppReferences($projectFile) {

    [string[]]$references = 
    "Configuration_Lib\Configuration_Lib.csproj",
    "Database\DatabaseRepositories_Lib\DatabaseRepositories_Lib.csproj",
    "Database\LoadDatabase_Lib\LoadDatabase_Lib.csproj",
    "Online\GetOnlineFiles_Lib\GetOnlineFiles_Lib.csproj",
    "Online\OnlineAccess_Lib\OnlineAccess_Lib.csproj",
    "ProcessMeetings\FileDataRepositories_Lib\FileDataRepositories_Lib.csproj",
    #"Online\GoogleCloud_Lib\GoogleCloud_Lib.csproj",
    "ProcessMeetings\ProcessRecording_Lib\ProcessRecording_Lib.csproj",
    "ProcessMeetings\ProcessTranscript_Lib\ProcessTranscript_Lib.csproj",
    "ProcessMeetings\ViewModels_Lib\ViewModels_Lib.csproj",
    "Utilities_Lib\Utilities_Lib.csproj"

    foreach ($element in $references) {
        $ref = "BackEnd/" + $element
        dotnet add $projectFile reference $ref
    }
}

function AddWorkflowAppPackages($project) {

    $packages = @(
        ("Google.Cloud.Speech.V1", "1.0.1"),
        ("Google.Cloud.Storage.V1", "2.1.0"),
        ("iTextSharp", "5.5.13.1"),
        ("Microsoft.Extensions.Configuration.FileExtensions", "2.0.0"),
        ("Microsoft.Extensions.Configuration.Json", "2.0.0"),
        ("Microsoft.Extensions.DependencyInjection", "2.2.0")
        ("Microsoft.Extensions.Logging.Console", "2.0.0"),
        ("Microsoft.Extensions.Logging.Debug", "2.0.0"),
        ("Microsoft.Extensions.Options.ConfigurationExtensions", "2.0.0"),
        ("Microsoft.NETCore.App", "2.0.0"),
        ("NLog", "4.6.6"),
        ("NLog.Web", "4.8.4")
    )

   foreach ($package in $packages) {
        $name = $package[0]
        $version = $package[1]
        dotnet add $project package $name -v $version
    }
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

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}

Main @args

