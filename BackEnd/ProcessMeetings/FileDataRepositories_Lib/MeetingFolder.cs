using GM.DatabaseRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using GM.DatabaseModel;
//using GM.DatabaseRepositories;
using GM.DatabaseModel;

namespace GM.FileDataRepositories
{
    // Work folders under Datafiles are named as follows:
    //    <country>_<state>_<county>_<town-or-city>_<gov-entity>_<language>/<date>
    // THe purpose of this class is to build this name from its parts or to extact the parts from a folder name.
    // If a meeting ID is passed to GetPathFromId, it will first look up the  meeting info in the database and then build the path.
    // For example:
    //      country = "USA"
    //      state = "PA"
    //      city = "Philadelphia"
    //      county = "Philadelphia"
    //      gov-entity = "CityCouncil"
    //      language = "en"
    //      date = "2016-03-17"
    // uses this folder:
    //     "Datafiles/USA_PA_Philadelphia_Philadelphia_CityCouncil_en/2016-03-17"
    //
    //  

    public class MeetingFolder
    {
        IMeetingRepository _meetingRepository;          // database meeting repository
        IGovBodyRepository _govBodyRepository;          // database govbody repository

        public string filename { get; private set; }
        public string path { get; private set; }
        public string location { get; private set; }
        public string country { get; private set; }
        public string state { get; private set; }
        public string county { get; private set; }
        public string municipality { get; private set; }
        public string governmentBody { get; private set; }
        public string language { get; private set; }
        public string date { get; private set; }
        public bool valid { get; private set; }


        public MeetingFolder(
            IMeetingRepository meetingRepository,
            IGovBodyRepository govBodyRepository
        )
        {
            _meetingRepository = meetingRepository;
            _govBodyRepository = govBodyRepository;
            valid = false;
        }

        public string GetNameFromId(long meetingId)
        {
            SetFields(meetingId);
            return path;
        }


        public string MeetingFolderFullPath(string datafiles)
        {
            return datafiles + "\\" + location + "\\" + date;
        }

        public bool SetFields(string _filename)
        {
            filename = _filename;
            valid = true;
            try
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                string[] parts = name.Split("_");

                country = parts[0];
                state = parts[1];
                county = parts[2];
                municipality = parts[3];
                governmentBody = parts[4];
                language = parts[5];
                date = parts[6];

                location = name.Substring(0, name.Length - 11);
                path = location + "\\" + date;
            }
            catch
            {
                valid = false;
            }
            return valid;
        }

        public bool SetFields(long meetingId)
        {
            Meeting meeting = _meetingRepository.Get(meetingId);
            GovernmentBody govBody = _govBodyRepository.Get(meeting.GovernmentBodyId);

            date = string.Format("{0:yyyy-MM-dd}", meeting.Date);
            location = govBody.Country + "_" + govBody.State + "_" + govBody.County + "_" + govBody.Municipality +
                "_" + govBody.Name + "_" + govBody.Languages[0].Name;
            filename = location + "_" + date;
            path = location + "\\" + date;

            country = govBody.Country;
            state = govBody.State;
            county = govBody.County;
            municipality = govBody.Municipality;
            governmentBody = govBody.Name;
            language = govBody.Languages[0].Name;

            valid = true;
            return valid;
        }

        //public string GetPartFolder(long meetingId, int part, string workfolderName, string datafiles)
        //{
        //    string meetingFolderPath = GetNameFromId(meetingId);

        //    string workFolder = meetingFolderPath + "\\" + workfolderName;
        //    string partFolder = workFolder + $"\\part{part:D2}";
        //    string partFolderPath = Path.Combine(datafiles, partFolder);

        //    return partFolderPath;
        //}

    }
}
