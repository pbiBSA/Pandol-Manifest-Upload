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
    class DataTranslator 
    {
        private DataSet Data2Translate { get; set; }  //dataset which contains the data to translate
        private ImportTemplateSettings TemplateSettings { get; set; }  //ImportTemplate settings for data
        private DataTable TranslationTable;  //Translation table data, of what translates to what
        private List<String> List2Translate;  //list of fields to translate
        private DataTable GrowerBlockTable;  //Grower lookup table
        private DataTable CommodityTable;  //commodity table
        int TranslateFromWhat = 1;  // use 1 if it is the description and 2 if it is for the value
        int Translate2What = 2;  // use 1 if it is the description and 2 if it is for the value
        int AdamsValueColulmn = 3;  //The column which contains the Adams value for the field being translated.
        int StyleValueColumn = 4;  //The column which contains the style value for the field being translated.
        int SizeValueColumn = 5;  //The column which contains the size value for the field being translated.
        string GrowerBlock;
        bool Completed;  //did the translation complete?

        public DataTranslator (DataSet ds, ImportTemplateSettings ImportSettings, List<String> tl, string gb) 
        {

                Data2Translate = ds;
                TemplateSettings = ImportSettings;
                List2Translate = tl;
                GrowerBlock = gb;  
                Completed = false;  //Did tranlation complete?  Not yet.

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
                    MessageBox.Show("There was an error while trying to load the Commodity data for translation.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to load theCommodity data for translation. \n" + e);
                    ds.Dispose();
                    return;
                }

        }
            

        public DataSet TranslateData()  //Method to translate the data in the Data2ToTranslate dataset
        {
               int rownumber;
               DataRow[] FoundRows;
               DataRow GrowerBlockRow;
               DataRow CommodityRow;
               string sTempField;
               int tempColumn;
               DataSet ds = new DataSet();  //temp dataset for translation table
               DataSet dsgb = new DataSet();  //temp dataset for grower block table
               bool styleSizedAdded = false;
               bool bmissingVariety = false;
               DataRow[] CommodityValidateRows = CommodityTable.Select("Data_Column_Name = 'Commodity'");  //get all rows for Commodity from validation table;

               try
               {
                   
                   
                   //get tranlation table data from database
                   string connString = Properties.Settings.Default.ApplicationSettingsConnectionString;
                   string query = "select [Data_Column_Name],[Description],[Value], [Adams_Value], [Style], [Size], [Custom_Value], [Ignore] from Translation_Validation_Table";

                   SqlConnection conn = new SqlConnection(connString);
                   SqlCommand cmd = new SqlCommand(query, conn);
                   conn.Open();

                   // create data adapter
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   // this will query the database and return the result to your datatable
                   da.Fill(ds);
                   conn.Close();
                   da.Dispose();
                   TranslationTable = ds.Tables[0];  //set the translation table
                   ds.Dispose();
               }

               catch (Exception e)
               {
                   MessageBox.Show("There was an error while trying to load the translation table.  \n" +
                    " Note what happened and contact administrator for help or see error log.  \n");
                   Error_Logging el = new Error_Logging("There was an error while trying to load the translation table.  \n" + e);
                   ds.Dispose();
                   Completed = false;
                   return Data2Translate;
               }

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
                            "AND GROWERNAMEIDX = '" + GrowerBlock.ToString() + "'";

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
                   ds.Dispose();
               }

               catch (Exception e)
               {
                   MessageBox.Show("There was an error while trying to load the Grower Block table.  \n" +
                    " Note what happened and contact administrator for help or see error log.  \n");
                   Error_Logging el = new Error_Logging("There was an error while trying to load the Grower Block table.  \n" + e);
                   ds.Dispose();
                   Completed = false;
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
                                styleSizedAdded = true;
                            }
                        }
                    
                //Translate values  generic routine  *************************************************************************
                //Takes the list of fields to evaluate and iterates through each of them.

               try
               {
                   foreach (string sField in List2Translate)  //go through list of fields to translate
                   {
                       rownumber = 0;


                       //This is for the case where packcodes are used in the data streadsheet.  ***
                       if ((styleSizedAdded) &  (sField == "Style")) //((sField == "Size") || (sField == "Style")))
                       {
                           sTempField = "PackCode";
                       }
                       else
                       {
                           sTempField = sField;
                       }
                       //***   


                        
 
                       FoundRows = TranslationTable.Select("Data_Column_Name = " + "'" + sTempField + "'");  //get all rows for sField from Translation table

                       foreach (DataRow row in Data2Translate.Tables[0].Rows)  //go through data table and translate
                       {
                           
                           foreach (DataRow TranslatingRow in FoundRows) //FoundRows contains all the translation rows for sField
                           {

                               if ((sField == "Commodity") && (String.IsNullOrEmpty(row[TemplateSettings.CommodityColumn].ToString())))
                               {
                                   //get commodity from tranlation table
                                   CommodityRow = TranslationTable.Select("Value = '" + row[TemplateSettings.VarietyColumn] + "'")[0];
                                   row[TemplateSettings.CommodityColumn] = CommodityRow[6];  //The commodity is at index 6 of the translation row
                               }
                               //set size for stone fruit
                               foreach (DataRow Commodityrow in CommodityValidateRows)
                               {
                                   //if commodity is a stone fruit
                                   if (Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.CommodityColumn].ToString() == Commodityrow[2].ToString() &&
                                                Commodityrow[3].ToString() == "Stone Fruit")
                                   {   //set the size to the grade value for stone fruit
                                       Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.SizeColumn] =
                                           Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.GradeColumn].ToString();
                                }

                               }
                               
                               if (sTempField == "PackCode")  //For pack codes us the packcode location
                               {
                                   tempColumn = TemplateSettings.PackCodeColumn;
                               }
                               else
                               {
                                   tempColumn = TemplateSettings.DataColumnLocation(sField).Column;
                               }


                               if (row[tempColumn].ToString().ToUpper().Trim() == TranslatingRow[TranslateFromWhat].ToString().ToUpper().Trim())
                               {
                                   //set field to translated value
                                   Data2Translate.Tables[0].Rows[rownumber][tempColumn] =
                                       TranslatingRow[Translate2What].ToString();
                                   if (sTempField == "PackCode")
                                   {
                                       Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.StyleColumn] = TranslatingRow[StyleValueColumn];

                                       foreach (DataRow Commodityrow in CommodityValidateRows)
                                         {
                                             //if commodity is a stone fruit
                                             if (Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.CommodityColumn].ToString() == Commodityrow[2].ToString() &&
                                                (Commodityrow[3].ToString() == "Stone Fruit"))
                                             {   //set the size if stone fruit
                                                 
                                             }
                                             else
                                             {
                                                 Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.SizeColumn] = TranslatingRow[SizeValueColumn];
                                             }
                                       }

                                   }

                               }

                               if ((row[tempColumn].ToString().ToUpper().Trim() == TranslatingRow[AdamsValueColulmn].ToString().ToUpper().Trim()) & 
                                   !(TranslatingRow[AdamsValueColulmn].ToString().Trim() == ""))  //Check for Adams codes and translate
                               {
                                   //set field to translated value
                                   Data2Translate.Tables[0].Rows[rownumber][tempColumn] =
                                       TranslatingRow[Translate2What].ToString();

                                   if (sTempField == "PackCode") 
                                   {
                                       Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.StyleColumn] = TranslatingRow[StyleValueColumn];
                                       foreach (DataRow Commodityrow in CommodityValidateRows)
                                       {
                                           //if commodity is a stone fruit
                                           if (Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.CommodityColumn].ToString() == Commodityrow[2].ToString() &&
                                              (Commodityrow[3].ToString() == "Stone Fruit"))
                                           {   //set the size if stone fruit

                                           }
                                           else
                                           {
                                               Data2Translate.Tables[0].Rows[rownumber][TemplateSettings.SizeColumn] = TranslatingRow[SizeValueColumn];
                                           }
                                       }

                                   }
                               }

                 


                           }  //end of FoundRows foreach loop



                           try
                           {
                               //Get the GrowerBlock from the grower block table for the variety and set the growerblock field for the 
                               //Data row to the growerblock value.
                               if (GrowerBlockTable.Select("VarietyCode = '" + row[TemplateSettings.VarietyColumn] + "'").Length > 0)
                               {  //Check to see if the variety was found in the grower block data
                                   GrowerBlockRow = GrowerBlockTable.Select("VarietyCode = '" + row[TemplateSettings.VarietyColumn] + "'")[0];
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
                               Completed = false;
                               MessageBox.Show("Getting Grower Block process had an error.  Please note what was done and see administrator for help or see error log.  \n");
                               Error_Logging el = new Error_Logging("Getting Grower Block process had an error.  \n  " + e);
                           }

                          //fill in blank pack codes and convert fumigation codes.
                           if (String.IsNullOrEmpty(row[TemplateSettings.PackCodeColumn].ToString()) &
                               (sTempField == "Style" || sTempField == "Size"))
                           {
                               //Create a pack code from existing style and size with a space between them
                               row[TemplateSettings.PackCodeColumn] = row[TemplateSettings.StyleColumn].ToString().Trim() + " " + 
                                   row[TemplateSettings.SizeColumn].ToString().Trim();
                           }

                           if (String.IsNullOrEmpty(row[TemplateSettings.FumigatedColumn].ToString()))  //Fumigation code translation
                           {
                               row[TemplateSettings.FumigatedColumn] = 0;
                           }
                           if((row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "FUMIGATED") ||
                               row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "Y")
                           {
                               row[TemplateSettings.FumigatedColumn] = 1;
                           }
                           if((row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "NON FUMIGATED") ||
                           row[TemplateSettings.FumigatedColumn].ToString().ToUpper().Trim() == "N")
                           {
                               row[TemplateSettings.FumigatedColumn] = 0;
                           }


                       

                           rownumber++;
                       }

                      

                   }  //end of list of fields to translate foreach loop



                   Completed = true; //translation succeeded :)
               }  //end of try block

               catch (Exception e)
               {
                   Completed = false;
                   MessageBox.Show("Translation process had an error.  Please note what was done and see administrator for help or see error log.  \n");
                   Error_Logging el = new Error_Logging("Translation process had an error.  \n  " + e);
               }

            
               return Data2Translate; //translated data set

        }  //end of TranslateData method

        public bool TranslationCompleted()  //return suceess of translation
        {
            return Completed;
        }

                    
      }  //end of class

   }  //end of namespace



   

