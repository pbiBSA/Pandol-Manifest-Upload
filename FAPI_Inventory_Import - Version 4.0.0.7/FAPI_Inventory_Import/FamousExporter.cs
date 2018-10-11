using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

//The class takes the data dataset, templatesettings and list of dropdown field values to generate the export/import file for Famous
namespace FAPI_Inventory_Import
{
    //This class takes the dataset passed in the constructor and forms a list of rows to be exported
    //the list will be used by the filemaker class to create the actual data file
    
    class FamousExporter
    {

        bool exported = false;  //Has data been exported?
        DataSet Data2Export = new DataSet();  //holder of data to export
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        private DataTable CommodityTable;  //commodity table
        List<string> RecordsToExport = new List<string>();  //List of exported data records
        List<string> exportStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");  //US culture format to use for dates
        int ReceiptNumber = 0;
        int ReUseReceiptNumber = 0;   //used as a flag to reuse receipt numbers


        public FamousExporter(DataSet ds, ImportTemplateSettings ImS, List<String> dl)  
        {
            Data2Export = ds.Copy();  
            exportStringList = dl;
            ImportSettings = ImS;

            try
            {                     
                //get Commodity data from database
                string connString = Properties.Settings.Default.ConnectionString;
                string query = "select [Data_Column_Name],[Description],[Value], [Custom_Value] FROM Translation_Validation_Table"; // WHERE Famous_Validate = 1";

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();

                DataSet commodityDataSet = new DataSet();
                // create data adapter
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                // this will query the database and return the result to your datatable
                da.Fill(commodityDataSet);
                conn.Close();
                da.Dispose();
                CommodityTable = commodityDataSet.Tables[0];  //set the translation table
                commodityDataSet.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show("There was an error while trying to load the Commodity data for export.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load theCommodity data for export. \n" + e);
                ds.Dispose();
                return;
            }
           
        }

        public bool ExportData() //creates the export list from the Data2Export dataset
        {
            StringBuilder exportLineString = new StringBuilder();  //string builder used to create export text lines.
            string tagnumber;  //temp string for tag number creation
            string LineNumberStringCheck = "";  //Used to hold the concatenated string to check for changes to increment the line number
            string TempLineNumberStringCheck = "";  //Temp string variable for the above
            int LineNumber = 0;
            string Tempgrade = "";
            
            RecordsToExport.Clear();  //clear list in case this method has been run already.

            DataRow[] CommodityValidateRows = CommodityTable.Select("Data_Column_Name = 'Commodity'");  //get all rows for Commodity from validation table;
                      

            //do combining of mixed pallets here and send name of export to use for title of window
            //Instantiate the box combining object for mixed pallets.
            CombineMixedBoxesOnPallets CombinedBoxes = new CombineMixedBoxesOnPallets(Data2Export, ImportSettings, "Famous");
            CombinedBoxes.CombineMixedPallets();
            CombinedBoxes.ViewData();
            Data2Export = CombinedBoxes.CombinedData();


            //Sort data before exporting  *********************************************************
            DataViewManager dvm = new DataViewManager();
            dvm.DataSet = Data2Export.Copy();
            //Name columns so they are always named the same for the sorting
            dvm.DataSet.Tables[0].Columns[ImportSettings.GradeColumn].ColumnName = "Grade Column";
            dvm.DataSet.Tables[0].Columns[1].ColumnName = "Grower Block Column";
            dvm.DataSet.Tables[0].Columns[ImportSettings.CommodityColumn].ColumnName = "Commodity Column";
            dvm.DataSet.Tables[0].Columns[ImportSettings.StyleColumn].ColumnName = "Style Column";
            dvm.DataSet.Tables[0].Columns[ImportSettings.SizeColumn].ColumnName = "PackSize Column";
            dvm.DataSet.Tables[0].Columns[ImportSettings.LabelColumn].ColumnName = "Label Column";
            //sort
            dvm.DataViewSettings[0].Sort = "[[Grower Block Column], [Label Column], [Style Column], [PackSize Column], [Grade Column]";  //"[Label], [PackSize], [Style], [Grade], [Grower Block], [Commodity]";
            dvm.DataSet.AcceptChanges();
            //Fill the Datarow array with the sorted data
            DataRow[] rows = dvm.DataSet.Tables[0].Select(string.Empty, "[Grower Block Column], [Grade Column]");
            //*************************************************************************************

            //Code to check for exporter and vessel number in archive
            string connString = Properties.Settings.Default.ArchiveConnectionString;  //get connection string from the application settings
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // Instantiate connection object
            SqlDataAdapter ArchivedReceiptsDataAdaptor = null;  //DataAdaptor for the Exporter-Vessel_Number, Receipt number table
            SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
            SqlCommand QueryCommand = null;  //query string


            //get receipt numbers data from archive database
            DataSet dt = new DataSet();
            if (Properties.Settings.Default.Mode.ToString() == "Test")  //check for test mode and use test archive if test mode
            {
                 QueryCommand = new SqlCommand("  Select DISTINCT [Exporter] + '-' + [Vessel_Number] AS EXNUM, [Receipt_Number] " + 
                                            "FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Test]" +
                                            "ORDER BY EXNUM", conn);
            }
            else
            {
                 QueryCommand = new SqlCommand("  Select DISTINCT [Exporter] + '-' + [Vessel_Number] AS EXNUM, [Receipt_Number] " + 
                                            "FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]" +
                                            "ORDER BY EXNUM", conn);
            }

           

            ArchivedReceiptsDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ArchivedReceiptsDataAdaptor);

