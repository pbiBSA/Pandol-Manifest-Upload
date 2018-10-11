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
using System.Data.SqlClient;


//This the validation class which validates the data in the dataset, Data2Validate.  It takes a dataset of the data from the imported data,
//an importTemplateSettings object (TemplateSettings) and a list of fields to validate.  
namespace FAPI_Inventory_Import
{
    class DataValidation
    {
        DataSet Data2Validate { get; set; }
        ImportTemplateSettings TemplateSettings { get; set; }
        DataTable ValidationTable;
        List<String> List2Validate = new List<string>();
        List<DataItemLocation> InvalidItemList = new List<DataItemLocation>(); 
        bool Passed;  //did it pass the validation? 
        DoesTagNumberExist TagNumberExist = new DoesTagNumberExist();
     

        int ValidateWhat = 2;  // use 1 if it is the description and 2 if it is for the value
                                  
        DataValidation()
        {           
            Passed = false;
            InvalidItemList.Clear();
         }

        public DataValidation(DataSet ds, ImportTemplateSettings  IS, List<String> lv)
            //this is the only constructor so it is important to us it correctly.
        {
            Data2Validate = ds;  //Data from the imported dataset
            TemplateSettings = IS;  //Settings from the template
            List2Validate = lv;   //List of fields to validate
            InvalidItemList.Clear();  //List of invalid data


            Cursor.Current = Cursors.WaitCursor;  //set the wait curser
            
            //Update Tag Number List
            try
            {
                string connString = Properties.Settings.Default.ConnectionString;
                SqlCommand Command = new SqlCommand();
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                conn.Open();

                Command.Connection = conn;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "RebuildTagNumberTable";   // Rebuild local list of famous tag numbers
               
                Command.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception exp)
            {
                MessageBox.Show("There was an error while trying to get Famous Tag Numbers.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to get Famous Tag Numbers. \n" + exp);
                Cursor.Current = Cursors.Default;
                return;
            }
           
            Passed = false;  //did not pass until it passes
            Cursor.Current = Cursors.Default;
        }

        public bool Validate()  //Validation routine
        {
            DataRow[] FoundValidateRows;
            DataRow[] CommodityValidateRows;
            Passed = false;
            int rownumber = 0;
            string sTempField;
            DataTable DatTable = new DataTable();
            DatTable = Data2Validate.Tables[0];

            DataSet ds = new DataSet();

            try
            {
                //get Validation data from database
                string connString = Properties.Settings.Default.ConnectionString;
                string query = "select [Data_Column_Name],[Description],[Value], [Custom_Value], [Famous_Validate], [Ignore] from Translation_Validation_Table"; // WHERE Famous_Validate = 1";

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();

                // create data adapter
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                // this will query the database and return the result to your datatable
                da.Fill(ds);
                conn.Close();
                da.Dispose();
                ValidationTable = ds.Tables[0];  //set the translation table
                ds.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show("There was an error while trying to load the Validation table.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Validation Table. \n" + e);
                ds.Dispose();
                return false;
            }


            try
            {
                //Validate values  generic routine  *************************************************************************
                //Takes the list of fields to evaluate and iterates through each of them.
                foreach (string sField in List2Validate)
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
                    //***                                                                                                        ***

                    FoundValidateRows = ValidationTable.Select("Data_Column_Name = " + "'" + sTempField + "'");  //get all rows for sField from validation table
                    CommodityValidateRows = ValidationTable.Select("Data_Column_Name = 'Commodity'");  //get all rows for Commodity from validation table


                    foreach (DataRow row in Data2Validate.Tables[0].Rows)  //interate through data rows and check the sField column
                    {
                        Passed = false;

                        foreach (DataRow validaterow in FoundValidateRows) //FoundValidateRows contains all the validation rows for sField
                        {
                            if (row[TemplateSettings.DataColumnLocation(sField).Column].ToString().Trim() == validaterow[ValidateWhat].ToString().Trim() &&
                                    validaterow[4].ToString() == "1") //Validate what tells
                            //it to check value or description in validate table
                            {
                                Passed = true;  //If found, set passed to true
                            }
                            else if (sField == "Grade")  //special case for grade.  Stone Fruit has no grade and should not be validated
                            {
                                foreach (DataRow Commodityrow in CommodityValidateRows)
                                    if (row[TemplateSettings.CommodityColumn].ToString().Trim() == Commodityrow[2].ToString() && Commodityrow[3].ToString() == "Stone Fruit")
                                    {
                                        Passed = true;  //If stone fruit and Grade, set passed to true as grade is not validated
                                    }
                            }

                            
                        }
                        if (!Passed)   //if it failed the validation add the location in the spreadsheet to the invalid list
                        {
                            if (rownumber >= TemplateSettings.DataColumnLocation(sField).Row)  //The sField row parm is the start row.
                            {
                                if (!((TemplateSettings.SizeColumn == TemplateSettings.StyleColumn) & (sField == "Style")))  //Skip for second cycle for case of Style_Size field
                                {                                                                                           // data as it will cycle for both size and style.
                                    InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.DataColumnLocation(sField).Column));  //add location of all failures to list.
                                }
                            }

                        }
                        if (InvalidItemList.Count() > 0)  //if there were any invalid entries, it did not pass
                        {
                            Passed = false;
                        }
                        rownumber++;
                    }
                }

