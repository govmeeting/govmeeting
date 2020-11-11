using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Utilities
{
    public class AudioProcessing
    {
        public int RecordingLength(string file)
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
            //int z = result.IndexOf(".", y);
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

        // Extract the audio from a file
        public void Extract(string inputFile, string outputFile)
        {
            RunCommand runCommand = new RunCommand();

            string inputFileQuoted = "\"" + inputFile + "\"";
            string outputFileQuoted = "\"" + outputFile + "\"";

            string command = "ffmpeg -i " + inputFileQuoted + " -ac 1 -ab 192000 -vn " + outputFileQuoted + " 2>&1";
            runCommand.ExecuteCmd(command);

            //// Convert to mono (it's now done in one step above)
            //string monoFileQuoted = "\"" + monoFile + "\"";
            //command = "ffmpeg -i " + outputFileQuoted + " -ac 1 " + monoFileQuoted + " 2>&1";
            //runCommand.ExecuteCmd(command);
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
