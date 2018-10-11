using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;

//This class will select the pallets for QC
namespace FAPI_Inventory_Import
{
    class QCPalletSelection
    {
        DataSet DataForQCDataSet = new DataSet();  //DataSet for QC pallet selection
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        List<string> QCStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        string commandstringtext;
        int ReceiptNumber = 0;

        public QCPalletSelection(DataSet ds, ImportTemplateSettings ims, List<string> asl, int rn)
        {
            DataForQCDataSet = new DataSet(); //start with clean dataset
            DataForQCDataSet = ds.Copy();  //Data for QC selection from the main data dataset
            ImportSettings = ims;  //import settings show where in the dataset each field is located
            QCStringList = asl;  //string data from main app controls
            ReceiptNumber = rn;  //receipt number for export data
        }


        public bool Select_Pallets()
        {
             //Clear Temp selection table
            using (SqlConnection sqlConnectionClear =
                new SqlConnection(Properties.Settings.Default.ArchiveConnectionString))
            {
                SqlCommand cmdClear = new SqlCommand();
                {
                    Int32 rowsAffected;

                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        cmdClear.CommandText = "DELETE FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection_Test]";  //Clear FAPI_QC_Pallet_Selection_Test Table
                    }                                                                                                      //before entering new pallets to work with
                    else
                    {
                        cmdClear.CommandText = "DELETE FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection]";  //Clear FAPI_QC_Pallet_Selection table
                    }

                    cmdClear.Connection = sqlConnectionClear;

                    sqlConnectionClear.Open();

                    try
                    {
                        rowsAffected = cmdClear.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error trying clearing the temp QC.  \n");
                        Error_Logging el = new Error_Logging("Error trying to clear selection table for QC.  \n" + ex);
                        return false;
                    }


                }
            }
            
            //Selection of the pallets and stores in the QC_Archive table.
            try
            {
                SqlConnection sqlConnectionArchive =
                    new SqlConnection(Properties.Settings.Default.ArchiveConnectionString);  //connection string in application settings

                SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnectionArchive;
                sqlConnectionArchive.Open();

                StringBuilder Command_Text = new StringBuilder();


                foreach (DataRow row in DataForQCDataSet.Tables[0].Rows)  //insert each record from the dataset and string list
                {
                    //Note the ' character is used to delineate text so must be removed from any text strings.  

                    Command_Text = new StringBuilder();
                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        Command_Text.Append("INSERT FAPI_QC_Pallet_Selection_Test (");
                    }
                    else
                    {
                        Command_Text.Append("INSERT FAPI_QC_Pallet_Selection (");
                    }
                    Command_Text.Append("[Selection_Date], [Receipt_Number], [Exporter], [Vessel_Number],[Pallet_Prefix],[Warehouse]");
                    Command_Text.Append(",[Region],[Grower_Block],[Commodity_ID],[Receiving_Date]");
                    Command_Text.Append(",[Pallet_Number],[Variety_Code], [Label_Code] ,[Style_Code],[Size_Code],[Pack_Code]");
                    Command_Text.Append(",[Grade_Code], [Grower_Number], [Boxes_Count], [Memo])");
                    Command_Text.Append("  VALUES (");
                    Command_Text.Append("'" + DateTime.Now + "', ");  //Selection Date
                    Command_Text.Append("'" + ReceiptNumber + "', ");  //Receipt Number 
                    Command_Text.Append("'" + QCStringList[11].ToString().Trim().Replace("'", "") + "', ");  //exporter 
                    Command_Text.Append("'" + QCStringList[13].ToString().Trim() + "', ");  //Vessel Number
                    Command_Text.Append("'" + QCStringList[10].ToString().Trim() + "', ");  //Pallet Prefix
                    Command_Text.Append("'" + QCStringList[3].ToString().Trim() + "', ");  //Warehouse
                    Command_Text.Append("'" + QCStringList[6].ToString().Trim() + "', ");  //Region
                    Command_Text.Append("'" + row[1].ToString().Trim() + "', ");  //Grower Block ID, always in column 1
                    Command_Text.Append("'" + row[ImportSettings.CommodityColumn].ToString().Trim() + "', ");  //Commodity ID
                    Command_Text.Append("'" + QCStringList[1] + "', ");  //Receiving Date 
                    Command_Text.Append("'" + row[ImportSettings.TagNumberColumn].ToString().Trim() + "', ");  //pallet number/tag number
                    Command_Text.Append("'" + row[ImportSettings.VarietyColumn].ToString().Trim() + "', ");  //Variety Code
                    Command_Text.Append("'" + row[ImportSettings.LabelColumn].ToString().Replace("'", "") + "', ").ToString().Trim();  //Label Code
                    if (ImportSettings.SizeColumn == ImportSettings.StyleColumn)  //if size and style column are same it is a pack code
                    {
                        Command_Text.Append("'" + "', ");  //Style Code
                        Command_Text.Append("'" + "', ");  //Size Code
                        Command_Text.Append("'" + row[ImportSettings.PackCodeColumn].ToString().Trim() + "', ");  //if pack code was used then put blank size and style
                    }
                    else
                    {
                        Command_Text.Append("'" + row[ImportSettings.StyleColumn].ToString().Trim() + "', ");  //Style Code
                        Command_Text.Append("'" + row[ImportSettings.SizeColumn].ToString().Trim() + "', ");  //Size Code
                        Command_Text.Append("'" + row[ImportSettings.PackCodeColumn].ToString().Trim() + "', ");  //Pack code
                    }
                    Command_Text.Append("'" + row[ImportSettings.GradeColumn].ToString().Trim() + "', ");  //Grade Code
                    Command_Text.Append("'" + row[ImportSettings.GrowerNumberColumn].ToString().Trim() + "', ");  //Grower Number
                    Command_Text.Append("'" + row[ImportSettings.InventoryQuantityColumn] + "', ");  //Box count or Inventory Quantity
                    Command_Text.Append("'" + "" + "')");  //Memo field blank, Since "'" messes up the command string it is removed

                    cmd.CommandText = Command_Text.ToString();

                    cmd.ExecuteNonQuery();
                    commandstringtext = cmd.CommandText.ToString();

                }

                sqlConnectionArchive.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error trying to Select QC Pallets import data.  \n" +
                    "Verify that the internet connection is OK and the Archive database is up.  \n" +
                    "  See error log for more details.   -   The command string is:  \n" + commandstringtext);
                Error_Logging el = new Error_Logging("Error trying to Select QC Pallets import data.  \n" + "   -   The command string is:  \n" + commandstringtext +
                    "Error message is:  \n" + e);
                return false;
            }

            //Select pallets for inspection and update the archive data table with "QC" in the memo column for pallets for QC inspection
            using (SqlConnection sqlConnection1 =
                new SqlConnection(Properties.Settings.Default.ArchiveConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        cmd.CommandText = "UpdateQCArchiveTable_Test";  //this is the stored procedure on the server
                    }                                                             //uses the Test table to store data 
                    else
                    {
                        cmd.CommandText = "UpdateQCArchiveTable";  //this is the stored procedure on the server
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    try
                    {
                        rowsAffected = cmd.ExecuteNonQuery();

                        if (!(rowsAffected == -1))
                        {
                            MessageBox.Show("There was an error in the script while Selecting pallets for QC.");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error trying to select pallets for QC.  \n" +
                            " Connection error or missing stored procedure.");
                        Error_Logging el = new Error_Logging("Error trying to select pallets for QC.  \n" +
                            " Connection error or missing stored procedure.  \n" + ex);
                        return false;
                    }

                }
            }

            return true;
        }


    }
}