                //Check for missing pack code, fumigation, hatch, deck values and duplicate Tag Numbers.
                rownumber = 0;
                foreach (DataRow row in Data2Validate.Tables[0].Rows)  //interate through data rows and validate other fields
                {
                    Passed = false;

                    if (String.IsNullOrEmpty(row[TemplateSettings.PackCodeColumn].ToString()))  //check for empty pack codes
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.PackCodeColumn));  //add location of failures to list.
                    }

                    if (String.IsNullOrEmpty(row[TemplateSettings.HatchColumn].ToString()))  //check for empty hatch
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.HatchColumn));  //add location of failures to list.
                        row[TemplateSettings.HatchColumn] = " ";
                    }

                    if (String.IsNullOrEmpty(row[TemplateSettings.DeckColumn].ToString()))  //check for empty Deck
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.DeckColumn));  //add location of failures to list.
                        row[TemplateSettings.DeckColumn] = " ";
                    }

                    if (row[TemplateSettings.TagNumberColumn].ToString().Trim().Length > 12 || row[TemplateSettings.TagNumberColumn].ToString().Trim().Length < 1)  //check for too long too short of tag numbers.
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.TagNumberColumn));  //add location of failures to list.
                    }

                    if (InvalidItemList.Count() > 0)  //if there were any invalid entries, it did not pass
                    {
                        Passed = false;
                    }
                    if (String.IsNullOrEmpty(row[TemplateSettings.FumigatedColumn].ToString()))  //check for empty fumigation
                    { 
                       InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.FumigatedColumn));  //add location of failures to list.
                    }
                    else
                        if (!(row[TemplateSettings.FumigatedColumn].ToString() == "1" || row[TemplateSettings.FumigatedColumn].ToString() == "0"))
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.FumigatedColumn));  //add location of failures to list.
                    }

                    //check Tag Numbers
                    if (TagNumberExist.TagNumberExist(row[TemplateSettings.TagNumberColumn].ToString().Trim()))
                    {
                        InvalidItemList.Add(new DataItemLocation(rownumber, TemplateSettings.TagNumberColumn));
                    }
                

                    rownumber++;
                }
                
            }

            catch (Exception e)
            {
                MessageBox.Show("Data Validation process had an error.  Please note what was done and see administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("Data Validation process had an error. \n" + e);
                return false;
            }

            if (InvalidItemList.Count() > 0)   //if there were any invalid entries, it did not pass
            {
                Passed = false;
            }
            else
            {
                Passed = true;
            }

                return Passed;
            
        }  //end of Validate Method

        public List<DataItemLocation> ListofInvalidItemLocations()  //gets the list of invalid data locations in the DataSet, Data2Validate.
        {
            if (Passed)  //If validation passed, make sure the invalid list is clear
                            //if it is requested
            {
                InvalidItemList.Clear();
            }
            return InvalidItemList;
        }
                  
    } //end of class
}  //end of namespace
