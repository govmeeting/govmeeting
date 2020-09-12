using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    public enum WorkStatus {
        Receiving, Received,
        Processing, Processed,
        Transcribing, Transcribed,
        Editing, Edited,
        Tagging, Tagged,
        Viewing, Viewed,
        Loading, Loaded,
        Alerting, Alerted
    };
    public enum SourceType
    {
        Recording,
        Transcript
    }

    /// <summary>
    /// The Meeting object is all the data associated with one specific meeting.
    /// </summary>
    public class Meeting
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Length { get; set; }
        public List<Section> Sections { get; set; }
        public long GovBodyId { get; set; }
        public string Language { get; set; }
        public string SourceFilename { get; set; }
        //public string WorkFolder { get; set; }
        public SourceType SourceType { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public bool Approved { get; set; }

        /*
         * If we were to say: public virtual List<Talk> ....
         * then EF would lazy load these as they are accessed.
         */
    }
}
