using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SortMultithreadedMsbuildLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new Dictionary<int, StringBuilder>();
            //var line = Console.In.ReadLine();
            //while (line != null)
            foreach (string line in System.IO.File.ReadLines(@"c:\tmp\test.txt"))
            {
                int process = 0;
                var re = new Regex(@"^ *(?<process>\d+)\>.*$");
                if (re.IsMatch(line))
                {
                    var match = re.Match(line);
                    process = Convert.ToInt32(match.Groups["process"].Value);
                }

                if (!lines.ContainsKey(process))
                {
                    lines[process] = new StringBuilder();
                }
                lines[process].AppendLine(line);

                //line = Console.In.ReadLine();
            }

            // Creating a file
            string myfile = @"c:\tmp\out.txt";

            // Appending the given texts
            using (StreamWriter sw = File.AppendText(myfile))
            {
                foreach (var i in lines.Keys)
                {
                    sw.WriteLine(lines[i]);
                }

            }
            //foreach (var i in lines.Keys)
            //{
            //    Console.Write(lines[i]);
            //}
        }
    }
}
