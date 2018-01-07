using System.IO;
using System;

namespace GM.ProcessRecordingLib
{
    class CheckForNew
    {

        string inputPath = @"..\..\..\Server\WebApp\wwwroot\assets\fullvideo\";
        public void check()
        {
            DirectoryInfo fullvideos = new DirectoryInfo(inputPath);
            FileInfo[] files = fullvideos.GetFiles();
            DateTime dt;
            foreach (FileInfo file in files)
            {
                string name = file.Name;
                int x = name.IndexOf(" ");
                if (x != -1)
                {
                    if (DateTime.TryParse(name.Substring(0, x - 1), out dt))
                    {
                    }
                }
            }
        }

    }
}
