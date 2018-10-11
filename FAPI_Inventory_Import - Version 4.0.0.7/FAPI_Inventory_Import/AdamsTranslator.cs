using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace FAPI_Inventory_Import
{
    //Translator for Export (old Adams) data
    class AdamsTranslator
    {
        private DataSet Data2Translate { get; set; }  //dataset which contains the data to translate
        private ImportTemplateSettings TemplateSettings { get; set; }  //ImportTemplate settings for data
        private DataTable TranslationTable;  //Translation table data, of what translates to what
        private List<String> List2Translate;  //list of fields to translate
        bool Completed = false;  //did the translation complete?
        
        public AdamsTranslator (DataSet ds, ImportTemplateSettings ImportSettings, List<String> tl) 
        {
                Data2Translate = ds.Copy();  //dataset containing data to translate
                TemplateSettings = ImportSettings;  //import seetings showing where data is in dataset
                List2Translate = tl;  //List of fields which need translation
                Completed = false;  //Did tranlation complete?  Not yet.
        }
            

        public DataSet TranslateData()  //Method to translate the data in the Data2ToTranslate dataset
        {
               int rownumber;
               DataRow[] FoundRows;
               string sTempField;
               DataSet ds = new DataSet();

               try
               {
                   //get tranlation table data from database
                   string connString = Properties.Settings.Default.ConnectionString;
                   string query = "select [Data_Column_Name],[Value],[Export_Value] from Export_Values";

                   System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                   System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                   conn.Open();

                   // create data adapter
                   System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                   // this will query the database and return the result to your datatable
                   da.Fill(ds);
                   conn.Close();
                   da.Dispose();
                   TranslationTable = ds.Tables[0];  //set the translation table
                   ds.Dispose();
               }

               catch (Exception e)
               {
                   MessageBox.Show("Error loading Export translation table from database.  \n" +
                       "Internet connection or SQL server may be down.  \n" + 
                       "Please note what was done prior to error and contact administrator or see error log for more details.  \n");
                   Error_Logging el = new Error_Logging("Error loading Export (Adams) translation table from database.  \n" + e);
                   
                   ds.Dispose();
                   Completed = false;
                   return Data2Translate;
               }
                        
                //Translate values  generic routine  *************************************************************************
                //Takes the list of fields to evaluate and iterates through each of them.
               try
               {
                   foreach (string sField in List2Translate)
                   {
                       rownumber = 0;
                       //This is for the case where the size and style are contatonated into one field in the data streadsheet.  ***
                       if ((TemplateSettings.SizeColumn == TemplateSettings.StyleColumn) & ((sField == "Size") || (sField == "Style")))
                       {
                           sTempField = "PackCode"; 
                       }
                       else
                       {
                           sTempField = sField;
                       }
                       //***                   

                       FoundRows = TranslationTable.Select("Data_Column_Name = " + "'" + sTempField + "'");  //get all rows for sField from Translation table

                       foreach (DataRow row in Data2Translate.Tables[0].Rows)
                       {
                           foreach (DataRow TranslatingRow in FoundRows) //FoundRows contains all the translation rows for sField
                           {

                               if (row[TemplateSettings.DataColumnLocation(sField).Column].ToString().ToUpper().Trim() == TranslatingRow[1].ToString().ToUpper().Trim())
                               // && TranslatingRow[2].ToString() != "")  //Famous value in column 1
                               {
                                   //set field to translated value.  Export value in column 2
                                   Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.DataColumnLocation(sField).Column] =
                                       TranslatingRow[2].ToString();
                               }
                              

                               
                           }

                           rownumber++;
                       }  
                   }
                   Completed = true;   

               }  //end of try block

               catch (Exception e)
               {
                   Completed = false;
                   MessageBox.Show("Export Translation process had an error.  Please note what was done and contact administrator for help or see error log for more details.  \n");
                   Error_Logging el = new Error_Logging("Export (Adams) Translation process had an error. \n  " + e);
                   
               }

               return Data2Translate;

        }  //end of TranslateData method

        public bool TranslationCompleted()
        {
            return Completed;
        }


    }
}
