using GM.DatabaseModel;
using GM.DatabaseRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GM.FileDataRepositories
{
    // When a new transcript or recording is received by the system,
    //   the convention for naming the file is:
    //   <country>_<state>_<county>_<town-or-city>_<gov-entity>_<language>_<date>.<extension>
    //   For example: USA_PA_Philadelphia_Philadelphia_CityCouncil_en_2017-12-07.pdf
    // When the new file is received, a database record is created for this meeting.
    // One may also be created for the government body, if this is the 
    //   first first meeting ever seen for this governement body.
    // The work folder for processing the meeting file is created as follows:
    //   <country>_<state>_<county>_<town-or-city>_<gov-entity>_<language>/<date>
    //   For example: USA_PA_Philadelphia_Philadelphia_CityCouncil_en/2017-12-07
    // 
    // The purpose of this class is to convert between:
    //   1. the original received filename for this meeting
    //   2. the path of the work folder for this meeting

    public class MeetingFolder
    {  
        public string Filename { get; private set; }
        public string Path { get; private set; }
        public string Location { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string County { get; private set; }
        public string Municipality { get; private set; }
        public string GovernmentBody { get; private set; }
        public string Language { get; private set; }
        public string Date { get; private set; }
        public bool Valid { get; private set; }


        public MeetingFolder(IOGovBodyRepository govBodyRepository, Meeting meeting)
        {
            try
            {
                GovernmentBody g = govBodyRepository.Get(meeting.GovernmentBodyId);
                Language = g.Languages[0].Name;
                Country = g.Country;
                State = g.State;
                County = g.County;
                Municipality = g.Municipality;
                Date = Date = string.Format("{0:yyyy-MM-dd}", meeting.Date);
                SetCalculatedFields();
                Valid = true;
            }
            catch
            {
                Valid = false;
            }
        }

        public MeetingFolder(
            string _country, string _state, string _county, string _municipality,
            DateTime _date, string _governmentBody, string _language)
        {
            try
            {
                Date = string.Format("{0:yyyy-MM-dd}", _date);

                Country = _country;
                State = _state;
                County = _county;
                Municipality = _municipality;
                GovernmentBody = _governmentBody;
                Language = _language;

                //location = country + "_" + state + "_" + county + "_" + municipality + "_" + governmentBody + "_" + language;
                //filename = location + "_" + date;
                //path = location + "\\" + date;
                SetCalculatedFields();
                Valid = true;
            }
            catch
            {
                Valid = false;
            }
        }

        private void SetCalculatedFields()
        {
            Location = Country + "_" + State + "_" + County + "_" + Municipality + "_" + GovernmentBody + "_" + Language;
            Filename = Location + "_" + Date;
            Path = Location + "\\" + Date;
        }

        public MeetingFolder(string filename)
        { 
            try
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(filename);
                string[] parts = name.Split("_");

                Country = parts[0];
                State = parts[1];
                County = parts[2];
                Municipality = parts[3];
                GovernmentBody = parts[4];
                Language = parts[5];
                Date = parts[6];

                SetCalculatedFields();
                //location = name.Substring(0, name.Length - 11);
                //path = location + "\\" + date;
                Valid = true;
            }
            catch
            {
                Valid = false;
            }
        }

        public string MeetingFolderFullPath(string datafiles)
        {
            return datafiles + "\\" + Location + "\\" + Date;
        }

        //public MeetingFolder MeetingToMeetingFolder(Meeting meeting)
        //{
        //    GovernmentBody g = govBodyRepository.Get(meeting.GovernmentBodyId);
        //    string language = g.Languages[0].Name;
        //    MeetingFolder meetingFolder = new MeetingFolder(g.Country, g.State, g.County, g.Municipality, meeting.Date, g.Name, language);
        //    return meetingFolder;
        //}
    }
}
