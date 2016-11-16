User Secrets are used to store information that should not be put in source control.
* Add Microsoft.Extensions.SecretManager.Tools to the tools section of the project.json file
* Run dotnet restore.
* A "UserSecretsId" will be added to the top of project.json. Its value is arbitrary, but is generally unique to the project.
* Add "builder.AddUserSecrets()" to the startup routine in startup.cs. 

Adding secrets:
* Open a command prompt at the project root folder and use these commands:
* dotnet-user-secrets --help
* dotnet user-secrets set MySecret ValueOfMySecret
* dotnet-user-secrets --list


User’s Secrets that get added using “Secret Manager Tool” are located in AppData of current logged in Windows users.
* C:\Users\<username>\AppData\Roaming\Microsoft\UserSecrets/<userSecretsId>/secrets.json

For NON windows machine they are located at 
* ~/.microsoft/usersecrets/<userSecretsId>/secrets.json

You can access user secrets in code via the configuration API:
* string testConfig = Configuration["MySecret"];
