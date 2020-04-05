using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using GM.Configuration;
using Newtonsoft.Json;
using GM.FileDataRepositories;
using GM.ViewModels;
using GM.DatabaseRepositories;
using GM.DatabaseModel;


namespace GM.Workflow
{
    public class ProcessProofread
    {
        int MEETINGID = 1;      // FOR DEVELOPMENT

        AddtagsRepository _addtagsRepository;
        FixasrRepository _fixasrRepository;
        IGovBodyRepository govBodyRepository;
        IMeetingRepository meetingRepository;

        public ProcessProofread(
            AddtagsRepository addtagsRepository,
            FixasrRepository fixasrRepository,
            IGovBodyRepository _govBodyRepository,
            IMeetingRepository _meetingRepository
            )
        {
            _addtagsRepository = addtagsRepository;
            _fixasrRepository = fixasrRepository;
            meetingRepository = _meetingRepository;
            govBodyRepository = _govBodyRepository;
        }

        // Normally the Run method will search the state of the work on fixing errors in voice recognition text.
        // If it finds that the work is completed for a meeting, it will convert the text into
        // the format needed for the next step in the process: tagging of the transcript.
        // For now we will just convert a test file.



        // Find all recordings where proofreading is complete and approved.
        public void Run()
        {

            List<Meeting> meetings = meetingRepository.FindAll(SourceType.Recording, WorkStatus.Proofread, true);

            foreach (Meeting meeting in meetings)
            {
                doWork(meeting);
            }

        }

        public void doWork(Meeting meeting)
        {

        }

        public void Runx()
        {
            //FixasrView fixasr = _fixasrRepository.GetFinal(MEETINGID);
            string fisasrText = GMFileAccess.Readfile(@"C:\GOVMEETING\_SOURCECODE\Testdata\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2016-10-11\Fixasr\part01\Step 3 - transcript corrected for errors - 04-LAST.json");
            FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(fisasrText);

            FormatConversions formatConversions = new FormatConversions();
            AddtagsView addtags = formatConversions.ConvertFixasrToAddtags(fixasr);

            _addtagsRepository.Put(addtags, MEETINGID);
        }
    }
}
