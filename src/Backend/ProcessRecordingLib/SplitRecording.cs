using System;
using System.IO;

namespace GM.ProcessRecordingLib
{
    public class SplitRecording
    {

            public void Split(string inputFile, string outputFolder)
        {
            RunCommand runCommand = new RunCommand();

            string inputFileQuoted = "\"" + inputFile + "\"";

            string command = "ffmpeg -i " + inputFileQuoted + " 2>&1";

            Directory.CreateDirectory(outputFolder);

            // Ffmpeg outputs all of its logging data to stderr,
            //  to leave stdout free for piping the output data to some other program or ffmpeg instance.

            // Get the lenght of the video in seconds. We will run the "ffmpeg -i" command and parse the standard output.
            // The line containing "Duration: ...." will contain the duration in HH:MM:SS format.
            // We will convert this to a TimeSpan object and then obtain total seconds.
            string result = runCommand.ExecuteCmd(command);
            int y = result.IndexOf("Duration: ");
            int z = result.IndexOf(".", y);
            string duration = result.Substring(y + 10, 8);
            TimeSpan time = TimeSpan.Parse(duration);
            int vlen = (int) time.TotalSeconds;
            int videoLength = 53 * 60 + 36;     // length of video in seconds

            // We will split the video into 180 (+ 5) second pieces.
            // There are two reasons for splitting.
            //  1. The voice recognition software will only allow up to 180 seconds of audio to be processed with one call.
            //  2. It will improve network delays if we can send only 3 minutes at a time to volunteer who are proof reading
            //     the results of the voice recognition.
            // Each piece will start at a 180 second margin: 03:00, 06:00, 09:00, etc.
            // But we will split the video into 185 second segments.
            // Thus there will be 5 seconds of overlap between consecutive pieces.
            // We do this in order to improve the voice recognition. Normally there are the half words and
            // half phrases at the start and end of segments. By having overlap, these can be ignored and we can
            // match up proper full words and phrases near the start and end that occur in each segment.

            int numberOfSections = videoLength / 180;
            // If the last piece is less than 120 seconds, add it to the last piece.
            if (videoLength - (numberOfSections * 180) < 120)
            {
                numberOfSections--;
            }

            string outputFile;
            string outputFileQuoted;
            string startTime;
            string filename = Path.GetFileNameWithoutExtension(inputFile);

            TimeSpan ts;
            for (int x = 0; x <= numberOfSections; x++)
            {
                ts = TimeSpan.FromSeconds(x * 180);
                startTime = ts.ToString("hh\\:mm\\:ss");
                outputFile = outputFolder + "\\" + filename + startTime.Replace(":", "-") + ".mp4";
                outputFileQuoted = "\"" + outputFile + "\"";
                command = "ffmpeg -ss " + startTime + " -i " + inputFileQuoted + " -t 00:03:05 -vcodec copy -acodec copy -y " + outputFileQuoted;
                runCommand.ExecuteCmd(command);
            }
        }
    }
}


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
