using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FAPI_Inventory_Import
{
    class DoesTagNumberExist
    {
        //bool FoundTagNumberTrue = true;
        int ReturnedValue = 0;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object  
        SqlCommand cmd;
        SqlParameter TagNumberParm;

      
        public bool TagNumberExist(string TagNum)
        {
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TagNumberMatchesInFamous";   // Stored procedure to look for tag number count
            TagNumberParm = new SqlParameter("@TagNumber", TagNum);
            TagNumberParm.Direction = ParameterDirection.Input;
            TagNumberParm.DbType = DbType.String;
            cmd.Parameters.Add(TagNumberParm);
            conn.Open();
            ReturnedValue = Convert.ToInt32(cmd.ExecuteScalar());    //ExecuteScalar());
            conn.Close();
            if(ReturnedValue == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
