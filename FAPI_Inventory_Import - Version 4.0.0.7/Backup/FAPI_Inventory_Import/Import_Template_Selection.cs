using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//This form for is for getting the import template settings.  The names of the templates and the template data
//comes from the FAPI_Import_Templates table in the ApplicationSettings database
namespace FAPI_Inventory_Import
{
    public partial class Import_Template_Selection : Form
    {
        DataSet ImportSettingsDataSet = new DataSet();  //dataset for the Import Settings table

        public Import_Template_Selection()
        {
            InitializeComponent();
        }

        private void Import_Template_Selection_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'applicationSettingsDataSetImportTemplateSettings.FAPI_Import_Templates' table.
            this.fAPI_Import_TemplatesTableAdapter.Fill(this.applicationSettingsDataSetImportTemplateSettings.FAPI_Import_Templates);


            string connString = Properties.Settings.Default.ConnectionString;  //get connection string from the aplication settings
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object
            SqlDataAdapter ImportSettingsDataAdaptor = null;  //DataAdaptor for the Translation-Validation table
            SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
            SqlCommand QueryCommand = null;  //query string


            //get tranlation-validation table data from database
           // QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates", conn);

            //get Import Templates table data from database
            /*
            if (false)                       //Properties.Settings.Default.Mode == "Test")
            {
                QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates_Test", conn);
            }
            else
            {
                QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates", conn);
            }
             */

            QueryCommand = new SqlCommand("SELECT * FROM Spreadsheet_Import_Templates", conn);

            ImportSettingsDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ImportSettingsDataAdaptor);

            conn.Open();

            ImportSettingsDataAdaptor.Fill(ImportSettingsDataSet);

            conn.Close();

        }
        public string getComboBoxValue()  //gets the template name from the combobox
        {
            return comboBoxTemplate.SelectedValue.ToString();
        }


        public DataRow getTemplateSettings()  //Gets the template settings as a datarow.
        {
            DataRow TemplateSettings;
            TemplateSettings = this.ImportSettingsDataSet.Tables[0].Rows[0];  //Default settings are in first row.

            if (!string.IsNullOrEmpty(comboBoxTemplate.Text))
            {
                foreach (DataRow dr in this.ImportSettingsDataSet.Tables[0].Rows)  //find the selected template
                {
                    if (dr[0].ToString() == comboBoxTemplate.SelectedValue.ToString()) //WHERE 0 is the field1 which has the 
                                                                                        //template name
                    {
                        TemplateSettings = dr; //Data row to be returned has the first column value = to selected value in
                                               //the combobox
                    }
                }
                
                
            }
            return TemplateSettings;
           
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
