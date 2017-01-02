using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Govmeeting.Backend.ReadTranscript;

namespace Govmeeting.Backend.ReadTranscript.Tests
{
    public class ReadLinesFromFile_stub : IReadLinesFromFile
    {
        int nextLine = 0;
        List<string> lines;

        public ReadLinesFromFile_stub(List<string> nextLines)
        {
            lines = nextLines;
        }

        public string NextLine()
        {
            if (nextLine < lines.Count)
            {
                return lines[nextLine++];
            }
            else return null;
        }

        public void Push(string line)
        {
            nextLine--;
        }

        public int getLinenum()
        {
            return 1; // This is just for displaying linenum if there is invalid data in the transcript file.
        }
    }
}
