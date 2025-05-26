using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace ESA_ORGIN
{
    class xl
    {
        public Microsoft.Office.Interop.Excel.Application EAPP = new Excel.Application();
        

        public void open(string Filename)
        {
            
            allow = false;
            var sorceBOOK = EAPP.Workbooks.Open(Filename);
            var Sorcesheet = sorceBOOK.ActiveSheet as Excel.Worksheet;
           
            EAPP.Visible = true;

            if (allow == true)
            {
                sorceBOOK.Close();
            }

        }
        bool allow = false;
        public void close(string filename)
        {
            allow = true;
            
            

           

        }
        public void Write(string SOURCEpath, string DESTINYpath, string Name)
        {
            
            EAPP.Visible = false;
            var sorceBOOK = EAPP.Workbooks.Open(SOURCEpath);
            var Sorcesheet = sorceBOOK.ActiveSheet as Excel.Worksheet;
            Sorcesheet.Copy();
            var newbook = EAPP.ActiveWorkbook;
            newbook.SaveAs(DESTINYpath + "/" + Name);
            newbook.Close();
            sorceBOOK.Close();
            EAPP.Quit();

        }
        public void delete(string filename)
        {

                File.Delete(filename);
            
        }
        public List<string> readheader(string filename)
        {
            List<string> depart = new List<string>();
            var EAPP = new Excel.Application();
            EAPP.Visible = false;
            var sorceBOOK = EAPP.Workbooks.Open(filename);
            var Sorcesheet = sorceBOOK.ActiveSheet as Excel.Worksheet;
            Excel.Range uRange = Sorcesheet.UsedRange;
            for (int i = 1; i <= uRange.Columns.Count; i++)
            {
                var cell = (string)(Sorcesheet.Cells[1, i] as Excel.Range).Value;
                depart.Add(cell);
            }

            return depart;
        }
        public void reader(string path, DataTable dt)
        {

            int count = 0;
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook wb = xlapp.Workbooks.Open(path);
            Excel.Worksheet ws = wb.ActiveSheet as Excel.Worksheet;
            Excel.Range uRange = ws.UsedRange;

            for (int i = 1; i <= uRange.Columns.Count; i++)
            {
                var cell = (string)(ws.Cells[1, i] as Excel.Range).Value;
                dt.Columns.Add(cell);
            }

            for (int i = 2; i <= uRange.Rows.Count; i++)
            {
                //dr object read and store the data in a row
                DataRow dr = dt.NewRow();
                for (int j = 1; j <= uRange.Columns.Count; j++)
                {
                    //cell variable store
                    var cell = (ws.Cells[i, j] as Excel.Range).Value;
                    dr[j - 1] = cell;
                }

                dt.Rows.Add(dr);
            }
            wb.Close();
            xlapp.Quit();

            //Sorting columns in data table
            //Rearrenge the columns maximum length order in datatable
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                int c = dt.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(i)));
                count += c;
                for (int j = 0; j <= i; j++)
                {
                    //get the count of i:j th column then store the length in m:n
                    int m = dt.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(i)));
                    int n = dt.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(j)));

                    //if n greater then m interchage the column
                    if (m > n)
                    {
                        dt.Columns[i].SetOrdinal(j);
                    }
                }
            }



        }
       
    }
}
