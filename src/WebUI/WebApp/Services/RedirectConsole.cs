using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Services
{
    public interface IRedirectConsole
    {
        void Start();
        void End();
    }

    public class RedirectConsole: IRedirectConsole
    {
        static FileStream ostrm;
        static StreamWriter writer;
        static TextWriter oldOut = Console.Out;

        public void Start()
        {
            try
            {
                ostrm = new FileStream("./DebugLogRedirectConsole.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("RedirectConsole.cs - Cannot open DebugLogRedirectConsole.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            writer.AutoFlush = true;
            Console.SetOut(writer);
            Console.WriteLine("Everything written to Console.Write() or");
            Console.WriteLine("Console.WriteLine() will be written to a file");
        }

        public void End()
        {
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("RedirectConsole.cs - Done");
        }

    }
}
