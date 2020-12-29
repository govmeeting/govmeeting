using System;
using System.Collections.Generic;
using System.Text;

namespace GM.OldViewModels

{

    /* These classes are used in the browser Fixasr module for editing the transcript produced
     * by Automatic Speech Recogniton.
     */

    public class FixasrViewModel
    {
        public double lastedit;
        public List<AsrSegment> asrsegments { get; set; }

        public FixasrViewModel()
        {
            asrsegments = new List<AsrSegment>();
        }
    }

    public class AsrSegment
    {
        public string startTime;     // start time
        public string said;        // what they said

        public AsrSegment(string _startTime, string _said)
        {
            startTime = _startTime;
            said = _said;
        }
    }

}
