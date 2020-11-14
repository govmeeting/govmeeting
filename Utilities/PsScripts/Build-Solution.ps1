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

# NOTE: The folder structure has changed since this was written.

function Main
{

    Set-Location C:/GOVMEETING/_SOURCECODE
    Get-Location | Write-Host

    ### Choose what to run by un-commenting one of the commands. ###

    #CreateWorkflowApp2

    ### Some miscellaneous commands ###
    # AddPackage $googleCloudLibProject "Google.Cloud.Translation.V2" "2.0.0"
    # BuildProject $googleCloudLibProject
    # dotnet remove "BackEnd\Online\GoogleCloud_Lib2\GoogleCloud_Lib2.csproj"  package "Google.Cloud.Translation.V2"
    # dotnet remove Backend\WorkflowApp2\WorkflowApp2.csproj package "Google.Cloud.Storage.V1"
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

    $workflowAppProject = "BackEnd\WorkflowApp2\WorkflowApp2.csproj"
    $oldProjectFolder = "BackEnd/WorkflowApp"
    $googleCloudLibProject = "BackEnd\Online\GoogleCloud_Lib2\GoogleCloud_Lib2.csproj"

    CreateWorkflowAppProject $workflowAppProject $oldProjectFolder
    CreateGoogleCloudLibProject $googleCloudLibProject
    AddReference $workflowAppProject $googleCloudLibProject
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

function GetFullPath($relativePath)
{
    $location = Get-Location
    $p = [IO.Path]::Combine($location, $relativePath)
    $q = [IO.Path]::GetFullPath($p)
    return $q
}

Main @args

