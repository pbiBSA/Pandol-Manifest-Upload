using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAPI_Inventory_Import
{
    public partial class CombinedMixedBoxesDataViewForm : Form
    {
        DataSet DataSetToView = new DataSet();
        bool Succeeded = false;

        
        public CombinedMixedBoxesDataViewForm()
        {
            InitializeComponent();
        }

        private void CombinedMixedBoxesDataViewForm_Load(object sender, EventArgs e)
        {

        }

        public bool ViewData(DataSet ds)
        {
            DataSetToView = ds;

            dataGridViewCombinedBoxesView.DataSource = DataSetToView.Tables[0].DefaultView;
            Succeeded = true;
            return Succeeded;

        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
