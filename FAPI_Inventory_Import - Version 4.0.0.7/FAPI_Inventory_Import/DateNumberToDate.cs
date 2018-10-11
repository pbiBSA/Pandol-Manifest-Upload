using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    //if the string is number representive of a date it is converted to a string date
    //if not it is just passed
    public static class DateNumberToDateString
    {
        

        public static string ConvertDateNumberToDateString(string sd)
        {
            string sDate;
            string tempString;
            sDate = sd;
            int number1 = 0;
            bool canConvert = int.TryParse(sDate, out number1);
            if (canConvert == true)  //if it is a number, in otherwords does it convert to a number
            {
                if (sDate.ToString().Substring(4, 2) == "20")  //number for date of form MMDDYYY
                {
                    tempString = sDate.ToString().Substring(0, 2) + "/" +
                    sDate.ToString().Substring(2, 2) + "/" +
                    sDate.ToString().Substring(4, 4);

                    sDate = tempString;
                }
                else if (sDate.ToString().Substring(0, 2) == "20")  //number for date of form YYYYMMDD
                {
                    tempString = sDate.ToString().Substring(4, 2) + "/" +
                    sDate.ToString().Substring(6, 2) + "/" +
                    sDate.ToString().Substring(0, 4);

                    sDate = tempString;
                }
               
            }

            else
            {
                //do nothing at this time
            }
            return sDate;

            
        }





    }
}
