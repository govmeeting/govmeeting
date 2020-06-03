using System;
using System.IO;
using Google.Protobuf.Collections;
using Microsoft.Extensions.Options;
using GM.Configuration;
using Google.Cloud.Speech.V1P1Beta1;

namespace GM.GoogleCLoud
{
    public class TranscribeParameters
    {
        public TranscribeParameters() { }
        public string audiofilePath { get; set; }
        public string objectName { get; set; }
        public string GoogleCloudBucketName { get; set; }
        public bool useAudioFileAlreadyInCloud { get; set; }
        public string language { get; set; }
        public int MinSpeakerCount { get; set; }
        public int MaxSpeakerCount { get; set; }
        public RepeatedField<string> phrases { get; set; }
    }

    public class TranscribeAudio
    {
        //private AppSettings config;
        //private string GoogleCloudBucketName;

        private SpeechClient speechClient;

        public TranscribeAudio()
        {
            //GoogleCloudBucketName = config.GoogleCloudBucketName;
            speechClient = SpeechClient.Create();
        }

        /// <param name="language">Language of the audio. This is the ISO 639 code</param>
        /// The audio file name may have been shortened. For the cloud object name, we want to use the original full
        /// name of the video, but change the extension to ".flac".
        public TranscribeResponse MoveToCloudAndTranscribe(TranscribeParameters transParams)
            //string audiofilePath, string objectName, string GoogleCloudBucketName, bool useAudioFileAlreadyInCloud, string language)
        {
            GoogleBucket gb = new GoogleBucket();

            if (transParams.useAudioFileAlreadyInCloud)
            {
                // Only upload if not in cloud
                if (!gb.IsObjectInBucket(transParams.GoogleCloudBucketName, transParams.objectName))
                {
                    gb.UploadFile(transParams.GoogleCloudBucketName, transParams.audiofilePath, transParams.objectName, "audio /x-flac");
                }
            }
            TranscribeResponse transcript = TranscribeInCloud(transParams);
            return transcript;
        }

        public TranscribeResponse TranscribeInCloud(TranscribeParameters transParams)
        {
            // var speechClient = SpeechClient.Create();

            string fileOnCloudStorage = "gs://" + transParams.GoogleCloudBucketName + "/" + transParams.objectName;
            RecognitionAudio recogAudio = RecognitionAudio.FromStorageUri(fileOnCloudStorage);

            SpeakerDiarizationConfig sdc = new SpeakerDiarizationConfig()
            {
                EnableSpeakerDiarization = true,
                MinSpeakerCount = transParams.MinSpeakerCount,
                MaxSpeakerCount = transParams.MaxSpeakerCount
            };

            var longOperation = speechClient.LongRunningRecognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 48000,
                EnableWordTimeOffsets = true,
                LanguageCode = transParams.language,
                EnableAutomaticPunctuation = true,
                DiarizationConfig = sdc,
                SpeechContexts = {
                    new SpeechContext {
                        Phrases = { transParams.phrases }
                    }
                }
            }, recogAudio);
            longOperation = longOperation.PollUntilCompleted();
            var response = longOperation.Result;

            // Transform the Google response into a more usable object.
            // TranscribeResponse transcript = GetLongTranscribeResponse(response);

            TranscribeResponse transcript = new TranscribeResponse();

            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine($"Transcript: { alternative.Transcript}");
                    Console.WriteLine("Word details:");
                    Console.WriteLine($" Word count:{alternative.Words.Count}");

                    RspAlternative alt = new RspAlternative(alternative.Transcript)
                    {
                        wordCount = alternative.Words.Count
                    };

                    int count = 1;
                    foreach (var item in alternative.Words)
                    {
                        alt.words.Add(new RspWord(item.Word, ParseDuration(item.StartTime),
                            ParseDuration(item.EndTime), count++));

                        Console.WriteLine($"  {item.Word}");
                        Console.WriteLine($"    WordStartTime: {item.StartTime}");
                        Console.WriteLine($"    WordEndTime: {item.EndTime}");
                    }
                    transcript.alternatives.Add(alt);
                }
            }
            return transcript;
        }


        // Transcribe a local audio file. We can only use this with audios up to 1 minute long.
        public TranscribeResponse TranscribeFile(string fileName, string language)
        {
            // var speechClient = SpeechClient.Create();
            RecognitionAudio recogAudio = RecognitionAudio.FromFile(fileName);

            var response = speechClient.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 48000,
                EnableWordTimeOffsets = true,
                LanguageCode = language,
            }, recogAudio);

            // Transform the Google response into a more usable object.
            TranscribeResponse transcript = GetShortTranscribeResponse(response);
            return transcript;
        }

        TranscribeResponse GetLongTranscribeResponse(LongRunningRecognizeResponse response)
        {
            return GetTranscribeResponse(response.Results);
        }

        TranscribeResponse GetShortTranscribeResponse(RecognizeResponse response)
        {
            return GetTranscribeResponse(response.Results);
        }

        public TranscribeResponse GetTranscribeResponse(RepeatedField<SpeechRecognitionResult> results)
        {
            TranscribeResponse transcript = new TranscribeResponse();

            foreach (var result in results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine($"Transcript: { alternative.Transcript}");
                    Console.WriteLine("Word details:");
                    Console.WriteLine($" Word count:{alternative.Words.Count}");

                    RspAlternative alt = new RspAlternative(alternative.Transcript)
                    {
                        wordCount = alternative.Words.Count
                    };

                    int count = 1;
                    foreach (var item in alternative.Words)
                    {
                        alt.words.Add(new RspWord(item.Word, ParseDuration(item.StartTime),
                            ParseDuration(item.EndTime), count++));

                        Console.WriteLine($"  {item.Word}");
                        Console.WriteLine($"    WordStartTime: {item.StartTime}");
                        Console.WriteLine($"    WordEndTime: {item.EndTime}");
                    }
                    transcript.alternatives.Add(alt);
                }
            }
            return transcript;
        }

        int ParseDuration(Google.Protobuf.WellKnownTypes.Duration duration)
        {
            String s = duration.ToString();
            s = s.Replace("s", "");
            s = s.Replace("\"", "");
            double d = Double.Parse(s);
            int milliseconds = (int) (d * 1000);
            return milliseconds;
        }

        // This method is not currently used. It would allow us to set the Google Application credentials file
        // when we create the SpeechClient. However, we are instead setting the environment variable
        // "GOOGLE_APPLICATION_CREDENTIALS" in a higher level routine. The Google Cloud libraries then
        // automatically use that value.

        // SpeechClient GetSpeechClient()
        // {
        //     string credentialsFilePath = config.GoogleApplicationCredentials;

        //     GoogleCredential googleCredential;
        //     using (Stream m = new FileStream(credentialsFilePath, FileMode.Open))
        //         googleCredential = GoogleCredential.FromStream(m);
        //     var channel = new Grpc.Core.Channel(SpeechClient.DefaultEndpoint.Host,
        //         googleCredential.ToChannelCredentials());
        //     var speech = SpeechClient.Create(channel);
        //     return speech;
        // }

    }
} 
