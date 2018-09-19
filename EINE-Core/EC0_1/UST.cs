using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATEM;
using System.IO;
using System.Xml.Serialization;

namespace EINE_Core.EC0_1
{
    /// <summary>
    /// The class representing a UST/information passed to a plugin
    /// </summary>
    public class UST
    {
        /// <summary>
        /// The notes in the UST.
        /// </summary>
        public Note[] Notes { get; set; }

        /// <summary>
        /// The raw information passed to EINE from UTAU.
        /// </summary>
        public string Raw { get; set; }

        /// <summary>
        /// The raw information passed to EINE form UTAU organised into sections by headers.
        /// </summary>
        public string[] RawOrganised { get; set; }

        /// <summary>
        /// Creates a UST object with no information
        /// </summary>
        public UST()
        {
            Notes = new Note[] { };
            Raw = "";
            RawOrganised = new string[] { };
        }

        /// <summary>
        /// Creates a UST object from the information passed to EINE from UTAU
        /// </summary>
        /// <param name="raw">The information passed to EINE from UTAU</param>
        public UST(string raw)
        {
            Raw = raw;
            InterpretRawOrganised();
            InterpretNotedProperties();
        }

        /// <summary>
        /// Reads through RawOrganised to set the other properties of this object
        /// </summary>
        public void InterpretNotedProperties()
        {
            List<Note> notes = new List<Note>();
            for (int i = 0; i < RawOrganised.Length; i++)
            {
                string noteraw = RawOrganised[i];
                string header = noteraw.Substring(2, 4);
                if (Common.CanBeInt(header) || header == Common.PREV || header == Common.NEXT) // If the header meets this condition, its contents are note data
                {
                    notes.Add(new Note(noteraw));
                }
            }

            notes = notes.OrderBy(note => note.Index).ToList();
            if (notes[0].Index == -2)
            {
                // Remove the note at the start of the array and put it at the end of the array.
                Note lastnote = notes[0];
                notes.RemoveAt(0);
                notes.Add(lastnote);
            }
            Notes = notes.ToArray();
        }

        /// <summary>
        /// Reads through Raw to separate it into sections, creating RawOrganised
        /// </summary>
        public void InterpretRawOrganised()
        {
            List<string> raw_split = Raw.Split(Common.Newline).ToList();
            raw_split.RemoveAt(raw_split.Count - 1); // Removes the last entry, which will always be an empty string.
            for (int i = 0; i < raw_split.Count;)
            {
                if (raw_split[i][0] == '[')
                {
                    i++;
                }
                else
                {
                    raw_split[i - 1] += "\n" + raw_split[i];
                    raw_split.RemoveAt(i);
                }
            }
            RawOrganised = raw_split.ToArray();
        }

        /// <summary>
        /// Reads through RawOrganised to reconstruct it into a singular string, creating Raw
        /// </summary>
        public void InterpretRaw()
        {
            string raw = RawOrganised[0].Replace("\n", Common.Newline);
            for (int i = 0; i < Notes.Length; i++)
            {
                Notes[i].InterpretMisc();
                raw += Common.Newline + Notes[i].RawHeader;
                foreach (string key in Notes[i].Misc.Keys)
                {
                    raw += Common.Newline + key + '=' + Notes[i].Misc[key];
                }
            }
            Raw = raw;
        }

        /// <summary>
        /// Saves this object to an XML file
        /// </summary>
        /// <param name="file">The file to save to</param>
        public void SaveXML(string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(UST));
                serialiser.Serialize(writer, this);
                writer.Flush();
            }
        }

        /// <summary>
        /// Loads a UST serialised to an XML file
        /// </summary>
        /// <param name="file">The file to load from</param>
        /// <returns>The deserialised object</returns>
        public static UST LoadXML(string file)
        {
            UST result = new UST();
            using (StreamReader reader = new StreamReader(file))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(UST));
                result = serialiser.Deserialize(reader) as UST;
            }
            return result;
        }

        /// <summary>
        /// Saves this object to a file in the format used by UTAU
        /// To load a UST from a file, use the string constructor for the UST object
        /// </summary>
        /// <param name="file"></param>
        public void SaveUST(string file)
        {
            InterpretRaw();
            File.WriteAllLines(file, Raw.Split(Common.Newline), Encoding.Default);
        }
    }
}
