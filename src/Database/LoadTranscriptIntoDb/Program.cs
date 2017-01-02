using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Ninject;
using Govmeeting.Backend.ReadTranscript;
using Govmeeting.Backend.DbAccess;


namespace Govmeeting.Backend.LoadTranscriptIntoDb
{
    /// <summary>
    /// Contains method "Main", the entry for this console app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The IOC container
        /// </summary>
        public static StandardKernel kernel;

        /// <summary>
        /// entry for this console app.
        /// </summary>
        /// <param name="args">The command line arguments - transcripts to be processed.</param>
        static int Main(string[] args)
        {
            SetTrace();

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: LoadTranscriptIntoDb filename [debug]");
                return -1;
            }
            string filename = args[0];

            if ((args.Length > 1) && (args[1].ToLower() == "debug"))
            {
                if (!Debugger.IsAttached)
                {
                    Debugger.Launch();
                }
                Debugger.Break();
            }

            //using (dBOperations dbOps = new dBOperations())
            //{
            dBOperations.InitializeDb();
            //}

            using (kernel = new StandardKernel())
            {
                kernel.Bind<IReadTranscriptFields>().To<ReadTranscriptFields>();
                kernel.Bind<IReadLinesFromFile>().ToConstructor(x => new ReadLinesFromFile(filename));
                var readTranscript = kernel.Get<ReadTranscriptFile>();
                ProcessTranscript readsave = new ProcessTranscript();
                readsave.LoadAndSave(readTranscript);
            }

            return 0;
        }

        /// <summary>
        /// Sets up the trace file.
        /// </summary>
        static void SetTrace()
        {
            // Create a file for trace output.
            string filename = string.Format("TraceOutput-{0:yyyy-MM-dd_HH-mm-ss_ffff}.log", DateTime.Now);
            Stream myFile = File.Create(filename);

            /* Create a new text writer using the output stream, and add it to
             * the trace listeners. */
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(myFile);
            Trace.Listeners.Add(myTextListener);

            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(tr1);

            // Write test output to the file.
            Trace.Write("Test trace output " + Environment.NewLine);
            
            // Flush the output.
            Trace.Flush(); 

        }
    }

}
