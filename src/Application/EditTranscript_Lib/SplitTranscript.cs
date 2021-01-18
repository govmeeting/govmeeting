using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.DTOs.Meetings;

namespace GM.Application.EditTranscript
{
    ///* Split the fixasr JSON object into segments.
    // *  {
    // *    "lastedit": 0,
    // *    "asrsegments": [
    // *      {"startTime":"0:00","said":"the tuesday october 11 selectmen's"},
    // *      {"startTime":"0:02","said":"meeting i will apologize apologize for"},
    // *      {"startTime":"0:06","said":"my voice i can hardly speak i woke up"},
    // *      {"startTime":"0:08","said":"Saturday with a terrible cold so if you"},
    // */
    public class SplitTranscript
    {
        //    readonly CultureInfo culture = CultureInfo.CurrentCulture;
        //    readonly string format = "hh\\:mm\\:ss";
        //    int sectionNumber;
        //    readonly FixasrView[] fixasrSegment = new FixasrView[2];

        public void Split(EditMeeting_Dto meetingEditDto, string outputFolder, int sectionSize, int overlap, int parts)
        {
            //        fixasrSegment[0] = new FixasrView();
            //        fixasrSegment[1] = new FixasrView();
            //        fixasrSegment[0].lastedit = 0;
            //        fixasrSegment[1].lastedit = 0;
            //        sectionNumber = 1;

            //        // Since we want the sections to overlap (if overlap is non-zero), we can be adding to 2 outputs at once
            //        // during the overlap. The first output that we start becomes the "primary" output.
            //        // When we reach sectionSize for the primary, we open the next output. We now add to both outputs until
            //        // we reach "sectionSize + overlap" on the primary. At that time we close the primary and write it to disk.
            //        // The output that just started writing to now becomes the primary.
            //        int primary = 0; // current primary output
            //        int secondary = 1;
            //        int currentPart = 1;

            //        foreach (AsrSegment asrsegment in fixasr.asrsegments)
            //        {
            //            TimeSpan timespan = TimeSpan.ParseExact(asrsegment.startTime, format, culture);
            //            int currentTime = (int) timespan.TotalSeconds;

            //            // If we are within the overlap time, add to both. Unless we are on the last part.
            //            if ((currentTime >= (sectionNumber * sectionSize)) && (currentTime <= (sectionNumber * sectionSize + overlap)) 
            //                && (currentPart != parts))
            //            {
            //                fixasrSegment[secondary].asrsegments.Add(asrsegment);
            //            }

            //            // If we are past the overlap. Write out the primary to disk and swap primary/secondary.
            //            //  Unless we are on the last part.
            //            if (currentTime > (sectionNumber * sectionSize + overlap)
            //                && (currentPart != parts))
            //            {
            //                WriteSection(outputFolder, primary, sectionNumber);
            //                sectionNumber++;
            //                currentPart++;
            //                fixasrSegment[primary] = new FixasrView();

            //                // Swap primary and secondary
            //                int x = primary;
            //                primary = secondary;
            //                secondary = x;
            //            }

            //            fixasrSegment[primary].asrsegments.Add(asrsegment);

            //        }
            //        // Handle end of file
            //        if (fixasrSegment[primary].asrsegments.Count > 0)
            //        {
            //            WriteSection(outputFolder, primary, sectionNumber);
            //        }
        }

    //    void WriteSection(string outputFolder, int primary, int partNumber)
    //    {
    //        string stringValue = JsonConvert.SerializeObject(fixasrSegment[primary], Formatting.Indented);

    //        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings
    //        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
    //        string outputFile = Path.Combine(outputFolder,$"part{partNumber:D2}","ToFix.json");

    //        File.WriteAllText(outputFile, stringValue);
    //    }
}
}
