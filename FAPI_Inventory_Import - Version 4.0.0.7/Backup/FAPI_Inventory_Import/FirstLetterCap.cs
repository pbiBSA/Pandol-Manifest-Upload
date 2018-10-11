/*Changes the first letter of every word to upper case.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    public static class UppercaseWords
    {

        public static string Uppercase(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.ToLower();
                char[] array = value.ToCharArray();
                // Handle the first letter in the string.
                if (array.Length >= 1)
                {
                    if (char.IsLower(array[0]))
                    {
                        array[0] = char.ToUpper(array[0]);
                    }
                }
                // Scan through the letters, checking for spaces.
                // ... Uppercase the lowercase letters following spaces.
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1] == ' ')
                    {
                        if (char.IsLower(array[i]))
                        {
                            array[i] = char.ToUpper(array[i]);
                        }
                    }
                }
                return new string(array);
            }
            return value;
        }

    }
}
