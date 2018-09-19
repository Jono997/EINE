using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATEM;
using System.Xml.Serialization;
using System.IO;

namespace EINE_Core.EC0_1
{
    /// <summary>
    /// The class serving as a representation of a note in UTAU
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The position of this Note object in the UST
        /// If -1, this is the PREV note
        /// If -2, this is the NEXT note
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The header of the note as written by UTAU
        /// </summary>
        public string RawHeader
        {
            get
            {
                switch (Index)
                {
                    case -1:
                        return "[#" + Common.PREV + ']';
                    case -2:
                        return "[#" + Common.NEXT + ']';
                    default:
                        {
                            string header = Index.ToString();
                            while (header.Length < 4)
                            {
                                header = '0' + header;
                            }
                            return "[#" + header + "]";
                        }
                }
            }
        }

        /// <summary>
        /// Unprocessed information
        /// </summary>
        public SerializableDictionary<string, string> Misc { get; set; }

        /// <summary>
        /// Creates a Note object with no information. Used to apease the XML serialiser.
        /// </summary>
        public Note()
        {
            Misc = new SerializableDictionary<string, string>();
        }

        /// <summary>
        /// Creates a Note object from the serialised note from UTAU.
        /// </summary>
        /// <param name="note_raw">The note as serialised by UTAU</param>
        public Note(string note_raw)
        {
            Misc = new SerializableDictionary<string, string>();

            foreach (string param in note_raw.Split('\n'))
            {
                if (param.Substring(0, 2) == "[#" && param.Last() == ']')
                {
                    string _index = param.Substring(2, 4);
                    if (_index == Common.PREV)
                        Index = -1;
                    else if (_index == Common.NEXT)
                        Index = -2;
                    else
                        Index = Convert.ToInt32(_index);
                }
                else
                {
                    string[] param_split = param.Split('=');
                    Misc.Add(param_split[0], param_split.SubArray(1).Stitch('='));
                }
            }
        }

        /// <summary>
        /// Reads through Misc to set the other properties of this object.
        /// </summary>
        public void InterpretNotedProperties()
        {

        }

        /// <summary>
        /// Reads through this object's properties to set certain values of Misc.
        /// </summary>
        public void InterpretMisc()
        {

        }
    }
}
