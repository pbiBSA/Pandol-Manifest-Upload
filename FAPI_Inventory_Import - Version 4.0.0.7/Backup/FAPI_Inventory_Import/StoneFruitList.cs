using System;
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
    public partial class StoneFruitList : Form
    {
        DataSet StoneFuitListDataSet = new DataSet();  //dataset for Stone Fruit List
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ApplicationSettingsConnectionString);  // create connection object
        SqlDataAdapter StoneFruitListDataAdaptor = null;  //DataAdaptor for the Stone Fruit List
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string
        
        public StoneFruitList()
        {
            InitializeComponent();
        }

        private void StoneFruitList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataSetStoneFruitList.StoneFuitCommodities' table. You can move, or remove it, as needed.
            this.stoneFuitCommoditiesTableAdapter.Fill(this.pBIApplicationTablesDataSetStoneFruitList.StoneFuitCommodities);

            
            try
            {
                //get Warehouse table data from database
                QueryCommand = new SqlCommand("SELECT [Commodity],[ID] FROM StoneFuitCommodities", conn);

                StoneFruitListDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(StoneFruitListDataAdaptor);

                StoneFruitListDataAdaptor.Fill(StoneFuitListDataSet);


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Stone Fruit List table for editing.  \n" +
                 " Note what happened and contact administrator for help.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Stone Fruit List table for editing.  \n" + ex);
                conn.Close();
                StoneFuitListDataSet.Dispose();

            }

            try  //Load the Stone Fruit List data into datagrid
            {
                this.dataGridViewStoneFuitList.DataSource = StoneFuitListDataSet.Tables[0];
                this.dataGridViewStoneFuitList.Columns[1].Visible = false;
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Stone Fruit datagrid for edit. \n" + exceptioncode);
                Error_Logging el = new Error_Logging("Error loading Stone Fruit list datagrid for edit. \n" + exceptioncode);


            }
              


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
             try
            {
                conn.Open();

                 StoneFruitListDataAdaptor.Update(StoneFuitListDataSet);

                MessageBox.Show("Changes to Stone Fruit list made.");
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Stone Fruit List connection was broken, can not save changes. \n" +
                        "Contact administrator to report connection problem.  \n");
                    Error_Logging el = new Error_Logging("Stone fruit List connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    StoneFruitListDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command for Stone Fruit list:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }


            conn.Close();
           
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dataGridViewStoneFuitList.CancelEdit();
        }

      

       
    }
}
