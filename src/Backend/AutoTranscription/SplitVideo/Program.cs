using System;

namespace SplitVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RunCommand runCommand = new RunCommand();

            string inputPath = @"..\..\..\Server\WebApp\wwwroot\assets\fullvideo\";
            string filename = "2016-10-11 Boothbay Harbor Selectmen.mp4";
            string inputFile = inputPath + filename;
            string inputFileQuoted = "\"" + inputFile + "\"";
            string command;

            // We can not use the following code to extract segments, since we have overlap.
            //string segmentLength = "180";
            //command = "ffmpeg - i " + inputFile + " - c copy - f segment - segment_time " + segmentLength + " - reset_timestamps 1 % 03d.mp4";
            //command = @"dir " + inputPath;
            //runCommand.ExecuteCmd(command);

            // The following inserts key frames at the points where we want to cut.
            //      string tmpFile = @"..\testdata\tmp.mp4";
            //      string outFile = @"..\testdata\out.mp4";
            //      command = "ffmpeg -i \"" + inputFile + "\" -force_key_frames 00:03:00,00:06:05 " + tmpFile;
            //      runCommand.ExecuteCmd(command);
            // When we inserted the key frames, it  extracted starting at 02:52 instead of at 03:00, which is specified.
            // But interestingly, it extracted up to 06:05, which is the end point we wanted.
            //      command = "ffmpeg -ss 00:03:00 -i " + tmpFile + " -t 00:03:05 -vcodec copy -acodec copy -y " + outFile;
            //      runCommand.ExecuteCmd(command);
            // When we did not insert the key frames, it extracted from exactly 03:00 and it ended at exactly 6:05, 
            // which is what we want. It did not have any unwanted artifacts at the start or end.

            command = "ffmpeg -i ..\\testdata\\tmp.mp4 2>&1";
            //command = "dir ..\\testdata";
            //command = "ffmpeg 2>&1";
            string result = runCommand.ExecuteCmd(command);
            int y = result.IndexOf("Duration: ");
            int z = result.IndexOf(".", y);
            string duration = result.Substring(y + 10, 8);
            TimeSpan time = TimeSpan.Parse(duration);

            // Ffmpeg outputs all of its logging data to stderr,
            //  to leave stdout free for piping the output data to some other program or ffmpeg instance.

            int videoLength = 53 * 60 + 36;     // length of video in seconds
            // we will split the video into 180 second pieces.
            int numberOfSections = videoLength / 180;
            // If the last piece is less than 120 seconds, add it to the last piece.
            if (videoLength - (numberOfSections * 180) < 120)
            {
                numberOfSections--;
            }

            string outFile;
            string startTime;
            TimeSpan ts;
            for (int x = 1; x <= numberOfSections; x++)
            {
                // startTime = "00:03:00";
                ts = TimeSpan.FromSeconds(x * 180);
                startTime = ts.ToString("hh\\:mm\\:ss");
                outFile = @"..\testdata\out-" + startTime.Replace(":", "-") + ".mp4";
                command = "ffmpeg -ss " + startTime + " -i " + inputFileQuoted + " -t 00:03:05 -vcodec copy -acodec copy -y " + outFile;
                runCommand.ExecuteCmd(command);
            }
        }
    }
}

/*
 * https://apple.stackexchange.com/questions/14613/how-do-i-split-a-video-every-x-minutes/110706
 * Split video every 180 seconds.
 * ffmpeg -i input.mp4 -c copy -f segment -segment_time 180 -reset_timestamps 1 %03d.mp4
 *     -c copy disables re-encoding video and audio, like -vcodec copy -acodec copy.
 *     -reset_timestamps 1 makes each segment start with a near-zero timestamp.
 * 
 * http://stackoverflow.com/questions/14005110/how-to-split-a-video-using-ffmpeg-so-that-each-chunk-starts-with-a-key-frame
 * Extract section of video
 * Ok, first of all assuming you know the start and stop duration; we will add key-frames at that duration.
 *      ffmpeg -i a.mp4 -force_key_frames 00:00:09,00:00:12 out.mp4
 * Now you can again try to cut the video from specific time.
 *      ffmpeg -ss 00:00:09 -i out.mp4 -t 00:00:03 -vcodec copy -acodec copy -y final.mp4
 *      
 *      https://superuser.com/questions/1167958/video-cut-with-missing-frames-in-ffmpeg/1168028#1168028
 *      
 *      https://superuser.com/questions/681885/how-can-i-remove-multiple-segments-from-a-video-using-ffmpeg
 *      
 *      My SO question:
 *      http://stackoverflow.com/questions/43814119/split-a-video-with-overlap-between-segments
 *      
 *      https://trac.ffmpeg.org/wiki/Seeking
 *      
 */
