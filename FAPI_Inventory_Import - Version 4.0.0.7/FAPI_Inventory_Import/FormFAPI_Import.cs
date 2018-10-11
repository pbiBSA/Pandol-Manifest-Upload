using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;


namespace FAPI_Inventory_Import
{
    public partial class FormFAPI_Import : Form
    {
        //Dropdown/textbox variables to hold the dropdown values.
        string sTransactionType;
        string sReceiveDate;
        string sBulkFlag = "N";
        string sWarehouse;
        string sRegion;
        string sGrowerBlock;
        string sExporterName;
        string sMethodID = " ";  //Set to space to skip requirement for value otherwise leave null
        string sStorageID;  
        string sPalletPrefix;
        string sDepartureDate;
        string sVesselNumber;
        string sVesselName;
        string sDestination;
        string sExporter;

        IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");

        //Template Settings datarow variable called templatesettings
        DataRow templatesettings;

       //List to hold list of fields to translate for import translation
        List<String> List2Translate = new List<string>();

        //List to hold list of fields to translate for Adams Export
        List<String> AdamsList2Translate = new List<string>();

        //List of fields to validate
        List<String> List2Validate = new List<string>();

        List<DataItemLocation> InvalidItemList = new List<DataItemLocation>();  //List of location of cells for invalid 
                                                                                // imported data after validation
        
       
        ImportTemplateSettings ImportSettings = new ImportTemplateSettings();  //import template settings object
                                                                               //will hold the template settings

        //Dataset which holds the imported data amd is passed when imported data is needed
        DataSet ImportedDataDataset = new DataSet();

        //Dataset which holds the imported data amd is passed when imported data is needed
        DataSet ImportedVesselDataDataset = new DataSet();

        //Dataset to hold original data before combining mixed pallet data
        DataSet UncombinedImportedDataDataset = new DataSet();

        //List of strings to be archived and exported
        List<string> exportFullDataList = new List<string>();  //List of dropdown's and textbox values

        DataSet ImportSettingsDataSet = new DataSet();  //dataset for the Import Settings table


        public FormFAPI_Import()
        {
            InitializeComponent();
            
        }

        private void FormFAPI_Import_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'applicationSettingsDataSet17.Grower_Name' table. 
            this.grower_NameTableAdapter.Fill(this.applicationSettingsDataSet17.Grower_Name);

            //Turn off Method and Storage dropdowns
            this.comboBoxMethodID.Visible = false;
            this.comboBoxStorageID.Visible = true;
            this.labelMethodID.Visible = false;
            this.labelStorageID.Visible = true;
            this.buttonTranslateOld.Visible = false;

            
            // TODO: This line of code loads data into the 'applicationSettingsDataSetImportTemplate.FAPI_Import_Templates' table. You can move, or remove it, as needed.
            this.fAPI_Import_TemplatesTableAdapter.Fill(this.applicationSettingsDataSetImportTemplate.FAPI_Import_Templates);
            
            string connString = Properties.Settings.Default.ConnectionString;  //get connection string from the application settings
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object
            SqlDataAdapter ImportSettingsDataAdaptor = null;  //DataAdaptor for the Translation-Validation table
            SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
            SqlCommand QueryCommand = null;  //query string


            //get tranlation-validation table data from database
            QueryCommand = new SqlCommand("SELECT * FROM FAPI_Import_Templates", conn);

            ImportSettingsDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ImportSettingsDataAdaptor);

            conn.Open();

            ImportSettingsDataAdaptor.Fill(ImportSettingsDataSet);


            conn.Close();
            

           //log application starting in test mode.
            if (Properties.Settings.Default.Mode == "Test")
            {
                Error_Logging el = new Error_Logging("Starting Test run.");
            }
            

           //Lists for translation and validation
               //Tranlation list creation
            List2Translate.Add("Variety");
            List2Translate.Add("Commodity");
            List2Translate.Add("Style");
            List2Translate.Add("Size");
            List2Translate.Add("PackCode");
            
            List2Translate.Add("Grade");
            List2Translate.Add("Label");
            List2Translate.Add("PalletType");
            //List2Translate.Add("Commodity");

            //Validation list creation
            List2Validate.Add("Variety");
            List2Validate.Add("Style");
            List2Validate.Add("Size");
            List2Validate.Add("Commodity");
            List2Validate.Add("Grade");
            List2Validate.Add("Label");
            List2Validate.Add("PalletType");
            

            //Adams tranlation list creation
            AdamsList2Translate.Add("Variety");
           // AdamsList2Translate.Add("Style");  //not used for Adams
           // AdamsList2Translate.Add("Size");  //not used for Adams
            AdamsList2Translate.Add("PackCode");
            AdamsList2Translate.Add("Grade");
            AdamsList2Translate.Add("Label");
          //  AdamsList2Translate.Add("PalletType");  //Not needed for Adams
           // AdamsList2Translate.Add("Prefix");  //Not needed for Adams

            //Disable export and test buttons until validated, except in test mode.
            if (Properties.Settings.Default.Mode == "Test")
            {
                this.buttonAdamsExport.Enabled = false;
                this.buttonFamousExport.Enabled = false;
                this.labelMode.Visible = true;
                this.exportToolStripMenuItem.Enabled = false;
                this.famousToolStripMenuItem.Enabled = false;
                this.adamsToolStripMenuItem.Enabled = false;
            }
            else if (Properties.Settings.Default.Mode == "Beta")
            {
                this.buttonAdamsExport.Enabled = false;
                this.buttonFamousExport.Enabled = false;
                this.labelMode.Text = "Beta Version";
                this.labelMode.Visible = true;
                this.exportToolStripMenuItem.Enabled = false;
                this.famousToolStripMenuItem.Enabled = false;
                this.adamsToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.buttonAdamsExport.Enabled = false;
                this.buttonFamousExport.Enabled = false;
                this.labelMode.Visible = false;
                this.exportToolStripMenuItem.Enabled = false;
                this.famousToolStripMenuItem.Enabled = false;
                this.adamsToolStripMenuItem.Enabled = false;
            }

          
            
