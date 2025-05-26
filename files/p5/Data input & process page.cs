using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ESA_ORGIN
{
    public partial class Form1 : Form
    {
        public Form1(List<string> Temp1, DataTable tempBDt, DataTable tempGDt)
        {
            InitializeComponent();
            selected = Temp1;
            Bdt = tempBDt;
            gdt = tempGDt;
            read(selected, Bdt);
            read(selected, gdt);
            Totatality();

        }
        static DataTable gdt = new DataTable();
        static DataTable Bdt = new DataTable();
        public List<string> selected = new List<string>();
        static int TNH, TNS, NSH, TNR, NRP, TNB, TNG, NDP, temp1, skipo;
        static int rc = 2, cc = 2, temp5 = 0;
        public void display()
        {
            for (int j = 0; j < selected.Count(); j++)
                label16.Text += selected[j].ToString() + " ,"; 
        }
        public void Totatality()
        {
            TNB = Counter(Bdt);
            label10.Text += TNB.ToString();
            TNS = TNG + TNB;
            label8.Text = (TNS).ToString();
            TNG = Counter(gdt);
            label11.Text = TNG.ToString();
            TNS = TNG + TNB;
            label8.Text = (TNS).ToString();
        }
        public void read(List<string> path, DataTable dt)
        {
            int i = 0, j = 0;
            List<string> dommi = new List<string>();
            for (i = 0; i < dt.Columns.Count; i++)
                dommi.Add(dt.Columns[i].ColumnName.ToString());
           
           for (j = 0; j < selected.Count(); j++)
            {
                for (i = 0; i < dommi.Count(); i++)
                {
                    if (selected[j].ToString() == dommi[i].ToString())
                    {
                        dommi.RemoveAt(i);
                    }
                }
            }
            for (i = 0; i < dommi.Count(); i++)
            {
                for (j = 0; j < dt.Columns.Count; j++)
                {
                    if (dommi[i].ToString() == dt.Columns[j].ColumnName.ToString())
                    {
                        dt.Columns.Remove(dt.Columns[j].ColumnName.ToString());
                    }
                }
            }


        }
        public int Counter(DataTable dt)
        {
            int count = 0;

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


            return count;
        }
            
       
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NSH = Convert.ToInt32(numericUpDown3.Value);
            if ((TNS % NSH) == 0)
                TNH = TNS / NSH;
            else
                TNH = (TNS / NSH) + 1;
            label9.Text = TNH.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NRP = Convert.ToInt32(numericUpDown4.Value);
            if ((NSH % NRP) == 0)
                TNR = NSH / NRP;
            else
                TNR = (NSH / NRP) + 1;
            write();

        }
        public void write()
        {

            folderBrowserDialog1.Description = "saving location";
            
            folderBrowserDialog1.ShowDialog();
            DataTable hall = new DataTable();

            label14.Visible = true;
            label15.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value += 10;
            label17.Text = "      Tips: Still wait the processing on";

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook nwb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet nws = nwb.ActiveSheet as Excel.Worksheet;
            Excel.Range RANg = nws.UsedRange;
            Excel.Borders border;
            
            app.ActiveWindow.DisplayGridlines = false;


            for (int i = 1; i <= TNR; i++)
            {
                hall.Columns.Add("Row" + i);
            }

            int split = 0, b, g, limit, m;
            if (TNR > 2 && (TNR % 2) == 0)
                split = TNR / 2;
            else if (TNR > 2 && (TNR % 2) != 0)
                split = (TNR / 2) + 1;

            g = (NSH / 2);
            b = NSH - g;
            limit = b;



            int range = (Int32)Math.Sqrt(TNH) + 2;

            for (int hc = 1; hc <= TNH + 1; hc++)
            {
                if((progressBar1.Value+(100/TNH))<=100)
                    progressBar1.Value += 100/TNH;
                label14.Text = "Processing " + progressBar1.Value.ToString() + "%";
                label15.Text = " ( Remaining Hall : " + (TNH - hc) + " ) ";
               
                for (int i = 1; i <= NRP; i++)
                {
                    hall.Rows.Add(" ");
                }


                m = 0;
                nws.Cells[rc, cc] = "Hall " + hc;
                var cell = nws.Range[nws.Cells[rc, cc], nws.Cells[rc, cc + TNR - 1]];
                nws.Range[nws.Cells[rc, cc], nws.Cells[rc, cc + TNR - 1]].Merge();
                nws.Range[nws.Cells[rc, cc], nws.Cells[rc, cc + TNR - 1]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                border = cell.Borders; border.LineStyle = Excel.XlLineStyle.xlContinuous; border.Weight = 3d;
                string[] bs = GetHallvalue(Bdt, b); string[] gs = GetHallvalue(gdt, g);

                int temp = 1;

                for (int i = 0; i < hall.Columns.Count; i++)
                {
                    for (int j = 0; j < hall.Rows.Count; j++)
                    {

                        if (temp == 1 && m < bs.Count())
                            hall.Rows[j][i] = bs[m];
                        if (temp == 0 && m < gs.Count())
                            hall.Rows[j][i] = gs[m];
                        m++;

                        if (m == b)
                        {
                            m = 0; temp = 0; goto the;
                        }
                    }
                the:
                    i++; i--;
                }

                //  shuffle(); 


                int tem = rc;
                foreach (DataRow dr in hall.Rows)
                {

                    for (int i = 1; i <= hall.Columns.Count; i++)
                    {

                        nws.Cells[(tem + 1), cc + i - 1] = dr[i - 1].ToString();

                        if (i == 1)
                        {
                            var bod = nws.Range[nws.Cells[rc + 1, cc + 1 - 1], nws.Cells[(tem + 1), cc + i - 1]];
                            border = bod.Borders;
                            border[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                            border[Excel.XlBordersIndex.xlEdgeLeft].Weight = 2;
                        }
                        if (i == hall.Columns.Count)
                        {
                            var bod = nws.Range[nws.Cells[rc + 1, cc + 1 - 1], nws.Cells[(tem + 1), cc + i - 1]];
                            border = bod.Borders;
                            border[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                            border[Excel.XlBordersIndex.xlEdgeRight].Weight = 2;
                        }
                    }
                    tem++;

                }

                for (int g1 = 0; g1 < hall.Columns.Count; g1++)
                {
                    var bod1 = nws.Range[nws.Cells[rc + 1, cc + g1], nws.Cells[(rc + NRP), cc + g1]];
                    border = bod1.Borders;
                    border[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    border[Excel.XlBordersIndex.xlEdgeBottom].Weight = 2;
                }

                hall.Clear();

               
                if (range == (hc))
                {
                    rc += (NRP + 2); range += range; cc = 2;
                }
                else
                {
                    rc += (0);
                    cc += (TNR + 1);

                }
            }
            app.Visible = true;
            string fInal = DateTime.Now.ToString("ss-mm-HH-dd-MM-yyyy");
            nwb.SaveAs((folderBrowserDialog1.SelectedPath.ToString()) + "/  ShufflerResulT__" + fInal);
            label15.Visible = false;
            label14.Visible = false;
            progressBar1.Visible= false;
            progressBar1.Value = 0;
        }

        public static bool allow = true;

        /*     public void shuffle()
             {
                 if (checker( hall.Rows[0][0].ToString(),hall.Rows[0][1].ToString()))
                 {
                     for (int i = 0; i < hall.Columns.Count; i++)
                     {
                         for (int j = 0; j < hall.Rows.Count - 1; j++)
                         {
                             if ((i % 2) == 0)
                             {
                                 if (!string.IsNullOrEmpty(hall.Rows[j + 1][i].ToString()))
                                 {
                                     string swap = hall.Rows[j][i].ToString();
                                     hall.Rows[j][i] = hall.Rows[j + 1][i];
                                     hall.Rows[j + 1][i] = swap;
                                 }
                             }
                         }
                     }
                 }
           
           
             }*/
        /* public Boolean checker(string a, string b)
         {
           
                 for (int i = 0; i < dt.Columns.Count; i++)
                 {
                     for (int j = 0; j < dt.Rows.Count; j++)
                     {
                         if (dt.Rows[j][i].ToString()==a)
                         {
                             for (int k = 0; k < dt.Rows.Count; k++)
                             {
                                 if (dt.Rows[k][i].ToString() == b)
                                     return true;
                             }
                            
                         }
                     }
                 }
                     
            
            
             return false;

         }*/

        public static List<string> fb = new List<string>();
     
        public string[] GetHallvalue(DataTable dt, int l)
        {
            temp5 = 0; temp1 = 1;
            List<string> values = new List<string>();
            while (temp1 < TNR)
            {
                skipo = 1;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    temp5 = dt.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(i)));
                    
                    if (allow == true && temp5 < NRP)
                    {

                        skipo++;
                        goto skip;
                    }

                    for (int j = 0; j < dt.Rows.Count && j < NRP; j++)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[j][i].ToString()))
                        {
                            values.Add(dt.Rows[j][i].ToString());
                            dt.Rows[j][i] = null;
                        }
                        if (values.Count() == l)
                        {
                            goto done;
                        }

                    }
                skip:
                    if (skipo == dt.Columns.Count && values.Count() != l)
                    {
                        n0n(dt, ref fb);
                    }

                }

                format(dt);
                temp1++;
            }
        done:

            string[] array = values.ToArray();

            return array;


        }
        public void n0n(DataTable dg, ref List<string> test)
        {
            format(dg);
            int pop = 0;
            int mute = (Int32)Math.Sqrt(test.Count());
            for (int x = (dg.Columns.Count - 1); x >= (TNR / 2); x--)
            {

                for (int y = 0; y < dg.Rows.Count; y++)
                {
                    if (!string.IsNullOrEmpty(dg.Rows[y][x].ToString()))
                    {
                        test.Add(dg.Rows[y][x].ToString());
                        dg.Rows[y][x] = null;
                    }
                }
                temp5 = dg.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(pop)));
                for (int y = temp5; y < dg.Rows.Count; y++)
                {
                    if (test.Count() != 0)
                    {
                        dg.Rows[y][pop] = test[0].ToString();
                        test.RemoveAt(0);
                    }
                }
                pop++;
                if (pop == (TNR / 2))
                    pop = 0;

            }
            allow = false;
        }
        
        public void format(DataTable dt)
        {

            List<string> te = new List<string>() { };
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                int m3 = dt.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>(i)));

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    if (!string.IsNullOrEmpty(dt.Rows[j][i].ToString()))
                    {
                        te.Add(dt.Rows[j][i].ToString());
                        dt.Rows[j][i] = null;
                    }

                }

                for (int k = 0; k < te.Count(); k++)
                {
                    dt.Rows[k][i] = te[k].ToString();

                }
                te.Clear();
            }
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label17.Visible = true;
            label17.Text = "      Tips: its fixed values";
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label17.Visible = true;
            label17.Text = "      Tips: its fixed values";
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label17.Visible = true;
            label17.Text = "      Tips: its fixed values";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label17.Visible = true;
            label17.Text = "      Tips: Restart the entire application";
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            label17.Visible = false;
        }

       

      
       
            
       
    }
}
