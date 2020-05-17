using Google.Cloud.Speech.V1;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GM.GoogleCLoud
{
    class StreamTranscribe
    {
        // usage in speech api sample
        // (StreamingOptions opts) => StreamingRecognizeAsync(opts.FilePath).Result

        /// <summary>
        /// Stream the content of the file to the API in 32kb chunks.
        /// </summary>
        // [START speech_streaming_recognize]
        static async Task<object> StreamingRecognizeAsync(string filePath)
        {
            var speech = SpeechClient.Create();
            var streamingCall = speech.StreamingRecognize();
            // Write the initial request with the config.
            await streamingCall.WriteAsync(
                new StreamingRecognizeRequest()
                {
                    StreamingConfig = new StreamingRecognitionConfig()
                    {
                        Config = new RecognitionConfig()
                        {
                            // Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                            Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                            // SampleRateHertz = 16000,
                            SampleRateHertz = 48000,
                            LanguageCode = "en",
                        },
                        InterimResults = true,
                    }
                });
            string responseText = "";
            // Print responses as they arrive.
            Task printResponses = Task.Run(async () =>
            {
                while (await streamingCall.ResponseStream.MoveNext(
                    default(CancellationToken)))
                {
                    foreach (var result in streamingCall.ResponseStream
                        .Current.Results)
                    {
                        foreach (var alternative in result.Alternatives)
                        {
                            Console.WriteLine("StreamTranscribe.cs - " + alternative.Transcript);
                            responseText = responseText + alternative.Transcript + "\n";
                        }
                    }
                }
            });
            // Stream the file content to the API.  Write 2 32kb chunks per 
            // second.
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                var buffer = new byte[32 * 1024];
                int bytesRead;
                while ((bytesRead = await fileStream.ReadAsync(
                    buffer, 0, buffer.Length)) > 0)
                {
                    await streamingCall.WriteAsync(
                        new StreamingRecognizeRequest()
                        {
                            AudioContent = Google.Protobuf.ByteString
                            .CopyFrom(buffer, 0, bytesRead),
                        });
                    await Task.Delay(500);
                };
            }
            await streamingCall.WriteCompleteAsync();
            await printResponses;
            return responseText;
        }
        // [END speech_streaming_recognize]



        //static async Task<object> StreamingMicRecognizeAsync(int seconds)
        //{
        //    if (NAudio.Wave.WaveIn.DeviceCount < 1)
        //    {
        //        Console.WriteLine("StreamTranscribe.cs - No microphone!");
        //        return -1;
        //    }
        //    var speech = SpeechClient.Create();
        //    var streamingCall = speech.StreamingRecognize();
        //    // Write the initial request with the config.
        //    await streamingCall.WriteAsync(
        //        new StreamingRecognizeRequest()
        //        {
        //            StreamingConfig = new StreamingRecognitionConfig()
        //            {
        //                Config = new RecognitionConfig()
        //                {
        //                    Encoding =
        //                    RecognitionConfig.Types.AudioEncoding.Linear16,
        //                    SampleRateHertz = 16000,
        //                    LanguageCode = "en",
        //                },
        //                InterimResults = true,
        //            }
        //        });
        //    // Print responses as they arrive.
        //    Task printResponses = Task.Run(async () =>
        //    {
        //        while (await streamingCall.ResponseStream.MoveNext(
        //            default(CancellationToken)))
        //        {
        //            foreach (var result in streamingCall.ResponseStream
        //                .Current.Results)
        //            {
        //                foreach (var alternative in result.Alternatives)
        //                {
        //                    Console.WriteLine("StreamTranscribe.cs - " + alternative.Transcript);
        //                }
        //            }
        //        }
        //    });
        //    // Read from the microphone and stream to API.
        //    object writeLock = new object();
        //    bool writeMore = true;
        //    var waveIn = new NAudio.Wave.WaveInEvent();
        //    waveIn.DeviceNumber = 0;
        //    waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
        //    waveIn.DataAvailable +=
        //        (object sender, NAudio.Wave.WaveInEventArgs args) =>
        //        {
        //            lock (writeLock)
        //            {
        //                if (!writeMore) return;
        //                streamingCall.WriteAsync(
        //                    new StreamingRecognizeRequest()
        //                    {
        //                        AudioContent = Google.Protobuf.ByteString
        //                            .CopyFrom(args.Buffer, 0, args.BytesRecorded)
        //                    }).Wait();
        //            }
        //        };
        //    waveIn.StartRecording();
        //    Console.WriteLine("StreamTranscribe.cs - Speak now.");
        //    await Task.Delay(TimeSpan.FromSeconds(seconds));
        //    // Stop recording and shut down.
        //    waveIn.StopRecording();
        //    lock (writeLock) writeMore = false;
        //    await streamingCall.WriteCompleteAsync();
        //    await printResponses;
        //    return 0;
        //}
    }
}
