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


        public string MeetingFolderFullPath(string datafiles)
        {
            return datafiles + "\\" + location + "\\" + date;
        }

        public bool SetFields(string filename)
        {
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
                return false;
            }
            valid = true;
            return true;
        }
        public bool SetFields(string _country, string _state, string _county, string _municipality, DateTime _date, string _governmentBody, string _language)
        {
            try
            {
                date = string.Format("{0:yyyy-MM-dd}", _date);

                country = _country;
                state = _state;
                county = _county;
                municipality = _municipality;
                governmentBody = _governmentBody;
                language = _language;

                location = country + "_" + state + "_" + county + "_" + municipality + "_" + governmentBody + "_" + language;
                filename = location + "_" + date;
                path = location + "\\" + date;
            }
            catch
            {
                return false;
            }
            valid = true;
            return true;
        }
    }
}
