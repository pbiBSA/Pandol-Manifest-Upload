using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FAPI_Inventory_Import
{
    class DataTranslatorByGrower
    {
        private DataSet Data2Translate { get; set; }  //dataset which contains the data to translate
        private ImportTemplateSettings TemplateSettings { get; set; }  //ImportTemplate settings for data
        private DataTable TranslationTable;  //Translation table data, of what translates to what
        //private DataTable GrowerBlockTable;  //Grower lookup table
        //int TranslateFromWhat = 1;  // use 1 if it is the description and 2 if it is for the value
        //int Translate2What = 2;  // use 1 if it is the description and 2 if it is for the value
        //int ExportValueColulmn = 3;  //The column which contains the Export value for the field being translated.
        //int StyleValueColumn = 4;  //The column which contains the style value for the field being translated.
        //int SizeValueColumn = 5;  //The column which contains the size value for the field being translated.
        List<string> exportStringList = new List<string>();  //contains data from dropdowns and datepicker to be exported
        private DataTable GrowerBlockTable;  //Grower lookup table
        string GrowerID;
        string GCVInfoTable;
        string Commodity;
        string GrowerCommodity;
        string Variety;
        string GrowerVariety;
        string StoneFruit;
        string GCV_ID;
        string TagNumber;
        string Prefix;
        //string GrowerBlock;
        string TranslationDetailsTable;
        //bool missingCommodity = false;
        bool missingVariety = false;
        bool missingStyle = false;
        bool missingSize = false;
        bool missingPackcode = false;
        bool missingLabel = false;
        bool missingGrade = false;
        bool missingPalletType = false;
       // bool Completed = false;  //did the translation complete?
        StringBuilder notTranslatedError = new StringBuilder();  //list to hold the name of fields that did not translate

        public DataTranslatorByGrower (DataSet ds, ImportTemplateSettings ImportSettings, List<String> tl, string gi, string pf) 
        {

                Data2Translate = ds;
                TemplateSettings = ImportSettings;
                Prefix = pf;
                GrowerID = gi;
               // Completed = false;  //Did tranlation complete?  Not yet.

                if (Properties.Settings.Default.Mode == "Test")
                {
                    GCVInfoTable = "GCV_Information_Test2";
                    TranslationDetailsTable = "Translation_Details_Test2";
                }
                else
                {
                    GCVInfoTable = "GCV_Information2";
                    TranslationDetailsTable = "Translation_Details2";
                }


                /*  Location in datarow of data to translate.
                * Grower_ID - 0, 
                * Grower_Name - 1, 
                * Grower_Commodity_Code - 2, 
                * Commodity_Code - 3, 
                * Commodity - 4, 
                * Grower_Variety_Code - 5,
                * Variety_Code - 6, 
                * Variety - 7, 
                * Stone_Fruit - 8,
                * GCV_Code - 9, 
                * Grower_Style_Code - 10,
                * Famous_Style_Code - 11, 
                * Grower_Size_Code - 12, 
                * Famous_Size_Code - 13, 
                * Grower_Pack_Code - 14, 
                * Famous_Pack_Code - 15, 
                * Adams_Pack_Code - 16, 
                * Grower_Label_Code - 17, 
                * Famous_Label_Code - 18, 
                * Adams_Label_Code - 19, 
                * Grower_Grade_Code - 20, 
                * Famous_Grade_Code - 21, 
                * Adams_Grade_Code - 22, 
                * Grower_Pallet_Type - 23, 
                * Famous_Pallet_Type - 24, 
                * Adams_Pallet_Type - 25
             
                */


                try 
            {
                    //get Translation data from database
                    string connString = Properties.Settings.Default.ConnectionString;
                    string query =
                        "SELECT Grower_ID, Grower_Name, Grower_Commodity_Code, Commodity_Code, Commodity, Grower_Variety_Code, " +
                        "Variety_Code, Variety, Stone_Fruit, "  + GCVInfoTable.ToString() + ".GCV_Code, Grower_Style_Code, " +
                            "Famous_Style_Code, Grower_Size_Code, Famous_Size_Code, Grower_Pack_Code, " +
                            "Famous_Pack_Code, Adams_Pack_Code, Grower_Label_Code, Famous_Label_Code, " +
                            "Adams_Label_Code, Grower_Grade_Code, Famous_Grade_Code, " +
                            "Adams_Grade_Code, Grower_Pallet_Type, Famous_Pallet_Type, " +
                            "Adams_Pallet_Type " +
                        "FROM " + GCVInfoTable.ToString() + " INNER JOIN " + TranslationDetailsTable.ToString() +
                            " ON " + GCVInfoTable.ToString() + ".GCV_Code = " + TranslationDetailsTable.ToString() + ".GCV_Code " +
                         "WHERE " + GCVInfoTable.ToString() + ".Grower_ID = " + GrowerID.ToString(); // Form translation table for grower;

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                    conn.Open();

                    DataSet translationDataSet = new DataSet();
                    // create data adapter
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    // this will query the database and return the result to the datatable
                    da.Fill(translationDataSet);
                    conn.Close();
                    da.Dispose();
                    TranslationTable = translationDataSet.Tables[0];  //set the translation table
                    translationDataSet.Dispose();
                }

                catch (Exception e)
                {
                    MessageBox.Show("There was an error while trying to create and load the translation data.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to create and load translation data. \n" + e);
                    ds.Dispose();
                    return;
                }

        }

        public DataSet TranslateData()  //Method to translate the data in the Data2ToTranslate dataset
        {
            DataRow GrowerBlockRow;
            DataSet dsgb = new DataSet();  //temp dataset for grower block table
           // Completed = false;
           // bool styleSizeAdded = false;
            bool bmissingVariety = false;
            StringBuilder notTranslatedError = new StringBuilder();


            //***************************
            try
            {
                //get Grower Block table data from database for the selected grower
                string connString = Properties.Settings.Default.ApplicationSettingsConnectionString;
                string query = "SELECT [ID] " +
                         ",[Famous_Grower_Block_Data].[NAME] " +
                         ",[Famous_Grower_Block_Data].[GROWERNAMEIDX]" +
                         ",Famous_Variety_Data.[VARIETYIDX] " +
                         ",Famous_Variety_Data.NAME AS 'VarietyCode'" +
                         "FROM [Famous_Grower_Block_Data], Famous_Variety_Data " +
                         "WHERE [Famous_Grower_Block_Data].VARIETYIDX = " +
                         "[Famous_Variety_Data].VARIETYIDX " +
                         "AND GROWERNAMEIDX = '" + GrowerID.ToString() + "'";

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // create data adapter for the grower block data
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query the database and return the result to the datatable
                da.Fill(dsgb);
                conn.Close();
                da.Dispose();
                GrowerBlockTable = dsgb.Tables[0];  //set the Grower Block table
                //ds.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show("There was an error while trying to load the Grower Block table.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Grower Block table.  \n" + e);
               // ds.Dispose();
               // Completed = false;
                return Data2Translate;
            }

            
            //Check to see if style and size columns needed to be added  ********
            string binary = Convert.ToString(TemplateSettings.Custom_1, 2);
            char[] AddCustomColumn = binary.ToCharArray();
            Array.Reverse(AddCustomColumn);

            if (AddCustomColumn.Length > 0)
            {
                if (AddCustomColumn[0] == '1')  //for add style-size column
                {
                   // styleSizeAdded = true;
                }
            }

            if (Data2Translate.Tables.Count == 0)
            {
                MessageBox.Show("There is no data to translate, please import a data file.");
                return Data2Translate;
            }

           //***************************
            //  Add code to check if field is already translated.

            //Translate fields
            foreach (DataRow row in Data2Translate.Tables[0].Rows)  //go through data table and translate
            {

                try
                {
                    // Translate Commodity
                    if (String.IsNullOrEmpty(row[TemplateSettings.CommodityColumn].ToString()))  //Check to see if commodity is empty, if so set it by variety
                    {
                        //if (row[TemplateSettings.CommodityColumn] != TranslationTable.Select("Grower_Variety_Code = '" + row[TemplateSettings.VarietyColumn] + "'")[0][3])
                        if (!String.IsNullOrEmpty(TranslationTable.Select("Grower_Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString()) + "'")[0][3].ToString().Trim()))
                        {
                            row[TemplateSettings.CommodityColumn] =  TranslationTable.Select("Grower_Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim()) + "'")[0][3];
                            GrowerCommodity = UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString().Trim());  //Set the commodity variable to the current commodity
                        }
                    }
                    else
                    {
                        GrowerCommodity = UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString().Trim());  //Set the commodity variable to the current commodity
                        if (TranslationTable.Select("Commodity_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString()) + "'").Count() == 0) //Is it not already translated
                        {
                            if (row[TemplateSettings.CommodityColumn] != TranslationTable.Select("Grower_Commodity_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString().Trim()) + "'")[0][3])
                            {
                                //Translate Commodity
                                GrowerCommodity = UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString().Trim());  //Reset commodity variable to updated value.
                                row[TemplateSettings.CommodityColumn] = TranslationTable.Select("Grower_Commodity_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.CommodityColumn].ToString().Trim()) + "'")[0][3];
                                
                            }
                        }
                    }

                    Commodity = row[TemplateSettings.CommodityColumn].ToString();

                    //Translate Variety
                    if (TranslationTable.Select("Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString()) + "'").Count() == 0)  //Is variety not translated
                    {
                        //   if (row[TemplateSettings.VarietyColumn] != TranslationTable.Select("Grower_Variety_Code = '" + row[TemplateSettings.VarietyColumn] + "'")[0][6])
                        if (TranslationTable.Select("Grower_Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim()) + "'").Count() != 0)
                        {
                            //Translate variety
                            GrowerVariety = UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim());
                            row[TemplateSettings.VarietyColumn] = TranslationTable.Select("Grower_Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim()) + "'")[0][6];

                        }
                    }
                    else
                    {
                        GrowerVariety = UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim());
                    }
                    


                    Variety = row[TemplateSettings.VarietyColumn].ToString().Trim();

                    StoneFruit = TranslationTable.Select("Variety_Code = '" + UppercaseWords.Uppercase(row[TemplateSettings.VarietyColumn].ToString().Trim()) + "'")[0][8].ToString();

                    GCV_ID = GrowerID.ToString() + "-" + row[TemplateSettings.CommodityColumn].ToString().Trim() + 
                        "-" + GrowerCommodity +
                        "-" + row[TemplateSettings.VarietyColumn].ToString().Trim() +
                        "-" + GrowerVariety;
                }

                catch (Exception e)
                {
                    MessageBox.Show("There was an error while trying to Translate Commodity and Variety.  \n" +
                        "For the " + Commodity + "commodity and/or the " + Variety +
                        " Variety.  \n" + " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to Translate Commodity and Variety. \n" + e);
                   
                    return Data2Translate; //paritial translated data set
                }

                // Translate remaing details
                // Style translation
                try
                {
                    if (row[TemplateSettings.StyleColumn].ToString().Length > 0)  // is there a style in exporter data
                    {   
                        if (TranslationTable.Select("Famous_Style_Code = '" + row[TemplateSettings.StyleColumn] + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() == 0)  //Is style not translated, not found in translation table.
                        {
                            if (TranslationTable.Select("Grower_Style_Code = '" + row[TemplateSettings.StyleColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'").Count() != 0)  // Grower style in translation table
                            {
                                row[TemplateSettings.StyleColumn] = TranslationTable.Select("Grower_Style_Code = '" + row[TemplateSettings.StyleColumn].ToString().Trim().ToUpper() + "' AND " +
                                       "GCV_Code = '" + GCV_ID + "'")[0][11];  //translate style
                            }
                            else
                            {
                                missingStyle = true;
                            }
                        }
                    }
                    else if (row[TemplateSettings.PackCodeColumn].ToString().Length > 0)  // No style in grower sheet so use packcode if present
                    {
                        if (TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() != 0)  // Grower packcode found in translation table
                        {
                            row[TemplateSettings.StyleColumn] = TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'")[0][11];  // get style from packcode
                        }
                        else
                        {
                            missingStyle = true;
                        }
                    }
                    else
                    {
                        missingStyle = true;
                    }

                    // Size translation
                    if (row[TemplateSettings.SizeColumn].ToString().Length > 0)  // is there a grower size in exporter data
                    {
                        if (TranslationTable.Select("Famous_Size_Code = '" + row[TemplateSettings.SizeColumn] + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() == 0) // is the size not found in translation table for famous code
                        {
                            if (TranslationTable.Select("Grower_Size_Code = '" + row[TemplateSettings.SizeColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'").Count() != 0)  // Grower size code found in translation table
                            {
                                row[TemplateSettings.SizeColumn] = TranslationTable.Select("Grower_Size_Code = '" + row[TemplateSettings.SizeColumn].ToString().Trim().ToUpper() + "' AND " +
                                       "GCV_Code = '" + GCV_ID + "'")[0][13]; // translate
                            }
                            else
                            {
                                missingSize = true;
                            }
                        }
                    }
                    else if (row[TemplateSettings.PackCodeColumn].ToString().Length > 0) //else is there a packcode to use
                    {
                        if (TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() != 0)  // Is the grower packcode found in translation table.
                        {
                            row[TemplateSettings.SizeColumn] = TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'")[0][13];  // Translate
                        }
                        else
                        {
                            missingSize = true;
                        }
                    }
                    else
                    {
                        missingSize = true;
                    }

                    // Packcode translation
                    if (row[TemplateSettings.PackCodeColumn].ToString().Length > 0)  // Is there a packcode in the exporter data
                    {
                        if (TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() != 0) // Is the grower packcode found in the translation table
                        {
                            row[TemplateSettings.PackCodeColumn] = TranslationTable.Select("Grower_Pack_Code = '" + row[TemplateSettings.PackCodeColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'")[0][15];  // Translate
                        }
                        else
                        {
                            missingPackcode = true;
                        }
                    }
                    else if (row[TemplateSettings.PackCodeColumn].ToString().Length == 0)  // if grower packcode not found in exporter data
                    {    // Can it be found by style and size
                        if (TranslationTable.Select("Grower_Style_Code = '" + row[TemplateSettings.StyleColumn].ToString().Trim().ToUpper() + "' AND " +
                                "Grower_Size_Code = '" + row[TemplateSettings.SizeColumn].ToString().Trim().ToUpper() + "' AND " + "GCV_Code = '" + GCV_ID + "'").Count() != 0)  
                        {
                            row[TemplateSettings.PackCodeColumn] = TranslationTable.Select("Grower_Style_Code = '" + row[TemplateSettings.StyleColumn].ToString().Trim().ToUpper() + "' AND " +
                                    "Grower_Size_Code = '" + row[TemplateSettings.SizeColumn].ToString().Trim().ToUpper() + "' AND " + "GCV_Code = '" + GCV_ID + "'")[0][15];  // Translate
                        }
                        else
                        {
                            missingPackcode = true;
                        }
                    }
                    else
                    {
                        missingPackcode = true;
                    }

                    // Label Translation
                    if (row[TemplateSettings.LabelColumn].ToString().Length > 0)  //Is grower label code found in exporter data
                    {
                       
                            if (TranslationTable.Select("Grower_Label_Code = '" +
                                   UppercaseWords.Uppercase(row[TemplateSettings.LabelColumn].ToString().Replace("'", "''").Trim()) + "' AND " +
                                    "GCV_Code = '" + GCV_ID + "'").Count() != 0)  //Grower label code found in translation table
                            {
                                row[TemplateSettings.LabelColumn] = TranslationTable.Select("Grower_Label_Code = '" +
                                        UppercaseWords.Uppercase(row[TemplateSettings.LabelColumn].ToString().Replace("'", "''").Trim()) + "' AND " +
                                        "GCV_Code = '" + GCV_ID + "'")[0][18];  // Translate
                            }
                            else
                            {
                                missingLabel = true;
                            }
                        
                    }
                    else
                    {
                        missingLabel = true;
                    }

                    // Grade Translation if it not a stone fruit
                    if (row[TemplateSettings.GradeColumn].ToString().Length > 0 & StoneFruit == "N")  // is there a grower grade and is it not a stone fruit (or berry)
                    {
                        if (TranslationTable.Select("Famous_Grade_Code = '" + row[TemplateSettings.GradeColumn].ToString().Trim() + "' AND " +
                               "GCV_Code = '" + GCV_ID + "'").Count() == 0)  // Is the grower grade not a Famous grade code
                        {
                            if (TranslationTable.Select("Grower_Grade_Code = '" + row[TemplateSettings.GradeColumn].ToString().Trim().ToUpper() + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'").Count() != 0) // Is the grower grade code found in the translation table.
                            {
                                row[TemplateSettings.GradeColumn] = TranslationTable.Select("Grower_Grade_Code = '" + row[TemplateSettings.GradeColumn].ToString().Trim().ToUpper() + "' AND " +
                                       "GCV_Code = '" + GCV_ID + "'")[0][21];  // Translate
                            }                           else
                            {
                                missingGrade = true;
                            }
                        }
                    }
                    else if (StoneFruit == "Y")
                    {
                        missingGrade = false;
                    }
                    else
                    {
                        missingGrade = true;
                    }


                    // Pallet Type Translation
                    if (row[TemplateSettings.PalletTypeColumn].ToString().Length > 0)  // Is the pallet type in the exporter data
                    {
                        
                            if (TranslationTable.Select("Grower_Pallet_Type = '" + UppercaseWords.Uppercase(row[TemplateSettings.PalletTypeColumn].ToString().Trim()) + "' AND " +
                                   "GCV_Code = '" + GCV_ID + "'").Count() != 0)  //  Is the grower pallet type found in the translation table
                            {
                                row[TemplateSettings.PalletTypeColumn] = TranslationTable.Select("Grower_Pallet_Type = '" + UppercaseWords.Uppercase(row[TemplateSettings.PalletTypeColumn].ToString().Trim()) + "' AND " +
                                       "GCV_Code = '" + GCV_ID + "'")[0][24];  // Translate
                            }
                            else
                            {
                                missingPalletType = true;
                            }
                        
                    }
                    else
                    {
                        missingPalletType = true;
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show("There was an error while trying to Translate details part of the translation.  \n" +
                       " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to translate details part of the translation. \n" + e);

                    return Data2Translate; //paritial translated data set
                }


                try
                {
                    //Get the GrowerBlock from the grower block table for the variety and set the growerblock field for the 
                    //Data row to the growerblock value.
                    if (GrowerBlockTable.Select("VarietyCode = '" + row[TemplateSettings.VarietyColumn].ToString().Trim() + "'").Length > 0)
                    {  //Check to see if the variety was found in the grower block data
                        GrowerBlockRow = GrowerBlockTable.Select("VarietyCode = '" + row[TemplateSettings.VarietyColumn].ToString().Trim() + "'")[0];
                        row[1] = GrowerBlockRow[0].ToString();
                    }
                    else
                    {
                        if (!bmissingVariety)  //only show message box for first occurance of missing variety in the grower block data.
                        {
                            MessageBox.Show("Variety code " + row[TemplateSettings.VarietyColumn].ToString() +
                                " is not in the Grower Block data for this grower.  ");
                        }
                        bmissingVariety = true;
                    }
                }

                catch (Exception e)
                {
                  //  Completed = false;
                    MessageBox.Show("Getting Grower Block process had an error.  Please note what was done and see administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("Getting Grower Block process had an error.  \n  " + e);
                }


                //fill in blank pack codes and convert fumigation codes.
                if (String.IsNullOrEmpty(row[TemplateSettings.PackCodeColumn].ToString()))
                {
                    //Create a pack code from existing style and size with a space between them
                    row[TemplateSettings.PackCodeColumn] = row[TemplateSettings.StyleColumn].ToString().Trim() + " " +
                        row[TemplateSettings.SizeColumn].ToString().Trim();
                }

                if (String.IsNullOrEmpty(row[TemplateSettings.FumigatedColumn].ToString()))  //Fumigation code translation
                {
                    row[TemplateSettings.FumigatedColumn] = 0;
                }
                if ((row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "FUMIGATED") ||
                    row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "Y")
                {
                    row[TemplateSettings.FumigatedColumn] = 1;
                }
                if ((row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "NON FUMIGATED") ||
                row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "N")
                {
                    row[TemplateSettings.FumigatedColumn] = 0;
                }

                if (TemplateSettings.PalletPrefixColumn == TemplateSettings.TagNumberColumn)  //special case for which has prefix as part of tag number already
                {                                                                         //and the import setting point to same column for both
                    TagNumber = row[TemplateSettings.TagNumberColumn].ToString().Trim();
                }
                else
                {
                    TagNumber = row[TemplateSettings.TagNumberColumn].ToString().Trim(); //set tag number to the data tag number
                    if (TagNumber.Length > 3)  //if is less than 4, it can not contain a prefix and a tag number in one
                    {
                        if (!(Prefix == (row[TemplateSettings.TagNumberColumn].ToString().Trim().Substring(0, 3)))) //Prefix not in Tag Number
                        {
                            TagNumber = Prefix + row[TemplateSettings.TagNumberColumn].ToString().Trim();  //append prefix code
                            row[TemplateSettings.TagNumberColumn] = TagNumber;
                        }
                    }
                }

                
                
            }



                if (missingGrade)
                {
                    notTranslatedError.Append("Grade, ");  //add to not Translated list
                }
                if (missingLabel)
                {
                    notTranslatedError.Append("Label, ");  //add to not Translated list
                }
                if (missingPackcode)
                {
                    notTranslatedError.Append("Pack Code, ");  //add to not Translated list
                }
                if (missingPalletType)
                {
                   var result = MessageBox.Show("Pallet Type is missing, would you like to use HT Wood?", "Warning",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                   if (result == DialogResult.OK)
                   {
                       foreach (DataRow row in Data2Translate.Tables[0].Rows)  //go through data table and translate
                       {
                           row[TemplateSettings.PalletTypeColumn] = "HT Wood";

                       }
                   }
                   else
                   {
                       notTranslatedError.Append("Pallet Type, ");  //add to not Translated list
                   }


                }
                if (missingSize)
                {
                    notTranslatedError.Append("Size, ");  //add to not Translated list
                }
                if (missingStyle)
                {
                    notTranslatedError.Append("Style, ");  //add to not Translated list
                }
                if (missingVariety)
                {
                    notTranslatedError.Append("Variety, ");  //add to not Translated list
                }


                if (notTranslatedError.Length == 0)  //if it is 0 Then all have been translated
                    {
                        MessageBox.Show("Translation Succeded!");
                    }
                 else
                    {
                        MessageBox.Show("The following parameters could not be translated: " + notTranslatedError
                        + " check that all required paramaters are in manifest and that translation is setup correctly.");
                    }
           

           //Completed = true;
            return Data2Translate; //translated data set
        }

    }
}
