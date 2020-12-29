using System.Collections.Generic;


namespace GM.OldViewModels
{
    public class OldFormatConversion
    {
        public AddtagsViewModel ConvertToMeetingViewDto(FixasrViewModel fixasr)
        {
            AddtagsViewModel addtags = new AddtagsViewModel();
            addtags.talks = new List<TalksView>();
            TalksView talk = new TalksView();
            talk.said = "";
            foreach (AsrSegment segment in fixasr.asrsegments)
            {
                string text = segment.said;
                string speaker = null;
                int startNextSpokenText = 0;
                int endLastSpokenText = -1;
                do
                {
                    int start = startNextSpokenText;
                    bool isNewSpeaker = GetNextSpeaker(text, ref startNextSpokenText, ref endLastSpokenText, ref speaker);

                    // If we have the start of a new speaker, close the current talk object and start another.
                    if (isNewSpeaker)
                    {
                        // If anything said by prior speaker on this line, add it to the text.
                        if ((endLastSpokenText - start) > 0)
                        {
                            string lasttext = text.Substring(start, endLastSpokenText - start);
                            talk.said = talk.said + lasttext;
                        }
                        // If the prior speaker said anything at all, add the talk object to addtags and start a new talk object.
                        if (talk.said.Length > 0)
                        {
                            addtags.talks.Add(talk);
                            talk = new TalksView();
                            talk.speaker = speaker;
                            talk.said = "";
                        }
                    }
                    else
                    {
                        if (talk.said != "")
                        {
                            talk.said = talk.said + " ";
                        }
                        talk.said = talk.said + text.Substring(start);
                        break;
                    }

                } while (true);
            }
            if (talk.said.Length > 0)
            {
                addtags.talks.Add(talk);
            }
            return addtags;
        }

        // Find the next speaker name in the text. The start of a new speaker is in square brackets. For example:
        //   "[Mary] Good morning, Joe. [Joe] Good Morning, Mary."
        bool GetNextSpeaker(string text, ref int startNextSpokenText, ref int endLastSpokenText, ref string Speaker)
        {
            int i;
            if ((i = text.IndexOf("[", startNextSpokenText)) != -1)
            {
                endLastSpokenText = i - 1;
                if ((i = text.IndexOf("]", i++)) != -1)
                {
                    // TODO - check end condition of "]" as last char in text.
                    startNextSpokenText = i + 1;
                    Speaker = text.Substring(endLastSpokenText + 2, startNextSpokenText - endLastSpokenText - 3);
                    startNextSpokenText = i + 1;
                    return true;
                }
            }
            return false;
        }
    }
}

/************* Fixasr format *******************
{
  "lastedit": 1967.5555419921875,
  "asrsegments": [
    {
      "startTime": "0:00",
      "said": "[Denise] For the tuesday October 11 selectmen's"
    },
    {
      "startTime": "0:02",
      "said": "meeting I will apologize, apologize for"
    }
}

 ************* Addtags format ****************
{ 
"sections": [
	'Invocation',
	'Approval of Journal',
],
"topics": [
	"Pave 4th St.",
	"Hire business manager",
],
"talks": [
	{"speaker":"COUNCIL PRESIDENT CLARKE","said":"    Good morning, everyone.\n     (Good morning.)\n","section":null,"topic":null,"showSetTopic":false},
	{"speaker":"COUNCILMAN GREENLEE","said":"    Thank you, Mr. President.  I move that the Journal of the meeting of Thursday, September 18th, 2014 be approved.\n     (Duly seconded.)\n","section":null,"topic":null,"showSetTopic":false}
  ]
}


 */