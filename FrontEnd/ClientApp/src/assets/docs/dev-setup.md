## Install and run the software

### Install External Software

* node
* .Net Core
* git

### Clone the repository

    > git clone https://github.com/govmeeting/govmeeting.git
    > mkdir _SECRETS

The "_SECRETS" folder is for keys and passwords that are not stored in the public repo.

### Build and run ClientApp

    > cd govmeeting/Frontend/CientApp
    > npm install
    > npm start

Go to localhost:4200 in your browser.

### Build and run WebApp

    > cd govmeeting/Backend/WebApp
    > dotnet build webapp.csproj
    > dotnet run bin/debug/dotnet2.0/webapp.dll

If the ClientApp is already running, go to localhost:5000 in your browser.
The WebApp will handle WebApi calls itself. But it will proxy client requests to the dev server running the client app.

### Build and run WorkflowApp

    > cd govmeeting/Backend/WorkflowApp
    > dotnet build workflowapp.csproj
    > dotnet run bin/debug/dotnet2.0/workflowapp.dll

## Documentation

Originally this documentation was kept in the Github Wiki pages.
But it was decided to move the pages into the main project itself, for two reasons:
* You cannot do a Pull Request for changes on Github Wiki pages. This makes it difficult
for members of the community to change the documentation.
* The documentation will more likely stay in sync with the code if it is together with the
code in the same repository. A single PR for code changes can include the documentation 
changes associated with it.

The documentation is written in Markdown and located in Frontend/ClientApp/src/app/assets/docs. 
 

 ## Google Cloud Platform account

If you want call the Google Speech APIs locally from your own computer, you need a Google Cloud Platform (GCP) account. Google was providing developers with a free account which includes a credit. For this project, you will just be using the Speech API and not per-cost servies like App Engine or Compute engines. Therefore, you will most likely not even accrue charges that you would need your credit for.

  * Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

  * Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project. 

  * Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs 


  * Generate a "service account" credential for this project. Click on Credentials in developer's console.


  * Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.


  * Download the credential JSON file.


  * Put the file in the `_SECRETS` folder that you created when you cloned the repo.

  * Rename the file `TranscribeAudio.json`.

NOTE: The above steps may have changed slightly. If so, please update this document.


#### Test GCP setup

  * Set the startup project in Visual Studio to `govmeeting/Backend/WorkflowApp`. Press F5.


  * Copy (don't move) one of the sample MP4 files from testdata to Datafiles/INCOMING.

  The program will now recognize that a new file has appeared and start processing it.
  The MP4 file will be moved to "COMPLETED" when done. You will see the results in
  sufolders, which were created in the "Datafiles" directory.

## Google API Keys

You will need these keys if you want to use or work on certain features of the registration and login process.

* ReCaptcha keys are needed to use ReCaptcha during user registration. They can be obtained at the [Google reCaptcha]( https://developers.google.com/recaptcha/).
* OAuth 2.0 credentials are used to do external user login without the need for the user to created a personal account on the site. Visit the  [Google API Console](https://console.developers.google.com/) to obtain credentials such as a client ID and client secret.


Create a file named "appsettings.Development.json" in the "_SECRETS" folder. It should contain the keys that you just obtained:

    {
     "ExternalAuth": {
    	"Google": {
		     "ClientId": "your-client-Id",
		     "ClientSecret": "your-client-secret"
        }
      },
      "ReCaptcha:SiteKey": "your-site-key",
      "ReCaptcha:Secret": "your-secret"
    }

#### Test reCaptcha

* Run the WebApp project.
* Click on "Register" in the upper right.
* The reCaptcha option should appear.

#### Test Google Authentication

* Run the WebApp project.
* Click on "Login" in the upper right.
* Under "Use another service to log in", choose "Google".