            conn.Open();

            ArchivedReceiptsDataAdaptor.Fill(dt);

            conn.Close();

            //get data for exporter-vessel from archive.  if it exists popup get receipt number window to get receipt number
            string ExporterVessel = "'" + exportStringList[11].ToString() + "-" + exportStringList[13].ToString() + "'";
            DataRow[] ReceiptRows = dt.Tables[0].Select("EXNUM = " + ExporterVessel);

            if (ReceiptRows.Length == 0)  //No matches were found for the exporter and vessel number
            {
                IncrementReceiptNumber rn = new IncrementReceiptNumber();
                ReceiptNumber = rn.GetNewReceiptNumber();  //get incremented receipt number
                ReUseReceiptNumber = 0;
            }
            else  //Matches found
            {
                //Open Select Receipt form
                Select_Receipt_Number Select_Receipt_Form = new Select_Receipt_Number(ReceiptRows);

                DialogResult result = Select_Receipt_Form.ShowDialog();

                if (result == DialogResult.OK)  //used clicked OK
                {
                    ReceiptNumber = Select_Receipt_Form.GetReceiptNumber();
                    ReUseReceiptNumber = 1;  //Reused the receipt number

                }
                else  //Cancel or window closed
                {
                    IncrementReceiptNumber rn = new IncrementReceiptNumber();
                    ReceiptNumber = rn.GetNewReceiptNumber();
                    ReUseReceiptNumber = 0;
                }

                Select_Receipt_Form.Dispose();
            }

            //get last line number used for this receipt number *****************************************
            LineNumber = CreateLineNumber.LastLineNumber(ReceiptNumber);  //set the start point to the last line number for this receipt number
                                                                          //the number will be incremented by 1 before using.

