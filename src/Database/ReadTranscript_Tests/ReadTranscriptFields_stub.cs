using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Govmeeting.Backend.ReadTranscript;

namespace Govmeeting.Backend.ReadTranscript.Tests
{
    public class ReadTranscriptFields_stub : IReadTranscriptFields
    {
        int nextField = 0;
        List<Field> fields;

        public ReadTranscriptFields_stub(List<Field> nextFields)
        {
            fields = nextFields;
        }

        public Field ReadNextField()
        {
            if (nextField < fields.Count)
            {
                return fields[nextField++];
            }
            else return null;
        }

        public Field ReadNextFieldOrText()
        {
            return ReadNextField(); ;
        }

        public void PushField(Field field)
        {
            nextField--;
        }

        public int Linenum()
        {
            return 1; // This is just for displaying linenum if there is invalid data in the transcript file.
        }
    }
}