            try
            {
                
                // This line of code loads data into the 'applicationSettingsDataSet.Inventory_Warehouse_Codes' table. 
                this.inventory_Warehouse_CodesTableAdapter.Fill(this.applicationSettingsDataSet.Inventory_Warehouse_Codes);
                // This line of code loads data into the 'applicationSettingsDataSetGrowersBlock.Grower_Block_ID_Codes' table.
                this.grower_Block_ID_CodesTableAdapter1.Fill(this.applicationSettingsDataSetGrowersBlock.Grower_Block_ID_Codes);
                // This line of code loads data into the 'applicationSettingsDataSetStorageID.Storage_ID_Codes' table.
                this.storage_ID_CodesTableAdapter.Fill(this.applicationSettingsDataSetStorageID.Storage_ID_Codes);          
                // This line of code loads data into the 'applicationSettingsDataSet4.Method_ID_Codes' table. 
                this.method_ID_CodesTableAdapter.Fill(this.applicationSettingsDataSet4.Method_ID_Codes);
                // This line of code loads data into the 'applicationSettingsDataSet1.Method_ID_Codes' table.
                this.region_ID_CodesTableAdapter.Fill(this.applicationSettingsDataSet1.Region_ID_Codes);
                // This line of code loads data into the 'applicationSettingsDataSet9.Commodity_Codes' table.
                this.commodity_CodesTableAdapter.Fill(this.applicationSettingsDataSet9.Commodity_Codes);

               
              //Set default import setting values which are in the first row of the settings table.
              //These are used in no template is selected.
                templatesettings = this.ImportSettingsDataSet.Tables[0].Rows[0];
                

                  ImportSettings.TemplateName = templatesettings[0].ToString();
                  ImportSettings.ExporterRow = Convert.ToInt32(templatesettings[1]);
                  ImportSettings.ExporterColumn = Convert.ToInt32(templatesettings[2]);
                  ImportSettings.DepartureDateRow = Convert.ToInt32(templatesettings[3]);
                  ImportSettings.DepartureDateColumn = Convert.ToInt32(templatesettings[4]);
                  ImportSettings.VesselNumberRow = Convert.ToInt32(templatesettings[5]);
                  ImportSettings.VesselNumberColumn = Convert.ToInt32(templatesettings[6]);
                  ImportSettings.VesselNameRow = Convert.ToInt32(templatesettings[7]);
                  ImportSettings.VesselNameColumn = Convert.ToInt32(templatesettings[8]);
                  ImportSettings.VesselDestinationRow = Convert.ToInt32(templatesettings[9]);
                  ImportSettings.VesselDestinationColumn = Convert.ToInt32(templatesettings[10]);
                  ImportSettings.PalletPrefixRow = Convert.ToInt32(templatesettings[11]);
                  ImportSettings.PalletPrefixColumn = Convert.ToInt32(templatesettings[12]);
                  ImportSettings.TagNumberRow = Convert.ToInt32(templatesettings[13]);
                  ImportSettings.TagNumberColumn = Convert.ToInt32(templatesettings[14]);
                  ImportSettings.CommodityRow = Convert.ToInt32(templatesettings[15]);
                  ImportSettings.CommodityColumn = Convert.ToInt32(templatesettings[16]);
                  ImportSettings.VarietyRow = Convert.ToInt32(templatesettings[17]);
                  ImportSettings.VarietyColumn = Convert.ToInt32(templatesettings[18]);
                  ImportSettings.StyleRow = Convert.ToInt32(templatesettings[19]);
                  ImportSettings.StyleColumn = Convert.ToInt32(templatesettings[20]);
                  ImportSettings.SizeRow = Convert.ToInt32(templatesettings[21]);
                  ImportSettings.SizeColumn = Convert.ToInt32(templatesettings[22]);
                  ImportSettings.GradeRow = Convert.ToInt32(templatesettings[23]);
                  ImportSettings.GradeColumn = Convert.ToInt32(templatesettings[24]);
                  ImportSettings.LabelRow = Convert.ToInt32(templatesettings[25]);
                  ImportSettings.LabelColumn = Convert.ToInt32(templatesettings[26]);
                  ImportSettings.PalletTypeRow = Convert.ToInt32(templatesettings[27]);
                  ImportSettings.PalletTypeColumn = Convert.ToInt32(templatesettings[28]);
                  ImportSettings.InventoryQuantityRow = Convert.ToInt32(templatesettings[29]);
                  ImportSettings.InventoryQuantityColumn = Convert.ToInt32(templatesettings[30]);
                  ImportSettings.FirstPackDateRow = Convert.ToInt32(templatesettings[31]);
                  ImportSettings.FirstPackDateColumn = Convert.ToInt32(templatesettings[32]);
                  ImportSettings.GrowerNumberRow = Convert.ToInt32(templatesettings[33]);
                  ImportSettings.GrowerNumberColumn = Convert.ToInt32(templatesettings[34]);
                  ImportSettings.HatchRow = Convert.ToInt32(templatesettings[35]);
                  ImportSettings.HatchColumn = Convert.ToInt32(templatesettings[36]);
                  ImportSettings.DeckRow = Convert.ToInt32(templatesettings[37]);
                  ImportSettings.DeckColumn = Convert.ToInt32(templatesettings[38]);
                  ImportSettings.FumigatedRow = Convert.ToInt32(templatesettings[39]);
                  ImportSettings.FumigatedColumn = Convert.ToInt32(templatesettings[40]);
                  ImportSettings.BillOfLadingRow = Convert.ToInt32(templatesettings[41]);
                  ImportSettings.BillOfLadingColumn = Convert.ToInt32(templatesettings[42]);
                  ImportSettings.MemoRow = Convert.ToInt32(templatesettings[43]);
                  ImportSettings.MemoColumn = Convert.ToInt32(templatesettings[44]);
                  ImportSettings.PackCodeRow = Convert.ToInt32(templatesettings[45]);
                  ImportSettings.PackCodeColumn = Convert.ToInt32(templatesettings[46]);
                  ImportSettings.Custom_1 = Convert.ToInt32(templatesettings[47]);
                  ImportSettings.Other = Convert.ToInt32(templatesettings[48]);
                  ImportSettings.DataSheet = templatesettings[49].ToString();
                  ImportSettings.DataRange = (templatesettings[50]).ToString();
                  ImportSettings.Special_Processing = templatesettings[51].ToString();
                 




              //Set selected dropdown defaults
                this.comboBoxTransactionType.SelectedIndex = 0;
                this.sReceiveDate = dateTimePickerReceiveDate.Text;

              
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error trying to load default settings. \n"  +
                    "Verify that there is an internet connections and that the SQL server is up.  " + 
                    "Application will close.  \n");
                Error_Logging el = new Error_Logging("Error trying to load default settings on start up. \n" + "Application will close.  \n" + exceptioncode);
                Application.Exit();
            }
        }

        //Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The user wants to exit the application. Close everything down.
          
            Application.Exit();
        }


        //Load Excel file, assumes that first row in data range contains the headers when the main data is read in
        //on the 2nd read pass.  
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                //Disable export buttons until validated, except in test mode.
                if (Properties.Settings.Default.Mode == "Test")
                {
                    this.buttonFamousExport.Enabled = true;                  
                }
                else
                {
                    this.buttonAdamsExport.Enabled = false;
                    this.buttonFamousExport.Enabled = false;
                }

                //reset labels to default values    
                this.labelExportFile.Text = "Famous File:  ";
                this.labelExportFile.ForeColor = Color.Black;
                this.labelExportAdamsFile.Text = "Adams File:  ";
                this.labelExportAdamsFile.ForeColor = Color.Black;
                this.labelTranslated.Text = "Data Has not been translated!";
                this.labelTranslated.ForeColor = Color.Red;
                this.labelCurrentFile.Text = "Import File:  ";
                this.labelCurrentFile.ForeColor = Color.Black;





                dataGridViewExcel.Columns.Clear();
                ImportedDataDataset = new DataSet();  //Set to new clear dataset before importing new excel file
                InvalidItemList.Clear();  //Clear the list of invalid cells in dataset.
                this.dataGridViewExcel.Update();

                //Get excel file
                openFileDialogExcel.InitialDirectory = Properties.Settings.Default.ImportExcelFilePath; //get default path from settings
            
            DialogResult result = openFileDialogExcel.ShowDialog();  //open file dialog for excel file

            if (result == DialogResult.OK)  //only try to open excel file if open dialog <OK> button was clicked.
                {                           //ignore if cancel is clicked or window is closed.

                    string fileName = openFileDialogExcel.FileName; // get file path and name from the dialog box.
                    labelCurrentFile.Text = labelCurrentFile.Text + fileName.ToString();  //show file path and name as label


                    //**********************************  Get the  data sheet name from the list of all datasheets.
                    frmSelectDataSheet SelectExcelSheet = new frmSelectDataSheet(fileName);

                    DialogResult SheetSelectResult = SelectExcelSheet.ShowDialog();

                    if (SheetSelectResult == DialogResult.OK)  //used clicked OK
                    {
                        ImportSettings.DataSheet = SelectExcelSheet.DataSheetName();
                        if (SelectExcelSheet.DataSheetName().IndexOf("-") != -1)
                        {
                            MessageBox.Show("Sheetname contains a hyphen and should be renamed.");
                            return;
                        }

                    }
                    else  // window closed
                    {
                        MessageBox.Show("The default data sheet: " + ImportSettings.DataSheet.ToString() +
                             " will be used.");

                    }

                    SelectExcelSheet.Dispose();


                    //*************************************

                    labelCurrentFile.ForeColor = Color.Green;  //make it green to show it was opened.

                    try
                    {  //Load entire datasheet into dataset to get vessel information which could be anywhere

                        ImportedVesselDataDataset = new DataSet();  //set to new dataset to clear an previous schema settings and data

                        OleDbConnectionStringBuilder connStringBuilder =  //use OleDbConnection to get excel data
                        new OleDbConnectionStringBuilder();

                        connStringBuilder.DataSource = fileName;  // Set path to excel file
                        connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                        connStringBuilder.Add("Extended Properties", "Excel 12.0;HDR=NO;IMEX=1");

                        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

                        DbDataAdapter adapter = factory.CreateDataAdapter();

                        DbCommand selectCommand = factory.CreateCommand();
                        selectCommand.CommandText = String.Format("select * from [" + ImportSettings.DataSheet + "]");  //Data from entire datasheet

                        DbConnection connection = factory.CreateConnection();
                        connection.ConnectionString = connStringBuilder.ToString();
                        selectCommand.Connection = connection;
                        adapter.SelectCommand = selectCommand;
                        adapter.Fill(this.ImportedVesselDataDataset);

                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading excel file. \n" +
                            "Verify that the worksheet name: '" +  ImportSettings.DataSheet.Substring(0, ImportSettings.DataSheet.Length -1) + 
                            "' is correct for the excel workbook.  \n" +
                            "And that the correct template was used.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading excel file for vessel information. \n" + exceptioncode);

                        return;
                    }

                    //Get Vessel Information from imported spreadsheet which is in the ImportedDataDataset Dataset.    
                try
                    {          
                        DataRow rowExporter;
                        rowExporter = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.ExporterRow];
                        textBoxExporter.Text = sExporter = rowExporter[ImportSettings.ExporterColumn].ToString().Trim();  //exporter
                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading Exporter. \n"  +
                            "Check the excel spreadsheet and template to see that they match.  \n");
                        Error_Logging el = new Error_Logging("Error loading Exporter. \n" + exceptioncode);
                        return;
                    }

                try
                {

                        DataRow rowDeparture;  //Departure date
                        rowDeparture = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.DepartureDateRow];
                        sDepartureDate = rowDeparture[ImportSettings.DepartureDateColumn].ToString().Trim();
                        sDepartureDate = DateNumberToDateString.ConvertDateNumberToDateString(sDepartureDate);  //Convert to date if a number

                        textBoxDepartureDate.Text = sDepartureDate = DateTime.Parse(sDepartureDate, mFomatter).ToString("MM/dd/yyyy");
                }

                catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading Departure Date. \n" +
                            " Verify that the spreadsheet is not open in excel, that the date format is correct \n" +
                            "in the spreadsheet and that the correct template was used.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading Departure Date. \n" + exceptioncode);
                        return;
                    }

                try
                {
                        DataRow rowVesselNumber;
                        rowVesselNumber = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.VesselNumberRow];
                        textBoxVesselNumber.Text = sVesselNumber = "";  //Vessel Number set to blank

                        DataRow rowVesselName;
                        rowVesselName = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.VesselNameRow];
                        textBoxVesselName.Text = sVesselName = rowVesselName[ImportSettings.VesselNameColumn].ToString().Trim();  //Vessel Name

                        DataRow rowDestination;
                        rowDestination = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.VesselDestinationRow];
                        textBoxDestination.Text = sDestination = rowDestination[ImportSettings.VesselDestinationColumn].ToString().Trim();  //Vessel Destination

                        DataRow rowPalletPrefix;
                        rowPalletPrefix = this.ImportedVesselDataDataset.Tables[0].Rows[ImportSettings.PalletPrefixRow];

                        //Pallet Prefix is sometimes in decimal format in the speadsheet so needs to be parsed.
                        string sTemptext;
                        sTemptext = rowPalletPrefix[ImportSettings.PalletPrefixColumn].ToString().Trim();
                        sTemptext = TruncateString.Truncate2(sTemptext.Split('.')[0], 3); //if it is from a tag number only use the first 3 characters
                        textBoxPalletPrefix.Text = sTemptext;  //Pallet Prefix
                        sPalletPrefix = sTemptext.Trim(); //set Pallet Prefix variable

                       // GetExporterFromPrefix ge = new GetExporterFromPrefix();
                        //sExporter = ge.GetExporterNameFromPrefix(sPalletPrefix, sExporter);
                        this.textBoxExporter.Text = sExporter;

                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error reading vessel information. \n"  +
                            "Verify that the correct template was used.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error reading vessel information. \n" + exceptioncode);
                        return;

                    }

                    // Get the data part of the spreadsheet  *****************************************************************
                    try
                    {  //Standard format excel file import of data section only and not entire datasheet so that the column headers will be the first row
                        this.ImportedDataDataset.Clear();

                        OleDbConnectionStringBuilder connStringBuilder =
                        new OleDbConnectionStringBuilder();

                        connStringBuilder.DataSource = fileName;  // Set path to excel file
                        connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                        connStringBuilder.Add("Extended Properties", "Excel 12.0;HDR=YES;IMEX=1");

                        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

                        DbDataAdapter adapter = factory.CreateDataAdapter();

                        DbCommand selectCommand = factory.CreateCommand();

                        selectCommand.CommandText = String.Format("select * from [" + ImportSettings.DataSheet + ImportSettings.DataRange + "]");  //Data range is gotten from the Import Settings

                        DbConnection connection = factory.CreateConnection();
                        connection.ConnectionString = connStringBuilder.ToString();
                        selectCommand.Connection = connection;
                        adapter.SelectCommand = selectCommand;

                        adapter.FillSchema(ImportedDataDataset, SchemaType.Source);

                        for (int i = 0; i < ImportedDataDataset.Tables[0].Columns.Count; i++)
                        {

                            ImportedDataDataset.Tables[0].Columns[i].DataType = typeof(string);
                        }

                        adapter.Fill(this.ImportedDataDataset);
                    }
                catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error reading Data section of spreadsheet. \n"  +
                            " Data Range in template may be incorrect.  \n" +
                            "Verify that the correct template was used.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading Spreadsheet for data range. \n" + exceptioncode);
                        return;

                    }

                try
                {

                        //Add Grower Block column as it is assumed to not be in any spreadsheet
                        DataColumn Col = ImportedDataDataset.Tables[0].Columns.Add("Grower Block", typeof(String));
                        Col.SetOrdinal(1);// to put the column in position 1;
 

                        //*************Add missing columns here for data sheets that has them missing
       
                        //Process the custom settings number.  Convert to binary and add columns based upon the bits  ********
                        string binary = Convert.ToString(ImportSettings.Custom_1, 2);
                        char[] AddCustomColumn = binary.ToCharArray();
                        Array.Reverse(AddCustomColumn);

                        for (int index = 0; index < AddCustomColumn.Length; index++)
                        {
                            if (index == 0)
                            {
                                if (AddCustomColumn[0] == '1')  //add style-size
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("Style", typeof(String));
                                    ImportedDataDataset.Tables[0].Columns.Add("PackSize", typeof(String));
                                }
                            }
                            if (index == 1)
                            {
                                if (AddCustomColumn[1] == '1')  //add grade
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("Grade", typeof(String));
                                }
                            }
                            if (index == 2)  //add pallet type
                            {
                                if (AddCustomColumn[2] == '1')
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("PalletType", typeof(String));
                                }
                            }
                            if (index == 3)
                            {
                                if (AddCustomColumn[3] == '1')  //add hatch and deck
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("Hatch", typeof(String));
                                    ImportedDataDataset.Tables[0].Columns.Add("Deck", typeof(String));
                                }
                            }
                           
                            if (index == 4)
                            {
                                if (AddCustomColumn[4] == '1')
                                {               //add commodity column
                                    DataColumn ColCommodity = ImportedDataDataset.Tables[0].Columns.Add("Commodity", typeof(String));
                                    ColCommodity.SetOrdinal(2);// to put the column in position 2;
                                }

                            }
                            if (index == 5)
                            {
                                if (AddCustomColumn[5] == '1')
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("Fumigation", typeof(String));  //add fumigation column
                                }
                            }
                            if (index == 6)
                            {
                                if (AddCustomColumn[6] == '1')
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("BillOfLading", typeof(String));  //add bill of lading column
                                }
                            }
                            if (index == 7)
                            {
                                if (AddCustomColumn[7] == '1')
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("PackCode", typeof(String));  //add pack code column
                                }
                            }
                            if (index == 8)
                            {
                                if (AddCustomColumn[8] == '1')
                                {
                                    ImportedDataDataset.Tables[0].Columns.Add("Memo", typeof(String));  //add Memo column
                                }
                            }
                        }

                        //  ************************************************************************************************************

                        if (ImportSettings.Special_Processing == "Pack Date") //for the case of a missing pack date column
                        {
                            ImportedDataDataset.Tables[0].Columns.Add("Pack Date", typeof(String));
                        }


                        //**********************************************************************



                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error adding missing columns. \n" +
                            " Verify that the correct template was used.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error adding missing columns. \n" + exceptioncode);
                        return;
                    }


                    try  //Load the imported spreadsheeting
                    {
                        dataGridViewExcel.DataSource = ImportedDataDataset.Tables[0].DefaultView;
                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading datagrid viewer. \nNote what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading DataGridView. \n" + exceptioncode);
                        return;

                    }


                    try
                    {
                        //'Remove empty rows at in dataset table as speadsheets could contain empty rows.
                        for (int h = 0; h < this.ImportedDataDataset.Tables[0].Rows.Count; h++)
                        {
                            if (this.ImportedDataDataset.Tables[0].Rows[h].IsNull(0) == true)
                            {
                                this.ImportedDataDataset.Tables[0].Rows[h].Delete();
                            }
                        }

                        ImportedDataDataset.AcceptChanges();
                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error removing blank rows from dataset table. \nNote what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error removing blank rows from dataset table. \n" + exceptioncode);
                        return;

                    }

                    try
                    {
                        if (ImportSettings.Special_Processing == "Pack Date")  //if pack date data was missing use departure date as a default
                        {
                            foreach (DataRow row in ImportedDataDataset.Tables[0].Rows)  //go through data table and add date
                            {
                                row[ImportSettings.FirstPackDateColumn] = sDepartureDate;
                            }
                        }
                    }
                catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error using departure date for missing pack date. \n" +
                            "Verify that the departure date is correct in the spreadsheet.  \n" +
                            "Note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error using departure date for missing pack date. \n" + exceptioncode);
                        return;

                    }


                }  //end if filedialog <OK> button clicked

        }


       
        //Set Warehouse variable when selected
        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(comboBoxWarehouse.Text))
            {
                sWarehouse = comboBoxWarehouse.SelectedValue.ToString().Trim();
            }         

        }

        //Set Region variable when selected
        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxRegion.Text))
            {
                sRegion = comboBoxRegion.Text.ToString().Trim();
            }
           
        }

        
        //Set Grower variable when selected
        private void comboBoxGrowerBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxGrowerBlock.Text))
            {
                sGrowerBlock = comboBoxGrowerBlock.SelectedValue.ToString();
                sExporterName = comboBoxGrowerBlock.Text;
                textBoxExporter.Text = sExporterName;
            }
        }

        //Set Receive Date variable when selected or changed
        private void dateTimePickerReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dateTimePickerReceiveDate.Value.ToString()))
            {
                sReceiveDate = DateTime.Parse(dateTimePickerReceiveDate.Value.ToString().Trim(), mFomatter).ToString("MM/dd/yyyy");
            }
        }

        //Set Method ID variable when selected, if used
        private void comboBoxMethodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxMethodID.Text))
            {
                sMethodID = comboBoxMethodID.SelectedValue.ToString();
            }
        }
        
        //Set Storage ID variable when selected, if used
        private void comboBoxStorageID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxStorageID.Text))
            {
                sStorageID = comboBoxStorageID.SelectedValue.ToString();
            }
        }


               //Gets the import template from FAPI_Import_Templates table
                private void toolStripMenuItemTemplate_Click(object sender, EventArgs e)
               {
                 //Disable export buttons until validated, except in test mode.
                   if (Properties.Settings.Default.Mode == "Test")
                   {
                       this.buttonAdamsExport.Enabled = false;
                       this.buttonFamousExport.Enabled = false;
                       this.exportToolStripMenuItem.Enabled = false;
                       this.famousToolStripMenuItem.Enabled = false;
                       this.adamsToolStripMenuItem.Enabled = false;
                   }
                   else
                   {
                       this.buttonAdamsExport.Enabled = false;
                       this.buttonFamousExport.Enabled = false;
                       this.exportToolStripMenuItem.Enabled = false;
                       this.famousToolStripMenuItem.Enabled = false;
                       this.adamsToolStripMenuItem.Enabled = false;
                   }

                   //reset export file labels
                   this.labelExportFile.Text = "Famous File:  ";
                   this.labelExportFile.ForeColor = Color.Black;
                   this.labelExportAdamsFile.Text = "Adams File:  ";
                   this.labelExportAdamsFile.ForeColor = Color.Black;


                   try
                   {       //Open templateform and get the template name
                       Import_Template_Selection templateform = new Import_Template_Selection();
                       templateform.ShowDialog();
                       templatesettings = templateform.getTemplateSettings();
                       templateform.Dispose();

                       //Set import template settings values
                       ImportSettings.TemplateName = templatesettings[0].ToString();
                       ImportSettings.ExporterRow = Convert.ToInt32(templatesettings[1]);
                       ImportSettings.ExporterColumn = Convert.ToInt32(templatesettings[2]);
                       ImportSettings.DepartureDateRow = Convert.ToInt32(templatesettings[3]);
                       ImportSettings.DepartureDateColumn = Convert.ToInt32(templatesettings[4]);
                       ImportSettings.VesselNumberRow = Convert.ToInt32(templatesettings[5]);
                       ImportSettings.VesselNumberColumn = Convert.ToInt32(templatesettings[6]);
                       ImportSettings.VesselNameRow = Convert.ToInt32(templatesettings[7]);
                       ImportSettings.VesselNameColumn = Convert.ToInt32(templatesettings[8]);
                       ImportSettings.VesselDestinationRow = Convert.ToInt32(templatesettings[9]);
                       ImportSettings.VesselDestinationColumn = Convert.ToInt32(templatesettings[10]);
                       ImportSettings.PalletPrefixRow = Convert.ToInt32(templatesettings[11]);
                       ImportSettings.PalletPrefixColumn = Convert.ToInt32(templatesettings[12]);
                       ImportSettings.TagNumberRow = Convert.ToInt32(templatesettings[13]);
                       ImportSettings.TagNumberColumn = Convert.ToInt32(templatesettings[14]);
                       ImportSettings.CommodityRow = Convert.ToInt32(templatesettings[15]);
                       ImportSettings.CommodityColumn = Convert.ToInt32(templatesettings[16]);
                       ImportSettings.VarietyRow = Convert.ToInt32(templatesettings[17]);
                       ImportSettings.VarietyColumn = Convert.ToInt32(templatesettings[18]);
                       ImportSettings.StyleRow = Convert.ToInt32(templatesettings[19]);
                       ImportSettings.StyleColumn = Convert.ToInt32(templatesettings[20]);
                       ImportSettings.SizeRow = Convert.ToInt32(templatesettings[21]);
                       ImportSettings.SizeColumn = Convert.ToInt32(templatesettings[22]);
                       ImportSettings.GradeRow = Convert.ToInt32(templatesettings[23]);
                       ImportSettings.GradeColumn = Convert.ToInt32(templatesettings[24]);
                       ImportSettings.LabelRow = Convert.ToInt32(templatesettings[25]);
                       ImportSettings.LabelColumn = Convert.ToInt32(templatesettings[26]);
                       ImportSettings.PalletTypeRow = Convert.ToInt32(templatesettings[27]);
                       ImportSettings.PalletTypeColumn = Convert.ToInt32(templatesettings[28]);
                       ImportSettings.InventoryQuantityRow = Convert.ToInt32(templatesettings[29]);
                       ImportSettings.InventoryQuantityColumn = Convert.ToInt32(templatesettings[30]);
                       ImportSettings.FirstPackDateRow = Convert.ToInt32(templatesettings[31]);
                       ImportSettings.FirstPackDateColumn = Convert.ToInt32(templatesettings[32]);
                       ImportSettings.GrowerNumberRow = Convert.ToInt32(templatesettings[33]);
                       ImportSettings.GrowerNumberColumn = Convert.ToInt32(templatesettings[34]);
                       ImportSettings.HatchRow = Convert.ToInt32(templatesettings[35]);
                       ImportSettings.HatchColumn = Convert.ToInt32(templatesettings[36]);
                       ImportSettings.DeckRow = Convert.ToInt32(templatesettings[37]);
                       ImportSettings.DeckColumn = Convert.ToInt32(templatesettings[38]);
                       ImportSettings.FumigatedRow = Convert.ToInt32(templatesettings[39]);
                       ImportSettings.FumigatedColumn = Convert.ToInt32(templatesettings[40]);
                       ImportSettings.BillOfLadingRow = Convert.ToInt32(templatesettings[41]);
                       ImportSettings.BillOfLadingColumn = Convert.ToInt32(templatesettings[42]);
                       ImportSettings.MemoRow = Convert.ToInt32(templatesettings[43]);
                       ImportSettings.MemoColumn = Convert.ToInt32(templatesettings[44]);
                       ImportSettings.PackCodeRow = Convert.ToInt32(templatesettings[45]);
                       ImportSettings.PackCodeColumn = Convert.ToInt32(templatesettings[46]);
                       ImportSettings.Custom_1 = Convert.ToInt32(templatesettings[47]);
                       ImportSettings.Other = Convert.ToInt32(templatesettings[48]);
                       ImportSettings.DataSheet = templatesettings[49].ToString();
                       ImportSettings.DataRange = (templatesettings[50]).ToString();
                       ImportSettings.Special_Processing = templatesettings[51].ToString();


                       //Show the current loaded template
                       labelCurrentTemplate.Text = templatesettings[0].ToString();
                       labelCurrentTemplate.ForeColor = Color.Green;  //Green means it loaded
                   }

                   catch (Exception exceptioncode)
                   {
                       MessageBox.Show("Error setting import template settings. \n" +
                           "Verify that there is an internet connection and the SQL server is up.  \n" +
                           "Note what was done and contact administrator.  \n");
                       Error_Logging el = new Error_Logging("Error setting import template settings. \n" + exceptioncode);
                   }
               }

        private void buttonFamousExport_Click(object sender, EventArgs e)  //Famous export button clicked
        {
            ExportToFamous();  //run the export to famous method 

        }

        private void famousToolStripMenuItem_Click(object sender, EventArgs e)  //Famous export menu item selected
        {
            ExportToFamous();  //run the export to famous method
        }


        private void ExportToFamous()
        {
            string tempfile; //export file name variable
            int ReceiptNumber = 0;  //receipt number for exports
            int ReUseReceiptNumber = 0;

            //set the labels and checkbox defaults
            this.labelExportFile.Text = "Famous File:  ";
            this.labelExportFile.ForeColor = Color.Black;
            this.labelExportAdamsFile.Text = "Adams File:  ";
            this.labelExportAdamsFile.ForeColor = Color.Black;



            //check to see if all dropdowns have been selected and if they are add them to the exportDataList
            //if not then add the names to the notSelectedList

            //to hold export code for famous export.  Order is important take note
            StringBuilder notSelectedError = new StringBuilder();  //list to hold the name of dropdowns not selected

            List<string> exportDataList = new List<string>();  //List of dropdown's values

            if (!String.IsNullOrEmpty(sTransactionType))
            {
                exportDataList.Add(sTransactionType); //add transaction type first, index 0
            }
            else
            {
                notSelectedError.Append("Transaction Type, ");  //add to not selected list
            }

            if (!String.IsNullOrEmpty(sReceiveDate))
            {
                exportDataList.Add(sReceiveDate.ToString());  //index 1
            }
            else
            {
                notSelectedError.Append("Received Date, ");
            }

            if (!String.IsNullOrEmpty(sBulkFlag))
            {
                exportDataList.Add(sBulkFlag);  //index 2
            }
            else
            {
                notSelectedError.Append("Bulk Flag, ");
            }

            if (!String.IsNullOrEmpty(sWarehouse))
            {
                exportDataList.Add(sWarehouse.Trim());  // index 3
            }
            else
            {
                notSelectedError.Append("Warehouse, ");
            }

            if (!String.IsNullOrEmpty(sExporterName))   //sGrowerBlock))
            {
                exportDataList.Add(sExporterName);                 //sGrowerBlock);  //index 4
            }
            else
            {
                notSelectedError.Append("Grower, ");
            }

           exportDataList.Add("");  //index 5  Old commodity ID remove later with code cleanup
           

            if (!String.IsNullOrEmpty(sRegion))
            {
                exportDataList.Add(sRegion.Trim());  //index 6
            }
            else
            {
                notSelectedError.Append("Region, ");
            }

            if (!String.IsNullOrEmpty(sMethodID))
            {
                exportDataList.Add(sMethodID);  // index 7
            }
            else
            {
                notSelectedError.Append("Method ID, ");
            }

            if (!String.IsNullOrEmpty(sStorageID))
            {
                exportDataList.Add(sStorageID);  // index 8
            }
            else
            {
                notSelectedError.Append("Storage ID, ");
            }

            if (checkBoxAvailable.Checked) //this the available flag.  Should be Y or N  // index 9
            {
                exportDataList.Add("Y");
            }
            else
            {
                exportDataList.Add("N");
            }

            exportDataList.Add(sPalletPrefix.Trim());  // index 10


            //These are used by the archive and Adam's processes  ****************
            if (!String.IsNullOrEmpty(textBoxExporter.Text))
            {
                exportDataList.Add(textBoxExporter.Text.Trim());  // index 11
            }
            else
            {
                exportDataList.Add(null);
            }

            if (!String.IsNullOrEmpty(textBoxDepartureDate.Text))
            {
                exportDataList.Add(textBoxDepartureDate.Text);  // index 12
            }
            else
            {
                exportDataList.Add(null);
            }

            if (!String.IsNullOrEmpty(textBoxVesselNumber.Text))
            {
                exportDataList.Add(textBoxVesselNumber.Text.Trim());  // index 13
            }
            else
            {
                notSelectedError.Append("Lot/Vessel Num, "); //exportDataList.Add(null);
            }

            if (!String.IsNullOrEmpty(textBoxVesselName.Text))
            {
                exportDataList.Add(textBoxVesselName.Text.Trim());  // index 14
            }
            else
            {
                exportDataList.Add(null);
            }

            if (!String.IsNullOrEmpty(textBoxDestination.Text))
            {
                exportDataList.Add(textBoxDestination.Text.Trim());  // index 15
            }
            else
            {
                exportDataList.Add(null);
            }

            exportFullDataList = exportDataList;  //Keep a copy for use elsewhere in the code         

            if (notSelectedError.Length == 0)  //if it is 0 then all dropdowns have been selected and complete export process
            {
                //Select QC pallets
               // QCPalletSelection QC = new QCPalletSelection(UncombinedImportedDataDataset, ImportSettings, exportFullDataList, ReceiptNumber);
               // QC.Select_Pallets();

                //UpdateImportDatasetForQC IQCDS = new UpdateImportDatasetForQC(ImportedDataDataset, ImportSettings);
               // ImportedDataDataset = IQCDS.UpdateDataSet();
                
                //Instantiate famous exporter and run the export process

                if (checkBoxXMLExport.Checked)
                {
                   
                    
                    
                    FamousXMLExporter FamousDataExporter = new FamousXMLExporter(ImportedDataDataset, ImportSettings, exportDataList);
                    FamousDataExporter.ExportData();
                    ReceiptNumber = FamousDataExporter.GetReceiptNumber();
                    ReUseReceiptNumber = FamousDataExporter.GetReUseReceiptNumber();
                    exportFullDataList.Add(ReUseReceiptNumber.ToString());  //add the flag for reusing an existing receipt number, index 16

                    //Get export file name and path
                    saveFileDialogSaveExportFile.InitialDirectory = Properties.Settings.Default.FamousExportFilePath;  //get default path from settings
                    saveFileDialogSaveExportFile.FileName = TruncateString.Truncate2(sExporter, 4) + "_"
                        + sVesselNumber.ToString() + "_Famous_FAPI.xml";
                    saveFileDialogSaveExportFile.ShowDialog();


                    if (saveFileDialogSaveExportFile.FileName != "")  //check if file name is blank
                    {
                        tempfile = saveFileDialogSaveExportFile.FileName;
                    }
                    else  //use default path and name if one not selected
                    {
                        tempfile = Properties.Settings.Default.FamousExportFilePath + "C:\\Famous_Export_File.xml";
                    }

                    saveFileDialogSaveExportFile.Dispose();


                    //This archives the data before export.
                    Archive_Data ad = new Archive_Data(UncombinedImportedDataDataset, ImportSettings, exportFullDataList, ReceiptNumber);

                    if (ad.Store_Data())
                    {  
                        //create export file using WriterExportTextFile object and passing the export line list from the exporter object
                        WriteExportTextFile exportfile = new WriteExportTextFile(FamousDataExporter.ExportList());
                        exportfile.WriteFile(tempfile);
                
                        this.labelExportFile.Text = labelExportFile.Text + tempfile;
                        this.labelExportFile.ForeColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("Data archive failed. Have admin check error log. /n Export file not created.");
                    }

                }
                else
                {
                    FamousExporter FamousDataExporter = new FamousExporter(ImportedDataDataset, ImportSettings, exportDataList);


                    FamousDataExporter.ExportData();
                    ReceiptNumber = FamousDataExporter.GetReceiptNumber();
                    ReUseReceiptNumber = FamousDataExporter.GetReUseReceiptNumber();
                    exportFullDataList.Add(ReUseReceiptNumber.ToString());  //add the flag for reusing an existing receipt number, index 16

                    //Get export file name and path
                    saveFileDialogSaveExportFile.InitialDirectory = Properties.Settings.Default.FamousExportFilePath;  //get default path from settings
                    saveFileDialogSaveExportFile.FileName = TruncateString.Truncate2(sExporter, 4) + "_"
                            + sVesselNumber.ToString() + "_Famous_FAPI.txt";
                    saveFileDialogSaveExportFile.ShowDialog();


                    if (saveFileDialogSaveExportFile.FileName != "")  //check if file name is blank
                    {
                        tempfile = saveFileDialogSaveExportFile.FileName;
                    }
                    else  //use default path and name if one not selected
                    {
                        tempfile = Properties.Settings.Default.FamousExportFilePath + "C:\\Famous_Export_File.txt";
                    }

                    saveFileDialogSaveExportFile.Dispose();


                    //This archives the data before export.  If it fails, export file is not created.
                    Archive_Data ad = new Archive_Data(UncombinedImportedDataDataset, ImportSettings, exportFullDataList, ReceiptNumber);

                    if (ad.Store_Data())
                    {
                        //create export file using WriterExportTextFile object and passing the export line list from the exporter object
                        WriteExportTextFile exportfile = new WriteExportTextFile(FamousDataExporter.ExportList());
                        exportfile.WriteFile(tempfile);

                        // MessageBox.Show("Export file: " + tempfile + " has been created");  //Show path and name of created file
                        this.labelExportFile.Text = labelExportFile.Text + tempfile;
                        this.labelExportFile.ForeColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("Data archive failed. Have admin check error log. /n Export file not created.");
                    }


                }

                this.buttonAdamsExport.Enabled = true;
                this.adamsToolStripMenuItem.Enabled = true;
            }
            else  //not all dropdowns or text boxes selected or filled out.
            {
                MessageBox.Show("Please fill out or select the following: " + notSelectedError
                    + " and try the export again.");
            }

        }

        private void buttonAdamsExport_Click(object sender, EventArgs e)  //Adams Export button clicked
        {
            //Initialize label for Adams export file name and location.
            this.labelExportAdamsFile.Text = "Export File:  ";
            this.labelExportAdamsFile.ForeColor = Color.Black;

            //Translate to Adams Codes with adams translator
            AdamsTranslator TranslateToAdams = new AdamsTranslator(ImportedDataDataset, ImportSettings, AdamsList2Translate);

            //Instantiate new Adams export to excel object
            AdamsExportToExcel ae = new AdamsExportToExcel(TranslateToAdams.TranslateData(), ImportSettings, exportFullDataList);
            if (!ae.WasExported()) //if export was sucessful
            {
                MessageBox.Show("The Export could not be completed.");
                return;
                
            }
            labelExportAdamsFile.Text = labelExportAdamsFile.Text + ae.excelFileName();  //set the label to the path and file name of exported file for Adams
            labelExportAdamsFile.ForeColor = Color.Green;
        }

        private void adamsToolStripMenuItem_Click(object sender, EventArgs e)  //Export Adams menu item selected
        {
            this.labelExportAdamsFile.Text = "Export File:  ";
            this.labelExportAdamsFile.ForeColor = Color.Black;

            //Translate to Adams Codes with adams translator
            AdamsTranslator TranslateToAdams = new AdamsTranslator(ImportedDataDataset, ImportSettings, AdamsList2Translate);

            AdamsExportToExcel ae = new AdamsExportToExcel(TranslateToAdams.TranslateData(), ImportSettings, exportFullDataList);
            if (!ae.WasExported())
            {
                MessageBox.Show("The Export could not be completed.");
                return;

            }
            labelExportAdamsFile.Text = labelExportAdamsFile.Text + ae.excelFileName();
            labelExportAdamsFile.ForeColor = Color.Green;
        }


        private void ExportToAdams()  
        {
    //*************** Export code for Adams export when exporting to the text file in their online spec. **************************
    //*************** Currently this is not used and is kept only for future reference if it is ever needed. **********************
            string tempfile; //export file name variable

            //Translate to Adams Codes
            AdamsTranslator TranslateToAdams = new AdamsTranslator(ImportedDataDataset, ImportSettings, AdamsList2Translate);

            //Create Adams Exporter
            AdamsExporter ExportAdams = new AdamsExporter(TranslateToAdams.TranslateData(), ImportSettings, exportFullDataList);
            ExportAdams.ExportData();

            //Get export file name and path
            saveFileDialogSaveExportFile.InitialDirectory = Properties.Settings.Default.AdamsExportFilePath;  //get default path from settings
            saveFileDialogSaveExportFile.FileName = saveFileDialogSaveExportFile.FileName = TruncateString.Truncate2(sExporter, 4) + "_"
                    + sVesselNumber.ToString() + "_Export.txt";
            saveFileDialogSaveExportFile.ShowDialog();


            if (saveFileDialogSaveExportFile.FileName != "")  //check if file name is blank
            {
                tempfile = saveFileDialogSaveExportFile.FileName;
            }
            else  //use default path and name if one not selected
            {
                tempfile = Properties.Settings.Default.AdamsExportFilePath + "\\_Export_File.txt";
            }

            saveFileDialogSaveExportFile.Dispose();

            //create export file using WriterExportTextFile object
            WriteExportTextFile exportfile = new WriteExportTextFile(ExportAdams.ExportList());
            exportfile.WriteFile(tempfile);


            MessageBox.Show("Export file: " + tempfile + " has been created");  //Show path and name of created file
           
        }
        //******** end of  old ExportToAdams *******************************************************************************************

        
        //Translate transaction type to code.  Data bound dropdowns can only hold text and not a description and code.
        private void comboBoxTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxTransactionType.Text))
            {
                if (comboBoxTransactionType.Text == "Packing")
                {
                    sTransactionType = "2";
                }
                else
                {
                    sTransactionType = "1";
                }
                           
            }
            else
            {
                sTransactionType = "1";  //default value
            }

        }


        private void buttonValidate_Click(object sender, EventArgs e)   //Clicking validation button
        {
            //Disable export buttons until validated, except in test mode.
            if (Properties.Settings.Default.Mode == "Test")
            {  
                this.buttonFamousExport.Enabled = true;
                this.exportToolStripMenuItem.Enabled = true;
                this.famousToolStripMenuItem.Enabled = true;
                this.adamsToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.buttonAdamsExport.Enabled = false;
                this.buttonFamousExport.Enabled = false;
                this.exportToolStripMenuItem.Enabled = false;
                this.famousToolStripMenuItem.Enabled = false;
                this.adamsToolStripMenuItem.Enabled = false;
            }


            DataGridViewCellStyle CellStyleInvalidData = new DataGridViewCellStyle();
            CellStyleInvalidData.BackColor = Color.Red;  //back color for invalid date

            DataGridViewCellStyle CellStyleValidData = new DataGridViewCellStyle();
            CellStyleValidData.BackColor = Color.Empty;  //back color for valid or unvalidated data

            if (InvalidItemList.Count > 0)
            {
                foreach (DataItemLocation il in InvalidItemList)  //sets all invalid cells to red
                {
                    dataGridViewExcel.Rows[il.Row].Cells[il.Column].Style = CellStyleValidData;
                }
            }

            //Instantiate the Data Validation object
            DataValidation ValidateData = new DataValidation(ImportedDataDataset, ImportSettings, List2Validate);
            if (ValidateData.Validate()) //enable export buttons only if imported excel file passed validation, except in test mode
            {

                this.buttonFamousExport.Enabled = true;
                this.exportToolStripMenuItem.Enabled = true;
                this.famousToolStripMenuItem.Enabled = true;
                this.adamsToolStripMenuItem.Enabled = false;

                string tempString = "";
                for (int i = 0; i < List2Validate.Count; i++)
                {
                    tempString = tempString + List2Validate[i].ToString() + ", ";
                }

                MessageBox.Show("All of the following items: " + tempString + " passed validation.", "Smiles!");
            }
            else
            {
                InvalidItemList = ValidateData.ListofInvalidItemLocations();
                foreach (DataItemLocation il in InvalidItemList)
                {
                    dataGridViewExcel.Rows[il.Row].Cells[il.Column].Style = CellStyleInvalidData;  //set background to red for invalid data cells
                }
                   
                MessageBox.Show("There are " + InvalidItemList.Count.ToString() + " items that failed validation.  Hatch and Deck are optional, "
                                   + "click <Validate> again to clear them.  "
                                   + "Tag Number will fail if longer than 12 characters or if it exists already in Famous.");  //show number of cells that failed

                if (Properties.Settings.Default.Mode.ToString() == "Test")
                {
                    this.buttonFamousExport.Enabled = true;
                    this.exportToolStripMenuItem.Enabled = true;
                    this.famousToolStripMenuItem.Enabled = true;
                    this.adamsToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.buttonFamousExport.Enabled = false;
                    this.exportToolStripMenuItem.Enabled = false;
                    this.famousToolStripMenuItem.Enabled = false;
                    this.adamsToolStripMenuItem.Enabled = false;
                }
            }
            
        }
