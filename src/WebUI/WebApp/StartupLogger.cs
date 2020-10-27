using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GM.WebApp
{
    // This is a basic alternative to NLog.
    public class StartupLogger
    {
        StreamWriter stream;


        public StartupLogger(string logFolder)
        {
            string filename = string.Format("Startup-{0:yyyy-MM-dd}.log", DateTime.Now);
            string logfile = Path.Combine(logFolder, filename);
            stream = File.AppendText(logfile);
            stream.AutoFlush = true;
        }          

        public void LogTrace(string text)
        {
            stream.WriteLine(text);
            
        }

        public void LogDebug(string text)
        {
            stream.WriteLine(text);

        }

        ~StartupLogger()
        {
            stream.Close();
        }
    }
}
