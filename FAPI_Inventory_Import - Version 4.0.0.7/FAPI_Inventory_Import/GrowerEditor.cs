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
    public partial class GrowerEditor : Form
    {
        DataSet GrowerEditorDataSet = new DataSet();  //dataset for the Warehouse table
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter GrowerEditorDataAdaptor = null;  //DataAdaptor for the Warehouse table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string
        
        
        public GrowerEditor()
        {
            InitializeComponent();
        }



        private void GrowerEditor_Load(object sender, EventArgs e)
        {
            try
            {
                //get Warehouse table data from database
                QueryCommand = new SqlCommand("SELECT * FROM Grower_Name", conn);

                GrowerEditorDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(GrowerEditorDataAdaptor);

                GrowerEditorDataAdaptor.Fill(GrowerEditorDataSet);


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Grower List table for editing.  \n" +
                 " Note what happened and contact administrator for help.  \n" );
                Error_Logging el = new Error_Logging("There was an error while trying to load the Grower List table for editing.  \n" + ex);
                conn.Close();
                GrowerEditorDataSet.Dispose();

            }

            try  //Load the import template data into datagrid
            {
                this.dataGridViewGrowerBlockEditor.DataSource = GrowerEditorDataSet.Tables[0];
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Grower datagrid for edit. \n" + exceptioncode);
                Error_Logging el = new Error_Logging("Error loading Grower list datagrid for edit. \n" + exceptioncode);


            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                GrowerEditorDataAdaptor.Update(GrowerEditorDataSet);

                MessageBox.Show("Changes to Grower list made.");
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Grower connection was broken, can not save changes. \n" +
                        "Contact administrator to report connection problem.  \n");
                    Error_Logging el = new Error_Logging("Grower connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    GrowerEditorDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Grower list:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
            this.Close();
        }
 
    }
}
