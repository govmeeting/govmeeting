﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using GM.Configuration;
using Newtonsoft.Json;
using GM.FileDataRepositories;
using GM.FileDataModel;


namespace GM.WorkFlow
{
    public class ProcessFixedTranscriptions
    {
        int MEETINGID = 1;      // FOR DEVELOPMENT

        AddtagsRepository _addtagsRepository;
        FixasrRepository _fixasrRepository;

        public ProcessFixedTranscriptions(
            AddtagsRepository addtagsRepository,
            FixasrRepository fixasrRepository
            )
        {
            _addtagsRepository = addtagsRepository;
            _fixasrRepository = fixasrRepository;
        }

        // Normally the Run method will search the state of the work on fixing errors in voice recognition text.
        // If it finds that the work is completed for a meeting, it will convert the text into
        // the format needed for the next step in the process: tagging of the transcript.

        public void Run()
        {
            // For now we will just convert a test file.
            //FixasrView fixasr = _fixasrRepository.GetFinal(MEETINGID);
            string fisasrText = FileAccess.Readfile(@"C:\GOVMEETING\testdata - other\BBH Selectmen\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN\2016-10-11\Step 3 - transcript corrected for errors - 04-LAST.json");
            FixasrView fixasr = JsonConvert.DeserializeObject<FixasrView>(fisasrText);

            FormatConversions formatConversions = new FormatConversions();
            AddtagsView addtags = formatConversions.ConvertFixasrToAddtags(fixasr);

            //_addtagsRepository.Put(addtags, MEETINGID);
        }
    }
}
