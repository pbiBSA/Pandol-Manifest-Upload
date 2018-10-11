using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Adams export is now called just export.   All visual references will show Export rather than Adams export.

namespace FAPI_Inventory_Import
{
    public partial class Adams_Codes_Editor : Form
    {
        string Data_Column_Name;  //variable for the column filter
        DataSet ExportCodesDataSet = new DataSet();  //dataset for the Adams_Values table
        string connString = Properties.Settings.Default.ConnectionString;  //get connection string from the aplication settings
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object
        SqlDataAdapter ExportCodesDataAdaptor = null;  //DataAdaptor for the Adams_Values table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string

        
        public Adams_Codes_Editor()
        {
            InitializeComponent();
        }

        private void Adams_Codes_Editor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'applicationSettingsDataSet18.Adams_Values' table. You can move, or remove it, as needed.
            this.adams_ValuesTableAdapter.Fill(this.applicationSettingsDataSet18.Adams_Values);

            comboBoxAdamsCodes.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(comboBoxAdamsCodes.SelectedValue.ToString()))
            {
                Data_Column_Name = comboBoxAdamsCodes.SelectedValue.ToString();
            }

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
        

             try
            {
                conn.Open();
                
                ExportCodesDataAdaptor.Update(ExportCodesDataSet);

                MessageBox.Show("Changes to Export Codes Table made.");  
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
                         "Check your internet connection and verify that the database server is online.  \n" +
                        "Contact administrator to report connection problem.  \n");
                    Error_Logging el = new Error_Logging("Connection was broken, can not save changes. \n" + ex);
                }
                else
                {
                    ExportCodesDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\nError was:   \n");
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }
          
          
            conn.Close();           
            this.Close();
        }

    

        private void comboBoxAdamsCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Code to filter tanslation-validation table goes here.

            if (comboBoxAdamsCodes.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(comboBoxAdamsCodes.SelectedValue.ToString()))
                {
                    Data_Column_Name = comboBoxAdamsCodes.SelectedValue.ToString();
                   ExportCodesDataSet.Clear();
                }
            }



            try
            {
                //get Adams Values table data from database


                QueryCommand = new SqlCommand("SELECT [Data_Column_Name], [Value], [Export_Value], [Export_Key] FROM Export_Values WHERE [Data_Column_Name] = '" + Data_Column_Name + "'", conn);

              ExportCodesDataAdaptor = new SqlDataAdapter(QueryCommand);

              cmdBuilder = new SqlCommandBuilder(ExportCodesDataAdaptor);

              ExportCodesDataAdaptor.Fill(ExportCodesDataSet);


                conn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the Export Codes table for editing.  \n" +
                     "Check your internet connection and verify that the database server is online.  \n" +
                 " Note what happened and contact administrator for help.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the Export Codes table for editing.  " +
                 "  \n" + ex);
                conn.Close();
               ExportCodesDataSet.Dispose();

            }

            try  //Load the imported data into datagrid
            {
                dataGridViewAdamsCodes.DataSource =ExportCodesDataSet.Tables[0];
                dataGridViewAdamsCodes.Columns[0].ReadOnly = true;
                dataGridViewAdamsCodes.Columns[3].Visible = false;
                
            }

            catch (Exception exceptioncode)
            {
                MessageBox.Show("Error loading Export Codes datagrid for edit. \n");
                Error_Logging el = new Error_Logging("Error loading Adams Codes datagrid for edit. \n" + exceptioncode);


            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.dataGridViewAdamsCodes.CancelEdit();  //cancel changes and close window
        }

        private void dataGridViewAdamsCodes_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = Data_Column_Name.ToString();
        }

       
    }
}
