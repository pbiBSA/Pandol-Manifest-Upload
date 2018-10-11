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
    public partial class RegionEditor : Form
    {
        DataSet RegionEditorDataSet = new DataSet();  //dataset for the Region ID table
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter RegionEditorDataAdaptor = null;  //DataAdaptor for the Region ID table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string

        public RegionEditor()
        {
            InitializeComponent();
        }



       
        private void RegionEditor_Load(object sender, EventArgs e)
        {
            try
            {
                //get Warehouse table data from database
                QueryCommand = new SqlCommand("SELECT * FROM Region_ID_Codes", conn);

                RegionEditorDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(RegionEditorDataAdaptor);

                RegionEditorDataAdaptor.Fill(RegionEditorDataSet);


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Region List table for editing.  \n" +
                     "Check your internet connection and verify that the database server is online.  \n" +
                 " Note what happened and contact administrator for help.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Region List table for editing.  \n" + ex);
                conn.Close();
                RegionEditorDataSet.Dispose();

            }

            try  //Load the import template data into datagrid
            {
                this.dataGridViewRegionEditor.DataSource = RegionEditorDataSet.Tables[0];
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Region datagrid for edit. \n");
                Error_Logging el = new Error_Logging("Error loading Region list datagrid for edit. \n" + exceptioncode);


            }

        
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                RegionEditorDataAdaptor.Update(RegionEditorDataSet);

                MessageBox.Show("Changes to Region list made.");
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Region connection was broken, can not save changes. \n" +
                        "Contact administrator to report connection problem.  \n");
                    Error_Logging el = new Error_Logging("Connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    RegionEditorDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Region list:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
            this.Close();
        }


       
    }
}
