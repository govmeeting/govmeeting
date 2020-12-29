using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GM.Utilities;
using Google.Protobuf.Collections;


namespace GM.Utilities.DevelopTranscription
{
    public class SampleVideo
    {
        public string path { get; set; }
        public string filename { get; set; }
        public string filepath
        {
            get { return Path.Combine(path, filename); }
        }
        public string objectname { get; set; }
        public RepeatedField<string> phrases { get; set; }

        public SampleVideo(string _path)
        {
            path = _path;
        }
    }

    public class SampleVideos
    {
        public SampleVideo LittleFallsVideo = new SampleVideo(GMFileAccess.GetTestdataFolder())
        {
            // https://www.lfnj.com/
            filename = "USA_NJ_Passaic_LittleFalls_TownshipCouncil_en_2020-06-20.mp4",
            objectname = "USA_NJ_Passaic_LittleFalls_TownshipCouncil_en_2020-06-20.flac",
            phrases = new RepeatedField<string> {
                "James Damiano", "Anthony Sgobba", "Albert Kahwaty",
                "Christopher Vancheri", "Maria Cordonnier", "Tanya Seber", "Charles Cuccia"
        },           
    };

        public SampleVideo VeronaVideo = new SampleVideo(GMFileAccess.GetTestdataFolder())
        {
            // https://www.veronanj.org/
            filename = "USA_NJ_Essex_Verona_TownCouncil_en_2020-05-20.mp4",
            objectname = "USA_NJ_Essex_Verona_TownCouncil_en_2020-05-20.flac",
            phrases = new RepeatedField<string> {
                "Jack McEvoy", "Alex Roman", "Ted Giblin", "Kevin Ryan", "Christine McGrath"
            }
        };

        public SampleVideo BoothbayHarborVideo = new SampleVideo(GMFileAccess.GetTestdataFolder())
        {
            filename = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.mp4",
            objectname = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15.flac",
            phrases = new RepeatedField<string> {
                "Denise Griffin", "Jay Warren","Wendy Wolf", "Russell Hoffman", "William Hamblen",
                "Thomas Woodin", "Tom Woodin", "Kellie Bigos", "Julia Latter"
            }
        };
    }
}
