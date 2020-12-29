using System;
using System.IO;
using Google.Protobuf.Collections;
using Google.Cloud.Speech.V1P1Beta1;
using Newtonsoft.Json;
using GM.Application.DTOs.Meetings;

namespace GM.Infrastructure.GoogleCloud
{

    public class TranscribeAudio
    {
        private readonly SpeechClient speechClient;

        public TranscribeAudio()
        {
            speechClient = SpeechClient.Create();
        }

        public TranscribedDto TranscribeAudioFile(TranscribeParameters transParams, string rawResponseFile = null)
        {
            LongRunningRecognizeResponse response = UploadAndTranscribeInCloud(transParams);

            // Save the raw response, if we were passed a file path.
            if (rawResponseFile != "")
            {
                string responseString = JsonConvert.SerializeObject(response, Formatting.Indented);
                File.WriteAllText(rawResponseFile, responseString);
            }

            TranscribedDto resp = TransformResponse.Simpify(response.Results);

            return TransformResponse.FixSpeakerTags(resp);
        }

        // Transcribe a local audio file. We can only use this with audios up to 1 minute long.
        public TranscribedDto TranscribeLocalFile(string fileName, string language)
        {
            //    // var speechClient = SpeechClient.Create();
            RecognitionAudio recogAudio = RecognitionAudio.FromFile(fileName);

            var response = speechClient.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 48000,
                EnableWordTimeOffsets = true,
                LanguageCode = language,
            }, recogAudio);

            TranscribedDto resp = TransformResponse.Simpify(response.Results);

            return TransformResponse.FixSpeakerTags(resp);
        }


        public LongRunningRecognizeResponse UploadAndTranscribeInCloud(TranscribeParameters transParams)
        {
            UploadToCloudIfNeeded(transParams);

            LongRunningRecognizeResponse response = TranscribeInCloud(transParams);
            return response;
        }

        private void UploadToCloudIfNeeded(TranscribeParameters transParams)
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
                SampleRateHertz = 44100,
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


        ////////////////////////////////////////////////////////////////////////////////////////// 
        ///  Original code for fixasr component
        //////////////////////////////////////////////////////////////////////////////////////////   

        //public TranscribeResultOrig MoveToCloudAndTranscribeOrig(TranscribeParameters transParams)
        //{
        //    LongRunningRecognizeResponse response = MoveToCloudAndTranscribe(transParams);

        //    TranscribeResultOrig rsp = TransformResp(response.Results);
        //    return rsp;
        //}

        //// Transcribe a local audio file. We can only use this with audios up to 1 minute long.
        //public TranscribeResultOrig TranscribeFile(string fileName, string language)
        //{
        //    // var speechClient = SpeechClient.Create();
        //    RecognitionAudio recogAudio = RecognitionAudio.FromFile(fileName);

        //    var response = speechClient.Recognize(new RecognitionConfig()
        //    {
        //        Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
        //        SampleRateHertz = 48000,
        //        EnableWordTimeOffsets = true,
        //        LanguageCode = language,
        //    }, recogAudio);

        //    // Transform the Google response into a more usable object.
        //    TranscribeResultOrig transcript = GetShortTranscribeResponse(response);
        //    return transcript;
        //}

        //private TranscribeResultOrig GetShortTranscribeResponse(RecognizeResponse response)
        //{
        //    return TransformResp(response.Results);
        //}


        //private TranscribeResultOrig TransformResp(RepeatedField<SpeechRecognitionResult> results)
        //{
        //    TranscribeResultOrig transcript = new TranscribeResultOrig();

        //    foreach (var result in results)
        //    {
        //        foreach (var alternative in result.Alternatives)
        //        {
        //            Console.WriteLine($"Transcript: { alternative.Transcript}");
        //            Console.WriteLine("Word details:");
        //            Console.WriteLine($" Word count:{alternative.Words.Count}");

        //            RspAlternative alt = new RspAlternative(alternative.Transcript)
        //            {
        //                wordCount = alternative.Words.Count
        //            };

        //            int count = 1;
        //            foreach (var item in alternative.Words)
        //            {
        //                alt.words.Add(new RspWord(item.Word, ParseDuration(item.StartTime),
        //                    ParseDuration(item.EndTime), count++));

        //                Console.WriteLine($"  {item.Word}");
        //                Console.WriteLine($"    WordStartTime: {item.StartTime}");
        //                Console.WriteLine($"    WordEndTime: {item.EndTime}");
        //            }
        //            transcript.alternatives.Add(alt);
        //        }
        //    }
        //    return transcript;
        //}

    }
} 
