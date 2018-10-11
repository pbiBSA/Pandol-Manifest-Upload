using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace FAPI_Inventory_Import
{
    public partial class frmSelectDataSheet : Form
    {
        
        String[] excelSheets;  // string array to hold datasheet names
        string sDatasheetName;


        public frmSelectDataSheet()
        {
            InitializeComponent();
        }

        public frmSelectDataSheet(string fn)
        {
            InitializeComponent();

            GetDataSheetName dsn = new GetDataSheetName();

            excelSheets = dsn.GetDataSheetNameList(fn);

            if (excelSheets.Length > 0)
            {
                for (int i = 0; i < excelSheets.Length; i++)
                {
                    cbDataSheetList.Items.Add(excelSheets[i]); // step through list of datasheet names.
                }

                cbDataSheetList.SelectedItem = 0;
            }
            else
            {
                MessageBox.Show("Error, there are no datasheets!", "Warning");
            }

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (!(cbDataSheetList.SelectedItem == null))
            {
                sDatasheetName = cbDataSheetList.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You must select a data sheet name.", "Action Required!");
                DialogResult = DialogResult.None;
            }
            
        }

        private void frmSelectDataSheet_Load(object sender, EventArgs e)
        {
            cbDataSheetList.SelectedItem = 0;
        }

        private void cbDataSheetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sDatasheetName = cbDataSheetList.SelectedText;

        }
        public string DataSheetName()
        {
            return sDatasheetName;
        }
    }
}
