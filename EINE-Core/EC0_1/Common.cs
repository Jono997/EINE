using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EINE_Core.EC0_1
{
    public static class Common
    {
        /// <summary>
        /// The line-ending used in plugin temp files
        /// </summary>
        public static string Newline = "\r\n";

        /// <summary>
        /// The header of the note before the selection
        /// </summary>
        public static string PREV = "PREV";

        /// <summary>
        /// The header of the note after the selection
        /// </summary>
        public static string NEXT = "NEXT";

        /// <summary>
        /// Checks to see if a string could be successfully converted into an int object
        /// </summary>
        /// <param name="check">The string to check</param>
        /// <returns>true if check can be successfully converted into an int
        /// false if converting check to an int would throw a FormatException</returns>
        public static bool CanBeInt(string check)
        {
            foreach (char chr in check)
            {
                if (chr < 48 || chr > 57) // 48-57 are the ASCII representations of numbers 0-9. Any characters out of this range would cause a FormatException to be thrown if this was to be converted
                    return false;
            }

            return true;

            /* Hacky way. It'll work, but it could be done better.
            try
            {
                Convert.ToInt32(check);
                return true;
            }
            catch (FormatException)
            {
                return false;
            } */
        }
    }
}
