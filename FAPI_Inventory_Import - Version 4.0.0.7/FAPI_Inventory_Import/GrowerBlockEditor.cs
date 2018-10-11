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
    public partial class GrowerBlockEditor : Form
    {
        DataSet GrowerBlockEditorDataSet = new DataSet();  //dataset for the Warehouse table
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter GrowerBlockEditorDataAdaptor = null;  //DataAdaptor for the Warehouse table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string
        
        
        public GrowerBlockEditor()
        {
            InitializeComponent();
        }



        private void GrowerBlockEditor_Load(object sender, EventArgs e)
        {
            try
            {
                //get Warehouse table data from database
                QueryCommand = new SqlCommand("SELECT * FROM Grower_Block_ID_Codes", conn);

                GrowerBlockEditorDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(GrowerBlockEditorDataAdaptor);

                GrowerBlockEditorDataAdaptor.Fill(GrowerBlockEditorDataSet);


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Grower Block List table for editing.  \n" +
                 " Note what happened and contact administrator for help.  \n" + ex);
                Error_Logging el = new Error_Logging("There was an error while trying to load the Grower Block List table for editing.  \n" + ex);
                conn.Close();
                GrowerBlockEditorDataSet.Dispose();

            }

            try  //Load the import template data into datagrid
            {
                this.dataGridViewGrowerBlockEditor.DataSource = GrowerBlockEditorDataSet.Tables[0];
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Grower Block datagrid for edit. \n" + exceptioncode);
                Error_Logging el = new Error_Logging("Error loading Grower Block list datagrid for edit. \n" + exceptioncode);


            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                GrowerBlockEditorDataAdaptor.Update(GrowerBlockEditorDataSet);

                MessageBox.Show("Changes to Grower Block list made.");
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Grower Block connection was broken, can not save changes. \n" +
                        "Contact administrator to report connection problem.  \n" + ex);
                    Error_Logging el = new Error_Logging("Grower Block connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    GrowerBlockEditorDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Grower Block list:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n" + ex);
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
            this.Close();
        }
 
    }
}
