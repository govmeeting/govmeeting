### Install tools

* Install node
* Install .Net Core

### Build and run ClientApp

    cd Frontend/CientApp
    npm install
    npm start
In a browser, go to localhost:4200

### Build and run WebApp

    cd Backend/WebApp
    dotnet build webapp.csproj
    dotnet run bin/debug/dotnet2.0/webapp.dll

### Build and run WorkflowApp

    cd Backend/WorkflowApp
    dotnet build workflowapp.csproj
    dotnet run bin/debug/dotnet2.0/workflowapp.dll
