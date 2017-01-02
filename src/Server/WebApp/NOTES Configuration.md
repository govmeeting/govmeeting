# Application Environment

ASP.NET Core references a particular environment variable, ASPNETCORE_ENVIRONMENT to describe the environment the application is currently running in.
This variable can be set to any value you like, but three values are used by convention: Development, Staging, and Production.

This value is set in the project properties under the Debug tab.

It is used often in the Views\Shared cshtml files.