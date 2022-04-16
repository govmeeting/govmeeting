# Process new transcript formats

The ultimate goal is to write code that will process any transcript format. But until then, we need to write custom code to handle each new format. When we have enough samples of different formats, we will be better able to write the generic code.

These are the steps for handling new transcript formats:

- Obtain a sample transcript of a government meeting as a pdf or text file.
- Name the file as follows: "country_state_county_municipality_agency_language-code_date.pdf". (or .txt) For example:

        "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".

- Create a new class with interface "ISpecificFix" in the project "ProcessTranscripts_Lib".
- Name the class "country_state_county_municipality_agency_language-code". For example:

        public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix

- Implement the class method:

        string Fix(string _transcript, string workfolder)

- Fix() receives the existing transcript text and returns the text in the following format:

```
Section: INVOCATION

Speaker: COUNCIL PRESIDENT CLARKE
    Good morning.  We're getting a very late start, so we'd like to get moving.
    To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise.
    (Councilmembers, guests, and visitors rise.)

Speaker: PASTOR NOVALES
    Good morning, City Council and guests and visitors.  I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly.  I'm honored to stand in this great place of decision-making.
...
```

When this class is completed, WorkflowApp will process the new transcripts when they appear in "DATAFILES/RECEIVED".

Notes:

We use System.Reflection to instantiate the correct class based on the name of the file to be processed.

See the class "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" in ProcessTranscripts_Lib for an example. You can understand better what this class is doing by looking at the log file traces in the "workfolder" that is passed as an argument to Fix().

We don't extract the following information now, but we will want to do this eventually.

- Officials in attendance
- Bills and resolutions introduced
- Voting results

Austin, TX - USA also has transcripts of public meetings online. A class was created called "USA_TX_TravisCounty_Austin_CityCouncil_en" in ProcessTranscripts_Lib. But the Fix() method was not implemented. Transcripts can be obtained from their website: [Austin, TX City Council](https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm)

# Modify the Client Dashboard

## Add a card for new feature

- At a terminal prompt, move to the folder: frontend/clientapp
- Enter: ng generate component your-feature
- Add your functionality to the files in : frontend/clientapp/src/app/your-feature
- Insert a new gm-small-card or gm-large-card element in app/dash-main/dash-main.html.
- Modify the icon, iconcolor, title, etc of the card element.
- If you need access to the name of the currently selected location and agency in your controller:
  - Add the location and agency input attributes to your feature element
  - Add location and agency @Input properties in your controller.

(See the other samples in dash-main.html)

## Re-arrange cards

1. Open the file: frontend/clientapp/src/app/dash-main/dash-main.html.
2. Change the card positions by
   changing the position of the gm-small-card or gm-large-card elements in this file.

# Logging

The log files for WebApp and WorkflowApp are in the folder "logs" at the root of the solution.

- "nlog-all-(date).log" contains all the log messages including system.
- The file "nlog-own-(date).log" contains only the application messages.

At the top of many of the component files in clientapp, a const "NoLog" is defined. Change its value from true to false to turn on console logging for only that component.

# Build Scripts

Powershell build scripts can be found in Utilities/PsScripts

- BuildPublishAndDeploy.ps1 -Call the other scripts to build a release and deploy it.
- Build-clientapp.ps1 - Build production versions of clientapp
- Publish-WebApp.ps1 - Build a "publish" folder of WebApp
- Copy-ClientAssets.ps1 - Copy clientapp assets to WebApp wwwroot folder
- Deploy-PublishFolder.ps1 - Deploy publish folder to a remote host
- Create the README.md file for Gethub from the documentation files

Deploy-PublishFolder.ps1 deploys the software to govmeeting.org, using FTP. The FTP login information is in the file appsettings.Development.json in the SECRETS folder. It contains FTP and other secrets for use in development. Below is the section of this file used by FTP:

    {
      ...
      "Ftp": {
        "username": "your-username",
        "password": "your-password",
        "domain": "your-domain"
      }
      ...
    }
