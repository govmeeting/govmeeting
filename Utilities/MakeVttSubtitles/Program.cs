//using GM.Application.DTOs.Meetings;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MakeVttSubtitles
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_SUBTITLE = 40;
            int MIN_SPLIT = 20;

            Console.WriteLine("Start of MakeVttSubtitles");

            string workFolder = @"C:\GOVMEETING\_SOURCECODE\src\WebUI\WebApp\clientapp\src\assets\stubdata";
            string editFile = workFolder + @"\ToEdit.json";
            string vttFile = workFolder + @"\ToEdit.vtt";

            using FileStream fs = File.Create(vttFile);
            using var vtt = new StreamWriter(fs);
            vtt.WriteLine("WEBVTT");
            vtt.WriteLine();

            string editMeetingDto = File.ReadAllText(editFile);
            EditMeetingModel editMeeting = JsonConvert.DeserializeObject<EditMeetingModel>(editMeetingDto);

            //string firstWord = editMeeting.Talks[0].Words[0].Word;

            foreach (TalkModel talk in editMeeting.talks)
            {
                int start;
                int next;
                int lastword = talk.words.Length - 1;
                string speaker = talk.speaker;
                string said = talk.said;
                //if (said.Length <= MAX_SUBTITLE)
                //{
                //    start = talk.words[0].starttime;
                //    next = talk.words[lastword].endtime;

                //    vtt.WriteLine(FormatVttTimeLine(start, next));
                //    vtt.WriteLine(said);
                //    vtt.WriteLine();
                //}
                //else
                //{
                    string word;
                    start = 0;
                    next = -1;
                    while (++next <= lastword)
                    {
                        // Are we on last word in talk?
                        if (next == lastword)
                        {
                            WriteSubtitles(vtt, talk.words, start, next);
                            break;
                        }

                        // Does this word end in punctuation?
                        word = talk.words[next].word;
                        if (HasPunctuation(word) && (start != next))
                        {
                            WriteSubtitles(vtt, talk.words, start, next);
                            start = next +1;
                            continue;
                        }

                        // Is the following word a "break" word?
                        word = talk.words[next + 1].word;
                        if (IsBreakWord(word))
                        {
                            WriteSubtitles(vtt, talk.words, start, next);
                            start = next + 1;
                            continue;
                        }
                    //}
                }
            }
            vtt.Flush();
            vtt.Close();
        }

        static bool HasPunctuation(string word)
        {
            string[] breakAfterPuncuation = { ".", "?", ",", ";" };

            foreach (string breakpunc in breakAfterPuncuation)
            {
                if (word.EndsWith(breakpunc))
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsBreakWord(string word)
        {
            string[] breakWords = { "and", "but", "or", "and", "which", "that" };
            foreach (string bword in breakWords)
            {
                if (word == bword)
                {
                    return true;
                }
            }
            return false;
        }

        static void WriteSubtitles(StreamWriter vtt, WordModel[] words, int start, int end)
        {
            int MAX_WORDS_IN_SUBTITLE = 12;

            int wordcount = end - start + 1;

            if (wordcount <= MAX_WORDS_IN_SUBTITLE)
            {
                WriteSubtitle(vtt, words, start, end);
            }
            else
            {
                int halfcount = wordcount / 2;
                WriteSubtitle(vtt, words, start, start + halfcount);
                WriteSubtitle(vtt, words, start + halfcount + 1, end);
            }
        }

        static void WriteSubtitle(StreamWriter vtt, WordModel[] words, int start, int end)
        {
            string subtitle;
            subtitle = GetSubtitle(words, start, end);
            vtt.WriteLine(FormatVttTimeLine(words[start].starttime, words[end].endtime));
            vtt.WriteLine(subtitle);
            vtt.WriteLine();
        }

        static string GetSubtitle(WordModel[] words, int start, int end)
        {
            string subtitle = "";
            for (int i = start; i <= end; i++)
            {
                if (i != start)
                {
                    subtitle = subtitle + " ";
                }
                subtitle = subtitle + words[i].word;
            }
            return subtitle;
        }

        static string FormatVttTimeLine(int startms, int endms)
        {
            double start = (double) startms / 1000;
            double end = (double) endms / 1000;
            string line = SecondsToTime(start) + " --> " + SecondsToTime(end);
            return line;
        }

        static string SecondsToTime(double seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
            return answer;
        }
    }
}
