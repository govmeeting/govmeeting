using System;
using System.IO;
using GM.Infrastructure.GetOnlineFiles;
using GM.Utilities;

namespace GM.Utilities.DevelopRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string outputFolder = Path.Combine(GMFileAccess.GetTestdataFolder(), "DevelopRetrieval");

            USA_TX_TravisCounty_Austin_CityCouncil_en getTrans = new USA_TX_TravisCounty_Austin_CityCouncil_en();

            DateTime lastMeetingTime = new DateTime(2020, 1, 1);
            bool result = getTrans.Do(lastMeetingTime, outputFolder);
        }
    }
}

/* Tampa, FL - City Council - https://apps.tampagov.net/cttv_cc_webapp/ - real time captioning
 * Boston, MA - http://michelleforboston.com/how-to-access-council-meeting-transcripts/
 *              https://www.boston.gov/public-notices/archive
 * Cambridge, MA - With $100 software and some time for editing, clerk makes full City Council transcripts a thing
 * Gulf Port, FL  - https://mygulfport.us/councilmeetings/  videos
 * Sudbury, MA - https://sudbury.vod.castus.tv/vod/?nav=programs%2FBoard%20of%20Selectmen
 * Scituate, MA - https://www.youtube.com/watch?v=D6gVn0L08is
 * Rockland, MA - https://www.youtube.com/watch?v=sbIfViMz7oY&list=PLH12n7SsKux-3JFMM22qHA2Uv3krGX08V
 * Harwich, MA - https://www.youtube.com/watch?v=AJK_jihjQ-A&list=PLSetH4aNaSHBn8dDqQid4sJahXKYtijRr
 * Stow, MA - https://www.youtube.com/watch?v=YPS57dRYIH8
 * Whitman, MA - https://www.youtube.com/watch?v=ZCzaErwivPI
 * Hanson, MA - https://www.youtube.com/watch?v=rLC2E7RkZeg
 * Maynard, MA - https://www.youtube.com/watch?v=Hf9Q6sFJYnA&list=PLcuBlhTLdwuQzeykXm6Dv0AZqDy4MkVY_
 * York, ME - https://www.youtube.com/watch?v=QV5cy9vs4Do  - 3hr
 * Freetown, MA - https://www.youtube.com/watch?v=d4w7zsCbqcc
 * Somers CT - https://www.youtube.com/watch?v=2gFPhq1vCeg
 * Acton, MA - https://www.youtube.com/watch?v=XTbrxNgG14E
 * Shrewsbury, MA -  https://www.youtube.com/watch?v=XTbrxNgG14E -  2.5hr
 * Baldwin, ME - https://www.youtube.com/watch?v=KEz5Ww8X70Y
 * Haddam, CT - https://www.youtube.com/watch?v=jvgeeL18lpc
 * Old Saybrook, CT - https://www.youtube.com/watch?v=ZifcXwbtz9U
 * Lebanon, ME - https://www.youtube.com/watch?v=S8QRN7OwkiM
 * South Thomaston, ME - https://www.youtube.com/watch?v=YUl8UchPOQ8
 * Hartland, ME - https://www.youtube.com/watch?v=6SrXnbgjt2M
 */
