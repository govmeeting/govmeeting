using Xunit;
using GM.Workflow;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using GM.Configuration;
using GM.DatabaseRepositories;
using GM.ProcessTranscript;
using GM.Utilities;
using Moq;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using GM.DatabaseModel;
using GM.FileDataRepositories;
using GM.DatabaseAccess;
using System.IO;

namespace GM.WorkflowApp.Tests
{
    public class WF2_ProcessTranscriptsTests
    {
        WF2_ProcessTranscripts wf2;
        NullLogger<WF2_ProcessTranscripts> logger;
        IOptions<AppSettings> config;
        ITranscriptProcess transcriptProcess;

        // We create a workfolder with a unique name for the tests.
        string datafilesPath = @"C:\TMP\" + Guid.NewGuid();

        // These are the results that the mock of TranscriptProcess will return.
        string processingResults = "Processing Results";


        public WF2_ProcessTranscriptsTests()
        {
            // Create dependencies of WF2_ProcessTranscripts

            // logger will be null logger
            logger = new NullLogger<WF2_ProcessTranscripts>();

            // Appsettings that it accesses
            AppSettings appsettings = new AppSettings()
            {
                DatafilesPath = datafilesPath,
                RequireManagerApproval = true
            };
            var mock = new Mock<IOptions<AppSettings>>();
            mock.Setup(a => a.Value).Returns(appsettings);
            config = mock.Object;

            // mock of TranscriptProcess that is called to process transcripts.
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
            List<Meeting> meetings = new List<Meeting>()
                {
                    new Meeting()
                    {
                        WorkFolder = "USA_ME_en_2014-09-08",
                        SourceFilename = "source.pdf",
                        SourceType = SourceType.Transcript,
                        WorkStatus = WorkStatus.Received,
                        Approved = false
                    }
                };

            // DBOperations that it calls (only FindMeetings)
            var mockDbOp = new Mock<IDBOperations>();
            mockDbOp.Setup(a => a.FindMeetings(SourceType.Transcript, WorkStatus.Received, true)).Returns(meetings);
            mockDbOp.Setup(a => a.WriteChanges());
            IDBOperations dBOperations = mockDbOp.Object;

            string workfolderPath = Path.Combine(datafilesPath, meetings[0].WorkFolder);
            string sourceFilePath = Path.Combine(workfolderPath, meetings[0].SourceFilename);
            string processedFile = Path.Combine(workfolderPath, WorkfileNames.processedTranscript);

            Directory.CreateDirectory(workfolderPath);
            File.WriteAllText(sourceFilePath, "Stub source file");


            // The Run method should process one transcript and create the processed file in the workfolder 
            wf2 = new WF2_ProcessTranscripts(logger, config, transcriptProcess, dBOperations);
            wf2.Run();
            Assert.True(File.Exists(processedFile), "Create processed file");
            string results = File.ReadAllText(processedFile);
            Assert.True(results == processingResults, "Processed results are correct");

            //GMFileAccess.DeleteDirectoryContents(workfolderPath);
            GMFileAccess.DeleteDirectoryAndContents(datafilesPath);
        }

        //  ### Experiments with IOptions
        //class AOptions : IOptions<AppSettings>
        //{
        //    public AppSettings Value => null;
        //}

        //public interface IAppsettings : IOptions<AppSettings>
        //{
        //    public string DatafilesPath { get; set; }
        //}

        //class DAppSettings : IAppsettings
        //{
        //    public AppSettings Value => null;
        //    public string DatafilesPath { get; set; }
        //}

        //class EAppSettings : IOptions<AppSettings>
        //{
        //    AppSettings IOptions<AppSettings>.Value => throw new NotImplementedException();
        //}
        //public interface IShape
        //{
        //    int area { get; }
        //}

        //public interface IFindWindow : IShape
        //{
        //    string WindowName { get; }
        //}

    }
}
