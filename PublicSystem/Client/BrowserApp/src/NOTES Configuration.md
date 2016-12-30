# Typescript compiler

## Latest installed version not in command window

Normally the latest compiler is installed using "npm install -g typescript".
On a Windows machine, this will install two files in "C:\Users\<user>\AppData\Roaming\npm"
* "tsc" and "tsc.cmd"

When you run "tsc -v" in a command window, you should see the latest version that you installed.
However, if you see something earlier, you quite possibly have an entry in the System PATH which points to 
an earlier installation.

### Solution

* Go to Control Panel, Advanced System Settings, Environment Variable and edit the System PATH.
There will possibly be an entry in it "C:\Program Files (x86)\Microsoft SDKs\TypeScript\....".
Delete this entry.

## Setting version used by VSCode

### Changing the global TypeScript version

1.Install the desired TypeScript version globally, for example npm install -g typescript@2.0.5
2.Open VS Code User Settings (F1 > Open User Settings)
3.Update/Insert "typescript.tsdk": "global_npm_path/typescript/lib"

Now all of the projects you open with VS Code will use this TypeScript version, unless of course there is a workspace setting that overrides this.

### Changing the local TypeScript version

1.Open the project in VS Code
2.Install the desired TypeScript version locally, for example npm install --save-dev typescript@2.0.5
3.Open VS Code Workspace Settings (F1 > Open Workspace Settings)
4.Update/Insert "typescript.tsdk": "./node_modules/typescript/lib"

Now only the project you installed this TypeScript version in will use that TypeScript version, the global installation will be ignored by VS Code in this project.

Note: The --save-dev will update your project's package.json, adding the TypeScript version you installed as a devDependency.


    