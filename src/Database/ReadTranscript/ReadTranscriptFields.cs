using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Govmeeting.Backend.ReadTranscript
{
    /// <summary>
    /// A "Field" in the transcript file is a name and value field. For example:
    ///     Topic: Introductions
    ///     Category: Meeting Business
    ///     Speaker: Denise Griffin
    /// </summary>
    public class Field
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;

        /// <summary>
        /// The value
        /// </summary>
        public string Value;
    }

    /// <summary>
    /// Methods called to read the fields in a transcript. Defining an interface allow us
    /// to write stubs for testing, so that the source could be a file or in-memory data.
    /// </summary>
    public interface IReadTranscriptFields
    {
        /// <summary>
        /// Reads the next field.
        /// </summary>
        /// <returns>next field or null</returns>
        Field ReadNextField();

        /// <summary>
        /// Reads the next field or lines of text.
        /// </summary>
        /// <returns>next line/text or null</returns>
        Field ReadNextFieldOrText();

        /// <summary>
        /// Pushes the field.
        /// </summary>
        /// <param name="field">The field.</param>
        void PushField(Field field);

        /// <summary>
        /// current linenum.
        /// </summary>
        /// <returns>linenum</returns>
        int Linenum();
    }

    /// <summary>
    /// Methods to read the fields in a transcript file.
    /// </summary>
    public class ReadTranscriptFields : IReadTranscriptFields
    {
        /// <summary>
        /// The reader
        /// </summary>
        IReadLinesFromFile reader;
        /// <summary>
        /// The next field
        /// </summary>
        Field nextField;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadTranscriptFields"/> class.
        /// </summary>
        /// <param name="readLinesFromFile">An IReadLinesFromFile object - injected by IoC container.</param>
        public ReadTranscriptFields(IReadLinesFromFile readLinesFromFile)
        {
            reader = readLinesFromFile;
        }

        /// <summary>
        /// Reads the next field.
        /// </summary>
        /// <returns>the next field or null if not next field.</returns>
        public Field ReadNextField()
        {
            string line;
            Field field;
            if (nextField != null)
            {
                field = nextField;
                nextField = null;
                return field;
            }
            
            field = new Field();

            while ((line = reader.NextLine()) != null)
            {
                if (line != "")
                {
                    int x;
                    if ((x = FindFieldColon(line, 4)) >= 0)
                    {
                        field.Name = line.Substring(0, x).Trim();
                        field.Value = line.Substring(x + 1).Trim();
                        return field;
                    }
                    else
                    {
                        StringBuilder text = new StringBuilder(line.Trim());
                        ReadTextLines(ref text);
                        // Todo(gm): output warning message if we find text lines where there should be a field.
                        // Right now we drop the text.
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Reads the next field or lines of text.
        /// </summary>
        /// <returns>the next field/text or null if no next.</returns>
        public Field ReadNextFieldOrText()
        {
            string line;
            Field field;
            if (nextField != null)
            {
                field = nextField;
                nextField = null;
                return field;
            }

            field = new Field();

            while ((line = reader.NextLine()) != null)
            {
                if (line != "")
                {
                    int x;
                    if ((x = FindFieldColon(line, 1)) >= 0)
                    {
                        field.Name = line.Substring(0, x).Trim();
                        field.Value = line.Substring(x + 1).Trim();
                    }
                    else
                    {
                        StringBuilder text = new StringBuilder(line.Trim());
                        ReadTextLines(ref text);
                        field.Value = text.ToString();
                        field.Name = "Text";
                    }
                    return field;
                }
            }
            return null;
        }

        /*
         * Push an field on the "stack"
         * Next call to ReadNextField will return this one.
         */
        /// <summary>
        /// Pushes the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void PushField(Field field)
        {
            nextField = field;
        }

        /// <summary>
        /// Get the current line number in the transcript. THisis used for debugging.
        /// </summary>
        /// <returns>current linenum</returns>
        public int Linenum()
        {
            return reader.getLinenum();
        }

        /// <summary>
        /// Reads the text lines.
        /// </summary>
        /// <param name="text">The text.</param>
        private void ReadTextLines(ref StringBuilder text)
        {
            string line;
            while ((line = reader.NextLine()) != null)
            {
                int x = FindFieldColon(line, 1);
                if (x == 0)
                {
                    text.Append(line);
                }
                else
                {
                    reader.Push(line);
                    return;
                }
            }
        }

        /// <summary>
        /// Find the position colon on a line containing a field.
        /// For example: "Topic: Introductions" or "Town Manager: Mr. Smith"
        /// The colon must follow a word and preced a space. The field name must contain at most maxWords words.
        /// Thus if a space precedes the colon, this is not a field.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="maxWords">The maximum words.</param>
        /// <returns>the position of the colon or -1 if no valid position</returns>
        int FindFieldColon(string line, int maxWords)
        {
            int words = 0;
            int s = 0;
            int x = line.IndexOf(":");

            while (true)
            {
                s = line.IndexOf(" ", s + 1);
                if (s == -1)
                {
                    return -1;     // A space was not found. No field on line.
                }
                else
                {
                    words++;
                }

                if (s < x)
                {
                    continue;               // A space was found before the colon - continue.
                }

                if (s == x + 1)
                {
                    if (words <= maxWords) return x;
                    return -1;              // Too many words in field name.
                }
            }
        }

    }

    /// <summary>
    /// InvalidTranscriptData exception
    /// </summary>
    public class InvalidTranscriptData : System.ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTranscriptData"/> class.
        /// </summary>
        public InvalidTranscriptData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTranscriptData"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InvalidTranscriptData(string message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTranscriptData"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public InvalidTranscriptData(string message, System.Exception inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTranscriptData"/> class.
        /// Constructor needed for serialization 
        /// when exception propagates from a remoting server to the client.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InvalidTranscriptData(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
