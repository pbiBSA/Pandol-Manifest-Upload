using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;

namespace FAPI_Inventory_Import
{
    public static class CreateLineNumber
    {
        public static int LastLineNumber(int rn)
        {
          
           int Line_Number = 0;
           int Receipt_Number = rn;

           try
           {
               //Code to check for last line number for the reciept number
               string connString = Properties.Settings.Default.ArchiveConnectionString;  //get connection string from the application settings
               System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // Instantiate connection object
               SqlDataAdapter LastLineNumberDataAdaptor = null;  //DataAdaptor for the last line number
               //SqlCommandBuilder cmdBuilder; //using sql command builder to create command
               SqlCommand QueryCommand = null;  //query string

               //get receipt numbers data from archive database
               DataSet dt = new DataSet();
               if (Properties.Settings.Default.Mode.ToString() == "Test")  //check for test mode and use test archive if test mode
               {
                   QueryCommand = new SqlCommand("   Select ISNULL(MAX([Last_Line_Number]), 0) " +
                                              "FROM [ImportDataWarehouse].[dbo].[Last_Line_Number_Test]" +
                                              "WHERE [Receipt_Number] = " + Receipt_Number, conn);
               }
               else
               {
                   QueryCommand = new SqlCommand(" Select  ISNULL(MAX([Last_Line_Number]), 0) " +
                                              "FROM [ImportDataWarehouse].[dbo].[Last_Line_Number]" +
                                              "WHERE [Receipt_Number] = " + Receipt_Number, conn);
               }



               LastLineNumberDataAdaptor = new SqlDataAdapter(QueryCommand);

               //cmdBuilder = new SqlCommandBuilder(LastLineNumberDataAdaptor);

               conn.Open();

               LastLineNumberDataAdaptor.Fill(dt);

               conn.Close();

               if (!(dt.Tables[0].Rows[0][0].Equals(null)))
               {
                   if (dt.Tables[0].Rows.Count == 1)
                   {
                       Line_Number = Convert.ToInt32(dt.Tables[0].Rows[0][0]);
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Problem trying to find the last line number for export.  /n" +
                   "Check network connection and verify that SQL database is running.  Check Error log " +
                   "for more information.");
               Error_Logging el = new Error_Logging("Problem trying to find the last line number for export.  /n" + 
                  "Error message is:  \n" + ex);

           }
               return Line_Number;
           

        }

        public static bool UpdateLineNumber(int rn, int ln)
        {
            int Line_Number = ln;
            int Receipt_Number = rn;
            //string commandstringtext;

            try
            {
                //Code to check for last line number for the reciept number
                string connString = Properties.Settings.Default.ArchiveConnectionString;  //get connection string from the application settings
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // Instantiate connection object

                conn.Open();
                // SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
                SqlCommand QueryCommand = null;  //query string

                //get receipt numbers data from archive database
                DataSet dt = new DataSet();
                if (Properties.Settings.Default.Mode.ToString() == "Test")  //check for test mode and use test archive if test mode
                {
                    QueryCommand = new SqlCommand("INSERT INTO [ImportDataWarehouse].[dbo].[Last_Line_Number_Test] " +
                                                        "([Receipt_Number], [Last_Line_Number]) " +
                                                        "VALUES(" + Receipt_Number + ", " + Line_Number + ")", conn);
                }
                else
                {
                    QueryCommand = new SqlCommand("INSERT INTO [ImportDataWarehouse].[dbo].[Last_Line_Number] " +
                                                        "([Receipt_Number], [Last_Line_Number]) " +
                                                        "VALUES(" + Receipt_Number + ", " + Line_Number + ")", conn);
                }

                QueryCommand.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed last line number update.  Contact administater or see error log for more informaion.");
                Error_Logging el = new Error_Logging("Error trying to update the last line number.  \n" + 
                   "Error message is:  \n" + ex);
       
            }


            return true;
        }

        
    }


}
