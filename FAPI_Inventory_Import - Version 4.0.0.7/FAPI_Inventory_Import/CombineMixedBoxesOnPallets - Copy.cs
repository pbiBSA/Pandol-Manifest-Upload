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
    class CombineMixedBoxesOnPallets
    {
        DataSet WorkingDataSet = new DataSet();  //working dataset
        ImportTemplateSettings TemplateSettings = new ImportTemplateSettings();  //application import settings
        string FormName;  //used in the view form title to show what export is being combined
        bool CombiningSuccessful = false;

        public CombineMixedBoxesOnPallets (DataSet ds, ImportTemplateSettings ts, string name)
        {     
            WorkingDataSet = ds;  //dataset frpm import spreadsheet
            TemplateSettings = ts;   //Import template settings
            FormName = name;
        }


        public bool CombineMixedPallets()   //Method to combine mixed pallet information into one entry record
        {
            DataSet TempDataSet = WorkingDataSet.Clone();  //temporary working dataset to add records to
            List<int> SkipRow = new List<int>();  //used to keep a list of duplicate records so they are not checked again or entered twice

            int MaxBoxCount = 0;  //Highest number of boxes in a set of duplicate pallet numbers
                
            //Now iterate through each record of the dataset to check for duplicate pallet numbers and add records to the temporary
            //dataset or add summary record to it.
            try
            {
                for (int CurrentRow = TemplateSettings.TagNumberRow; CurrentRow < WorkingDataSet.Tables[0].Rows.Count; CurrentRow++)
                {
                    int BoxCount = 0;  //Running total of boxes for duplicates pallet numbers

                    DataSet tempWorkingDataSet = new DataSet();  //Dataset which will contain the summarized data
                    DataRow TempDataRow = WorkingDataSet.Tables[0].Rows[CurrentRow];  //this will be current row when added to the tempDataSet
                    // or the summary row if there are multiple pallet numbers

                    if (!(SkipRow.Contains(CurrentRow)))  //Do not reset the MaxBoxCount if it is a duplicate pallet number as this 
                    //holds the highest box count for dups
                    {
                        MaxBoxCount = 0;
                    }

                    //add current box count to BoxCount
                    BoxCount = BoxCount + Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.InventoryQuantityColumn]);

                    //Iterate through remaining rows to check for duplicates and add any found rows that have the same pallet number to the
                    //SkipRow list to use when updating dataset
                    for (int CurrentTempRow = (CurrentRow + 1); CurrentTempRow < WorkingDataSet.Tables[0].Rows.Count; CurrentTempRow++)
                    {
                        //Check for dup
                        if (WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.TagNumberColumn].ToString() ==
                            WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.TagNumberColumn].ToString())  //case where there is a dup pallet number
                        {
                            SkipRow.Add(CurrentTempRow);  //slip duplicate rows
                            TempDataRow[TemplateSettings.MemoColumn] = "MX";  //add MX to the memo field for duplicate pallet numbers

                            //check to see if the current records box count/quantity is greater than the others that have already been
                            // checked with the same pallet number
                            if (MaxBoxCount < Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.InventoryQuantityColumn]))
                            {
                                MaxBoxCount = Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.InventoryQuantityColumn]);

                                if (!SkipRow.Contains(CurrentTempRow)) //don't use if already checked
                                {
                                    TempDataRow = WorkingDataSet.Tables[0].Rows[CurrentTempRow];

                                }
                            }

                            BoxCount = BoxCount + Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.InventoryQuantityColumn]);

                        }
                    }
                    TempDataRow[TemplateSettings.InventoryQuantityColumn] = BoxCount.ToString();  //put total box count in boxes/quantity field

                    if (!(SkipRow.Contains(CurrentRow)))  //if not already checked add to dataset
                    {
                        TempDataSet.Tables[0].ImportRow(TempDataRow);  //add tempDataRow to the temporary dataset only if is not duplicate pallet number
                    }

                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error while combining mixed pallets.  \n Note what you were doing and contact administrator for help.  \n" + e);
                Error_Logging el = new Error_Logging("Error while combining mixed pallets.  \n" + e);
            }

            WorkingDataSet = TempDataSet;

            CombiningSuccessful = true;
            return CombiningSuccessful;

        }  //end of CombineMixedPallets

        public bool Succeeded()
        {
            return CombiningSuccessful;
        }

        public DataSet CombinedData()  //returns the combined dataset.  If the combining has not taken place
        {                                   //it returns an empty dataset with the same structure and schema
            if (CombiningSuccessful)
            {
                return WorkingDataSet;
            }
            else
            {
                return WorkingDataSet.Clone();
            }

        }

        public bool ViewData()
        {
            //code goes here to popup a window that shows combined data
            CombinedMixedBoxesDataViewForm CombinedDataView = new CombinedMixedBoxesDataViewForm();


            CombinedDataView.ViewData(WorkingDataSet);
           
            CombinedDataView.Text = FormName +  " combined data for export...";
            CombinedDataView.ShowDialog();
            
            WorkingDataSet.AcceptChanges();
            CombinedDataView.Dispose();

            return true;

        }

        
    }  //end of class
}  //end of namespace
