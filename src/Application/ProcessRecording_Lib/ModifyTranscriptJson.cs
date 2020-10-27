using System;
using System.Collections.Generic;
using System.Text;
using GM.ViewModels;
using GM.GoogleCloud;

namespace GM.ProcessRecording
{

    /**********************************************************************
     * Modify the Google speech format to our own "EdittranscriptView" format.
     ***********************************************************************/

    public class ModifyTranscriptJson
    {

        public EditTranscriptViewModel Modify(TranscribeResult transcript)
        {
            EditTranscriptViewModel editmeeting = new EditTranscriptViewModel();

            foreach (Result result in transcript.results)
            {
                Talk talk = new Talk(result.text, result.confidence);
                int speaker = -1;

                foreach (RespWord respword in result.words)
                {
                    Word word = new Word(
                        respword.word,
                        respword.confidence,
                        respword.startTime,
                        respword.endTime,
                        respword.speakerTag,
                        respword.wordNum
                    );
                    if (speaker != word.speaker)
                    {
                        if (speaker != -1)
                        {
                            editmeeting.talks.Add(talk);
                            talk = new Talk(result.text, result.confidence);
                        }
                        speaker = word.speaker;
                        talk.speaker = "Speaker " + speaker.ToString();
                    }
                    talk.words.Add(word);
                }
                editmeeting.talks.Add(talk);
            }
            return editmeeting;
        }

        public EditTranscriptViewModel Modify2(TranscribeResult transcript)
        {
            EditTranscriptViewModel editmeeting = new EditTranscriptViewModel();

            foreach (Result result in transcript.results)
            {
                Talk talk = new Talk(result.text, result.confidence);

               int speaker = -1;
               foreach (RespWord respword in result.words)
                {
                    Word word = new Word(
                        respword.word,
                        respword.confidence,
                        respword.startTime,
                        respword.endTime,
                        respword.speakerTag,
                        respword.wordNum
                    );

                    // Check if the speaker is the same for all words
                    // "speaker" will equal "-2" if different speakers.
                    if (speaker != -2)
                    {
                        if (speaker == -1)
                        {
                            speaker = word.speaker;  // we found first speaker (could also be 0)
                        }
                        else
                        {
                            if (speaker != word.speaker)
                            {
                                speaker = -2;  // we found two speakers do not match
                            }
                        }
                    }

                    switch (speaker)
                    {
                        case 0:
                            talk.speaker = "UNKOWN";
                            break;
                        case -2:
                            talk.speaker = "DIFFERENT";
                            break;
                        default:
                            talk.speaker = "Speaker " + speaker.ToString();
                            break;
                    }

                    talk.words.Add(word);

                }
                editmeeting.talks.Add(talk);
            }
            return editmeeting;
        }
    }
}
