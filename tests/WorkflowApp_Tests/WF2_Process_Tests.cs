using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using GM.Application.Configuration;
//using GM.DatabaseRepositories;
using GM.Application.ProcessTranscript;
using GM.Utilities;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using GM.Infrastructure.FileDataRepositories;
using GM.DatabaseAccess;
using System.IO;
using System.Globalization;

using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;

namespace GM.Tests.WorkflowApp_Tests
{
    public class WF2_Process_Tests
    {
        //WF2_Process wf2;
        //readonly ILogger<WF2_Process> logger;
        //readonly IOptions<AppSettings> config;
        //readonly ITranscriptProcess transcriptProcess;
        //readonly string datafilesPath;
        //readonly string processingResults;

        //public WF2_Process_Tests()
        //{
        //    // Mock ILogger. Use null logger
        //    logger = new NullLogger<WF2_Process>();
        //    // This is in case we need to debug CI using logging.
        //    //ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        //    //logger = loggerFactory.CreateLogger<WF2_ProcessTranscriptsTests>();
        //    //logger.LogInformation("In constructor WF2_ProcessTranscriptsTests");

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

        //    // Mock TranscriptProcess.Process(..)
        //    // This is the method that will be called to do the actual processing
        //    // Mock it by just returning sample results
        //    var mockTranscriptProcess = new Mock<ITranscriptProcess>();
        //    processingResults = "Sample Processing Results";
        //    mockTranscriptProcess.Setup(a => a.Process(
        //        It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(processingResults);
        //    transcriptProcess = mockTranscriptProcess.Object;
        //}

        //[Fact()]
        //public void Create_WF2_ProcessTranscripts_Test()
        //{
        //    var mockDbOp = new Mock<IDBOperations>();
        //    IDBOperations dBOperations = mockDbOp.Object;

        //    wf2 = new WF2_Process(logger, config, transcriptProcess, dBOperations);
        //    Assert.True(wf2 != null, "Create new WF2_ProcessTranscripts");
        //}

        ////[Fact()]
        //public void Run_WF2_Process_One_Transcript_Test()
        //{
        //    // Mock some sample database records, a Meeting and Govbody.
        //    // WF2_ProcessTranscripts will search for all meetings with
        //    // correct SourceType, WorkStatus and Approved status.
        //    string meetingDate = "2018-12-25";  // random meeting date
        //    CultureInfo ci = CultureInfo.InvariantCulture;
        //    DateTime meetingDateTime = DateTime.ParseExact(meetingDate, "yyyy-MM-dd", ci);
        //    long govbodyId = 5;  // random Id
        //    List<Meeting> meetings = new List<Meeting>()
        //    {
        //        new Meeting()
        //        {
        //            Date = meetingDateTime,
        //            GovbodyId = govbodyId,
        //            SourceFilename = "source.pdf",
        //            SourceType = SourceType.Transcript,
        //            WorkStatus = WorkStatus.Received,
        //            Approved = false
        //        }
        //    };
        //    Govbody govbody = new Govbody("Senate", 1, govbodyId)
        //    {
        //        LongName = "USA_ME"
        //    };

        //    // Create the Datafiles folder
        //    Directory.CreateDirectory(datafilesPath);

        //    // WF2_ProcessTranscripts expects a workfolder for this meeting to already exist.
        //    string workfolderName = govbody.LongName + "_" + meetingDate;
        //    string workFolderPath = Path.Combine(datafilesPath, workfolderName);
        //    Directory.CreateDirectory(workFolderPath);

        //    //  It expects the workfolder to contain the file for the transcript to be processed.
        //    string sourceFilePath = Path.Combine(workFolderPath, meetings[0].SourceFilename);
        //    File.WriteAllText(sourceFilePath, "Sample Source File Coneents");

        //    // Mock the DBOperations that it will call
        //    var mockDbOp = new Mock<IDBOperations>();
        //    mockDbOp.Setup(a => a.FindMeetings(SourceType.Transcript, WorkStatus.Received, true)).Returns(meetings);
        //    mockDbOp.Setup(a => a.WriteChanges());
        //    mockDbOp.Setup(a => a.GetWorkFolderName(It.IsAny<Meeting>())).Returns(workfolderName);
        //    IDBOperations dBOperations = mockDbOp.Object;

        //    //################ This is the actual test. Everything else was setup ############. 
        //    wf2 = new WF2_Process(logger, config, transcriptProcess, dBOperations);
        //    wf2.Run();
        //    // 
        //    //################################################################################. 

        //    // WF2_ProcessTranscripts should have writen the results to the processedFile
        //    string processedFile = Path.Combine(workFolderPath, WorkfileNames.processedTranscript);
        //    Assert.True(File.Exists(processedFile), "Processed results were written to file.");

        //    // Check the content of processedFile
        //    string results = File.ReadAllText(processedFile);
        //    Assert.True(results == processingResults, "Processed results are correct");

        //    // Clean up the temporary Datafiles folder and all its contents.
        //    GMFileAccess.DeleteDirectoryAndContents(datafilesPath);
        //}
    }
}
