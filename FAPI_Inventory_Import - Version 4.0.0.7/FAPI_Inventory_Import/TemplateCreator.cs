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
    public partial class TemplateCreator : Form
    {
       //Template location variables.
      string sTemplateName;
      int ExporterRow = -1;
      int ExporterColumn = -1;
      int DepartureDateRow = -1;
      int DepartureDateColumn = -1;
      int VesselNumberRow = -1;
      int VesselNumberColumn = -1;
      int VesselNameRow = -1;
      int VesselNameColumn = -1;
      int DestinationRow = -1;
      int DestinationColumn = -1;
      int PrefixRow = -1;
      int Prefix = -1;
      int TagNumberRow = -1;
      int TagNumberColumn = -1;
      int CommodityRow = -1;
      int CommodityColumn = -1;
      int VarietyRow = -1;
      int VarietyColumn = -1;
      int StyleRow = -1;
      int StyleColumn = -1;
      int SizeRow = -1;
      int SizeColumn = -1;
      int GradeRow = -1;
      int GradeColumn = -1;
      int LabelRow = -1;
      int LabelColumn = -1;
      int PalletTypeRow = -1;
      int PalletTypeColumn = -1;
      int InventoryQuantityRow = -1;
      int InventoryQuantityColumn = -1;
      int FirstPackDateRow = -1;
      int FirstPackDateColumn = -1;
      int GrowerNumberRow = -1;
      int GrowerNumberColumn = -1;
      int HatchRow = -1;
      int HatchColumn = -1;
      int DeckRow = -1;
      int DeckColumn = -1;
      int FumigatedRow = -1;
      int FumigatedColumn = -1;
      int BillOfLadingRow = -1;
      int BillOfLadingColumn = -1;
      int MemoRow = -1;
      int MemoColumn = -1;
      int PackCodeRow = -1;
      int PackCodeColumn = -1;
      int Custom_Columns = -1;
      int Other = 0;
      string DataSheet;
      string DataRange;
      string SpecialProcessing = "None";

     // int TemplateIDX = -1;

      int TempRow = 0;
      int TempColumn = 0;
      string TempColumnName = "";

      int dataSectionOffset = 0;

      bool NextPressed = true;
      bool BackPressed = false;

      string TempFieldName = "";
      bool GrowerBlockAdded = false;

     // bool Editing = false;

      bool CustomColumnsNotSet = true;

      DataTable TemplateFields;
      Int32 FieldIndex = -1;
      DataSet ExcelSheetDataSet = new DataSet();

      DataSet TempImportTemplateDataSet = new DataSet();
      DataTable TempTemplateTable = new DataTable();
      DataSet ImportTemplateEditorDataSet = new DataSet();  //dataset for the Import Template Settings table
      SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
      SqlDataAdapter ImportTemplateEditorDataAdaptor = null;  //DataAdaptor for the Import Template Settings table
      SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
      SqlCommand QueryCommand = null;  //query string

    

        public TemplateCreator()
        {
            InitializeComponent();
            DataRow dr;
            TemplateFields = new DataTable();
            TemplateFields.Columns.Add("FieldName", typeof(string));
            TemplateFields.Columns.Add("DataSection", typeof(bool));
            dr = TemplateFields.NewRow();  // 0
            dr[0] = "Exporter";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 1
            dr[0] = "Departure Date";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 2
            dr[0] = "Vessel Number";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 3
            dr[0] = "Vessel Name";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 4
            dr[0] = "Destination";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 5
            dr[0] = "Prefix";
            dr[1] = false;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 6
            dr[0] = "Tag Number";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 7
            dr[0] = "Commodity";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 8
            dr[0] = "Variety";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 12
            dr[0] = "Label";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 22
            dr[0] = "Pack Code";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 11
            dr[0] = "Grade";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 15
            dr[0] = "Pack Date";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 16
            dr[0] = "Grower Number";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow(); // 14
            dr[0] = "Quantity/Count";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow(); // 17
            dr[0] = "Hatch";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 18
            dr[0] = "Deck";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 19
            dr[0] = "Fumigated";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 20
            dr[0] = "Bill of Lading";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 13
            dr[0] = "Pallet Type";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 21
            dr[0] = "Memo";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 9
            dr[0] = "Style";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 10
            dr[0] = "Size";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
           
            dr = TemplateFields.NewRow();  // 23
            dr[0] = "Left Upper Data Section Cell";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();  // 24
            dr[0] = "Last Right Column of Data";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);
            dr = TemplateFields.NewRow();
            dr[0] = "Done";
            dr[1] = true;
            TemplateFields.Rows.Add(dr);

            FieldIndex = -1;

            bDelete.Enabled = false;
            bEdit.Enabled = false;
 
        }

        private void bLoadExcelFile_Click(object sender, EventArgs e)
        {
            RestartClear();
            GetExcelFile();
            lMissingColumnsValue.Text = "Custom Code: ";
            
        }

        public void GetExcelFile()
        {
  
                dataGridViewExcel2.Columns.Clear();
                ExcelSheetDataSet = new DataSet();  //Set to new clear dataset before importing new excel file
                this.dataGridViewExcel2.Update();

                //Get excel file
                openFileDialogExcel.InitialDirectory = Properties.Settings.Default.ImportExcelFilePath; //get default path from settings
            
            DialogResult result = openFileDialogExcel.ShowDialog();  //open file dialog for excel file

            if (result == DialogResult.OK)  //only try to open excel file if open dialog <OK> button was clicked.
                {                           //ignore if cancel is clicked or window is closed.

                    string fileName = openFileDialogExcel.FileName; // get file path and name from the dialog box.
                    labelCurrentFile.Text = fileName.ToString() + " Excel file opened.";  //show file path and name as label

                    //**********************************  Get the  data sheet name from the list of all datasheets.
                    frmSelectDataSheet SelectExcelSheet = new frmSelectDataSheet(fileName);

                    DialogResult SheetSelectResult = SelectExcelSheet.ShowDialog();

                    if (SheetSelectResult == DialogResult.OK)  //used clicked OK
                    {
                        DataSheet = SelectExcelSheet.DataSheetName();

                    }
                    else  // window closed
                    {
                        DataSheet = "Data$";
                        MessageBox.Show("The default data sheet: Data$, will be used.");

                    }

                    tbDataSheet.Text = DataSheet;

                    SelectExcelSheet.Dispose();


                    //*************************************

                    labelCurrentFile.ForeColor = Color.Green;  //make it green to show it was opened.

                    try
                    {  //Load entire datasheet into dataset to get vessel information which could be anywhere

                        ExcelSheetDataSet = new DataSet();  //set to new dataset to clear an previous schema settings and data

                        OleDbConnectionStringBuilder connStringBuilder =  //use OleDbConnection to get excel data
                        new OleDbConnectionStringBuilder();

                        connStringBuilder.DataSource = fileName;  // Set path to excel file
                        connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                        connStringBuilder.Add("Extended Properties", "Excel 8.0;HDR=NO;IMEX=1");

                        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

                        DbDataAdapter adapter = factory.CreateDataAdapter();

                        DbCommand selectCommand = factory.CreateCommand();
                        selectCommand.CommandText = String.Format("select * from [" + DataSheet + "]");  //Data from entire datasheet

                        DbConnection connection = factory.CreateConnection();
                        connection.ConnectionString = connStringBuilder.ToString();
                        selectCommand.Connection = connection;
                        adapter.SelectCommand = selectCommand;
                        adapter.Fill(this.ExcelSheetDataSet);

                      

                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading excel file to template creator. \n" +
                            "Verify that the worksheet name is Data"  +
                            " Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading excel file to template creator. \n" + exceptioncode);

                        return;
                    }
              

                    try  //Load the imported spreadsheeting
                    {
                        dataGridViewExcel2.DataSource = ExcelSheetDataSet.Tables[0].DefaultView;
                        //dataGridViewExcel2.Columns[1].Visible = false;
                        
                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error loading datagrid viewer. \nNote what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error loading DataGridView. \n" + exceptioncode);
                        return;

                    }

             
                    try
                    {
                        //'Remove empty columns at in dataset table as speadsheets could contain empty columns on the rightside.
                        bool removeColumn = true;
                        for (int h = 15; h < this.ExcelSheetDataSet.Tables[0].Columns.Count; h++)
                        {
                            removeColumn = true;
                            for (int r = 0; r < this.ExcelSheetDataSet.Tables[0].Rows.Count; r++)
                            {
                                if (this.ExcelSheetDataSet.Tables[0].Rows[r][h].ToString().Length > 0)
                                {
                                    removeColumn = false;
                                }
                            }
                            if (removeColumn)
                            {
                                this.ExcelSheetDataSet.Tables[0].Columns.RemoveAt(h);
                            }

                        }

                     ;
  
                        ExcelSheetDataSet.AcceptChanges();
                    }

                    catch (Exception exceptioncode)
                    {
                        MessageBox.Show("Error removing blank rows from dataset table. \nNote what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error removing blank rows from dataset table. \n" + exceptioncode);
                        return;

                    }
                
                    GetDataSheetName dsn = new GetDataSheetName();

                   

                }  //end if filedialog <OK> button clicked
            
        }

        private void AddGrowerBlockColumn()
        {

            try
            {

                //Add Grower Block column as it is assumed to not be in any spreadsheet
                DataColumn Col = ExcelSheetDataSet.Tables[0].Columns.Add("Grower Block", typeof(String));
                Col.SetOrdinal(1);// to put the column in position 1;
                GrowerBlockAdded = true;
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error adding grower block column.  \n" +
                    "note what was done and contact administrator.  \n");
                Error_Logging el = new Error_Logging("Error adding grower blcok column. \n" + exceptioncode);
                GrowerBlockAdded = false;
                return;
            }
        }

        private void dataGridViewExcel2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbRow.Text = "Row: " + dataGridViewExcel2.CurrentCell.RowIndex.ToString();
            TempRow = dataGridViewExcel2.CurrentCell.RowIndex;
            TempColumn = dataGridViewExcel2.CurrentCell.ColumnIndex;
            TempColumnName = dataGridViewExcel2.Columns[TempColumn].Name;
            lbColumn.Text = "Column: " + TempColumnName;
            
            

          
            //code to set the row and column indexes
            if (FieldIndex > 0)
            {
                bBack.Enabled = true;
                if (bStart.Enabled == false & !Convert.ToBoolean(TemplateFields.Rows[FieldIndex - 1][1]))
                {
                    switch (FieldIndex)
                    {
                        case 1:
                            ExporterRow = TempRow; 
                            ExporterColumn = TempColumn; 
                            break;
                        case 2:
                            DepartureDateRow = TempRow;  
                            DepartureDateColumn = TempColumn;  
                            break;
                        case 3:
                            VesselNumberRow = TempRow;  
                            VesselNumberColumn = TempColumn;  
                            break;
                        case 4:
                            VesselNameRow = TempRow;  
                            VesselNameColumn = TempColumn;   
                            break;
                        case 5:
                            DestinationRow = TempRow;   
                            DestinationColumn = TempColumn;   
                            break;
                        case 6:
                            PrefixRow = TempRow;   
                            Prefix = TempColumn;   

                            if (!GrowerBlockAdded)
                            {
                                AddGrowerBlockColumn();
                                GrowerBlockAdded = true;
                                dataGridViewExcel2.Columns[1].Visible = false;
                                dataGridViewExcel2.Refresh();
                            }
                            if (CustomColumnsNotSet)
                                {
                                    AddCustomColumns(Custom_Columns);
                                    CustomColumnsNotSet = false;
                                }
                            dataGridViewExcel2.ClearSelection();
                            dataGridViewExcel2.Refresh();
                            break;

                        default:
                            break;

                    }
                    bStart.Enabled = true;
                }
                if (bStart.Enabled == false & Convert.ToBoolean(TemplateFields.Rows[FieldIndex - 1][1]))
                {
                    bBack.Enabled = true;
                    switch (FieldIndex)
                    {
                        case 7:
                            TagNumberRow = TempRow - dataSectionOffset;   
                            dataSectionOffset = TempRow;
                            TagNumberColumn = TempColumn;   
                            TagNumberRow = 0;  // this is the first data row of all sheets
                            break;
                        case 8:
                            CommodityRow = TempRow - dataSectionOffset;   
                            CommodityColumn = TempColumn;   
                            break;
                        case 9:
                            VarietyRow = TempRow - dataSectionOffset;   
                            VarietyColumn = TempColumn;   
                            break;
                        case 10:
                            LabelRow = TempRow - dataSectionOffset;   
                            LabelColumn = TempColumn;   
                            break;
                        case 11:
                            PackCodeRow = TempRow - dataSectionOffset;   
                            PackCodeColumn = TempColumn;   
                            break;
                        case 12:
                            GradeRow = TempRow - dataSectionOffset;   
                            GradeColumn = TempColumn;   
                            break;
                        case 13:
                            FirstPackDateRow = TempRow - dataSectionOffset;   
                            FirstPackDateColumn = TempColumn;   
                            break;
                        case 14:
                            GrowerNumberRow = TempRow - dataSectionOffset;   
                            GrowerNumberColumn = TempColumn;   
                            break;
                        case 15:
                            InventoryQuantityRow = TempRow - dataSectionOffset;   
                            InventoryQuantityColumn = TempColumn;   
                            break;
                        case 16:
                            HatchRow = TempRow - dataSectionOffset;   
                            HatchColumn = TempColumn;   
                            break;
                        case 17:
                            DeckRow = TempRow - dataSectionOffset;   
                            DeckColumn = TempColumn;   
                            break;
                        case 18:
                            FumigatedRow = TempRow - dataSectionOffset;   
                            FumigatedColumn = TempColumn;   
                            break;
                        case 19:
                            BillOfLadingRow = TempRow - dataSectionOffset;   
                            BillOfLadingColumn = TempColumn;   
                            break;
                        case 20:
                            PalletTypeRow = TempRow - dataSectionOffset;   
                            PalletTypeColumn = TempColumn;   
                            break;
                        case 21:
                            MemoRow = TempRow - dataSectionOffset;   
                            MemoColumn = TempColumn;   
                            break;
                        case 22:
                            StyleRow = TempRow - dataSectionOffset;   
                            StyleColumn = TempColumn;   
                            break;
                        case 23:
                            SizeRow = TempRow - dataSectionOffset;   
                            SizeColumn = TempColumn;   
                            break;
                        case 24:
                            DataRange = GetExcelColumnName.FromColumnNumber(TempColumn);
                            DataRange = DataRange + TempRow.ToString();
                            tbDataRange.Text = DataRange;
                            break;
                        case 25:
                            DataRange = DataRange + ":";
                            DataRange = DataRange + GetExcelColumnName.FromColumnNumber(TempColumn);
                            tbDataRange.Text = DataRange;
                            break;
                        default:
                            bBack.Enabled = false;
                            break;
                    }
                }

                bStart.Enabled = true;
            }
            bStart.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sTemplateName = tbTemplateName.Text;
  
        }

        private bool CheckTemplateName(string name)
        {
            if(GetTemplate(tbTemplateName.Text))
            {
                return false;
            }

            return true;
        }

        private void bCheckName_Click(object sender, EventArgs e)
        {
            //Make template name box green of OK to use and red if not
            if (CheckTemplateName(sTemplateName) & tbTemplateName.Text.Length > 0)
            {
                tbTemplateName.BackColor = Color.LightGreen;
                tbTemplateName.ForeColor = Color.Black;
            }
            else
            {
                tbTemplateName.BackColor = Color.Red;
                tbTemplateName.ForeColor = Color.Blue;
            }
            
        }

      

        private void SetCustomColumns()  //sets the custum columns code
        {
            Double Exponet = 0;
            Double tempCustomColumns = 0;
            Custom_Columns = 0;

          

            for (int i = 0; i < lbMissingColumns.SelectedItems.Count; i++)
            {
                Exponet = Convert.ToDouble(lbMissingColumns.SelectedIndices[i]);
                tempCustomColumns = tempCustomColumns + Math.Pow(2.0, Exponet);
            }
            Custom_Columns = Convert.ToInt32(tempCustomColumns);
           
        }

        private void bSetMissingColumnsCode_Click(object sender, EventArgs e)
        {
            if (RemoveAddedColumns(Custom_Columns)) //Check to see if custom columns were already added and if so remove them
            {                                         //returns true when done
                SetCustomColumns();
                lMissingColumnsValue.Text = "Custom Code: " + Custom_Columns.ToString();
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            //Code to start template creation
            NextPressed = true;
            bStart.Enabled = false;
            bBack.Enabled = false;
            if(BackPressed)
            {
                FieldIndex++;
                BackPressed = false;
            }
            if (FieldIndex <= 0)
            {
                bStart.Text = "Next";
                FieldIndex = 0;
                
            }
            if (FieldIndex >= 0 & TempFieldName.Length > 0)
            {
                RemoveCompletedField(TempFieldName);
                TempFieldName = TempFieldName + " (" + TempRow.ToString()  
                    + ", " + TempColumnName + ")"; 

                lbRow.Text = "Row: " + TempRow.ToString();   
                lbColumn.Text = "Column: " + TempColumnName;   
                AddCompletedField(TempFieldName);
            }
            if (FieldIndex >= 0)
            {
                lFieldName.Text = TemplateFields.Rows[FieldIndex][0].ToString();
            }
            if (FieldIndex >= 0)
            {
                TempFieldName = lFieldName.Text;
            }
           
            if (FieldIndex == TemplateFields.Rows.Count -1)
            {
                lTemplateIndex.Text = "Completed";
                lTemplateIndex.Font = new Font(lTemplateIndex.Font, FontStyle.Bold);
                lTemplateIndex.ForeColor = Color.Green;
                bBack.Enabled = false;

                return;
            }
            if (FieldIndex >= 24)  //disable back button when done
            {
                bBack.Enabled = false;
            }
           
            lTemplateIndex.Text = "Step " + FieldIndex.ToString() + " of " + (TemplateFields.Rows.Count - 1).ToString();
            FieldIndex++;
        }

        private void bRestart_Click(object sender, EventArgs e)
        {
            RestartClear();
        }


        private void tbDataSheet_TextChanged(object sender, EventArgs e)
        {
            if (tbDataSheet.Text.Length > 0)
            {
                DataSheet = tbDataSheet.Text;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSaveExit_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                MessageBox.Show("Template has been saved, continue with exit.");
            }
            else
            {
                return;
            }
            this.Close();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            //Open templateform edit form to edit a template directly from the table.
            Import_Template_Editor Import_Template_Editor_Form = new Import_Template_Editor();
            Import_Template_Editor_Form.ShowDialog();

            Import_Template_Editor_Form.Dispose();
            
           
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected template record?", "Warning!",      
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string DeleteStoredProcedure;

                /*
               if (false)         //Properties.Settings.Default.Mode == "Test")  Use production table even in test mode
                {
                    DeleteStoredProcedure = "[DeleteTemplateTest]";
                }
                else
                {
                    DeleteStoredProcedure = "[DeleteTemplate]";
                }
                 */

                DeleteStoredProcedure = "[DeleteTemplate]";

                try
                {

                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlCommand Command = new SqlCommand();
                    SqlParameter ParamDetailsID;  //Parameter to pass DetailsID to DeleteTranslationDetail sp
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);                  
                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = DeleteStoredProcedure;   // Stored procedure to delete selected record
                    ParamDetailsID = new SqlParameter("@Template_Name", tbSelectedTemplate.Text);
                    ParamDetailsID.Direction = ParameterDirection.Input;
                    ParamDetailsID.DbType = DbType.String;
                    Command.Parameters.Add(ParamDetailsID);
                    Command.ExecuteNonQuery();
                    conn.Close();

                   
                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to delete template record.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to delete template record. \n" + exp);
                    return;
                }
                ViewTemplates();

            }
            else
            {
                return;
            }

        }

        private void bView_Click(object sender, EventArgs e)
        {
            //View all templates code here
            ViewTemplates();
            bDelete.Enabled = true;
            bEdit.Enabled = true;
            lTemplateSelected.Visible = true;
            tbSelectedTemplate.Visible = true;
        }
        private void ViewTemplates()
        {
            try
            {
                ImportTemplateEditorDataSet = new DataSet();
                //get Import Templates table data from database
                /*
                if (false)              //  Properties.Settings.Default.Mode == "Test")  Use production table always
                {
                    QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates_Test", conn);
                }
                else
                {
                    QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates", conn);
                }
                 */

                QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates", conn);

                ImportTemplateEditorDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(ImportTemplateEditorDataAdaptor);

                ImportTemplateEditorDataAdaptor.Fill(ImportTemplateEditorDataSet);


                conn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the import template table for editing.  \n" +
                    "Check your internet connection and verify that the database server is online.  \n" +
                 " Note what happened and contact administrator for help.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Import template table for editing.  \n" + ex);
                conn.Close();
                ImportTemplateEditorDataSet.Dispose();

            }

            try  //Load the import template data into datagrid
            {
                this.dgvTemplatesView.DataSource = ImportTemplateEditorDataSet.Tables[0];
                dgvTemplatesView.Visible = true;
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Import Template datagrid for edit. \n");
                Error_Logging el = new Error_Logging("Error loading Import Template datagrid for edit. \n" + exceptioncode);


            }
        }


        private bool SaveChanges()
        {
            StringBuilder MissingTemplateData = new StringBuilder();  //list to hold the name of dropdowns/variables and text boxes not populated
            //for missing message box
            if (String.IsNullOrEmpty(sTemplateName))
            {
                MissingTemplateData.Append("Template Name, ");  //add to missing list
            }
            if ((ExporterColumn == -1))
            {
                MissingTemplateData.Append(" Exporter, ");  //add to missing list
            }
            if ((DepartureDateColumn == -1))
            {
                MissingTemplateData.Append("  Departure Date, ");  //add to missing list
            }
            if ((VesselNumberColumn == -1))
            {
                MissingTemplateData.Append(" Vessel Number, ");  //add to missing list
            }
            if ((VesselNameColumn == -1))
            {
                MissingTemplateData.Append(" Vessel Name, ");  //add to missing list
            }
            if ((DestinationColumn == -1))
            {
                MissingTemplateData.Append(" Destination, ");  //add to missing list
            }
            if ((Prefix == -1))
            {
                MissingTemplateData.Append(" Prefix, ");  //add to missing list
            }
            if ((TagNumberColumn == -1))
            {
                MissingTemplateData.Append(" Tag Number, ");  //add to missing list
            }
            if ((CommodityColumn == -1))
            {
                MissingTemplateData.Append(" Commodity, ");  //add to missing list
            }
            if ((VarietyColumn == -1))
            {
                MissingTemplateData.Append(" Variety, ");  //add to missing list
            }
            if ((StyleColumn == -1))
            {
                MissingTemplateData.Append(" Style, ");  //add to missing list
            }
            if ((SizeColumn == -1))
            {
                MissingTemplateData.Append(" Size, ");  //add to missing list
            }
            if ((GradeColumn == -1))
            {
                MissingTemplateData.Append(" Grade, ");  //add to missing list
            }
            if ((LabelColumn == -1))
            {
                MissingTemplateData.Append(" Label, ");  //add to missing list
            }
            if ((PalletTypeColumn == -1))
            {
                MissingTemplateData.Append(" Pallet Type, ");  //add to missing list
            }
            if ((InventoryQuantityColumn == -1))
            {
                MissingTemplateData.Append(" Inventory Quantity, ");  //add to missing list
            }
            if ((FirstPackDateColumn == -1))
            {
                MissingTemplateData.Append(" First Pack Date, ");  //add to missing list
            }
            if ((GrowerNumberColumn == -1))
            {
                MissingTemplateData.Append(" Grower Number, ");  //add to missing list
            }
            if ((HatchColumn == -1))
            {
                MissingTemplateData.Append(" Hatch, ");  //add to missing list
            }
            if ((DeckColumn == -1))
            {
                MissingTemplateData.Append(" Deck, ");  //add to missing list
            }
            if ((FumigatedColumn == -1))
            {
                MissingTemplateData.Append(" Fumigated, ");  //add to missing list
            }
            if ((BillOfLadingColumn == -1))
            {
                MissingTemplateData.Append(" Bill of Lading, ");  //add to missing list
            }
            if ((PackCodeColumn == -1))
            {
                MissingTemplateData.Append(" Pack Code, ");  //add to missing list
            }
            if ((MemoColumn == -1))
            {
                MissingTemplateData.Append(" Memo, ");  //add to missing list
            }
            if ((Custom_Columns == -1))
            {
                MissingTemplateData.Append(" Missing Columns, ");  //add to missing list
            }
            if (String.IsNullOrEmpty(DataSheet))
            {
                MissingTemplateData.Append(" DataSheet, ");  //add to missing list
            }
            if (String.IsNullOrEmpty(DataRange))
            {
                MissingTemplateData.Append("Data Range, ");  //add to missing list
            }

            
            //Insert new or update template
            if (MissingTemplateData.Length == 0)  //Check if any required data is missing
            {
                try
                {
                    //Update or add the translation data to GCV-Information and Translation_Details tables
                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlCommand Command = new SqlCommand();

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;

                    /*
                    if (false)                       //   Properties.Settings.Default.Mode == "Test")  //Use production table always
                    {
                        Command.CommandText = "UpdateCreateTemplateTest";
                    }
                    else
                    {
                        Command.CommandText = "UpdateCreateTemplate";
                    }
                     */
                    Command.CommandText = "UpdateCreateTemplate";

                    //parameter and data to save
                    Command.Parameters.Add(new SqlParameter("@Template_Name", sTemplateName));
                    Command.Parameters.Add(new SqlParameter("@ExporterRow", ExporterRow));
                    Command.Parameters.Add(new SqlParameter("@ExporterColumn", ExporterColumn));
                    Command.Parameters.Add(new SqlParameter("@DepartureDateRow", DepartureDateRow));
                    Command.Parameters.Add(new SqlParameter("@DepartureDateColumn", DepartureDateColumn));
                    Command.Parameters.Add(new SqlParameter("@VesselNumberRow", VesselNumberRow));
                    Command.Parameters.Add(new SqlParameter("@VesselNumberColumn", VesselNumberColumn));
                    Command.Parameters.Add(new SqlParameter("@VesselNameRow", VesselNameRow));
                    Command.Parameters.Add(new SqlParameter("@VesselNameColumn", VesselNameColumn));
                    Command.Parameters.Add(new SqlParameter("@DestinationRow", DestinationRow));
                    Command.Parameters.Add(new SqlParameter("@DestinationColumn", DestinationColumn));
                    Command.Parameters.Add(new SqlParameter("@PrefixRow", PrefixRow));
                    Command.Parameters.Add(new SqlParameter("@Prefix", Prefix));
                    Command.Parameters.Add(new SqlParameter("@TagNumberRow", TagNumberRow));
                    Command.Parameters.Add(new SqlParameter("@TagNumberColumn", TagNumberColumn));
                    Command.Parameters.Add(new SqlParameter("@CommodityRow", CommodityRow));
                    Command.Parameters.Add(new SqlParameter("@CommodityColumn", CommodityColumn));
                    Command.Parameters.Add(new SqlParameter("@VarietyRow", VarietyRow));
                    Command.Parameters.Add(new SqlParameter("@VarietyColumn", VarietyColumn));
                    Command.Parameters.Add(new SqlParameter("@StyleRow", StyleRow));
                    Command.Parameters.Add(new SqlParameter("@StyleColumn", StyleColumn));
                    Command.Parameters.Add(new SqlParameter("@SizeRow", SizeRow));
                    Command.Parameters.Add(new SqlParameter("@SizeColumn", SizeColumn));
                    Command.Parameters.Add(new SqlParameter("@GradeRow", GradeRow));
                    Command.Parameters.Add(new SqlParameter("@GradeColumn", GradeColumn));
                    Command.Parameters.Add(new SqlParameter("@LabelRow", LabelRow));
                    Command.Parameters.Add(new SqlParameter("@LabelColumn", LabelColumn));
                    Command.Parameters.Add(new SqlParameter("@PalletTypeRow", PalletTypeRow));
                    Command.Parameters.Add(new SqlParameter("@PalletTypeColumn", PalletTypeColumn));
                    Command.Parameters.Add(new SqlParameter("@InventoryQuantityRow", InventoryQuantityRow));
                    Command.Parameters.Add(new SqlParameter("@InventoryQuantityColumn", InventoryQuantityColumn));
                    Command.Parameters.Add(new SqlParameter("@FirstPackDateRow", FirstPackDateRow));
                    Command.Parameters.Add(new SqlParameter("@FirstPackDateColumn", FirstPackDateColumn));
                    Command.Parameters.Add(new SqlParameter("@GrowerNumberRow", GrowerNumberRow));
                    Command.Parameters.Add(new SqlParameter("@GrowerNumberColumn", GrowerNumberColumn));
                    Command.Parameters.Add(new SqlParameter("@HatchRow", HatchRow));
                    Command.Parameters.Add(new SqlParameter("@HatchColumn", HatchColumn));
                    Command.Parameters.Add(new SqlParameter("@DeckRow", DeckRow));
                    Command.Parameters.Add(new SqlParameter("@DeckColumn", DeckColumn));
                    Command.Parameters.Add(new SqlParameter("@FumigatedRow", FumigatedRow));
                    Command.Parameters.Add(new SqlParameter("@FumigatedColumn", FumigatedColumn));
                    Command.Parameters.Add(new SqlParameter("@BillOfLadingRow", BillOfLadingRow));
                    Command.Parameters.Add(new SqlParameter("@BillOfLadingColumn", BillOfLadingColumn));
                    Command.Parameters.Add(new SqlParameter("@MemoRow", MemoRow));
                    Command.Parameters.Add(new SqlParameter("@MemoColumn", MemoColumn));
                    Command.Parameters.Add(new SqlParameter("@PackCodeRow", PackCodeRow));
                    Command.Parameters.Add(new SqlParameter("@PackCodeColumn", PackCodeColumn));
                    Command.Parameters.Add(new SqlParameter("@Custom_Columns", Custom_Columns));
                    Command.Parameters.Add(new SqlParameter("@Other", Other));
                    Command.Parameters.Add(new SqlParameter("@Data_Sheet", DataSheet));
                    Command.Parameters.Add(new SqlParameter("@Data_Range", DataRange));
                    Command.Parameters.Add(new SqlParameter("@Special_Processing", SpecialProcessing));

                    Command.ExecuteNonQuery();  //run the stored procedure on the SQL server


                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to save template data.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to save template data. \n" + exp);
                    
                    return false;
                }
            }
            else  //not all required are present.
            {
                MessageBox.Show("Please redo the template, the following information is missing: " + MissingTemplateData
                    + " and try saving again.");
                return false;
            }

                return true;
            }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                MessageBox.Show("Template has been saved.");
                ViewTemplates();
            }

        }

        private bool AddCustomColumns(int ColumnCode)
        {

            //*************Add missing columns here for data sheets that has them missing
               try
               {
                        //Process the custom settings number.  Convert to binary and add columns based upon the bits  ********
                        string binary = Convert.ToString(ColumnCode, 2);
                        char[] AddCustomColumn = binary.ToCharArray();
                        Array.Reverse(AddCustomColumn);

                        for (int index = 0; index < AddCustomColumn.Length; index++)
                        {
                            if (index == 0)
                            {
                                if (AddCustomColumn[0] == '1')  //add style-size
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Style", typeof(String));
                                    ExcelSheetDataSet.Tables[0].Columns.Add("PackSize", typeof(String));
                                }
                            }
                            if (index == 1)
                            {
                                if (AddCustomColumn[1] == '1')  //add grade
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Grade", typeof(String));
                                }
                            }
                            if (index == 2)  //add pallet type
                            {
                                if (AddCustomColumn[2] == '1')
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("PalletType", typeof(String));
                                }
                            }
                            if (index == 3)
                            {
                                if (AddCustomColumn[3] == '1')  //add hatch and deck
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Hatch", typeof(String));
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Deck", typeof(String));
                                }
                            }
                           
                            if (index == 4)
                            {
                                if (AddCustomColumn[4] == '1')
                                {               //add commodity column
                                    DataColumn ColCommodity = ExcelSheetDataSet.Tables[0].Columns.Add("Commodity", typeof(String));
                                    ColCommodity.SetOrdinal(2);// to put the column in position 2;
                                }

                            }
                            if (index == 5)
                            {
                                if (AddCustomColumn[5] == '1')
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Fumigation", typeof(String));  //add fumigation column
                                }
                            }
                            if (index == 6)
                            {
                                if (AddCustomColumn[6] == '1')
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("BillOfLading", typeof(String));  //add bill of lading column
                                }
                            }
                            if (index == 7)
                            {
                                if (AddCustomColumn[7] == '1')
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("PackCode", typeof(String));  //add pack code column
                                }
                            }
                            if (index == 8)
                            {
                                if (AddCustomColumn[8] == '1')
                                {
                                    ExcelSheetDataSet.Tables[0].Columns.Add("Memo", typeof(String));  //add Memo column
                                }
                            }
                        }

                        //  ************************************************************************************************************

                        if (tbDataRange.Text == "Pack Date") //for the case of a missing pack date column
                        {
                            ExcelSheetDataSet.Tables[0].Columns.Add("Pack Date", typeof(String));
                        }


                        //**********************************************************************



                    }

                    catch (Exception exCode)
                    {
                        MessageBox.Show("Error adding missing columns. \n" +
                            " Verify that a new spreadsheet has been loaded.  \n" +
                            "Otherwise note what was done and contact administrator.  \n");
                        Error_Logging el = new Error_Logging("Error adding missing columns. \n" + exCode);
                        return false;
                    }

               dataGridViewExcel2.DataSource = ExcelSheetDataSet.Tables[0].DefaultView;
               
            return true;
        }

        private void dgvTemplatesView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedrowindex = dgvTemplatesView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dgvTemplatesView.Rows[selectedrowindex];

            tbSelectedTemplate.Text = selectedRow.Cells[0].Value.ToString();
        }

        private void AddCompletedField(string fn)
        {
            lbFinishedItems.Items.Add(fn);
        }

        private void TemplateCreator_Load(object sender, EventArgs e)
        {

        }

        private bool GetTemplate(string tm)
        {
            //code to get the template
            try
            {
                //get Variety data from database
                string connString = Properties.Settings.Default.ConnectionString;
                SqlDataAdapter TemplateDataAdaptor;
                SqlCommand Command = new SqlCommand();
                SqlParameter TemplateName;  //Parameter to pass commodity to [GetTemplateTest] sp

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                conn.Open();

                Command.Connection = conn;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "GetTemplate";   // Stored procedure to get all Famous varieties for this commodity
                TemplateName = new SqlParameter("@TemplateName", tbTemplateName.Text);
                TemplateName.Direction = ParameterDirection.Input;
                TemplateName.DbType = DbType.String;
                Command.Parameters.Add(TemplateName);

                TempImportTemplateDataSet = new DataSet();

                // create data adapter
                TemplateDataAdaptor = new System.Data.SqlClient.SqlDataAdapter(Command);
                // this will query the database and return the result to your datatable
                TemplateDataAdaptor.Fill(TempImportTemplateDataSet);
                conn.Close();
                TemplateDataAdaptor.Dispose();
                TempTemplateTable = new DataTable(); // table of varities for the selected commodity
                if (TempImportTemplateDataSet.Tables[0] != null)
                {
                    TempTemplateTable = TempImportTemplateDataSet.Tables[0];  //set the variety table
                }
                TempImportTemplateDataSet.Dispose();
            }

            catch (Exception exp)
            {
                MessageBox.Show("There was an error while trying to load the Template data for selected template.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Template data for selected template. \n" + exp);
                TempImportTemplateDataSet.Dispose();
                return false;
            }
            if (TempTemplateTable != null)
            {
                if (TempTemplateTable.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void ShowMissingColumnNames(int mc)
        {
            //Process the custom settings number.  Convert to binary and add columns based upon the bits  ********
            string binary = Convert.ToString(mc, 2);
            char[] AddCustomColumn = binary.ToCharArray();
            Array.Reverse(AddCustomColumn);

            for (int index = 0; index < AddCustomColumn.Length; index++)
            {
                if (index == 0)
                {
                    if (AddCustomColumn[0] == '1')  //style-size
                    {
                        lbMissingColumns.SelectedIndex = 0;
                    }
                }
                if (index == 1)
                {
                    if (AddCustomColumn[1] == '1')  //grade
                    {
                        lbMissingColumns.SelectedIndex = 1;
                    }
                }
                if (index == 2)  //pallet type
                {
                    if (AddCustomColumn[2] == '1')
                    {
                        lbMissingColumns.SelectedIndex = 2;
                    }
                }
                if (index == 3)
                {
                    if (AddCustomColumn[3] == '1')  //hatch and deck
                    {
                        lbMissingColumns.SelectedIndex = 3;
                    }
                }

                if (index == 4)
                {
                    if (AddCustomColumn[4] == '1')
                    {               //commodity column
                        lbMissingColumns.SelectedIndex = 4;
                    }

                }
                if (index == 5)
                {
                    if (AddCustomColumn[5] == '1')
                    {
                        lbMissingColumns.SelectedIndex = 5;
                    }
                }
                if (index == 6)
                {
                    if (AddCustomColumn[6] == '1')
                    {
                        lbMissingColumns.SelectedIndex = 6;
                    }
                }
                if (index == 7)
                {
                    if (AddCustomColumn[7] == '1')
                    {
                        lbMissingColumns.SelectedIndex = 7;
                    }
                }
                if (index == 8)
                {
                    if (AddCustomColumn[8] == '1')
                    {
                        lbMissingColumns.SelectedIndex = 8;
                    }
                }
            }
        }

        private void bBack_Click(object sender, EventArgs e)  //go back one step
        {
            BackPressed = true;
            if(NextPressed)
            {
                FieldIndex--;
                NextPressed = false;
            }

            if (FieldIndex >= 0)
            {
                FieldIndex--;    // only decrease if index is greater than or equal to 0
                
            }
            if (FieldIndex == 0)  // turn off back button if at 0
            {
                bBack.Enabled = false;
            }
            if (FieldIndex < 0)
            {
                bBack.Enabled = false;
                bStart.Enabled = true;
                return;
            }

            lFieldName.Text = TemplateFields.Rows[FieldIndex][0].ToString();
            lTemplateIndex.Text = "Step " + FieldIndex.ToString() + " of " + (TemplateFields.Rows.Count).ToString();
            if (FieldIndex >= 0)
            {
                TempFieldName = lFieldName.Text;
            }
            if (FieldIndex >= 0 & TempFieldName.Length > 0)
            {
                RemoveCompletedField(TempFieldName);
                RemoveCompletedField(TempFieldName);
                CustomColumnsNotSet = true;
                lFieldName.Text = TempFieldName;
                if (TempFieldName == "Exporter")
                {
                    bBack.Enabled = false;
                }
            }

            //when index is less than 7 remove added columns
            if (FieldIndex <= 7)
            {
                RemoveAddedColumns(Custom_Columns);
                if (ExcelSheetDataSet.Tables[0].Columns.Contains("Grower Block"))
                {
                    ExcelSheetDataSet.Tables[0].Columns.Remove("Grower Block");  //Remove Grower Block column if there
                    ExcelSheetDataSet.AcceptChanges();
                    GrowerBlockAdded = false;
                }
                else
                {
                    GrowerBlockAdded = false;
                }
                dataGridViewExcel2.ClearSelection();
                dataGridViewExcel2.Refresh();
            }
            if (FieldIndex == -2)
            {
                dataGridViewExcel2.ClearSelection();
                dataGridViewExcel2.Rows[TempRow].Cells[TempColumn - 2].Selected = true;
                dataGridViewExcel2.Refresh();
            }

            if (FieldIndex == TemplateFields.Rows.Count - 1)
            {
                bBack.Enabled = false;
                return;
            }
            
        }

       

        private void RemoveCompletedField(string fn)  //removes completed fields from finished list
        {

            if (lbFinishedItems.FindString(fn) != -1)
            {
                lbFinishedItems.Items.Remove(lbFinishedItems.Items[lbFinishedItems.FindString(fn)]);
            }
        }

        private bool RemoveAddedColumns(int ColumnCode)  //removes any missing columns that were added when called.
        {
            
                if (ColumnCode == -1)
                {
                    CustomColumnsNotSet = true;  //should already be true first time through, but may not be for reset.
                    return true;
                }
                //code to remove columns here  *********************

                  try
               {
                        //Process the custom settings number.  Convert to binary and add columns based upon the bits  ********
                        string binary = Convert.ToString(ColumnCode, 2);
                        char[] AddCustomColumn = binary.ToCharArray();
                        Array.Reverse(AddCustomColumn);

                        for (int index = 0; index < AddCustomColumn.Length; index++)
                        {
                            if (index == 0)
                            {
                                if (AddCustomColumn[0] == '1')  //Remove style-size
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Style"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Style");
                                    }
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("PackSize"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("PackSize");
                                    }
                                }
                            }
                            if (index == 1)
                            {
                                if (AddCustomColumn[1] == '1')  //Remove grade
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Grade"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Grade");
                                    }
                                }
                            }
                            if (index == 2)  //Remove pallet type
                            {
                                if (AddCustomColumn[2] == '1')
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("PalletType"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("PalletType");
                                    }
                                }
                            }
                            if (index == 3)
                            {
                                if (AddCustomColumn[3] == '1')  //Remove hatch and deck
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Hatch"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Hatch");
                                    }
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Deck"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Deck");
                                    }
                                }
                            }
                           
                            if (index == 4)
                            {
                                if (AddCustomColumn[4] == '1')
                                {               //Remove commodity column
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Commodity"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Commodity");
                                    }
                                }

                            }
                            if (index == 5)
                            {
                                if (AddCustomColumn[5] == '1')
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Fumigation"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Fumigation");  //Remove fumigation column
                                    }
                                }
                            }
                            if (index == 6)
                            {
                                if (AddCustomColumn[6] == '1')
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("BillOfLading"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("BillOfLading");  //Remove bill of lading column
                                    }
                                }
                            }
                            if (index == 7)
                            {
                                if (AddCustomColumn[7] == '1')
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("PackCode"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("PackCode");  //Remove pack code column
                                    }
                                }
                            }
                            if (index == 8)
                            {
                                if (AddCustomColumn[8] == '1')
                                {
                                    if (ExcelSheetDataSet.Tables[0].Columns.Contains("Memo"))
                                    {
                                        ExcelSheetDataSet.Tables[0].Columns.Remove("Memo");  //Remove Memo column
                                    }
                                }
                            }
                        }

                //**************************************************

                ExcelSheetDataSet.AcceptChanges();
                CustomColumnsNotSet = true;  //sucessfully removed.
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while trying to remove missing columns to add new set");
                CustomColumnsNotSet = false;  //best to not try to set them again later if there are any errors
                Error_Logging el = new Error_Logging("There was an error while trying to remove previously added columns. \n" + ex);
                return false;
            }

        }

        private void RestartClear()
        {
            //Editing = false;
            FieldIndex = 0;
            bStart.Text = "Start";
            bStart.Enabled = true;
            lFieldName.Text = "...";
            TempFieldName = "";
            lbRow.Text = "Row:";
            lbColumn.Text = "Column:";
            lMissingColumnsValue.Text = "Custom Code: ";
            lbMissingColumns.ClearSelected();
            lbFinishedItems.Items.Clear();
            lTemplateIndex.Text = "...";
            lTemplateIndex.ForeColor = Color.Black;
            lTemplateIndex.Font = new Font(lTemplateIndex.Font, FontStyle.Regular);


            //Remove andy added missing columns
            RemoveAddedColumns(Custom_Columns);
            lbMissingColumns.ClearSelected();  //Clear the list of selected missing columns
            if (ExcelSheetDataSet.Tables.Count > 0)
            {
                if (ExcelSheetDataSet.Tables[0].Columns.Contains("Grower Block"))
                {
                    ExcelSheetDataSet.Tables[0].Columns.Remove("Grower Block");  //Remove Grower Block column if there
                    GrowerBlockAdded = false;
                    ExcelSheetDataSet.AcceptChanges();
                }
            }

            //reset variables to defaults
            ExporterRow = -1;
            ExporterColumn = -1;
            DepartureDateRow = -1;
            DepartureDateColumn = -1;
            VesselNumberRow = -1;
            VesselNumberColumn = -1;
            VesselNameRow = -1;
            VesselNameColumn = -1;
            DestinationRow = -1;
            DestinationColumn = -1;
            PrefixRow = -1;
            Prefix = -1;
            TagNumberRow = -1;
            TagNumberColumn = -1;
            CommodityRow = -1;
            CommodityColumn = -1;
            VarietyRow = -1;
            VarietyColumn = -1;
            StyleRow = -1;
            StyleColumn = -1;
            SizeRow = -1;
            SizeColumn = -1;
            GradeRow = -1;
            GradeColumn = -1;
            LabelRow = -1;
            LabelColumn = -1;
            PalletTypeRow = -1;
            PalletTypeColumn = -1;
            InventoryQuantityRow = -1;
            InventoryQuantityColumn = -1;
            FirstPackDateRow = -1;
            FirstPackDateColumn = -1;
            GrowerNumberRow = -1;
            GrowerNumberColumn = -1;
            HatchRow = -1;
            HatchColumn = -1;
            DeckRow = -1;
            DeckColumn = -1;
            FumigatedRow = -1;
            FumigatedColumn = -1;
            BillOfLadingRow = -1;
            BillOfLadingColumn = -1;
            MemoRow = -1;
            MemoColumn = -1;
            PackCodeRow = -1;
            PackCodeColumn = -1;
            Custom_Columns = -1;

            ExcelSheetDataSet.AcceptChanges();
            if (ExcelSheetDataSet.Tables.Count > 0)
            {
                dataGridViewExcel2.DataSource = ExcelSheetDataSet.Tables[0].DefaultView;
            }
        }

        

 


       


      
      

       


    }
}
