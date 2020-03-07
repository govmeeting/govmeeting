## Disable authorization during development

proofreading or adding tags, the "Save" button will call WebApi to save the changes. Normally the user
needs to be logged in as "Proofreader" or "Editor" to do this. You can disable authorization by defining the C#
preprocesser symbol "NOAUTH". This can be be done in FixasrController.cs or AddtagsController.cs for that
controller. Un-comment the "#if NOAUTH" line at the top of the file.

You can also define NOAUTH for the entire WebApp project. Either enter the following in WebApi.scproj.

    <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'>
    <DefineConstants>NOAUTH</DefineConstants>
    </PropertyGroup>

or if using Visual Studio, go to WebApp property pages -> Build ->
and enter NOAUTH in the "Conditional Compiliation Symbols" box.


## Add a new table to the database

## Add more fields to the database for the logged in user

Add properties to the class "ApplicationUser" in the file BackEnd\Database\DatabaseAccess_Lib\ApplicationUser.
When the WebApp is restarted, new fields will be automatically generated in the database.
After these changes are made in development and tested, an SQL change script can then be generated to update the production database.

## Dependency Injection (DI)

DI is used throughout all projects. It allows components
and subsystems to be stubbed out easily for develpment and testing.

For example, in FrontEnd/ClientApp/src/app/app.module.ts, if you set
"isAspServerRunning = false" at the top of the file, stubs will be used
for services that call the WebApi. They will use sample local data instead
of calling the WebApi.

## Logging

The log files for WebApp and WorkflowApp are in the folder "logs" at the root of the solution.
"nlog-all-(date).log" contains all the log messages including system.
"The file "nlog-own-(date).log" contains only the application messages.

At the top of many of the component files in ClientApp, a const "NoLog" is defined.
Change its value from true to false to turn on console logging for only that component.
