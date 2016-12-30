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


This does not work. I get: "Breakpoint ignored because generated code not found (source map problem?)"
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Launch Chrome against localhost, with sourcemaps",
            "type": "chrome",
            "request": "launch",
            "url": "http://localhost:5555",
            "sourceMaps": true,
            "webRoot": "${workspaceRoot}/dist/dev"
        },
        {
            "name": "Attach to Chrome, with sourcemaps",
            "type": "chrome",
            "request": "attach",
            "port": 9222,
            "sourceMaps": true,
            "webRoot": "${workspaceRoot}/dist/dev"
        }
    ]
}


I changed to this, as recommended by https://github.com/Microsoft/vscode-chrome-debug/issues/272
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Launch Chrome against localhost, with sourcemaps",
            "type": "chrome",
            "request": "launch",
            "url": "http://localhost:5555",
            "sourceMaps": true,
            "webRoot": "${workspaceRoot}/src/client"
        },
        {
            "name": "Attach to Chrome, with sourcemaps",
            "type": "chrome",
            "request": "attach",
            "port": 9222,
            "sourceMaps": true,
            "webRoot": "${workspaceRoot}/src/client"
        }
    ]
}
This did not help. 


All the help sites say to look at the "diagnostic logs". I could not locate these.
On https://github.com/hbenl/vscode-firefox-debug, there is info on using diagnostic logging.
Diagnostic logging
The following example for the  log  property will write all log messages to the file  log.txt  in your workspace:
...
    "log": {
        "fileName": "${workspaceRoot}/log.txt",
        "fileLevel": {
            "default": "Debug"
        }
    }
...
This example will write all messages about conversions between paths and urls and all error messages to the VS Code console:
...
    "log": {
        "consoleLevel": {
            "PathConversion": "Debug",
            "default": "Error"
        }
    }
...
However, this appears to be just for the Firefox debugginh extension.

For Chrome, at https://github.com/Microsoft/vscode-chrome-debug, it says to add:
   "diagnosticLogging" :true 
Then it will write out diagnostics to the console, and to this file:
  ~/.vscode/extensions/msjsdiag.debugger-for-chrome/vscode-chrome-debug.txt .
This worked.


Many errors were produced. Many of them related to not being able to find the source maps.
I found one reference to the problem in the angular-seed github pages.
	https://github.com/Microsoft/vscode-chrome-debug/issues/272
A fix seems to have been made in angular-seed:
	https://github.com/mgechev/angular-seed/issues/1564
I downloaded the latest angular-seed.
It contains a launch.json:
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Launch Chrome against localhost, with sourcemaps",
      "type": "chrome",
      "preLaunchTask": "start",
      "request": "launch",
      "url": "http://localhost:5555",
      "sourceMaps": true,
      "webRoot": "${workspaceRoot}/src/client",
      "sourceMapPathOverrides": {
        "app/*": "${webRoot}/app/*"
      }
    },
    {
      "name": "Attach to Chrome, with sourcemaps",
      "type": "chrome",
      "request": "attach",
      "port": 9222,
      "sourceMaps": true,
      "webRoot": "${workspaceRoot}/src/client",
      "sourceMapPathOverrides": {
        "app/*": "${webRoot}/app/*"
      }
    }
  ]
}

When I tried to use debug on the downloaded copy, I got this error:
	"Could not find the preLaunchTask 'start'"
The reason is because there is no task "start" within .vscode/tasks.
Why is that prelaunch task there????
I removed the prelaunch tast within launch.json. I set breakpoint within main.ts (on PlatformBrowserDymanic() ...)
However it did not stop there but elsewhere and showed a lot of "unhandled exceptions".
I just let it continue from that point and the program ran ok. But it did not hit my breakpoint.
I removed the initial breakpoint and set one within app.component.ts (on console.log(..))
This time, it ran ok and hit my breakpoint. 



















** Using Visual Studio 2015 ** 