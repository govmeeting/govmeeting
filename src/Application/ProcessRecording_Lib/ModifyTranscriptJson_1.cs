using System;
using System.Collections.Generic;
using System.Text;
using GM.ViewModels;
using GM.GoogleCloud;

namespace GM.ProcessRecording
{

    /*
     * Modify the trancription output from Google speech format to our own "FixasrView" format.
     * The Google data contains start and end times for every word. We do not need such
     * fine grained data for the process that will fix errors in the transcription.
     * We will include timestamps for approximately every 40 characters of text.
     * 
     ******* Google Format:

           {
             "alternatives": [
               {
                 "text": "and in when you came in this evening there's a copy of the ambulance ... ",
                 "wordCount": 69,
                 "words": [
                   {
                     "text": "and",
                     "startTime": 0,
                     "endTime": 1000,
                     "position": 1
                   },
                   {
                     "text": "in",
                     "startTime": 1000,
                     "endTime": 1600,
                     "position": 2
                   },

    ****** Our "Fixasr" data format:

       {
         "lastedit": 0,
         "asrsegments": [
           {"startTime":"0:00","said":"the tuesday october 11 selectmen's"},
           {"startTime":"0:02","said":"meeting i will apologize apologize for"},
           {"startTime":"0:06","said":"my voice i can hardly speak i woke up"},
           {"startTime":"0:08","said":"Saturday with a terrible cold so if you"},


    * Roughly we are displaying up to 40 characters of text per line. 
    */

    public class ModifyTranscriptJson_1
    {
        public FixasrViewModel Modify(TranscribeResultOrig transcript)
        {
            int MaxCharactersPerRecord = 40;
            FixasrViewModel fixasr = new FixasrViewModel();
            string line = "";
            int startTime = 0;

            fixasr.lastedit = 0;

            foreach (RspAlternative alternative in transcript.alternatives)
            {
                foreach (RspWord word in alternative.words)
                {
                    if (line.Length + word.text.Length > MaxCharactersPerRecord)
                    {
                        AsrSegment segment = NewSegment(startTime, line);
                        fixasr.asrsegments.Add(segment);
                        line = "";
                        startTime = word.startTime;
                    }
                    line = line + ((line.Length == 0) ? word.text : " " + word.text);
                }
            }
            if (line != "")
            {
                AsrSegment segment = NewSegment(startTime, line);
                fixasr.asrsegments.Add(segment);

            }
            return fixasr;
        }

        AsrSegment NewSegment(int startTime, string line)
        {
            TimeSpan t = new TimeSpan(0, 0, 0, 0, startTime);
            string format = @"hh\:mm\:ss";
            string start = t.ToString(format);
            AsrSegment segment = new AsrSegment(start, line);
            return segment;
        }
}
}
