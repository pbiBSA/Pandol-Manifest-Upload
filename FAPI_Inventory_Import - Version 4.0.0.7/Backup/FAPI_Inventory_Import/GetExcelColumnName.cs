using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    public static class GetExcelColumnName
    {

        public static string FromColumnNumber(int columnNumber)
        {
            int dividend = columnNumber + 1;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