            try  //Begin creation of the export string list for export
            {
                for (int ExportDataRow = 0; ExportDataRow < rows.Length; ExportDataRow++)
                {

                    //used to check to see if any of the product defining variables have changed.
                    TempLineNumberStringCheck = rows[ExportDataRow][1].ToString().Trim()  //Exporter
                        + rows[ExportDataRow][ImportSettings.CommodityColumn].ToString().Trim()  //Commodity
                        + rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim()  //Variety
                        + rows[ExportDataRow][ImportSettings.StyleColumn].ToString().Trim()  //Style
                        + rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim()  //Size
                        + rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim()  //Grade
                        + rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim(); //Label             
                    
                    exportLineString = new StringBuilder();  //Start with as fresh stingbuilder object to create the export text line
             
                    exportLineString.AppendFormat("{0,-9}", ReceiptNumber);  //blank for Receipt/Entry number  Increment this number!!!!
                    exportLineString.AppendFormat("{0,1}", exportStringList[0]);  //add Transaction type
                    exportLineString.AppendFormat("{0,-10}", exportStringList[1].Split(' ')[0]); //add Receive/Packdate, splitting off date
                    exportLineString.AppendFormat("{0,1}", exportStringList[2]);  //add Bulk Flag
                    exportLineString.AppendFormat("{0,-40}", exportStringList[3]);  //add Warehouse
                    exportLineString.AppendFormat("{0,-12}", TruncateString.Truncate2(rows[ExportDataRow][ImportSettings.MemoColumn].ToString().Trim(), 12));  //add Memo values
                    exportLineString.AppendFormat("{0,-40}", "");  //add blanks for Description field
                    exportLineString.AppendFormat("{0,-40}", "");  //add blanks for Access Group field

                    //If product definition changes, increment the line number
                    if (LineNumberStringCheck != TempLineNumberStringCheck)
                    {
                        LineNumber++;
                        
                    }
                    LineNumberStringCheck = TempLineNumberStringCheck;  //set old line identifier text to new one

                    exportLineString.AppendFormat("{0,5}", LineNumber.ToString());  //line number field

                    //add prefix number to front of tag number.
                    if ((ImportSettings.PalletPrefixColumn == ImportSettings.TagNumberColumn) || (exportStringList[10].ToString().Length < 1))  //special case for which has prefix as part of tag number already
                    {                                                                         //and the import setting point to same column for both
                        tagnumber = rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim();
                    }
                    else
                    {
                        tagnumber = rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim(); //set tag number to the data tag number
                        if (tagnumber.Length > 3)  //if is less than 4, it can not contain a prefix and a tag number in one
                        {
                            if (!(exportStringList[10].ToString() == (rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim().Substring(0, 3)))) //Prefix not in Tag Number
                            {
                                tagnumber = exportStringList[10].ToString() + rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim();  //append prefix code
                            }
                        }
                    }
                    exportLineString.AppendFormat("{0,-12}", tagnumber);  //add Tag Number
                    exportLineString.AppendFormat("{0,-12}", rows[ExportDataRow][1].ToString().Trim());  //add Grower Block ID, is always in column 1
                    exportLineString.AppendFormat("{0,-12}", "");  //add blank Pool ID field
                    exportLineString.AppendFormat("{0,1}", "");  //add blank for receipt# as lot id field
                    exportLineString.AppendFormat("{0,-12}", exportStringList[13].ToString().Trim());  //add Lot ID/Vessel number field
                    exportLineString.AppendFormat("{0,-40}", "");  //add blanks for Lot Description field
                    exportLineString.AppendFormat("{0,-12}", "");  //add blanks for Product ID field
                    exportLineString.AppendFormat("{0,-10}", rows[ExportDataRow][ImportSettings.CommodityColumn].ToString().Trim());   //add commondity ID
                    exportLineString.AppendFormat("{0,-16}", rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim());  //add Variety ID
                    exportLineString.AppendFormat("{0,-10}", rows[ExportDataRow][ImportSettings.StyleColumn].ToString().Trim());  //add Style ID
                    exportLineString.AppendFormat("{0,-10}", rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim());  //add Size ID

                    //Clear stone fruit Grade
                    Tempgrade = rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim();  //add Grade ID
                        foreach (DataRow Commodityrow in CommodityValidateRows)
                        {
                            if (rows[ExportDataRow][ImportSettings.CommodityColumn].ToString() == Commodityrow[2].ToString() &&
                                                         Commodityrow[3].ToString() == "Stone Fruit")
                            {
                                Tempgrade = "";  //use blank for grade
                            } 
                        }

                    exportLineString.AppendFormat("{0,-10}", Tempgrade); //set grade
                                      
                    exportLineString.AppendFormat("{0,-16}", rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim());  //add Label ID
                    exportLineString.AppendFormat("{0,-16}", exportStringList[6]);  //add Region ID
                    exportLineString.AppendFormat("{0,-16}", exportStringList[7]);  //add Method ID
                    exportLineString.AppendFormat("{0,-16}", exportStringList[8]);  //add Storage ID
                    exportLineString.AppendFormat("{0,-16}", rows[ExportDataRow][ImportSettings.PalletTypeColumn].ToString().Trim());  //add Color ID/Pallet Type
                    exportLineString.AppendFormat("{0,-16}", "");  //add blanks for Quality
                    exportLineString.AppendFormat("{0,-16}", "");  //add blanks for Condition
                    exportLineString.AppendFormat("{0,1}", exportStringList[9]);  //add Availabel Flag
                    exportLineString.AppendFormat("{0,8}", rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString().Trim());  //add Inventory/box count 
                    exportLineString.AppendFormat("{0,-3}", "000");  //add 3 zeros for inventory quantity which has 3 implied decimal places
                    exportLineString.AppendFormat("{0,-11}", "");  //add blanks for Quantity field
                    exportLineString.AppendFormat("{0,-5}", "");  //add blanks for Unit of Measure field
                    exportLineString.AppendFormat("{0,-4}", "");  //add blanks for Units per Pallet field
                    exportLineString.AppendFormat("{0,-12}", "");  //add blanks for Room/Row ID field


                    exportLineString.AppendFormat("{0,-10}", DateTime.Parse(DateNumberToDateString.ConvertDateNumberToDateString( rows[ExportDataRow]
                                                            [ImportSettings.FirstPackDateColumn].ToString().Trim()), mFomatter).ToString("MM/dd/yyyy"));  //add First Pack Date
                    exportLineString.AppendFormat("{0,-14}", "");  //add blanks for GTIN field
                    exportLineString.AppendFormat("{0,-20}", "");  //add blanks for GS1Lot field
                    exportLineString.AppendFormat("{0,-10}", "");  //add blanks for GS1 Date field



                    RecordsToExport.Add(exportLineString.ToString());  //add record to record list to send to file
                }

                CreateLineNumber.UpdateLineNumber(ReceiptNumber, LineNumber);

                exported = true;  //happy export :)
            }

            catch (Exception e)
            {
                exported = false;
                MessageBox.Show("Famous Export process failed.  \nPlease note what was done and see admin for help.  \n");
                Error_Logging el = new Error_Logging("Famous Export process had an error.  \n" + e);
            }

            return exported;  //let progrom know it completed
        }
        
        public List<string> ExportList()  //Gets the export line list
        {
            if (exported)
            {
                return RecordsToExport;
            }
            else
            {
                RecordsToExport.Clear();
                RecordsToExport.Add("Export method has not run yet or had an error.");
                return RecordsToExport;
            }
        }

        public int GetReceiptNumber()
        {
            return ReceiptNumber;
        }

        public int GetReUseReceiptNumber()
        {
            return ReUseReceiptNumber;
        }
                
        
        public bool ExportConversionSucceeded()  //check to see if export was successful.
        {
            return exported;
        }

    }  //end of class
}  //end of namespace
