using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace FAPI_Inventory_Import
{
    class FamousXMLExporter
    {
        bool exported = false;  //Has data been exported?
        DataSet Data2Export = new DataSet();  //holder of data to export
        //DataTable DataTableForExport;
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        private DataTable StoneFruitTable;  //Stone Fruit table
        List<string> RecordsToExport = new List<string>();  //List of exported data records
        List<string> exportStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");  //US culture format to use for dates
        int ReceiptNumber = 0;
        int ReUseReceiptNumber = 0;   //used as a flag to reuse receipt numbers
        string CrudType = "Create";

        public FamousXMLExporter(DataSet ds, ImportTemplateSettings ImS, List<String> dl)  
        {
            Data2Export = ds.Copy();  
            exportStringList = dl;
            ImportSettings = ImS;

            try
            {
                 
                //get Commodity data from database
                string connString = Properties.Settings.Default.ConnectionString;
                string query = "select [Commodity] FROM [StoneFuitCommodities]"; // List of stone fruits and berries;

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();

                DataSet StoneFruitDataSet = new DataSet();
                // create data adapter
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                // this will query the database and return the result to your datatable
                da.Fill(StoneFruitDataSet);
                conn.Close();
                da.Dispose();
                StoneFruitTable = StoneFruitDataSet.Tables[0];  //set the translation table
                StoneFruitDataSet.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show("There was an error while trying to load the Commodity data for XML export.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load theCommodity data for XML export. \n" + e);
                ds.Dispose();
                return;
            }
           
        }

        public bool ExportData() //creates the export list from the Data2Export dataset
        {
            StringBuilder exportLineString = new StringBuilder();  //string builder used to create export text lines.
            DataSet TempDataSet = new DataSet();  //dataset for summing the box count for each grower block
            string tagnumber;  //temp string for tag number creation
            string ProductCheck = "";  //Used to hold the concatenated string to check for changes to increment the line number
            string TempProductCheck = "";  //Temp string variable for the above
           //string TempGrowerBlockID = "";  //Temp string for holding grower block ID to detect when it changes
            int LineNumber = 0;
            string Tempgrade = "";
            int TempGrowerBoxCount = 0;
            string TempGrowerBlock;
            string TempCommodity;
            string TempVariety;
            string TempStyle;
            string TempSize;
            string TempGrade2;
            string TempLabel;
            bool FirstProductBlock = true;

            RecordsToExport.Clear();  //clear list in case this method has been run already.

           // DataRow[] StoneFruitRows = StoneFruitTable.Select("[Commodity] = *");  //get all rows for stone fruit commodities;


            //do combining of mixed pallets here and send name of export to use for title of window
            //Instantiate the box combining object for mixed pallets.
            CombineMixedBoxesOnPallets CombinedBoxes = new CombineMixedBoxesOnPallets(Data2Export, ImportSettings, "Famous");
            CombinedBoxes.CombineMixedPallets();
            CombinedBoxes.ViewData();
            Data2Export = CombinedBoxes.CombinedData();


            //Sort data before exporting  *********************************************************
            DataViewManager dvm = new DataViewManager();
            dvm.DataSet = Data2Export.Copy();
            DataTable dt1 = new DataTable();
           
            
            //Name columns so they are always named the same for the sorting
            dvm.DataSet.Tables[0].Columns[ImportSettings.GradeColumn].ColumnName = "GradeColumn";
            dvm.DataSet.Tables[0].Columns[1].ColumnName = "GrowerBlockColumn";
            dvm.DataSet.Tables[0].Columns[ImportSettings.CommodityColumn].ColumnName = "CommodityColumn";
            dvm.DataSet.Tables[0].Columns[ImportSettings.StyleColumn].ColumnName = "StyleColumn";
            dvm.DataSet.Tables[0].Columns[ImportSettings.SizeColumn].ColumnName = "PackSizeColumn";
            dvm.DataSet.Tables[0].Columns[ImportSettings.LabelColumn].ColumnName = "LabelColumn";
            dvm.DataSet.Tables[0].Columns[ImportSettings.PackCodeColumn].ColumnName = "PackCode";
            //sort
           // dvm.DataViewSettings[0].Sort = "GrowerBlockColumn, LabelColumn, PackCode, PackSizeColumn, StyleColumn, GradeColumn";  //"[Label], [PackSize], [Style], [Grade], [Grower Block], [Commodity]";
 
            dvm.DataSet.AcceptChanges();

          
            //Fill the Datarow array with the sorted data
            DataRow[] rows = dvm.DataSet.Tables[0].Select(string.Empty, "GrowerBlockColumn, LabelColumn, PackCode, PackSizeColumn, StyleColumn, GradeColumn", DataViewRowState.CurrentRows);
          
            //*************************************************************************************

            //Code to check for exporter and vessel number in archive
            string connString = Properties.Settings.Default.ArchiveConnectionString;  //get connection string from the application settings
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // Instantiate connection object
            SqlDataAdapter ArchivedReceiptsDataAdaptor = null;  //DataAdaptor for the Exporter-Vessel_Number, Receipt number table
           // SqlDataAdapter ArchivedReceiptsDataAdaptor2 = null;  //DataAdaptor for the Exporter_Name-Vessel_Number, Receipt number table
            SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
            //SqlCommandBuilder cmdBuilder2; //using sql command builder to create update command
            SqlCommand QueryCommand = null;  //query string
            //SqlCommand QueryCommand2 = null;  //query string


            //get receipt numbers data from archive database for Exporter
            DataSet dt = new DataSet();
            if (Properties.Settings.Default.Mode.ToString() == "Test")  //check for test mode and use test archive if test mode
            {
                QueryCommand = new SqlCommand("  Select DISTINCT [Exporter_Name] + '-' + [Vessel_Number] AS EXNUM, [Receipt_Number] " +
                                           "FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Test]" +
                                           "ORDER BY EXNUM", conn);
            }
            else
            {
                QueryCommand = new SqlCommand("  Select DISTINCT [Exporter_Name] + '-' + [Vessel_Number] AS EXNUM, [Receipt_Number] " +
                                           "FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]" +
                                           "ORDER BY EXNUM", conn);
            }

           


            ArchivedReceiptsDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ArchivedReceiptsDataAdaptor);

            conn.Open();

            ArchivedReceiptsDataAdaptor.Fill(dt);

            conn.Close();


           


            //get data for exporter-vessel from archive.  if it exists popup get receipt number window to get receipt number
            string ExporterVessel = "'" + exportStringList[11].ToString().Trim() + "-" + exportStringList[13].ToString().Trim() + "'";
            DataRow[] ReceiptRows = dt.Tables[0].Select("EXNUM = " + ExporterVessel);
          
      


            if (ReceiptRows.Length == 0)  //No matches were found for the exporter and vessel number
            {
                IncrementReceiptNumber rn = new IncrementReceiptNumber();
                ReceiptNumber = rn.GetNewReceiptNumber();  //get incremented receipt number
                ReUseReceiptNumber = 0;
                CrudType = "Create";
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
                    CrudType = "Update";
                }
                else  //Cancel or window closed
                {
                    IncrementReceiptNumber rn = new IncrementReceiptNumber();
                    ReceiptNumber = rn.GetNewReceiptNumber();
                    ReUseReceiptNumber = 0;
                    CrudType = "Create";
                }

                Select_Receipt_Form.Dispose();
            }

            //get last line number used for this receipt number *****************************************
            LineNumber = CreateLineNumber.LastLineNumber(ReceiptNumber);  //set the start point to the last line number for this receipt number
            //the number will be incremented by 1 before using.

            try  //Begin creation of the export string list for export
            {
                string tempString;
                //Add Header info
                exportLineString.AppendLine("<InventoryTransaction>");
                exportLineString.AppendLine("  <CRUDType>" + CrudType + "</CRUDType>");
                if (exportStringList[0] == "1")  //convert transaction type code to text
                {
                    tempString = "Receive";
                }
                else if (exportStringList[0] == "2")
                {
                    tempString = "Pack";
                }
                else
                {
                    tempString = "repack";
                }
                exportLineString.AppendLine("  <TransactionType>" + tempString + "</TransactionType>");
                exportLineString.AppendLine("  <ProductType>Grower</ProductType>");
                exportLineString.AppendLine("  <ReceivingEntryNumber>" + ReceiptNumber.ToString() + "</ReceivingEntryNumber>");
                exportLineString.AppendLine("  <TransactionDate>" +
                   DateTime.Parse(DateNumberToDateString.ConvertDateNumberToDateString(exportStringList[1].Split(' ')[0]), mFomatter).ToString("yyyy-MM-dd")
                   + "</TransactionDate>");

                //exportStringList[1].Split(' ')[0] + "</TransactionDate>");
                exportLineString.AppendLine("  <BulkFlag>" + exportStringList[2].ToString() + "</BulkFlag>");
                // exportLineString.AppendLine("  <FirstReceiveDate>2011-05-02</FirstReceiveDate>");  //Optional
                exportLineString.AppendLine("  <Warehouse>" + exportStringList[3] + "</Warehouse>");
                exportLineString.AppendLine("  <LotId>" + exportStringList[13].ToString().Trim() + "</LotId>");  //Vessel Number/Lot ID
               
                exportLineString.AppendLine("  <ProductLines>");

                RecordsToExport.Add(exportLineString.ToString());  //add record to record list to send to file

                //Add imported data to export
                    for (int ExportDataRow = 0; ExportDataRow < rows.Length; ExportDataRow++)
                    {

                        exportLineString = new StringBuilder();

                      /*
                        if (TempGrowerBlockID != rows[ExportDataRow][1].ToString().Trim())  //Look for changed blockID
                        {

                            exportLineString.AppendLine("    <ProductLine>");
                            exportLineString.AppendLine("      <CRUDType>Create</CRUDType>");
                
                            LineNumber++;  //Line number starts from zero so increment even the first time through

                            exportLineString.AppendLine("      <LineNumber>" + LineNumber.ToString() + "</LineNumber>");
                            exportLineString.AppendLine("      <BlockId>" + rows[ExportDataRow][1].ToString().Trim() + "</BlockId>");

                            
                            
                            //add code to get inventory quantity for block ID  *********************************************************
                            DataViewManager Gdvm = new DataViewManager();
                            Gdvm.DataSet = Data2Export.Copy();
                            TempGrowerBlock = rows[ExportDataRow][1].ToString().Trim();
                            Gdvm.DataSet.Tables[0].Columns[1].ColumnName = "Grower_Block_Column";
                            DataRow[] GrowerBlockrows = Gdvm.DataSet.Tables[0].Select("Grower_Block_Column = '" + TempGrowerBlock + "'");
                                                   
                            TempGrowerBoxCount = 0;
                            foreach (DataRow Growerrow in GrowerBlockrows)  // Sum up the total inventory quantity for the grower block
                            {
                                TempGrowerBoxCount = TempGrowerBoxCount + Convert.ToInt32(Growerrow[ImportSettings.InventoryQuantityColumn]);

                            }

                             exportLineString.AppendLine("      <InventoryQuantity>" +
                                          TempGrowerBoxCount + "</InventoryQuantity>");

                            exportLineString.AppendLine("      <AvailableFlag>" + exportStringList[9] + "</AvailableFlag>");
                            //exportLineString.AppendLine("      <CompletedFlag>" + exportStringList[9] + "</CompletedFlag>");  //Optional

                        }
                       */
                      
                      //  TempGrowerBlockID = rows[ExportDataRow][1].ToString().Trim();  //set old BlockID identifier text to new one

                        
                        //used to check to see if any of the product defining variables have changed.
                        TempProductCheck = rows[ExportDataRow][1].ToString().Trim()   //Grower block
                            +rows[ExportDataRow][ImportSettings.CommodityColumn].ToString().Trim()  //Commodity
                            + rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim()  //Variety
                            + rows[ExportDataRow][ImportSettings.StyleColumn].ToString().Trim()  //Style
                            + rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim()  //Size
                            + rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim()  //Grade
                            + rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim(); //Label             

                       // exportLineString = new StringBuilder();  //Start with as fresh stingbuilder object to create the export text line

                        //details
                     

                        //If product definition changes, increment the line number
                        if (ProductCheck != TempProductCheck)
                        {

                            //****************
                            if (!(FirstProductBlock))  //skip the first time through
                            {
                                exportLineString.AppendLine("      </InventoryTags>");
                                exportLineString.AppendLine("    </ProductLine>");
                            }
                            FirstProductBlock = false;  // set to false after first pass

                            exportLineString.AppendLine("    <ProductLine>");
                            exportLineString.AppendLine("      <CRUDType>Create</CRUDType>");   //" + CrudType + "</CRUDType>");

                            LineNumber++;  //Line number starts from zero so increment even the first time through

                            exportLineString.AppendLine("      <LineNumber>" + LineNumber.ToString() + "</LineNumber>");
                            exportLineString.AppendLine("      <BlockId>" + rows[ExportDataRow][1].ToString().Trim() + "</BlockId>");



                            //add code to get inventory quantity for block ID  *********************************************************
                            DataViewManager Gdvm = new DataViewManager();
                            Gdvm.DataSet = Data2Export.Copy();
                            TempGrowerBlock = rows[ExportDataRow][1].ToString().Trim();
                            TempCommodity = rows[ExportDataRow][ImportSettings.CommodityColumn].ToString().Trim();
                            TempVariety = rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim();
                            TempStyle = rows[ExportDataRow][ImportSettings.StyleColumn].ToString().Trim();
                            TempSize = rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim();
                            TempGrade2 = rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim();
                            TempLabel = rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Replace("'", "''").Trim();

                            Gdvm.DataSet.Tables[0].Columns[1].ColumnName = "TempGrower_Block_Column";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.CommodityColumn].ColumnName = "TempCommodity";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.VarietyColumn].ColumnName = "TempVariety";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.StyleColumn].ColumnName = "TempStyle";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.SizeColumn].ColumnName = "TempSize";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.GradeColumn].ColumnName = "TempGrade";
                            Gdvm.DataSet.Tables[0].Columns[ImportSettings.LabelColumn].ColumnName = "TempLabel";





                           // DataRow[] GrowerBlockrows = Gdvm.DataSet.Tables[0].Select("Grower_Block_Column = '" + TempGrowerBlock + "'");
                            DataRow[] GrowerBlockrows;  //Don't use Grade if it is blank.
                            if (TempGrade2.Length > 0)
                            {
                                GrowerBlockrows = Gdvm.DataSet.Tables[0].Select("TempGrower_Block_Column = '" + TempGrowerBlock +
                                        "' AND TempCommodity = '" + TempCommodity + "' AND TempVariety = '" + TempVariety + "' AND TempStyle = '" +
                                        TempStyle + "' AND TempSize = '" + TempSize + "' AND TempGrade = '" + TempGrade2 +
                                        "' AND TempLabel = '" + TempLabel + "'");
                            }
                            else
                            {
                                GrowerBlockrows = Gdvm.DataSet.Tables[0].Select("TempGrower_Block_Column = '" + TempGrowerBlock +
                                "' AND TempCommodity = '" + TempCommodity + "' AND TempVariety = '" + TempVariety + "' AND TempStyle = '" +
                                TempStyle + "' AND TempSize = '" + TempSize +  "' AND TempLabel = '" + TempLabel + "'");
                            }
                             
                           

                            TempGrowerBoxCount = 0;
                            foreach (DataRow Growerrow in GrowerBlockrows)  // Sum up the total inventory quantity for the grower block
                            {
                                TempGrowerBoxCount = TempGrowerBoxCount + Convert.ToInt32(Growerrow[ImportSettings.InventoryQuantityColumn]);

                            }

                            exportLineString.AppendLine("      <InventoryQuantity>" +
                                         TempGrowerBoxCount + "</InventoryQuantity>");

                            exportLineString.AppendLine("      <AvailableFlag>" + exportStringList[9] + "</AvailableFlag>");

                            //*************

                            exportLineString.AppendLine("      <Product>");
                            exportLineString.AppendLine("        <CommodityId>" + rows[ExportDataRow][ImportSettings.CommodityColumn].ToString().Trim()
                                                + "</CommodityId>");
                            exportLineString.AppendLine("        <VarietyId>" + rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim()
                                                + "</VarietyId>");
                            exportLineString.AppendLine("        <StyleId>" + rows[ExportDataRow][ImportSettings.StyleColumn].ToString().Trim()
                                                + "</StyleId>");
                            exportLineString.AppendLine("        <SizeId>" + rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim()
                                                + "</SizeId>");

                            //Check to see if it is a stone fruit. then use size for Grade otherwise use the grade
                            Tempgrade = rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim();  //add Grade ID
                            //foreach (DataRow StoneFruitRow in StoneFruitTable.Rows) //check all listed change if it is a stone fruit
                           // {
                              //  if (rows[ExportDataRow][ImportSettings.CommodityColumn].ToString() == StoneFruitRow[0].ToString())
                              //  {
                               //     Tempgrade = rows[ExportDataRow][ImportSettings.SizeColumn].ToString().Trim();  //use size for grade
                               // }
                           // }
                         
                            if (Tempgrade.Length > 0) // export grade only if it has a value
                            {
                                exportLineString.AppendLine("        <GradeId>" + Tempgrade + "</GradeId>");
                            }

                            exportLineString.AppendLine("        <LabelId>" + rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim()
                                                 + "</LabelId>");
                            //exportLineString.AppendLine("        <MethodId>" + exportStringList[7]
                            //+ "</MethodId>");
                            exportLineString.AppendLine("        <RegionId>" + exportStringList[6]
                                             + "</RegionId>");
                            exportLineString.AppendLine("        <StorageId>" + exportStringList[8]
                                                 + "</StorageId>");
                            exportLineString.AppendLine("        <ColorId>" + rows[ExportDataRow][ImportSettings.PalletTypeColumn].ToString().Trim()
                                           + "</ColorId>");  //Used for Pallet code

                            exportLineString.AppendLine("      </Product>");
                            exportLineString.AppendLine("      <InventoryTags>");

                        }
                        ProductCheck = TempProductCheck;  // Set the product check variable to current

                        //Inventory tag section
                        exportLineString.AppendLine("        <InventoryTag>");    
                       
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
                        exportLineString.AppendLine("        <TagId>" + tagnumber + "</TagId>");

                        //Total quantity
                        exportLineString.AppendLine("        <InventoryQuantity>" +
                                          rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString().Trim() + "</InventoryQuantity>");
                        exportLineString.AppendLine("        <Quantity>" + rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString().Trim() +
                                                             "</Quantity>");

                        exportLineString.AppendLine("        <AvailableFlag>" + exportStringList[9] + "</AvailableFlag>");

                       // exportLineString.AppendLine("        <GS1Date>" + DateTime.Parse(DateNumberToDateString.ConvertDateNumberToDateString(rows[ExportDataRow]
                                                   //         [ImportSettings.FirstPackDateColumn].ToString().Trim()), mFomatter).ToString("yyyy-MM-dd") +
                                                  //  "</GS1Date>");  //First Pack Date
                        exportLineString.AppendLine("        </InventoryTag>");

                    RecordsToExport.Add(exportLineString.ToString());  //add record to record list to send to file
                }
                
                exportLineString = new StringBuilder();
               
                exportLineString.AppendLine("      </InventoryTags>");
                exportLineString.AppendLine("    </ProductLine>");
                exportLineString.AppendLine("  </ProductLines>");
                exportLineString.AppendLine("</InventoryTransaction>");  //add final tags
                RecordsToExport.Add(exportLineString.ToString());

                CreateLineNumber.UpdateLineNumber(ReceiptNumber, LineNumber);

                exported = true;  //happy export :)
            }

            catch (Exception e)
            {
                exported = false;
                MessageBox.Show("Famous Export process failed.  \nPlease note what was done and see admin for help.  \n");
                Error_Logging el = new Error_Logging("Famous Export process had an error.  \n" + e);
            }

            return exported;  //let program know it completed
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
    }
}
