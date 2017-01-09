##Getting Started

### Fork the govmeeting repo

Create a Github account if you do not have one.
Go to https://github.com/govmeeting/govmeeting.
Click "Fork" (upper right) to create your own fork of the repo.

### Clone a copy to your local computer.

Go to https://github.com/(your_username)/govmeeting.
Click "Clone or Download" (green button) and copy the web URL.
Open a git shell on your local computer.
> git clone (web_URL)
> cd govmeeting

### Build and run just the client
This will use static test files instead of getting the data from the server

> cd src\client\BrowserApp
> npm install
> npm start

### Build and run the server and client


Open the govmeeting\govmeeting.sln project in Visual Studio.