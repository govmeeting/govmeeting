using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using GM.Application.Configuration;
//using GM.DatabaseRepositories;
using GM.Application.ProcessTranscript;
using GM.Utilities;
using Moq;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using GM.Infrastructure.FileDataRepositories;
using GM.DatabaseAccess;
using System.IO;
using System.Globalization;
using GM.Infrastructure.GetOnlineFiles;
using NLog.Filters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.Runtime.CompilerServices;

using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;

namespace GM.Tests.WorkflowApp_Tests
{

    public class WF1_Retrieve_Tests
    {
        //WF1_Retrieve wf1;
        //NullLogger<WF1_Retrieve> logger;
        //readonly IOptions<AppSettings> config;
        //IRetrieveNewFiles retrieveNewFiles = null;
        //string datafilesPath = Path.Combine(Directory.GetCurrentDirectory(), @"DATAFILES" + Guid.NewGuid());

        //public WF1_Retrieve_Tests()
        //{
        //    // Mock ILogger. Use null logger
        //    logger = new NullLogger<WF1_Retrieve>();

        //    // We  create a temporary DATAFILES folder with a unique name.
        //    datafilesPath = Path.Combine(Directory.GetCurrentDirectory(), @"DATAFILES" + Guid.NewGuid());

        //    // Mock the settings used in Appsettings
        //    AppSettings appsettings = new AppSettings()
        //    {
        //        DatafilesPath = datafilesPath,
        //        RequireManagerApproval = true
        //    };
        //    var mock = new Mock<IOptions<AppSettings>>();
        //    mock.Setup(a => a.Value).Returns(appsettings);
        //    config = mock.Object;
        //}

        //[Fact()]
        //public void Create_WF1_RetrieveOnlineFiles_Test()
        //{
        //    var mockDbOp = new Mock<IDBOperations>();
        //    IDBOperations dBOperations = mockDbOp.Object;

        //    wf1 = new WF1_Retrieve(logger, config, dBOperations, retrieveNewFiles);
        //    Assert.True(wf1 != null, "Create new WF2_ProcessTranscripts");
        //}

        ////[Fact()]
        //public void RetrieveOneOnlineFile_Test()
        //{
        //    string scheduledDate = "2020-08-25";
        //    DateTime scheduledDateTime = DateTime.ParseExact(scheduledDate, "yyyy-MM-dd", new CultureInfo("en-US"));

        //    // Mock some sample database records.
        //    // We expect WF1_RetrieveOnlineFiles to search for all Govbody's with scheduled meetings.
        //    List<Govbody> govbodies = new List<Govbody>()
        //    {
        //        new Govbody("Senate", 1, 10)
        //        {
        //            LongName = "USA_ME",
        //        },
        //        new Govbody("House", 2, 11)
        //        {
        //            LongName = "USA_NJ_Summit"
        //        }
        //    };

        //    govbodies[0].AddScheduledMeeting(new ScheduledMeeting()
        //    {
        //        Date = scheduledDateTime
        //    });

        //    // We expect WF1_RetrieveOnlineFiles to add a new meeting to this empty list
        //    List<Meeting> meetings = new List<Meeting>();

        //    // Create the Datafiles folder
        //    Directory.CreateDirectory(datafilesPath);

        //    // We expect WF1_RetrieveOnlineFiles to create a workfolder for the meeting that's retrieved.
        //    // Actual date of meeting that was retrieved.
        //    string actualDate = "2020-08-24";
        //    DateTime actualDateTime = DateTime.ParseExact(actualDate, "yyyy-MM-dd", new CultureInfo("en-US"));
        //    string workfolderName = govbodies[0].LongName + "_" + actualDate;
        //    string workFolderPath = Path.Combine(datafilesPath, workfolderName);

        //    // Mock all DBOperations that WF2_ProcessTranscripts calls
        //    var mockDbOp = new Mock<IDBOperations>();
        //    // FindGovBodiesWithScheduledMeetings returns Govbodys that have scheduled meetings.
        //    List<Govbody> govbodiesWithSchedules = new List<Govbody>() { govbodies[0] };
        //    mockDbOp.Setup(a => a.FindGovBodiesWithScheduledMeetings()).Returns(govbodiesWithSchedules);
        //    // Add adds the meeting to meetings collection.
        //    mockDbOp.Setup(a => a.Add(It.IsAny<Meeting>())).Returns((Meeting m) => {
        //        meetings.Add(m);
        //        return 1;
        //    });
        //    mockDbOp.Setup(a => a.WriteChanges());
        //    IDBOperations dBOperations = mockDbOp.Object;

        //    // Mock the RetrieveFile method.
        //    // It will call this method to retrieve an online file.
        //    // We create the file here to mock that it was retrieved.
        //    string fileRetrieved = Path.Combine(datafilesPath, "SomeRecording.mp4");
        //    File.WriteAllText(fileRetrieved, "Contents of SomeRecording");
        //    SourceType sourceType;
        //    var mockRetrieveNewFiles = new Mock<IRetrieveNewFiles>();
        //    mockRetrieveNewFiles.Setup(a => a.RetrieveFile(
        //        It.IsAny<Govbody>(), scheduledDateTime, out actualDateTime, out sourceType)).Returns(fileRetrieved);
        //    retrieveNewFiles = mockRetrieveNewFiles.Object;

        //    //################ This is the actual test. Everything else was setup ############. 
        //    // Create the object to be tested.
        //    wf1 = new WF1_Retrieve(logger, config, dBOperations, retrieveNewFiles);
        //    // Call its Run method.
        //    wf1.Run();
        //    // We expect the retrieved file was written to workfolder under this name.
        //    string sourceFileName = "source.mp4";
        //    string sourceFilePath = Path.Combine(workFolderPath, sourceFileName);
        //    Assert.True(File.Exists(sourceFilePath), "Retrieved file was written to work folder.");
        //    // We expect that a Meeting object was added to meetings.
        //    Assert.True(meetings.Count == 1, "New meeting was added to meetings");
        //    // We expect that Meeting object to have these properties.
        //    Meeting m = meetings[0];
        //    Assert.True(m.SourceType == SourceType.Recording, "SourceType is Recording");
        //    Assert.True(m.SourceFilename == sourceFileName, "SourceFilename is correct");
        //    Assert.True(m.Date == actualDateTime, "Date is actual date");
        //    Assert.True(m.WorkStatus == WorkStatus.Received, "WorkStatus is Received");
        //    Assert.True(m.Approved == false, "Approved is false");

        //    //################################################################################. 

        //    // Clean up the temporary Datafiles folder and all its contents.
        //    GMFileAccess.DeleteDirectoryAndContents(datafilesPath);
        //}
    }
}
