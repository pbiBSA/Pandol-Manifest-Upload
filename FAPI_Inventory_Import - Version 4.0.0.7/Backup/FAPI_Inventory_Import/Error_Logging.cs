using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FAPI_Inventory_Import
{
    class Error_Logging  //This writes error messages and a time-date stamp to the error log
    {

        string ErrorMessage;
        string FileName;

        public Error_Logging(string sError)
        {
            FileName = Properties.Settings.Default.ErrorFile;  //default location
            ErrorMessage = DateTime.Now.ToString();  //add time stamp
            ErrorMessage = ErrorMessage + ":  " + sError;

            //create a writer and open the file
                TextWriter tw = new StreamWriter(FileName,true);

                tw.WriteLine(ErrorMessage);  //write error message

                // close the stream
                tw.Close();

        }

    }
}
