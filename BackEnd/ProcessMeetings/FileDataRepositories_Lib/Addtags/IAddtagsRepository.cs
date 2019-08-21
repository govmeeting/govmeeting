using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.ViewModels;

namespace GM.FileDataRepositories
{
    /* This is the repository for the transcripts which are being
     * edited. The edits mostly involve adding tags to the "tags".
     * The tags represent:
     *  Topic   - that the topic of discussion is changing
     *  Section - that the meeting section is changing
     *  Bill    - that a specific bill is now being discussed
     */
    public interface IAddtagsRepository
    {
        AddtagsView Get(long meetingId);

        bool Put(AddtagsView value, long meetingId);
    }
}
