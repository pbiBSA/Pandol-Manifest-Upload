using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;
using Excel = Microsoft.Office.Interop.Excel;


namespace FAPI_Inventory_Import
{
    //exports data into a spreadsheet for Export
    class AdamsExportToExcel
    {
        bool exported = false;  //Has data been exported?
        DataSet Data2Export = new DataSet();  //holder of data to export
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //Holder of the import settings
        List<string> exportStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");
        DateTime Dt;  //used for date time manipulation
        int BoxCount = 0;
        string ExcelFileName;
        string tempString;

        public AdamsExportToExcel(DataSet ds, ImportTemplateSettings ImS, List<String> dl)
        {
            //set data
            Data2Export = ds.Copy();
            ImportSettings = ImS;
            exportStringList = dl;

            //do combining here
            CombineMixedBoxesOnPallets CombinedBoxes = new CombineMixedBoxesOnPallets(Data2Export, ImportSettings, "Adams");
            CombinedBoxes.CombineMixedPallets();
            CombinedBoxes.ViewData();
            Data2Export = CombinedBoxes.CombinedData();

            
            SaveFileDialog saveFileDialogSaveExportFile = new SaveFileDialog();  
            object misValue = System.Reflection.Missing.Value;
            string sExporter = exportStringList[11].ToString();
            string sVesselNumber = exportStringList[13].ToString();
            


            //Get export file name and path
            saveFileDialogSaveExportFile.InitialDirectory = Properties.Settings.Default.AdamsExportFilePath;  //get default path from settings
            saveFileDialogSaveExportFile.FileName = saveFileDialogSaveExportFile.FileName = TruncateString.Truncate2(sExporter, 4) + "_"
                    + sVesselNumber.ToString() + "_Export.xls";
            DialogResult result = saveFileDialogSaveExportFile.ShowDialog();


            if (saveFileDialogSaveExportFile.FileName != "")  //check if file name is blank
            {
                ExcelFileName = saveFileDialogSaveExportFile.FileName;
            }
            else  //use default path and name if one not selected
            {
                ExcelFileName = Properties.Settings.Default.AdamsExportFilePath + "\\Export_File.xls";
            }

            saveFileDialogSaveExportFile.Dispose();


            if (result == DialogResult.OK)  //only try to open excel file if open dialog <OK> button was clicked.
            {
              
                    Excel.ApplicationClass excelapp = new Excel.ApplicationClass();
                    excelapp.Visible = true;
                    excelapp.DisplayAlerts = false;  //don't display any dialog boxes or alerts from the excel app.


                    Excel._Workbook workbook = (Excel._Workbook)(excelapp.Workbooks.Add(Type.Missing));
                    Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;


                try
                  {
                    //Write top section labels
                    worksheet.Cells[1, 1] = "Exporter:";
                    worksheet.Cells[2, 1] = "Port:";
                    worksheet.Cells[3, 1] = "Vessel Name:";
                    worksheet.Cells[4, 1] = "Pandol Lot Number:";

                    worksheet.Cells[1, 8] = "Total Box Count:";

                    //Set headers of data section
                    worksheet.Cells[5, 1] = "\n\nPallet \nPrefix";
                    worksheet.Cells[5, 2] = "\n\nPallet\nNumber";
                    worksheet.Cells[5, 3] = "\n\n\nSpecies";
                    worksheet.Cells[5, 4] = "\n\n\nVariety";
                    worksheet.Cells[5, 5] = "\n\n\nLabel";
                    worksheet.Cells[5, 6] = "\nPack\nDescription";
                    worksheet.Cells[5, 7] = "Majority\nGrade\nSize";
                    worksheet.Cells[5, 8] = "\nMajority\nPack Date";
                    worksheet.Cells[5, 9] = "\nMajority\nProducer";
                    worksheet.Cells[5, 10] = "\nBox\nCount";
                    worksheet.Cells[5, 11] = "\n\n\nHatch";
                    worksheet.Cells[5, 12] = "\n\n\nDeck";
                    worksheet.Cells[5, 13] = "\nFumigation\nCode";
                    worksheet.Cells[5, 14] = "\n\n\nPallet Memo";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating Excel workbook for Export. \nContact the adminstrator for help and note what you just did.  \n" +
                        "See error log for more information.  \n");
                    Error_Logging el = new Error_Logging("Error creating Excel workbook for Export. \n" + ex);
                }

                try
                {

                    //Write exporter and shipping data in top section of spreadsheet
                    worksheet.Cells[1, 2] = exportStringList[11].ToString();  //Exporter Name
                    worksheet.Cells[2, 2] = exportStringList[15].ToString();  //Destination Port
                    worksheet.Cells[3, 2] = exportStringList[14].ToString();  //Vessel Name
                    worksheet.Cells[4, 2] = exportStringList[13].ToString();  //Pandol Lot Number
                }
                 catch(Exception ex)
                {
                    MessageBox.Show("Error writing top section of Excel workbook for Export. \nContact the adminstrator for help and note what you just did.  \n" +
                        "See error log for more information.  \n");
                    Error_Logging el = new Error_Logging("Error writing top section of Excel workbook for Export. \n" + ex);
                }


                    //write pallet data
                try
                {
                    int tempdataRow = 0;
                    BoxCount = 0;

                    for (int ExportDataRow = 0; ExportDataRow < Data2Export.Tables[0].Rows.Count; ExportDataRow++)
                    {
                        tempdataRow = ExportDataRow + 6; //start on row 6

                        if (exportStringList[10].ToString().Length < 1)  //check to see if prefix is blank
                        {
                            worksheet.Cells[tempdataRow, 1] =
                                Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim().Substring(0, 3);
                        }
                        else
                        {
                            worksheet.Cells[tempdataRow, 1] = exportStringList[10].ToString();  //Pallet Prefix
                        }

                        if (ImportSettings.PalletPrefixColumn == ImportSettings.TagNumberColumn || exportStringList[10].ToString().Length < 1)
                        {
                            tempString = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString().Trim();
                            worksheet.Cells[tempdataRow, 2] = tempString.Substring(3, tempString.Length - 3);  //Pallet Number
                        }
                        else
                        {
                            worksheet.Cells[tempdataRow, 2] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.TagNumberColumn].ToString();  //Pallet Number
                        }
                        worksheet.Cells[tempdataRow, 3] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.CommodityColumn].ToString();  //Species/Commodity
                        worksheet.Cells[tempdataRow, 4] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.VarietyColumn].ToString();  //Variety
                        worksheet.Cells[tempdataRow, 5] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.LabelColumn].ToString();  //Label
                        //Pack Description
                        worksheet.Cells[tempdataRow, 6] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.PackCodeColumn].ToString();  //Pack Code
                        worksheet.Cells[tempdataRow, 7] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GradeColumn].ToString();  //Majority Grade
                        Dt = DateTime.Parse(DateNumberToDateString.ConvertDateNumberToDateString(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.FirstPackDateColumn].ToString()), mFomatter);
                        worksheet.Cells[tempdataRow, 8] = Dt.ToString("MM/dd/yyyy");  //Pack Date
                        worksheet.Cells[tempdataRow, 9] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.GrowerNumberColumn].ToString();  //Producer

                        worksheet.Cells[tempdataRow, 10] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.InventoryQuantityColumn].ToString();  //Box Count

                        if (Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.HatchColumn].ToString().Trim() ==
                            Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim() &
                        Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim().Split('-').Length == 2 &
                            Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim().Length < 4)
                        {
                            worksheet.Cells[tempdataRow, 11] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.HatchColumn].ToString().Trim().Split('-')[0];  //Hatch
                            worksheet.Cells[tempdataRow, 12] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim().Split('-')[1];  //Deck
                        }
                        else
                        {
                            worksheet.Cells[tempdataRow, 11] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.HatchColumn].ToString().Trim();  //Hatch
                            worksheet.Cells[tempdataRow, 12] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.DeckColumn].ToString().Trim();  //Deck
                        }
                        worksheet.Cells[tempdataRow, 13] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.FumigatedColumn].ToString();  //Fumigation
                        worksheet.Cells[tempdataRow, 14] = Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.MemoColumn].ToString();  //Memo

                        BoxCount = BoxCount + Convert.ToInt32(Data2Export.Tables[0].Rows[ExportDataRow][ImportSettings.InventoryQuantityColumn]);  //get running total of boxes

                    }

                    worksheet.Cells[1, 10] = BoxCount;

                    

                    workbook.SaveAs(ExcelFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);

                    excelapp.UserControl = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing pallet data to Export Excel spreadsheet. \nContact the adminstrator for help and note what you just did.  \n" +
                        "See error log for more information.  \n");
                    Error_Logging el = new Error_Logging("Error writing pallet data to Export Excel spreadsheet. \n" + ex);
                }

                workbook.Close(true, misValue, misValue);
                excelapp.Quit();

                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelapp);

                exported = true;  //Happy export  :)
            }

        }

        private void releaseObject(object obj)  //Release the excel object and any connections and memmory
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing excel object \nPlease note what was done and contact administrator.  \n");
                Error_Logging el = new Error_Logging("Exception Occured while releasing excel object. \n" + ex);
                
            }



        }

        public bool WasExported()  //was the export successful?
        {
            return exported;
        }

        public string excelFileName()  //Get the export file name
        {
            return ExcelFileName;
        }
    }
}
