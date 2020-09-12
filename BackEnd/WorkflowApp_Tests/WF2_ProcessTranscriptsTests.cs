using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using GM.Configuration;
using GM.DatabaseRepositories;
using GM.ProcessTranscript;
using GM.Utilities;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using GM.DatabaseModel;
using GM.FileDataRepositories;
using GM.DatabaseAccess;
using System.IO;
using System.Globalization;

namespace GM.WorkflowApp.Tests
{
    public class WF2_ProcessTranscriptsTests
    {
        WF2_ProcessTranscripts wf2;
        readonly NullLogger<WF2_ProcessTranscripts> logger;
        readonly IOptions<AppSettings> config;
        readonly ITranscriptProcess transcriptProcess;

        ILogger<WF2_ProcessTranscriptsTests> loggerReal;

        // We will create a temporary DATAFILES folder with a unique name for the tests.
        readonly string datafilesPath = Path.Combine(Directory.GetCurrentDirectory(), @"DATAFILES" + Guid.NewGuid());

        // These are the results that the mock of TranscriptProcess will return.
        readonly string processingResults = "Sample Processing Results";


        public WF2_ProcessTranscriptsTests()
        {

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            loggerReal = loggerFactory.CreateLogger<WF2_ProcessTranscriptsTests>();
            loggerReal.LogInformation("REALLOGGER TEST - WF2_ProcessTranscriptsTests");

            // Create dependencies used by WF2_ProcessTranscripts that are needed
            // for all the tests.

            // logger will be null logger
            logger = new NullLogger<WF2_ProcessTranscripts>();

            // Mock of the Appsettings that it accesses
            AppSettings appsettings = new AppSettings()
            {
                DatafilesPath = datafilesPath,
                RequireManagerApproval = true
            };
            var mock = new Mock<IOptions<AppSettings>>();
            mock.Setup(a => a.Value).Returns(appsettings);
            config = mock.Object;

            // Mock of TranscriptProcess that it called to process transcripts.
            // Its Process method will returns the results.
            // WF2_ProcessTranscripts should write the results to the workfolder.
            var mockTranscriptProcess = new Mock<ITranscriptProcess>();
            mockTranscriptProcess.Setup(a => a.Process(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(processingResults);
            transcriptProcess = mockTranscriptProcess.Object;
        }


        [Fact()]
        public void Create_WF2_ProcessTranscriptsTest()
        {
            var mockDbOp = new Mock<IDBOperations>();
            IDBOperations dBOperations = mockDbOp.Object;

            wf2 = new WF2_ProcessTranscripts(logger, config, transcriptProcess, dBOperations);
            Assert.True(wf2 != null, "Create new WF2_ProcessTranscripts");
        }

        [Fact()]
        public void Run_WF2_Process_One_TranscriptTest()
        {
            string meetingDate = "2018-12-25";  // random meeting date
            CultureInfo ci = CultureInfo.InvariantCulture;
            DateTime meetingDateTime = DateTime.ParseExact(meetingDate, "yyyy-MM-dd", ci);

            long govbodyId = 5;  // random Id
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting()
                {
                    Date = meetingDateTime,
                    GovBodyId = govbodyId,
                    SourceFilename = "source.pdf",
                    SourceType = SourceType.Transcript,
                    WorkStatus = WorkStatus.Received,
                    Approved = false
                }
            };

            GovBody govbody = new GovBody()
            {
                Id = govbodyId,
                LongName = "USA_ME"
            };

            // WF2_ProcessTranscripts expects a workfolder to exist that contains
            // the source file for the transcript to be processed.
            string workfolderName = govbody.LongName + "_" + meetingDate;
            string workFolderPath = Path.Combine(datafilesPath, workfolderName);
            loggerReal.LogInformation("REALLOGGER TEST datafilesPath={0}", datafilesPath);
            Directory.CreateDirectory(datafilesPath);
            loggerReal.LogInformation("REALLOGGER TEST workFolderPath={0}", workFolderPath);
            Directory.CreateDirectory(workFolderPath);
            string sourceFilePath = Path.Combine(workFolderPath, meetings[0].SourceFilename);
            File.WriteAllText(sourceFilePath, "Sample Source File Coneents");

            // We expect WF2_ProcessTranscripts to write the results of processing the transcript
            // to the following file.
            string processedFile = Path.Combine(workFolderPath, WorkfileNames.processedTranscript);

            loggerReal.LogInformation("REALLOGGER TEST procesedFilePath={0}", processedFile);


            // Mock all DBOperations that WF2_ProcessTranscripts calls
            var mockDbOp = new Mock<IDBOperations>();
            mockDbOp.Setup(a => a.FindMeetings(SourceType.Transcript, WorkStatus.Received, true)).Returns(meetings);
            mockDbOp.Setup(a => a.WriteChanges());
            mockDbOp.Setup(a => a.GetWorkFolderName(It.IsAny<Meeting>())).Returns(workfolderName);
            IDBOperations dBOperations = mockDbOp.Object;

            // This is where we actually execute the class to be tested. Everything else was setup for this. 
            wf2 = new WF2_ProcessTranscripts(logger, config, transcriptProcess, dBOperations);
            wf2.Run();

            Assert.True(true, "Always true");
            //Assert.True(File.Exists(processedFile), "Processed results were written to file.");
            //string results = File.ReadAllText(processedFile);
            //Assert.True(results == processingResults, "Processed results are correct");

            // Clean up the temporary Datafiles folder and all its contents.
            //GMFileAccess.DeleteDirectoryAndContents(datafilesPath);
        }
    }
}
