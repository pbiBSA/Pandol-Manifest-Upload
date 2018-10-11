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
    public partial class Select_Receipt_Number : Form
    {
        DataTable Receipt_Number_Table = new DataTable();
        DataRow[] ReceiptRows;
        int Receipt_Number = 0;

        public Select_Receipt_Number()
        {
            InitializeComponent();
        }

        public Select_Receipt_Number(DataRow[] dr)
        {
            InitializeComponent();
            //Receipt_Number_Table = dt;
            ReceiptRows = dr;
          

            for (int i = 0; i < ReceiptRows.Length; i++) // dt.Rows.Count; i++)
            {
                comboBoxReceiptNumber.Items.Add(ReceiptRows[i][1]); // (dt.Rows[i][1]);
            }

            return;
        }

        public int GetReceiptNumber()
        {
            return Receipt_Number;
        }

        private void Select_Receipt_Number_Load(object sender, EventArgs e)
        {
            comboBoxReceiptNumber.SelectedItem = 0;

        }

        private void comboBoxReceiptNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Receipt_Number = Convert.ToInt32(comboBoxReceiptNumber.SelectedItem.ToString());
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonUse_Click(object sender, EventArgs e)
        {
            if (!(comboBoxReceiptNumber.SelectedItem == null))
            {
                Receipt_Number = Convert.ToInt32(comboBoxReceiptNumber.SelectedItem.ToString());
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You must select a receipt number to use or press the <Cancel> button.", "Action Required!");
                DialogResult = DialogResult.None;
            }
        }


    }
}
