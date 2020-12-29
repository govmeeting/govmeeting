using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace GM.Application.ProcessTranscript
{
    interface ISpecificFix
    {
        string Fix(string _transcript, string workfolder);
    }

    // TODO All methods in TranscriptFixes are in need of unit tests.

    // NOTE: During the transcript fixes, a trace files is written to the work folder after each step.
    // Each trace file contains the complete text of the transcript, after each particular fix is applied.
    // Therefore if the final fixed transcript contains strange or invalid text, it is easy to trace it
    // back to where those errors were introduced during the "fix" process.

    public class TranscriptFixes
    {
        public string Fix(string workfolder, string text, string location)
        {
            string transcript;

            // The name of the class handling the transcript fixes is the same as the location name encoded in the file.
            // For example for a transcript file named:
            //    "USA_PA_Philadelphia_Philadelphia_CityCouncil_en__2017-12-07.pdf"
            // the location is:
            //      "USA_PA_Philadelphia_Philadelphia_CityCouncil_en"
            // (It's really location plus language indicator - "en")
            //
            // We use the Reflection API to obtain an instance of the class from the string name of the class.
            // This enables the creators of new ISpecificFix classes to just write the new class and not need
            // to modify exising code to instantiate the class.

            ISpecificFix specificFix = CreateInstance<ISpecificFix>("ProcessTranscript_Lib.dll", "GM.Application.ProcessTranscript", location);


            //ISpecificFix specificFix;
            //switch (location)
            //{
            //    case "USA_PA_Philadelphia_Philadelphia_CityCouncil_en":
            //        specificFix = new USA_PA_Philadelphia_Philadelphia_CityCouncil_en(workfolder);
            //        break;
            //    case "USA_TX_TravisCounty_Austin_CityCouncil_en":
            //        specificFix = new USA_TX_TravisCounty_Austin_CityCouncil_en(workfolder);
            //        break;
            //    default:
            //        specificFix = new USA_PA_Philadelphia_Philadelphia_CityCouncil_en(workfolder);
            //        break;
            //}

            transcript = specificFix.Fix(text, workfolder);
            return transcript;
        }


        public static I CreateInstance<I>(string dllName, string spaceName, string className) where I : class
        {
            // The following only works in VS but not in VsCode.
            // string assemblyPath = Path.Combine(Environment.CurrentDirectory, dllName);

            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Assembly assembly;
            assembly = Assembly.LoadFrom(assemblyPath);
			
            Type type = assembly.GetType(spaceName + "." + className);
            return Activator.CreateInstance(type) as I;
        }

    }
}
