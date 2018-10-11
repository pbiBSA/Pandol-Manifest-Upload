using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;


namespace FAPI_Inventory_Import
{
    class Error_Logging  //This writes error messages and a time-date stamp to the error log
    {

        string ErrorMessage;
        string FileName;
        string sUserID;
        bool bIsNotLogged = true;

        public Error_Logging(string sError)
        {
            sUserID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            FileName = Properties.Settings.Default.ErrorFile;  //default location
            ErrorMessage = DateTime.Now.ToString();  //add time stamp
            ErrorMessage = ErrorMessage + ":  " + sError.ToString().Replace("'", " ");
            bIsNotLogged = true;

            //create a writer and open the file
                TextWriter tw = new StreamWriter(FileName,true);

                tw.WriteLine(ErrorMessage);  //write error message

                // close the stream
                tw.Close();

                Error_Log_To_Database();

        }

         public bool Error_Log_To_Database()
         {
             try
             {
                 SqlConnection sqlConnectionErrorLog =
                        new SqlConnection(Properties.Settings.Default.ArchiveConnectionString);  //connection string in application settings

                 SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                 cmd.CommandType = System.Data.CommandType.Text;
                 cmd.Connection = sqlConnectionErrorLog;
                 sqlConnectionErrorLog.Open();

                 StringBuilder Command_Text = new StringBuilder();

                 Command_Text = new StringBuilder();
                 if (Properties.Settings.Default.Mode.ToString() == "Test")
                 {
                     Command_Text.Append("INSERT [PBIApplicationTables].[dbo].[ApplicationErrorLog_Test] (");
                 }
                 else
                 {
                     Command_Text.Append("INSERT [PBIApplicationTables].[dbo].[ApplicationErrorLog] (");
                 }

                 Command_Text.Append("[UserID],[ErrorMessage], [VersionNumber])");
                 Command_Text.Append("  VALUES (");
                 Command_Text.Append("'" + sUserID + "', ");  //User ID
                 Command_Text.Append("'" + ErrorMessage + "', ");  //Error message 

                 if (Properties.Settings.Default.Mode.ToString() == "Test")
                 {
                     Command_Text.Append("' Test " + Application.ProductVersion.ToString() + "')");  //  Test Mode
                 }
                 else
                 {
                     Command_Text.Append("'" + Application.ProductVersion.ToString() + "')");  //  write version into error log tabl
                 }




                 cmd.CommandText = Command_Text.ToString();

                 cmd.ExecuteNonQuery();

                 sqlConnectionErrorLog.Close();

                 return true;
             }

             catch(Exception exceptioncode)
                   {
                       MessageBox.Show("Error logging error to database. \n" +
                           "Verify that there is an internet connection and the SQL server is up.  \n" +
                           "Note what was done and contact administrator.  \n");
                       if (bIsNotLogged)
                       {
                           TextWriter tw = new StreamWriter(FileName, true);
                           tw.WriteLine("Error logging error to database. \n" + exceptioncode);  //write error message
                           // close the stream
                           tw.Close();
                           //    Error_Logging el = new Error_Logging("Error logging error to database. \n" + exceptioncode);
                           bIsNotLogged = false;
                       }
                 
                 return false;
             }
         }

    }
}
