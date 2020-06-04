using System;
using System.IO;
using Google.Protobuf.Collections;
using Microsoft.Extensions.Options;
using GM.Configuration;
using Google.Cloud.Speech.V1P1Beta1;
using Newtonsoft.Json;

namespace GM.GoogleCLoud
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

    public class TranscribeAudio
    {
        private SpeechClient speechClient;

        public TranscribeAudio()
        {
            speechClient = SpeechClient.Create();
        }

        // TranscribeRsp is the original format that we returned when using fixasr
        // TranscribeResponse is the new format for fixtagview.

        public TranscribeResponse TranscribeAudioFile(TranscribeParameters transParams)
        {
            LongRunningRecognizeResponse response = _MoveToCloudAndTranscribe(transParams);

            string responseString = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(@"C:\GOVMEETING\TESTDATA\DevelopTranscription\rawResponse.json", responseString);

            TranscribeResponse rsp = TransformResponse(response.Results);
            return rsp;
        }

        public TranscribeRsp MoveToCloudAndTranscribe(TranscribeParameters transParams)
        {
            LongRunningRecognizeResponse response = _MoveToCloudAndTranscribe(transParams);
            TranscribeRsp rsp = TransformResp(response.Results);
            return rsp;
        }
        private LongRunningRecognizeResponse _MoveToCloudAndTranscribe(TranscribeParameters transParams)
        {
            MoveToCloudIfNeeded(transParams);
            LongRunningRecognizeResponse response = TranscribeInCloud(transParams);
            return response;
        }

        private void MoveToCloudIfNeeded(TranscribeParameters transParams)
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
        }

        public LongRunningRecognizeResponse TranscribeInCloud(TranscribeParameters transParams)
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

            return response;
        }


        // Transcribe a local audio file. We can only use this with audios up to 1 minute long.
        public TranscribeRsp TranscribeFile(string fileName, string language)
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
            TranscribeRsp transcript = GetShortTranscribeResponse(response);
            return transcript;
        }

        private TranscribeRsp GetShortTranscribeResponse(RecognizeResponse response)
        {
            return TransformResp(response.Results);
        }

        private TranscribeRsp TransformResp(RepeatedField<SpeechRecognitionResult> results)
        {
            TranscribeRsp transcript = new TranscribeRsp();

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

        private TranscribeResponse TransformResponse(RepeatedField<SpeechRecognitionResult> srrs)
        {
            TranscribeResponse transcript = new TranscribeResponse();
            int resultCount = 0;
            int totalCount = 0;

            foreach (SpeechRecognitionResult srr in srrs)
            {
                if (srr.Alternatives.Count > 1)
                {
                    resultCount++;
                    Console.WriteLine($"ERROR: more than 1 alternative - result {resultCount}");
                };

                SpeechRecognitionAlternative sra = srr.Alternatives[0];

                Result result = new Result(sra.Transcript)
                {
                    wordCount = sra.Words.Count,
                    confidence = sra.Confidence
                };
                Console.WriteLine($"Next result: {sra.Words.Count} words");

                foreach (var item in sra.Words)
                {;
                    totalCount++;
                    long startTime = item.StartTime.Seconds * 1000 +item.StartTime.Nanos / 1000000;
                    long endTime = item.EndTime.Seconds * 1000 + item.EndTime.Nanos / 1000000;

                    result.words.Add(new RespWord(item.Word, item.Confidence, startTime, endTime,item.SpeakerTag, totalCount));
                }
                transcript.results.Add(result);
            }
            return transcript;
        }

        private int ParseDuration(Google.Protobuf.WellKnownTypes.Duration duration)
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
