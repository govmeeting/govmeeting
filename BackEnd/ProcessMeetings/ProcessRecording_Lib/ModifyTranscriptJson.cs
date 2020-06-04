using System;
using System.Collections.Generic;
using System.Text;
using GM.ViewModels;
using GM.GoogleCLoud;

namespace GM.ProcessRecording
{

    /**********************************************************************
     * Modify the trancription output from Google speech format to our own "FixasrView" format.
     ***********************************************************************/

    public class ModifyTranscriptJson
    {
        public FixtagviewView Modify(TranscribeResponse transcript)
        {
            FixtagviewView fixtagview = new FixtagviewView();

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

                fixtagview.talks.Add(talk);
            }
            return fixtagview;
        }

    }
}
