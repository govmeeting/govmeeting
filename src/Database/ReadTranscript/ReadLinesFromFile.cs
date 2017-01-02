using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.ReadTranscript
{
    /// <summary>
    /// Interface to read lines from file.
    /// </summary>
    public interface IReadLinesFromFile
    {
        /// <summary>
        /// Gets the linenum.
        /// </summary>
        /// <returns>linenum</returns>
        int getLinenum();

        /// <summary>
        /// Nexts the line.
        /// </summary>
        /// <returns>next line or null</returns>
        string NextLine();

        /// <summary>
        /// Pushes the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        void Push(string line);
    }

    /// <summary>
    /// Read lines from file
    /// </summary>
    public class ReadLinesFromFile : IReadLinesFromFile
    {
        /// <summary>
        /// The _filename
        /// </summary>
        string _filename;

        /// <summary>
        /// The _filestream
        /// </summary>
        System.IO.StreamReader _filestream;

        /// <summary>
        /// The linenum
        /// </summary>
        int linenum;

        /// <summary>
        /// The next line
        /// </summary>
        string nextLine;

        /// <summary>
        /// Gets the linenum. This is to display, in case of invalid data, in an error message.
        /// </summary>
        /// <returns>
        /// The linenum.
        /// </returns>
        public int getLinenum()
        {
           return linenum;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLinesFromFile"/> class.
        /// </summary>
        /// <param name="filename">The filename - injected by IoC container.</param>
        public ReadLinesFromFile(string filename)
        {
            _filename = filename;
            _filestream = new System.IO.StreamReader(_filename);
            linenum = 0;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ReadLinesFromFile"/> class.
        /// </summary>
        ~ReadLinesFromFile()
        {
            _filestream.Close();
        }

        /// <summary>
        /// Get next line.
        /// </summary>
        /// <returns>the line or null if no next line</returns>
        public string NextLine()
        {
            string line;
            if (nextLine != null)
            {
                line = nextLine;
                nextLine = null;
                return line;
            }
            while ((line = _filestream.ReadLine()) != null)
            {
                linenum++;
                if (line != "") return line;
            }
            return null;
        }

        /// <summary>
        /// Pushes the specified line onto the "stack". Next call to ReadNextLine will return this one.
        /// This "stack" only consists of a single entry.
        /// </summary>
        /// <param name="line">The line.</param>
        public void Push(string line)
        {
            nextLine = line;
        }

    }
}
