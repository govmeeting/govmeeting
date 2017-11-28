using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    /* This class is used in the browser Fixasr module for editing the transcript produced by Automatic Speech Recogniton. YouTube puts
	a time indicator on the start of short approximately equal segments
	of time. 
     */
    public class AsrSegment
    {
        public string startTime;     // start time
        public string said;        // what they said
    }
}
