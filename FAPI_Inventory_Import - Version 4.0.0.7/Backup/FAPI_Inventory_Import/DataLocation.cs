using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    //Used to hold the location of a data item in a dataset.
    class DataItemLocation
    {
        public int Row;
        public int Column;

        public DataItemLocation(int iRow, int iColumn)
        {
            Row = iRow;
            Column = iColumn;
        }
      }
}
