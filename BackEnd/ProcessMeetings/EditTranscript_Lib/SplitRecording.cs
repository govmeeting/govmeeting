using GM.Utilities;
using System;
using System.IO;

namespace GM.EditTranscript
{
    public class SplitRecording
    {

        public int Split(string inputFile, string outputFolder, int segmentSize, int segmentOverlap)
        {

            //RunCommand runCommand = new RunCommand();
            AudioProcessing audioProcessing = new AudioProcessing();

            Directory.CreateDirectory(outputFolder);

            int videoLength = audioProcessing.RecordingLength(inputFile);
            int numberOfSections = videoLength / segmentSize;
            int mod = videoLength % segmentSize;
            // If the last segment is greater than 1/2 segment size, put it in it's own segment.
            if (mod > (segmentSize / 2))
            {
                numberOfSections++;
            }
            //string inputFilename = Path.GetFileNameWithoutExtension(inputFile);

            // Create subfolders part01, part02, part03, etc
            for (int x = 1; x <= numberOfSections; x++)
            {
                int start = (x - 1) * segmentSize;

                string segmentFolder = outputFolder + $"\\part{x:D2}";
                Directory.CreateDirectory(segmentFolder);

                string outputFile = segmentFolder + "\\" + "ToFix.mp4";
                if (x < numberOfSections)
                {
                    audioProcessing.ExtractPart(inputFile, outputFile, start, segmentSize + segmentOverlap);
                }
                else
                {
                    audioProcessing.ExtractPart(inputFile, outputFile, start); // extract to end
                }
            }
            return numberOfSections;
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
