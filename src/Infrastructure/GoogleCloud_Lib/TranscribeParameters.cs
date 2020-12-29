using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf.Collections;


namespace GM.Infrastructure.GoogleCloud
{
    public class TranscribeParameters
    {
        public TranscribeParameters() { }
        public string audiofilePath { get; set; }
        public string objectName { get; set; }
        public string GoogleCloudBucketName { get; set; }
        public bool useAudioFileAlreadyInCloud { get; set; }
        public string language { get; set; } // This is the ISO 639 code
        public int MinSpeakerCount { get; set; }
        public int MaxSpeakerCount { get; set; }
        public RepeatedField<string> phrases { get; set; }
    }
}
