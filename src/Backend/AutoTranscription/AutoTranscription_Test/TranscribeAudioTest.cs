using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TranscriptionLibrary;

namespace Backend.AutoTranscription_Test
{
    public class TranscribeAudioTest
    {
        TranscribeAudio transcribeAudio = new TranscribeAudio();

        [Fact]
        public void transcribe()
        {
            string transcription;
            
            transcription = transcribeAudio.Transcribe("../testdata/audio.raw", "en");
            Assert.Equal(transcription, "xxxx");
        }

    }
}


// https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/
// http://dotnetcoretutorials.com/2017/03/30/third-party-dependency-injection-asp-net-core/
