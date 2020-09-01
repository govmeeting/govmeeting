using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GM.Utilities

{
    public class RunCommand
    {
        public string ExecuteCmd(string command)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            // wrap IDisposable into using (in order to release hProcess) 
            using(Process process = new Process()) {
              process.StartInfo = procStartInfo;
              process.Start();

              // Add this: wait until process does its work
              process.WaitForExit();

              // and only then read the result
              string result = process.StandardOutput.ReadToEnd();
              Console.WriteLine("RunCommand.cs - " + result);
              return result;
            }
        }
    }
}
