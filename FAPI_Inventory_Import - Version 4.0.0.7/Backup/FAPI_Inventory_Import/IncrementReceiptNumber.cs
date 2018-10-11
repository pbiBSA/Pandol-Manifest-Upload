using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FAPI_Inventory_Import
{
    //This gets and increments the receipt number which is needed for the Famous import.
    class IncrementReceiptNumber
    {
        private int ReceiptNumber = 0;
        DataSet ReceiptNumberDataSet = new DataSet();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object
        SqlDataAdapter ReceiptNumberDataAdaptor = null;  //DataAdaptor for the Translation-Validation table
        SqlCommandBuilder cmdBuilder; //using sql command builder to create update command
        SqlCommand QueryCommand = null;  //query string

        public int  GetNewReceiptNumber()
        {
            //get receipt number from database

            conn.Open();

            QueryCommand = new SqlCommand("SELECT TOP 1 [LastReceiptNumber],[GUID_Key] FROM LastReceiptNumber", conn);

            ReceiptNumberDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ReceiptNumberDataAdaptor);

            ReceiptNumberDataAdaptor.Fill(ReceiptNumberDataSet);
            ReceiptNumber = Convert.ToInt32(ReceiptNumberDataSet.Tables[0].Rows[0][0]);
            ReceiptNumber++;
            ReceiptNumberDataSet.Tables[0].Rows[0][0] = ReceiptNumber;

            ReceiptNumberDataAdaptor.Update(ReceiptNumberDataSet);

            conn.Close();

            return ReceiptNumber;

        }

        public int GetReceiptNumber()
        {
            //get receipt number from database

            conn.Open();

            QueryCommand = new SqlCommand("SELECT TOP 1 [LastReceiptNumber],[GUID_Key] FROM LastReceiptNumber", conn);

            ReceiptNumberDataAdaptor = new SqlDataAdapter(QueryCommand);

            cmdBuilder = new SqlCommandBuilder(ReceiptNumberDataAdaptor);

            ReceiptNumberDataAdaptor.Fill(ReceiptNumberDataSet);
            ReceiptNumber = Convert.ToInt32(ReceiptNumberDataSet.Tables[0].Rows[0][0]);

            conn.Close();

            return ReceiptNumber;

        }

    }
}
