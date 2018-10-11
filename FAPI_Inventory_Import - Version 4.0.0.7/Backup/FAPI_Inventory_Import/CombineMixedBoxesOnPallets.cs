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
    //combines the data for mixed pallets and uses the data for the highes box count as the data for the pallet
    class CombineMixedBoxesOnPallets
    {
        DataSet WorkingDataSet = new DataSet();  //working dataset
        ImportTemplateSettings TemplateSettings = new ImportTemplateSettings();  //application import settings
        DataTable CommodityTable;
        string FormName;  //used in the view form title to show what export is being combined
        bool CombiningSuccessful = false;

        public CombineMixedBoxesOnPallets (DataSet ds, ImportTemplateSettings ts, string name)
        {     
            WorkingDataSet = ds;  //dataset frpm import spreadsheet
            TemplateSettings = ts;   //Import template settings
            FormName = name;

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
                MessageBox.Show("There was an error while trying to load the Commodity data for the combining.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load theCommodity data. \n" + e);
                ds.Dispose();
                return;
            }

        }


        public bool CombineMixedPallets()   //Method to combine mixed pallet information into one entry record
        {
            DataSet TempDataSet = WorkingDataSet.Clone();  //temporary working dataset to add records to
            List<int> SkipRow = new List<int>();  //used to keep a list of duplicate records so they are not checked again or entered twice
            DataRow[] CommodityValidateRows = CommodityTable.Select("Data_Column_Name = 'Commodity'");  //get all rows for Commodity from validation table;

            int MaxBoxCount = 0;  //Highest number of boxes in a set of duplicate pallet numbers
            
                
            //Now iterate through each record of the dataset to check for duplicate pallet numbers and add records to the temporary
            //dataset or add summary record to it.
            try
            {
                string MaxFruitSize = "";  //Largest size for stone fruit
                for (int CurrentRow = TemplateSettings.TagNumberRow; CurrentRow < WorkingDataSet.Tables[0].Rows.Count; CurrentRow++)
                {
                    int BoxCount = 0;  //Running total of boxes for duplicates pallet numbers
                    MaxFruitSize = WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.GradeColumn].ToString();  //Current size number for stone fruit
                    bool IsStoneFruit = false;

                    DataSet tempWorkingDataSet = new DataSet();  //Dataset which will contain the summarized data
                    DataRow TempDataRow = WorkingDataSet.Tables[0].Rows[CurrentRow];  //this will be current row when added to the tempDataSet
                    // or the summary row if there are multiple pallet numbers

                    if (!(SkipRow.Contains(CurrentRow)))  //Do not reset the MaxBoxCount if it is a duplicate pallet number as this 
                    //holds the highest box count for dups
                    {
                        MaxBoxCount = 0;
                        MaxFruitSize = WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.GradeColumn].ToString();
                    }

                    //add current box count to BoxCount
                    BoxCount = BoxCount + Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.InventoryQuantityColumn]);

                    //Iterate through remaining rows to check for duplicates and add any found rows that have the same pallet number to the
                    //SkipRow list to use when updating dataset
                    for (int CurrentTempRow = (CurrentRow + 1); CurrentTempRow < WorkingDataSet.Tables[0].Rows.Count; CurrentTempRow++)
                    {
                        foreach (DataRow Commodityrow in CommodityValidateRows)
                            if (WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.CommodityColumn].ToString() == Commodityrow[2].ToString() && Commodityrow[3].ToString() == "Stone Fruit")
                            {
                                IsStoneFruit = true;  //If stone fruit and Grade, set passed to true as grade is not validated
                            }
                        //Check for dup
                        if (WorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.TagNumberColumn].ToString().Trim() ==
                            WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.TagNumberColumn].ToString().Trim())  //case where there is a dup pallet number
                        {
                            SkipRow.Add(CurrentTempRow);  //skip duplicate rows
                            //TempDataRow[TemplateSettings.MemoColumn] = "MX";  //add MX to the memo field for duplicate pallet numbers
                        
                            //Get max fruit size for stone fruit
                            if ((MaxFruitSize.CompareTo(WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.GradeColumn].ToString()) < 0 )  &&
                                        (IsStoneFruit))  //
                            {
                                MaxFruitSize = WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.GradeColumn].ToString();

                                 TempDataRow = WorkingDataSet.Tables[0].Rows[CurrentTempRow];
                                 if (!SkipRow.Contains(CurrentTempRow)) //don't use if already checked
                                 {
                                     TempDataRow = WorkingDataSet.Tables[0].Rows[CurrentTempRow];

                                 }
                                 
                            }
                            
                            //check to see if the current records box count/quantity is greater than the others that have already been
                            // checked with the same pallet number
                            if ((MaxBoxCount < Convert.ToInt32(WorkingDataSet.Tables[0].Rows[CurrentTempRow][TemplateSettings.InventoryQuantityColumn]))   &&
                                        !(IsStoneFruit))
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

                    if (IsStoneFruit)
                    {
                        TempDataRow[TemplateSettings.GradeColumn] = MaxFruitSize;  //put total box count in boxes/quantity field
                    }


                    if (!(SkipRow.Contains(CurrentRow)))  //if not already checked add to dataset
                    {
                        TempDataSet.Tables[0].ImportRow(TempDataRow);  //add tempDataRow to the temporary dataset only if is not duplicate pallet number
                    }

                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error while combining mixed pallets.  \n Note what you were doing and contact administrator for help or see error log for more details.  \n");
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
            //Popup a window that shows combined data
            CombinedMixedBoxesDataViewForm CombinedDataView = new CombinedMixedBoxesDataViewForm();
            CombinedDataView.ViewData(WorkingDataSet);
            CombinedDataView.Text = FormName +  " combined data for export...";
            CombinedDataView.ShowDialog();
            CombinedDataView.Dispose();

            return true;

        }

        
    }  //end of class
}  //end of namespace
