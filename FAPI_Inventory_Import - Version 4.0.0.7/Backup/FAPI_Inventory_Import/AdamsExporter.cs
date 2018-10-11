using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;

namespace FAPI_Inventory_Import
{
    //Old export to text file.  Kept for future use if needed
    //This class takes a validated and translated dataset and creates a record 
    //list to be streamed to a text file for export.
    class AdamsExporter
    {
        bool exported = false;  //Has data been exported?
        DataSet Data2Export = new DataSet();  //holder of data to export
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        List<string> RecordsToExport = new List<string>();  //List of exported data records
        List<string> exportStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        List<string> RecordsToExportIDOne = new List<string>();
        List<string> RecordsToExportIDTwo = new List<string>();
        IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");
        

        public AdamsExporter(DataSet ds, ImportTemplateSettings ImS, List<String> dl)  
        {
            Data2Export = ds.Copy();  //copy the incoming data to a working dataset
            exportStringList = dl;  //string list for control data from the main application
            ImportSettings = ImS;  //import settting for import file type
        }

        public bool ExportData() //creates the export list from the Data2Export dataset
        {
            StringBuilder exportLineString = new StringBuilder();  //string builder used to create export text lines.
            string palletnumber;  //temp string for tag number creation
            string tempString;  //used for string manipulation
            string tempRowID;  //used to identify the rows to sort export data into Export sort order
            int BoxCount = 0;  //boxcount variable used mainly for format manipulation
            int TotalBoxCount = 0; //running total of boxes
            DateTime Dt;  //used for date time manipulation

            RecordsToExport.Clear();  //clear list incase this method has been run already.


            try
            {
            //Create boat information and first line to be exported, record ID = 0 item
            exportLineString = new StringBuilder();  //Start with as fresh stingbulder
            exportLineString.AppendFormat("{0,1}", "0");  //Record ID = 0
            exportLineString.AppendFormat("{0,1}", "0");  //File revision number
            exportLineString.AppendFormat("{0,-10}", TruncateString.Truncate2(exportStringList[11].ToString(), 10));  //Exporter
                    Dt = DateTime.Parse(exportStringList[12], mFomatter);  //format date to yyMMdd format
            exportLineString.AppendFormat("{0,-6}", Dt.ToString("yyMMdd"));  //Ship Date in form of YYMMDD
            exportLineString.AppendFormat("{0,-6}", TruncateString.Truncate2(exportStringList[13].ToString(),6));  //Exporter's ship number
            exportLineString.AppendFormat("{0,-15}", TruncateString.Truncate2(exportStringList[14].ToString(),15));  //Ship's name
            exportLineString.AppendFormat("{0,-15}", TruncateString.Truncate2(exportStringList[15].ToString(),15));  //Destination

            RecordsToExport.Add(exportLineString.ToString());  //add record to record list to send to file
            }

            catch (Exception e)
            {
                exported = false;
                MessageBox.Show("Export process for ship information had an error.  \nPlease note what was done and see administrator for help.  \n");
                Error_Logging el = new Error_Logging("Export (Adams) process for ship information had an error. \n" + e);
                return false;
            }
            
            
            try
            {
                //Record ID = 1 items.  Puts them on the RecordsToExportOne list.           *******
                RecordsToExportIDOne.Clear();
                for (int ExportDataRow = 0; ExportDataRow < Data2Export.Tables[0].Rows.Count; ExportDataRow++)
                {
                    exportLineString = new StringBuilder();  //Start with as fresh stingbulder

                    exportLineString.AppendFormat("{0,1}", "1");  //Record ID = 1
                    //add prefix number to front of tag/pallet number.
                    if (ImportSettings.PalletPrefixColumn == ImportSettings.TagNumberColumn)
                    {
                        palletnumber = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim();
                    }
                    else
                    {
                        palletnumber = exportStringList[10].ToString() +
                            Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim()).ToString("0000000");
                    }
                    exportLineString.AppendFormat("{0,-10}", TruncateString.Truncate2(palletnumber, 10));  //add pallet Number
                    exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim(), 4));  //add Variety ID
                    exportLineString.AppendFormat("{0,-3}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim(), 3));  //add Label ID
                    exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.PackCodeColumn].ToString().Trim(), 4));  //add Pack Code
                    if ((TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim(), 1) != "G") &
                        (Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim().Length < 4))
                    {                                                                                       //Left justified if 
                        exportLineString.AppendFormat("{0,4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim(), 4));  //add Grade ID
                    }
                    else
                    {
                        exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim(),4));  //add Grade ID
                    }
                        Dt = DateTime.Parse(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.FirstPackDateColumn].ToString(), mFomatter);
                    exportLineString.AppendFormat("{0,-6}", Dt.ToString("yyMMdd"));  //add Pack Date
                    exportLineString.AppendFormat("{0,-4}", Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GrowerNumberColumn].ToString().Trim());  //add Grower ID
                    BoxCount = Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString().Trim());
                    exportLineString.AppendFormat("{0,-6}", BoxCount.ToString("000000"));  //add Inventory/box count 
                  
                    //RPC box type goes here!!!!!!!!!!!!!!!!!!!!!!!  tbd
                    exportLineString.AppendFormat("{0,-4}", "");  //add RPC Box 


                    RecordsToExportIDOne.Add(exportLineString.ToString());  //add record to record list to send to file
                }
            }

                catch (Exception e)
                {
                    exported = false;
                    MessageBox.Show("Export process for record ID = 1 items had an error.  \nPlease note what was done and see administrator for help.  \n");
                    Error_Logging el = new Error_Logging("Export (Adams) process for record ID = 1 items had an error. \n" + e);
                    return false;
                }

            //do combining here
            CombineMixedBoxesOnPallets CombinedBoxes = new CombineMixedBoxesOnPallets(Data2Export, ImportSettings, "Adams");
            CombinedBoxes.CombineMixedPallets();
            CombinedBoxes.ViewData();
            Data2Export = CombinedBoxes.CombinedData();


             try
            {
                //Record ID = 2 items.  Puts them on the RecordsToExportTwo list.   ***************
                RecordsToExportIDTwo.Clear();
                TotalBoxCount = 0;
                BoxCount = 0;
                 
                for (int ExportDataRow = 0; ExportDataRow < Data2Export.Tables[0].Rows.Count; ExportDataRow++)
                {
                    tempString = "";
                    exportLineString = new StringBuilder();  //Start with as fresh stingbulder

                    exportLineString.AppendFormat("{0,1}", "2");  //Record ID = 2
                    //add prefix number to front of tag/pallet number.
                    if (ImportSettings.PalletPrefixColumn == ImportSettings.TagNumberColumn)
                    {
                        palletnumber = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim();
                    }
                    else
                    {
                        palletnumber = exportStringList[10].ToString() +
                            Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim()).ToString("0000000");
                    }
                    exportLineString.AppendFormat("{0,-10}", palletnumber);  //add pallet Number
                    exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim(), 4));  //add Variety ID
                    exportLineString.AppendFormat("{0,-3}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.LabelColumn].ToString().Trim(),3));  //add Label ID
                    exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.PackCodeColumn].ToString().Trim(), 4));  //add Pack Code
                    //exportLineString.AppendFormat("{0,-14}", "");  //Blank spaces   If spec is followed use this instead of the code below
                    //******added to match Export spreadsheet results
                    if ((TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.VarietyColumn].ToString().Trim(), 1) != "G") &
                        (Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim().Length < 4 ))
                    {                                                                                       
                        exportLineString.AppendFormat("{0,4}", Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim());  //add Grade ID
                    }
                    else
                    {
                        exportLineString.AppendFormat("{0,-4}", Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString().Trim());  //add Grade ID
                    }
                    Dt = DateTime.Parse(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.FirstPackDateColumn].ToString(), mFomatter);
                    exportLineString.AppendFormat("{0,-6}", Dt.ToString("yyMMdd"));  //add Pack Date
                    exportLineString.AppendFormat("{0,-4}", Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GrowerNumberColumn].ToString().Trim());  //add Grower ID
                    //*******

                        BoxCount = Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString().Trim());
                    exportLineString.AppendFormat("{0,-6}", BoxCount.ToString("000000"));  //Box Count
                      //keep running total
                    TotalBoxCount = TotalBoxCount + Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.InventoryQuantityColumn]); 

                    exportLineString.AppendFormat("{0,1}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.HatchColumn].ToString().Trim(),1));  //add Hatch
                    exportLineString.AppendFormat("{0,1}", "-");  //add -
                    exportLineString.AppendFormat("{0,1}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim(),1));  //add Deck
                    exportLineString.AppendFormat("{0,-9}", "");  //add blanks
                    exportLineString.AppendFormat("{0,1}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.FumigatedColumn].ToString().Trim(),1));  //Fumigation
                    exportLineString.AppendFormat("{0,-4}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow]
                                                                                [ImportSettings.BillOfLadingColumn].ToString(), 4).Trim());  //add B/L Number
                    if (Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.PalletTypeColumn].ToString().Trim() == "Chep")
                    {
                        tempString = "C";
                    }
                    else
                    {
                        tempString = "";
                    }
                    exportLineString.AppendFormat("{0,1}", tempString);  //add pallet type, "C" for chep and blank otherwise
                    exportLineString.AppendFormat("{0,-10}", TruncateString.Truncate2(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.MemoColumn].ToString().Trim(), 10));

                                       
                    RecordsToExportIDTwo.Add(exportLineString.ToString());  //add record to record list to send to file
                }
            }

            catch (Exception e)
            {
                exported = false;
                MessageBox.Show("Export process for record ID = 2 items had an error.  \nPlease note what was done and see administrator for help.  \n");
                Error_Logging el = new Error_Logging("Export (Adams) process for record ID = 2 items had an error. \n" + e);
                
                return false;
            }
                                                                                      // **********

             try
             {
                 //Merge RecordsToExportIDOne and RecordsToExportIDTwo in proper order for export file
                 tempString = ""; //initialize tempString to blank/empty
                 tempRowID = ""; //set tempRowID to empty string as there have been no rows checked yet
                 int lastsameItem = 0;
                 int lastsameItem2 = 0;

                 for (int ItemOne = 0; ItemOne < RecordsToExportIDOne.Count; ItemOne++)
                 {

                     if (string.IsNullOrEmpty(tempRowID) & !(string.IsNullOrEmpty(RecordsToExportIDOne[ItemOne])))  //add first record from RecordsToExportOne to 
                     //records to export as this would be the next record and is a special case
                     {
                         RecordsToExport.Add(RecordsToExportIDOne[0]);
                         //record which should be in the list
                         tempRowID = RecordsToExportIDOne[ItemOne].Substring(1, 14);
                     }
                     for (int nextItem = lastsameItem; nextItem < RecordsToExportIDOne.Count; nextItem++)  //add item 1 records that have the same row ID
                         if ((RecordsToExportIDOne[nextItem].Substring(1, 14) == tempRowID) & nextItem != 0)
                         {
                             RecordsToExport.Add(RecordsToExportIDOne[nextItem]);
                             lastsameItem = nextItem;
                             tempRowID = RecordsToExportIDOne[lastsameItem].Substring(1, 14);
                             ItemOne = nextItem;  //start at the next item in the list as others have now been checked
                         }

                     for (int nextItem2 = lastsameItem2; nextItem2 < RecordsToExportIDTwo.Count; nextItem2++)  //next add the item 2 record
                     {
                         if ((RecordsToExportIDTwo[nextItem2].Substring(1, 14) == tempRowID))
                         {
                             RecordsToExport.Add(RecordsToExportIDTwo[nextItem2]);
                             lastsameItem2 = nextItem2;  //fount the item on list and set it as the last found item

                         }
                     }
                     if (lastsameItem + 1 < RecordsToExportIDOne.Count)  //set the tempRowID to the next value unless it is the last item
                     {
                         tempRowID = RecordsToExportIDOne[lastsameItem + 1].Substring(1, 14);
                     }
                 }
             }

             catch (Exception e)
             {
                 exported = false;
                 MessageBox.Show(" Error in ordering Export records for export.  \nPlease note what was done and see administrator for help. \n");
                 Error_Logging el = new Error_Logging(" Error in ordering Export (Adams) records for export.  \n" + e);
                 
                 return false;
             }

            
             try
             {
                 //Record ID 3 item  Overall summary record
                 exportLineString = new StringBuilder();
                 exportLineString.AppendFormat("{0,1}", "3");  //add Record ID
                 exportLineString.AppendFormat("{0,-35}", "");  //add blanks
                 exportLineString.AppendFormat("{0,6}", TotalBoxCount.ToString("000000"));  //add grand total count for boxes

                 RecordsToExport.Add(exportLineString.ToString());  //add record to record list to send to file
                 exported = true;
             }

             catch (Exception e)
             {
                 exported = false;
                 MessageBox.Show("Export process for record ID = 3 item had an error.  \nPlease note what was done and see administrator for help.  \n");
                 Error_Logging el = new Error_Logging("Export (Adams) process for record ID = 3 item had an error.  \n" + e);
      
                 return false;
             }


            return exported;  //let progrom know it completed
        }
        
        public List<string> ExportList()  //Gets the export line list
        {
            if (exported)  //if export succeeded return the list of records to export
            {
                return RecordsToExport;
            }
            else  //if export method has not run yet or had an error, clear the records list and put an error message in it to return
            {
                RecordsToExport.Clear();
                RecordsToExport.Add("Export method has not run yet or had an error.");
                return RecordsToExport;
            }
        }

        public bool ExportConversionSucceeded()  //check to see if export was successful.
        {
            return exported;
        }

    }
}
