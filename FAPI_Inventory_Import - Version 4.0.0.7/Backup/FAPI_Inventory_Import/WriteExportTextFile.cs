using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//This class takes a list of strings (ListToWrite) and writes them to a text file (.txt).
namespace FAPI_Inventory_Import
{
    class WriteExportTextFile
    {
        List<string> ListToWrite = new List<string>();

        public WriteExportTextFile(List<string> l2w)
        {
            ListToWrite = l2w;

        }

        public bool WriteFile(string fn)
        {
            string FilePathandName = fn;

            try
            {
                //create a writer and open the file
                TextWriter tw = new StreamWriter(FilePathandName);

                for (int line = 0; line < ListToWrite.Count; line++)
                {

                    tw.WriteLine(ListToWrite[line]);  //write each line
                }

                // close the stream
                tw.Close();
            }

            catch (Exception e)
            {
                throw (e);
            }

            return true;
        }

    }
}
