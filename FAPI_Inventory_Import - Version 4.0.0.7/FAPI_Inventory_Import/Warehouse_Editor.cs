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
    public partial class Warehouse_Editor : Form
    {
        DataSet WarehouseEditorDataSet = new DataSet();  //dataset for the Warehouse table
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter WarehouseEditorDataAdaptor = null;  //DataAdaptor for the Warehouse table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string
        
        
        public Warehouse_Editor()
        {
            InitializeComponent();
        }

        private void Warehouse_Editor_Load(object sender, EventArgs e)
        {

            try
            {
                //get Warehouse table data from database
                QueryCommand = new SqlCommand("SELECT * FROM Inventory_Warehouse_Codes", conn);

                WarehouseEditorDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(WarehouseEditorDataAdaptor);

                WarehouseEditorDataAdaptor.Fill(WarehouseEditorDataSet);


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Warehouse List table for editing.  \n" +
                     "Check your internet connection and verify that the database server is online.  \n" +
                 " Note what happened and contact administrator for help.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Warehouse List table for editing.  \n" + ex);
                conn.Close();
                WarehouseEditorDataSet.Dispose();

            }

            try  //Load the import template data into datagrid
            {
                this.dataGridViewWarehouseEditor.DataSource = WarehouseEditorDataSet.Tables[0];
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Warehouse datagrid for edit. \n");
                Error_Logging el = new Error_Logging("Error loading Warehouse list datagrid for edit. \n" + exceptioncode);


            }

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
             try
            {
                conn.Open();

                WarehouseEditorDataAdaptor.Update(WarehouseEditorDataSet);

                MessageBox.Show("Changes to Warehouse list made.");
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
                    WarehouseEditorDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Warehouse list:  \n" + 
                        cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + 
                        cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
            this.Close();
        }

  

       

    }
      
}