// old translation button
        private void buttonTranslate_Click(object sender, EventArgs e)  //Translate button clicked
        {

            if (!string.IsNullOrEmpty(sGrowerBlock))
            {
                //Instantiate Data Translation object for the Famous export
                DataTranslator ImportDataTranslator = new DataTranslator(ImportedDataDataset, ImportSettings, List2Translate, sGrowerBlock);
                ImportedDataDataset = ImportDataTranslator.TranslateData(); //set the imported dataset to the translated data
       

                dataGridViewExcel.DataSource = ImportedDataDataset.Tables[0].DefaultView; //show in datagrid view

                UncombinedImportedDataDataset = ImportedDataDataset.Copy();  //make a copy for export before any changes are made

                labelTranslated.Text = "Data has been translated";
                labelTranslated.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Please select a Grower from the Grower list."); //A grower must be selected to do a translation
            }
        }


        //textboxes text changed
        private void textBoxPalletPrefix_TextChanged(object sender, EventArgs e)
        {
            sPalletPrefix = textBoxPalletPrefix.Text.Trim();
            if (sPalletPrefix.Length > 3)
                {        
                MessageBox.Show("Prefix must be 3 or fewer characters.", "Warning!");
                textBoxPalletPrefix.Text = sPalletPrefix = sPalletPrefix.Trim().Substring(0, 3); 
                }
        }

        private void textBoxDepartureDate_TextChanged(object sender, EventArgs e)
        {
            sDepartureDate = textBoxDepartureDate.Text.Trim();
        }

        private void textBoxVesselNumber_TextChanged(object sender, EventArgs e)
        {
            sVesselNumber = textBoxVesselNumber.Text.Trim();
           
        }

        private void textBoxVesselName_TextChanged(object sender, EventArgs e)
        {
            sVesselName = textBoxVesselName.Text.Trim();
            textBoxVesselNumber.Text = UppercaseWords.Uppercase(sVesselNumber);
        }

        private void textBoxDestination_TextChanged(object sender, EventArgs e)
        {
            sDestination = textBoxDestination.Text.Trim();
        }

        private void textBoxExporter_TextChanged(object sender, EventArgs e)
        {
            //sExporter = textBoxExporter.Text.Trim();  //Use text in text box
            sGrowerBlock = comboBoxGrowerBlock.SelectedValue.ToString();  //Use export dropdown
        }


        //Bring up about box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxFAPI_Import abx = new AboutBoxFAPI_Import();
            abx.ShowDialog();
            abx.Dispose();
        }

        //future placeholder for help
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help is currently not available.");
        }


        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.grower_Block_ID_CodesTableAdapter1.FillBy(this.applicationSettingsDataSetGrowersBlock.Grower_Block_ID_Codes);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.inventory_Warehouse_CodesTableAdapter.FillBy(this.applicationSettingsDataSetWarehouseCodes.Inventory_Warehouse_Codes);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //Edit Translation-Validation Table
        private void translationValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Translation and validation form
            Translation_Validation_Table_Editor Translation_ValidationEditorform = new Translation_Validation_Table_Editor();
            Translation_ValidationEditorform.ShowDialog();

            Translation_ValidationEditorform.Dispose();

        }

        //Edit Warehouses
        private void wareHousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Warehouse Editor form
            Warehouse_Editor Warehouse_Editor_Form = new Warehouse_Editor();
            Warehouse_Editor_Form.ShowDialog();

            Warehouse_Editor_Form.Dispose();
        }

        //Edit Regions
        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open RegionEditorform
            RegionEditor RegionEditor_Form = new RegionEditor();
            RegionEditor_Form.ShowDialog();

            RegionEditor_Form.Dispose();
        }

        //Edit Growers
        private void growersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Grower Editor
            GrowerEditor GrowerEditor_Form = new GrowerEditor();
            GrowerEditor_Form.ShowDialog();

            GrowerEditor_Form.Dispose();
        }

        //update templates
        private void templatesToolStripMenuItem1_Click(object sender, EventArgs e)  //update template menu item selected
        {
            //Open templateform and get the template name
            Import_Template_Editor Import_Template_Editor_Form = new Import_Template_Editor();
            Import_Template_Editor_Form.ShowDialog();

            Import_Template_Editor_Form.Dispose();

        }

      

        //Update tables with Famous Data from the oracle database for Famous which is linked
        //to the applicationsettings SQL database.
        private void updateTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //update the application data tables from Famous database
            using (SqlConnection sqlConnection =
                new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 Returncode;

                        cmd.CommandText = "sp_Get_Data_From_Famous_And_Update_Tables2";  //this is the stored procedure on the server
                        cmd.CommandType = CommandType.StoredProcedure;                  //to get the famous data and update the tables
                        cmd.Connection = sqlConnection;

                        sqlConnection.Open();

                        Returncode = cmd.ExecuteNonQuery();

                        if (Returncode == -1)
                        {
                            MessageBox.Show("The table updates for the Upload Manifest Application have been made.", "Update Succeeded!");
                        }
                        else
                        {
                            MessageBox.Show("The table updates for the Upload Manifest Application Could not be made.", "Update Failed!");
                        }
                  }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("The updates to the Upload Manifest Application tables had an error.  \n", "Update Failed!");
                    Error_Logging el = new Error_Logging("The updates tot he Upload Mafifest Application had an error. \n" + ex);
                }

            }
        }

        //Edit the Adams translation table.
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Open Adams Codes Editor form
            Adams_Codes_Editor Adams_Codes_Editor_Form = new Adams_Codes_Editor();
            Adams_Codes_Editor_Form.ShowDialog();

            Adams_Codes_Editor_Form.Dispose();

        }

        private void updateTranslationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open translations Editor form
            FrmGrowerCodeTranslation Grower_Codes_Translation_Form = new FrmGrowerCodeTranslation();
            Grower_Codes_Translation_Form.ShowDialog();

            Grower_Codes_Translation_Form.Dispose();
        }


        private void stoneFruitListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open StoneFruitLIstform
            StoneFruitList StoneFruitList_Form = new StoneFruitList() ;
            StoneFruitList_Form.ShowDialog();

            StoneFruitList_Form.Dispose();
        }
      // New translation action
        private void Button4Transalation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sGrowerBlock))
            {
                //Instantiate Data Translation object for the Famous export
                DataTranslatorByGrower ImportDataTranslatorbyGrower = new DataTranslatorByGrower(ImportedDataDataset, ImportSettings, List2Translate, sGrowerBlock, sPalletPrefix);
                ImportedDataDataset = ImportDataTranslatorbyGrower.TranslateData(); //set the imported dataset to the translated data

                if (ImportedDataDataset.Tables.Count > 0)
                {
                    dataGridViewExcel.DataSource = ImportedDataDataset.Tables[0].DefaultView; //show in datagrid view

                    UncombinedImportedDataDataset = ImportedDataDataset.Copy();  //make a copy for export before any changes are made

                    labelTranslated.Text = "Data has been translated";
                    labelTranslated.ForeColor = Color.Green;
                }
            }
            else
            {
                MessageBox.Show("Please select a Grower from the Grower list."); //A grower must be selected to do a translation
            }
        }

        private void templateCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open templateform and get the template name
            TemplateCreator Template_Creator_Form = new TemplateCreator();
            Template_Creator_Form.ShowDialog();

            Template_Creator_Form.Dispose();

        }

        private void exportCodeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Adams Codes Editor form
            Adams_Codes_Editor Adams_Codes_Editor_Form = new Adams_Codes_Editor();
            Adams_Codes_Editor_Form.ShowDialog();

        }

        private void menuStripExportApp_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
       
    }
}
