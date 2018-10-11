using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    //Used to truncate strings for export
        public static class TruncateString
        {
            /// <summary>
            /// Get a substring of the first N characters.
            /// </summary>
            public static string Truncate(string source, int length)
            {
                if (source.Length > length)
                {
                    source = source.Substring(0, length);
                }
                return source;
            }

            public static string GetLastofString(string source, int length)
            {
                if (source.Length > length)
                {
                    source = source.Substring((source.Length - length), source.Length - 1);
                }
                return source;
            }


            /// <summary>
            /// Get a substring of the first N characters. [Slow]
            /// </summary>
            public static string Truncate2(string source, int length)
            {
                return source.Substring(0, Math.Min(length, source.Length));
            }
        }

}
