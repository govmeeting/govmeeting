using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.ViewModels;


namespace GM.FileDataRepositories
{
    /* This is the repository for the Automatic Speech Recogniton transcripts which are being
     * corrected for errors.
     */
    public interface IFixasrRepository
    {
        FixasrView Get(long meetingIde, int part);

        bool Put(FixasrView value, long meetingId, int part);
    }
}
