using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;

namespace FAPI_Inventory_Import
{
    class UpdateImportDatasetForQC
    {
         DataSet DataForQCDataSet = new DataSet();  //DataSet for QC pallet selection
         DataSet QCDataSet = new DataSet();
         private DataTable QCTable;  //QC table to hold list of pallets to QC
         string QCquery;
         DataSet WorkingDataSet = new DataSet();  //working dataset
         ImportTemplateSettings TemplateSettings = new ImportTemplateSettings();  //application import settings

         public UpdateImportDatasetForQC(DataSet ds, ImportTemplateSettings ts)
        {
            DataForQCDataSet = new DataSet(); //start with clean dataset
            DataForQCDataSet = ds.Copy();  //Data for QC selection from the main data dataset
            TemplateSettings = ts;  //Template settings

            //Get the list of pallets to QC
            string QCconnString = Properties.Settings.Default.ArchiveConnectionString;
            StringBuilder QCCommand_Text = new StringBuilder();
            if (Properties.Settings.Default.Mode.ToString() == "Test")
            {
                QCquery = "select [Pallet_Number] FROM [QC_Archive_Test]"; // List of pallets for QC from test table;
            }
            else
            {
                QCquery = "select [Pallet_Number] FROM [QC_Archive]"; // List of pallets for QC;
            }

            System.Data.SqlClient.SqlConnection QCconn = new System.Data.SqlClient.SqlConnection(QCconnString);
            System.Data.SqlClient.SqlCommand QCcmd = new System.Data.SqlClient.SqlCommand(QCquery, QCconn);
            QCconn.Open();

            DataSet QCDataSet = new DataSet();
            // create data adapter
            System.Data.SqlClient.SqlDataAdapter QCda = new System.Data.SqlClient.SqlDataAdapter(QCcmd);
            // this will query the database and return the result to your datatable
            QCda.Fill(QCDataSet);
            QCconn.Close();
            QCda.Dispose();
            QCTable = QCDataSet.Tables[0];  //set the translation table
            QCDataSet.Dispose();
           
        }

         public DataSet UpdateDataSet()
         {
             try
             {
                 int CurrentRow = 0;

                 DataSet tempWorkingDataSet = new DataSet();  //
                 tempWorkingDataSet = DataForQCDataSet.Copy();

                 for (int QCCurrentRow = 0; QCCurrentRow < QCTable.Rows.Count; QCCurrentRow++) //iterate through the QC pallet list
                 {
                     for (CurrentRow = 0; CurrentRow < tempWorkingDataSet.Tables[0].Rows.Count; CurrentRow++)
                     {
                         if (tempWorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.TagNumberColumn].ToString().Trim() == QCTable.Rows[QCCurrentRow][0].ToString().Trim())
                         {
                             tempWorkingDataSet.Tables[0].Rows[CurrentRow][TemplateSettings.MemoColumn] = "QC";
                         }
                     }

                 }

                 DataForQCDataSet = tempWorkingDataSet;

                 return DataForQCDataSet;
             }
             catch (Exception e)
             {
                 MessageBox.Show("QC process failed.  It will continue without selecting pallets for QC  \nPlease note what was done and see admin for help.  \n");
                 Error_Logging el = new Error_Logging("QC process had an error.  \n" + e);
                 return DataForQCDataSet;
             }

         }



    }
}
