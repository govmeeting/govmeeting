# Development Setup

This is continuation of the Quickstart procedures on the [Govmeeting Project Readme](https://github.com/govmeeting/govmeeting). 

## Google Cloud Platform account

If you want call the Google Speech APIs locally from your own computer, you need to sign up for a Google Cloud Platform (GCP) account. As of today (February 2018) Google was still providing developers with free account which includes a $300 credit. For this project, you will just be using the Speech API and not  per-cost servies like App Engine or Compute engines. Therefore, you will most likely not even accrue any charges.

  * Open an account with [Google Cloud Platform](https://cloud.google.com/free/)

  * Go to the [Google Cloud Dashboard](http://console.cloud.google.com) and create a project. 

  * Go to the [Google Developer's Console](http://console.developers.google.com) and enable the Speech & Cloud Storage APIs 


  * Generate a "service account" credential for this project. Click on Credentials in developer's console.


  * Give this account "Editor" permissions on the project. Click on the account. On the next page, click Permissions.


  * Download the credential JSON file.


  * Put the file in a folder named `_SECRETS` outside the repo folder.
   If the repo is in "govmeeting", this folder is `govmeeting/../_SECRETS`.


  * Rename the file `TranscribeAudio.json`.

NOTE: The above are the steps, as I remember doing them. I am sure that some details could be added.
If there is something essential missing, please create an issue in the [Govmeeting Issues](https://github.com/govmeeting/govmeeting/issues) and give it the "Wiki" label.

Github does not yet support Pull Requests on a Wiki repository.


#### Test GCP setup

  * Set the startup project in Visual Studio to `Backend/ProcessingINPROGRESS`. Press F5.


  * Copy (don't move) one of the sample MP4 files from testdata to Datafiles/INCOMING.

  The program will now recognize that a new file has appeared and start processing it.
  The MP4 file will be moved to "COMPLETED" when done. You will see the results in
  sufolders, which were created in the "Datafiles" directory.

## Google API Keys

You do NOT need these keys for most Govmeeting development. But the software will use them if they are present when testing user registration and login.

* ReCaptcha keys are needed to use ReCaptcha during user registration. They can be obtained at the [Google reCaptcha]( https://developers.google.com/recaptcha/).
* OAuth 2.0 credentials are used to do external user login without the need for the user to created a personal account on the site. Visit the  [Google API Console](https://console.developers.google.com/) to obtain credentials such as a client ID and client secret.


Create a file named "appsettings.Development.json" in the same "_SECRETS" folder as mentioned above under "Creating a GCP project". It should contain the keys that you just obtained:

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
