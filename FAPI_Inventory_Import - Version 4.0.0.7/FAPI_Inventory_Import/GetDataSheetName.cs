using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace FAPI_Inventory_Import
{
    
    class GetDataSheetName
    {
        public string sExcelFileName;

        public GetDataSheetName()
        {
        }

        public string[] GetDataSheetNameList(string FileName)
        {
            sExcelFileName = FileName;

            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            String connString;
            String ServerVersionTxt;

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
              //  String connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
               //   "Data Source=" + sExcelFileName; + ";Extended Properties=Excel 12.0;";

                if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                    connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sExcelFileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007    //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +  sExcelFileName + ";Extended Properties=\"Excel 12.0; HDR=No;\"";

                        //"Provider=Microsoft.ACE.OLEDB.12.0;"Data Source=" + sExcelFileName + ";Extended Properties= \"Excel 12.0 Xml;HDR=No; IMEX=1\"";
                    //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sExcelFileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=No\"";
                else
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sExcelFileName + ";Extended Properties=\"Excel 8.0;;HDR= No; IMEX=1\"";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);     //new OleDbConnection(connString);
                // Open connection with the database.
              //  OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Data$]", objConn);
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(
            OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
               // for (int j = 0; j < excelSheets.Length; j++)
                //{
                    // Query each excel sheet.
                //}

                return excelSheets;
            }
            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error reading excel file. \n" + exceptioncode +
                          
                           "\n  Otherwise note what was done and contact administrator.  \n");
                Error_Logging el = new Error_Logging("Error Reading excel file. \n" + exceptioncode);
                
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
    }
}
