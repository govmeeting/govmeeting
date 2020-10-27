using System;
using System.IO;

namespace GM.EditTranscript
{
    public class SplitRecording
    {

        public int Split(string inputFile, string outputFolder, int segmentSize, int segmentOverlap)
        {

            RunCommand runCommand = new RunCommand();
            Directory.CreateDirectory(outputFolder);

            int videoLength = RecordingLength(inputFile);
            int numberOfSections = videoLength / segmentSize;
            int mod = videoLength % segmentSize;
            // If the last segment is greater than 1/2 segment size, put it in it's own segment.
            if ( mod > (segmentSize/2))
            {
                numberOfSections++;
            }
            //string inputFilename = Path.GetFileNameWithoutExtension(inputFile);

            // Create subfolders part01, part02, part03, etc
            for (int x = 1; x <= numberOfSections; x++)
            {
                int start = (x - 1) * segmentSize;

                string segmentFolder = Path.Combine(outputFolder, $"part{x:D2}");
                Directory.CreateDirectory(segmentFolder);

                string outputFile = Path.Combine(segmentFolder, "ToFix.mp4");
                if (x < numberOfSections)
                {
                    ExtractPart(inputFile, outputFile, start, segmentSize + segmentOverlap);
                }
                else
                {
                    ExtractPart(inputFile, outputFile, start); // extract to end
                }
            }
            return numberOfSections;
        }
        int RecordingLength(string file)
        {
            // Get the length of the video in seconds. We will run the "ffmpeg -i" command and parse the standard output.
            // The line containing "Duration: ...." will contain the duration in HH:MM:SS format.
            // We will convert this to a TimeSpan object and then obtain total seconds.

            RunCommand runCommand = new RunCommand();
            string inputFileQuoted = "\"" + file + "\"";
            // Ffmpeg outputs all of its logging data to stderr,
            //  to leave stdout free for piping the output data to some other program or ffmpeg instance.
            string command = "ffmpeg -i " + inputFileQuoted + " 2>&1";

            string result = runCommand.ExecuteCmd(command);
            int y = result.IndexOf("Duration: ");
            int z = result.IndexOf(".", y);
            string duration = result.Substring(y + 10, 8);
            TimeSpan time = TimeSpan.Parse(duration);
            int videoLength = (int)time.TotalSeconds;     // length of video in seconds
            return videoLength;
        }

        public void ExtractPart(string videofile, string filecopy, string startAsHhmmss, int lengthInSeconds = 0)
        {
            RunCommand runCommand = new RunCommand();
            string length = SecondsToHhmmss(lengthInSeconds);
            // The comand that we build must contain double quotes around the filenames, since these may contain spaces.
            string inputFileQuoted = "\"" + videofile + "\"";
            string outputFileQuoted = "\"" + filecopy + "\"";
            string lengthOption = (lengthInSeconds > 0) ? " -t " + length : "";
            {

            }
            string command = "ffmpeg -ss " + startAsHhmmss + " -i " + inputFileQuoted + lengthOption + " -vcodec copy -acodec copy -y " + outputFileQuoted;
            runCommand.ExecuteCmd(command);
        }
        public void ExtractPart(string videofile, string filecopy, int startTimeInSeconds, int lengthInSeconds = 0)
        {
            string timeString = SecondsToHhmmss(startTimeInSeconds);
            ExtractPart(videofile, filecopy, timeString, lengthInSeconds);
        }

        public static string SecondsToHhmmss(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            string timeString = timeSpan.ToString("hh\\:mm\\:ss");
            return timeString;
        }
    }
}

/*
ffmpeg -ss [start] -i in.mp4 -t [duration] -c copy out.mp4
Here, the options mean the following:
    -ss specifies the start time, e.g. 00:01:23.000 or 83 (in seconds)
    -t specifies the duration of the clip (same format).
    Recent ffmpeg also has a flag to supply the end time with -to.
    -c copy copies the first video, audio, and subtitle bitstream from the input to the output file without re-encoding them.
    This won't harm the quality and make the command run within seconds.
    if you don't specify a duration, it will go to the end.
 */


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
