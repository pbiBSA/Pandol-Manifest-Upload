using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAPI_Inventory_Import
{
    public partial class Import_Template_Editor : Form
    {
        DataSet ImportTemplateEditorDataSet = new DataSet();  //dataset for the Import Template Settings table
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter ImportTemplateEditorDataAdaptor = null;  //DataAdaptor for the Import Template Settings table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string
        
        public Import_Template_Editor()
        {
            InitializeComponent();
        }

        private void Import_Template_Editor_Load(object sender, EventArgs e)
        {

            try
            {
                //get Import Templates table data from database
                /*
                if (false)       //Properties.Settings.Default.Mode == "Test")
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
                this.dataGridViewImportTemplateEditor.DataSource = ImportTemplateEditorDataSet.Tables[0];
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Import Template datagrid for edit. \n");
                Error_Logging el = new Error_Logging("Error loading Import Template datagrid for edit. \n" + exceptioncode);


            }
        
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                ImportTemplateEditorDataAdaptor.Update(ImportTemplateEditorDataSet);

                MessageBox.Show("Changes to Import Templates Table made.");
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Connection was broken, can not save changes. \n" +
                        "Contact administrator to report connection problem.  \n");
                    Error_Logging el = new Error_Logging("Connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    ImportTemplateEditorDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Import Templates:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
            this.Close();
        }


       

    }
}
