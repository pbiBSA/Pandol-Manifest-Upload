using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FAPI_Inventory_Import
{
    class GetExporterFromPrefix
    {
        
        //This class takes a prefix code and a exporter name and will return the translated 
        //exporter code/name or the original exporter name
        string exporter;

        public string GetExporterNameFromPrefix(string prfx, string expt)
        {

            DataSet ds = new DataSet();
            string prefix = prfx;
            exporter = expt;
            try
            {
                //get tranlation table data from database
                string connString = Properties.Settings.Default.ApplicationSettingsConnectionString;
                //get only the row where the column name is Prefix and the value is the prefix
                string query = "SELECT TOP 1 * FROM Translation_Validation_Table  WHERE [Data_Column_Name] = 'Prefix'  AND [Value] = '" + prefix + "'";

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query the database and return the result to your datatable
                da.Fill(ds);
                conn.Close();
                da.Dispose();
                if (ds.Tables[0].Rows.Count == 1)
                {
                    exporter = ds.Tables[0].Rows[0][3].ToString(); //set the exporter name
                }
                ds.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show("There was an error while trying to get the exporter via prefix code.  \n" +
                 " Note what happened and contact administrator for help or see error log for more details.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to get the exporter via prefix code.  \n" +
                 "  \n" + e);
                ds.Dispose();
            }

            return exporter;
        }


    }
}
