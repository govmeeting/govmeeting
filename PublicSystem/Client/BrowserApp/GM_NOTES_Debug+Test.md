** Using VsCode **

Open project folder in VsCode
Open a Bash shell
cd to project folder
 (On my system: cd F:/GOVMEETING/CODE/SOURCE/Govmeeting/PublicSystem/Client/BrowserApp)

> npm install
> npm run build.dev
> npm start
    Hit Ctrl-C to stop server

** Debug in VsCode **

See: https://code.visualstudio.com/Docs/editor/debugging
and: http://stackoverflow.com/questions/36494938/debug-run-angular2-typescript-with-visual-studio-code

Check that you have the latest Typescript: Help -> Check for Updates
Install extension for Chrome debugging:
    View -> Extensions -> Search for Extensions in Marketplace
    Search for "Debugger for Chrome" and install.
Click on the Debugging icon in the View Bar on the side of VS Code.
Create launch.json file
    Click on Configure gear icon on Debug top bar and choose "Chrome".
In tsconfig.json, make sure you have "sourceMap": true


9222













**Using Visual Studio 2015**