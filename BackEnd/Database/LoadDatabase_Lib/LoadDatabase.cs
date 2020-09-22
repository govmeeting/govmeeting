using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using GM.ViewModels;

namespace GM.LoadDatabase
{
    public class LoadDatabase
    {

        public void LoadSampleData(string file)
        {
            string sample = File.ReadAllText(file);
            TranscriptViewModel transcript = JsonConvert.DeserializeObject<TranscriptViewModel>(sample);
        }

    }
}
