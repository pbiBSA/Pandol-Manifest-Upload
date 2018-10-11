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
    //This is for archiving the import data to the Import Data Warehouse.  It must be used before mixed pallet data is combined
    //into one record per pallet.
    class Archive_Data
    {
        DataSet DataToArchiveDataSet = new DataSet();  //DataSet to archive
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        List<string> archiveStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        string commandstringtext;
        int ReceiptNumber = 0;
        bool IsError = false;

        public Archive_Data(DataSet ds, ImportTemplateSettings ims , List<string> asl, int rn)
        {
            DataToArchiveDataSet = new DataSet(); //start with clean dataset
            DataToArchiveDataSet = ds.Copy();  //Data to archive from the main data dataset
            ImportSettings = ims;  //import settings show where in the dataset each field is located
            archiveStringList = asl;  //string data from main app controls
            ReceiptNumber = rn;  //receipt number for export data
            IsError = false;
        }

        public bool Store_Data()
        {
            //stores the data in the archive database
            try
            {
                SqlConnection sqlConnectionArchive =
                    new SqlConnection(Properties.Settings.Default.ArchiveConnectionString);  //connection string in application settings

                SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnectionArchive;
                sqlConnectionArchive.Open();
                IsError = false;

                StringBuilder Command_Text = new StringBuilder();


                foreach (DataRow row in DataToArchiveDataSet.Tables[0].Rows)  //insert each record from the dataset and string list
                {
                    //Note the ' character is used to delineate text so must be removed from any text strings.

                    if (IsError)
                    {
                        break;
                    }

                    Command_Text = new StringBuilder();
                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        Command_Text.Append("INSERT FAPI_Import_Data_Archive_Temp_Test (");
                    }
                    else
                    {
                        Command_Text.Append("INSERT FAPI_Import_Data_Archive_Temp (");
                    }
                    Command_Text.Append("[Receipt_Number], [Exporter],[Departure_Date],[Vessel_Number],[Vessel_Name],[Destination],[Pallet_Prefix],[Warehouse]");
                    Command_Text.Append(",[Region],[Grower_Block],[Commodity_ID],[Transaction_Type],[Receiving_Date],[Method_Id],[Storage_ID]");
                    Command_Text.Append(",[Import_Template],[Pallet_Number],[Variety_Code], [Label_Code] ,[Style_Code],[Size_Code],[Pack_Code]");
                    Command_Text.Append(",[Grade_Code],[Pack_Date], [Grower_Number], [Boxes_Count], [hatch], [Deck], [Fumigated], [Bill_of_Lading],[Pallet_Type],[Memo],[Other],[Test_Data])");
                    Command_Text.Append("  VALUES (");
                    Command_Text.Append("'" + ReceiptNumber + "', ");  //Receipt Number 
                    Command_Text.Append("'" + archiveStringList[11].ToString().Trim().Replace("'", "") + "', ");  //exporter 
                    Command_Text.Append("'" + archiveStringList[12] + "', ");  //Departure Date
                    Command_Text.Append("'" + archiveStringList[13].ToString().Trim() + "', ");  //Vessel Number
                    Command_Text.Append("'" + archiveStringList[14].ToString().Trim().Replace("'", "") + "', ");  //Vessel Name
                    Command_Text.Append("'" + archiveStringList[15].ToString().Trim().Replace("'", "") + "', ");  //Destination
                    Command_Text.Append("'" + archiveStringList[10] + "', ");  //Pallet Prefix
                    Command_Text.Append("'" + archiveStringList[3].ToString().Trim() + "', ");  //Warehouse
                    Command_Text.Append("'" + archiveStringList[6].ToString().Trim() + "', ");  //Region
                    Command_Text.Append("'" + row[1].ToString() + "', ");  //Grower Block ID, always in column 1
                    Command_Text.Append("'" + row[ImportSettings.CommodityColumn] + "', ");  //Commodity ID
                    Command_Text.Append("'" + archiveStringList[0] + "', ");  //Transaction Type
                    Command_Text.Append("'" + archiveStringList[1] + "', ");  //Receiving Date 
                    Command_Text.Append("'" + archiveStringList[7] + "', ");  //Method ID
                    Command_Text.Append("'" + archiveStringList[8] + "', ");  //Storage ID
                    Command_Text.Append("'" + ImportSettings.TemplateName + "', ");  //Template Name
                    Command_Text.Append("'" + row[ImportSettings.TagNumberColumn].ToString().Trim() + "', ");  //pallet number/tag number
                    Command_Text.Append("'" + row[ImportSettings.VarietyColumn] + "', ");  //Variety Code
                    Command_Text.Append("'" + row[ImportSettings.LabelColumn].ToString().Trim().Replace("'", "") + "', ");  //Label Code
                    if (ImportSettings.SizeColumn == ImportSettings.StyleColumn)  //if size and style column are same it is a pack code
                    {
                        Command_Text.Append("'" + "', ");  //Style Code
                        Command_Text.Append("'" + "', ");  //Size Code
                        Command_Text.Append("'" + row[ImportSettings.PackCodeColumn] + "', ");  //if pack code was used then put blank size and style
                    }
                    else
                    {
                        Command_Text.Append("'" + row[ImportSettings.StyleColumn] + "', ");  //Style Code
                        Command_Text.Append("'" + row[ImportSettings.SizeColumn] + "', ");  //Size Code
                        Command_Text.Append("'" + row[ImportSettings.PackCodeColumn] + "', ");  //Pack code
                    }
                    Command_Text.Append("'" + row[ImportSettings.GradeColumn] + "', ");  //Grade Code
                    Command_Text.Append("'" + DateNumberToDateString.ConvertDateNumberToDateString(row[ImportSettings.FirstPackDateColumn].ToString()) + "', ");  //First Pack Date
                    Command_Text.Append("'" + row[ImportSettings.GrowerNumberColumn].ToString().Trim() + "', ");  //Grower Number
                    Command_Text.Append("'" + row[ImportSettings.InventoryQuantityColumn] + "', ");  //Box count or Inventory Quantity
                    Command_Text.Append("'" + row[ImportSettings.HatchColumn].ToString().Trim() + "', ");  //Hatch     
                    Command_Text.Append("'" + row[ImportSettings.DeckColumn].ToString().Trim() + "', ");  //Deck
                    Command_Text.Append("'" + row[ImportSettings.FumigatedColumn] + "', ");  //Fumigated
                    Command_Text.Append("'" + row[ImportSettings.BillOfLadingColumn].ToString().Trim() + "', ");  //Bill of Lading
                    Command_Text.Append("'" + row[ImportSettings.PalletTypeColumn] + "', ");  //Pallet Type
                    Command_Text.Append("'" + row[ImportSettings.MemoColumn].ToString().Trim().Replace("'", "") + "', ");  //Memo field, Since "'" messes up the command string it is removed
                    Command_Text.Append("'" + archiveStringList[16] + "', ");  //Other field, Used as the flag to reuse receipt number
                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        Command_Text.Append("' Test " + Application.ProductVersion.ToString() + "')");  //  Test Mode
                    }
                    else
                    {
                        Command_Text.Append("'" + Application.ProductVersion.ToString() + "')");  //  write version into test data field
                    }


                    

                    cmd.CommandText = Command_Text.ToString();
                    commandstringtext = cmd.CommandText.ToString();
                    cmd.ExecuteNonQuery();

                }

                sqlConnectionArchive.Close();

            }

            catch (Exception e)
            {
                MessageBox.Show("Error trying to archive import data.  \n" + 
                    "Verify that the internet connection is OK and the Archive database is up.  \n" +
                    "  See error log for more details.   -   The command string is:  \n" + commandstringtext);
                Error_Logging el = new Error_Logging("Error trying to archive import data.  \n" + "   -   The command string is:  \n" + commandstringtext + 
                    "Error message is:  \n" + e);
                IsError = true;
                return false;
            }

            //update the archive data table with export name and variety for reporting
            using (SqlConnection sqlConnection1 = 
                new SqlConnection(Properties.Settings.Default.ArchiveConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    if (Properties.Settings.Default.Mode.ToString() == "Test")
                    {
                        cmd.CommandText = "sp_UpdateManifestUploadArchiveInfoTest";  //this is the stored procedure on the server
                    }                                                             //uses the Test import archive to store data 
                    else
                    {
                        cmd.CommandText = "sp_UpdateManifestUploadArchiveInfoVersion2";  //this is the stored procedure on the server
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    try
                    {
                        rowsAffected = cmd.ExecuteNonQuery();

                        if (!(rowsAffected == -1))
                        {
                            MessageBox.Show("There was an error in the script while updating the archive table.");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error trying to run archive update script.  \n");
                        Error_Logging el = new Error_Logging("Error trying to run archive update script.  \n" + ex);
                        return false;
                    }

                }
            }

            return true;
        }

    }
}
