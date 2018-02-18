﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;
using WebApp.Services;
using Microsoft.Extensions.Options;
using WebApp.Features.Shared;
using System.Globalization;
using Govmeeting.Backend.Model;

namespace WebApp.Models
{
    // This is a "repository" of "viewable" transcripts. Viewable transcripts are the JSON files generated by the last step in the 
    // processing, the adding of tags. They are named "T4-tagged.json", meaning they completed step 4 of the processing.
 
    public class ViewMeetingRepository : IViewMeetingRepository
    {
        private const string STEP4_BASE_NAME = "T4-tagged";
        private const string EXTENSION = "json";

        string DatafilesPath;
        string TestdataPath;
        IMeetingRepository meetingRepository;
        IGovBodyRepository govBodyRepository;

        public ViewMeetingRepository(ISharedConfig config, IMeetingRepository _meetingRepository, IGovBodyRepository _locationRepository)
        {
            DatafilesPath = config.DatafilesPath;
            TestdataPath = config.TestdataPath;
            meetingRepository = _meetingRepository;
            govBodyRepository = _locationRepository;
        }

        public ViewMeeting Get(long meetingId)
        {
            Meeting meeting = meetingRepository.Get(meetingId);
            GovernmentBody govBody = govBodyRepository.Get(meeting.GovernmentBodyId);

            //DateTime dt = DateTime.Parse(meeting.date, null, System.Globalization.DateTimeStyles.RoundtripKind);
            string date = string.Format("{0:yyyy-MM-dd}", meeting.Date);

            string path = govBody.Country + "_" + govBody.State + "_" + govBody.County + "_" + govBody.Municipality + 
                "_" + govBody.Name + "_" + govBody.Languages[0] + "\\" + date;

            // Todo-g - Remove later - For development: If the data is not in Datafiles folder, copy it from testdata.
            UseTestData.CopyIfNeeded(path, DatafilesPath, TestdataPath);

            string latestCopy = Path.Combine(DatafilesPath, path, STEP4_BASE_NAME + "." + EXTENSION);

            if (File.Exists(latestCopy))
            {
                return GetViewMeetingByPath(latestCopy);
            }
            else
            {
                return null;
            }
        }

        private ViewMeeting GetViewMeetingByPath(string path)
        {
            string meetingString = Common.Readfile(path);
            if (meetingString != null)
            {
                ViewMeeting meeting = JsonConvert.DeserializeObject<ViewMeeting>(meetingString);
                return meeting;
            } else
            {
                return null;
            }
        }
    }
}
