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
    //This is for edititing the Translation-Validation table by the user.
    public partial class Translation_Validation_Table_Editor : Form
    {
        string Data_Column_Name;  //variable for the column filter
        DataSet TranslationValidationDataSet = new DataSet();  //dataset for the translation-validation table
        string connString = Properties.Settings.Default.ConnectionString;  //get connection string from the aplication settings
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object
        SqlDataAdapter TranslationValidationDataAdaptor = null;  //DataAdaptor for the Translation-Validation table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string

        
        public Translation_Validation_Table_Editor()
        {
            InitializeComponent();
        }

        private void Translation_Validation_Table_Editor_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'applicationSettingsDataSet15.Translation_Validation_Table' table for the combo box.
            this.translation_Validation_TableTableAdapter.Fill(this.applicationSettingsDataSet15.Translation_Validation_Table);
            comboBoxFieldSelect.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(comboBoxFieldSelect.SelectedValue.ToString()))
            {
                Data_Column_Name = comboBoxFieldSelect.SelectedValue.ToString();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Code to filter tanslation-validation table goes here.

            if (comboBoxFieldSelect.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(comboBoxFieldSelect.SelectedValue.ToString()))
                {
                    Data_Column_Name = comboBoxFieldSelect.SelectedValue.ToString();
                    TranslationValidationDataSet.Clear();
                }
            }

            

            try
            {
                //get tranlation-validation table data from database

                if (this.checkBoxMissingAdams.Checked)  //allow the user to look only for entries that do not have a value in the Adams_Value field
                {
                    QueryCommand = new SqlCommand("SELECT * FROM Translation_Validation_Table WHERE [Data_Column_Name] = '" +
                        Data_Column_Name + "' AND [Adams_Value] is null", conn);
                }
                else
                {
                    QueryCommand = new SqlCommand("SELECT * FROM Translation_Validation_Table WHERE [Data_Column_Name] = '" + Data_Column_Name + "'", conn);
                }

                TranslationValidationDataAdaptor = new SqlDataAdapter(QueryCommand);

                cmdBuilder = new SqlCommandBuilder(TranslationValidationDataAdaptor);

                TranslationValidationDataAdaptor.Fill(TranslationValidationDataSet);

                
                conn.Close();
 
            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the translation table for editing.  \n" +
                     "Check your internet connection and verify that the database server is online.  \n" +
                 " Note what happened and contact administrator for help or see error log for more details.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to load the translation-validation table for editing.  " +
                 "  \n" + ex);
                conn.Close();
                TranslationValidationDataSet.Dispose();
                
            }

             try  //Load the imported data into datagrid
                {
                    dataGridViewtranslationValidationTable.DataSource = TranslationValidationDataSet.Tables[0];
                }

                catch (Exception exceptioncode)
                {
                    MessageBox.Show("Error loading translator-validator datagrid for edit. \n");
                    Error_Logging el = new Error_Logging("Error loading translator-validator datagrid for edit. \n" + exceptioncode);


                }


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {  
            try
            {
                conn.Open();
                
                TranslationValidationDataAdaptor.Update(TranslationValidationDataSet);

                MessageBox.Show("Changes to Translation-Validation Table made.");
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
                    TranslationValidationDataAdaptor.Dispose();
                    MessageBox.Show("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText);
                    Error_Logging el = new Error_Logging("Error while updating database with update command:  \n" + cmdBuilder.GetUpdateCommand().CommandText + "\n" + ex);
                }
            }
          
          
            conn.Close();           
            this.Close();
        }
    }
}
