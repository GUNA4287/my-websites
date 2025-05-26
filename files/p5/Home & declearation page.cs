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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        xl xl = new xl();
         public CheckBox cB;
        public DataTable Bdt = new DataTable();
        public DataTable Gdt = new DataTable();
         public List<CheckBox> boxlist = new List<CheckBox>();
         public static string Databasepath, Bdatabases, Gdatabases;
        private void Form2_Load(object sender, EventArgs e)
        {
            Arrange();
   
            panel1.Visible=true;
            splitContainer1.Visible=false;
            

        }
        public void Arrange()
        {
            Databasepath = System.IO.Directory.GetCurrentDirectory(). ToString() + "\\APPDATABASE";
            FileInfo fi = new FileInfo(Databasepath);
           
            try
            {
               
                

               
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(Databasepath);
                }
               

            }
            catch (Exception exx)
            {
                string msg="THiS application couldn't Run. PLEASE reinstall the Program!!!!!";
                MessageBox.Show(msg, "ERROR");
            } 
           
            if (!fi.Exists && !string.IsNullOrEmpty(Databasepath.ToString()))
            {

                Bdatabases = Databasepath + "\\BOYS.xlsx"; Gdatabases = Databasepath + "\\GIRLS.xlsx";

                Check(Bdatabases, "BOYS"); Check(Gdatabases, "GIRLS");
               
            }
            
        }

        public void Check(string file, string name)
        {
            string Filepath;
            FileInfo fi = new FileInfo(file);
            if (!fi.Exists)
            {
                openFileDialog1.Title = "Browse the DATABASE for " + name;
                openFileDialog1.ShowDialog();
                Filepath = openFileDialog1.FileName.ToString();
                 if (!string.IsNullOrEmpty(Filepath))
                 {
                     xl.Write(Filepath, Databasepath, name);
                }
            }
        }
              
         
        private void button4_Click(object sender, EventArgs e)
        {
            
           
            
            List<string> depart = new List<string>();
            depart = xl.readheader(Bdatabases);
            int nbox = 0;
            int bpace = (int)Math.Sqrt(depart.Count());
            for (int i = 0, j = 0; nbox < depart.Count(); i += 100)
            {
                if (nbox == bpace)
                {
                    j += 30;
                    i = 0;
                    bpace += (int)Math.Sqrt(depart.Count());
                }

                cB = new CheckBox { Name = depart[nbox].ToString(), Text = depart[nbox].ToString(), Location = new System.Drawing.Point(92+i, 189+j), AutoSize = true };
                boxlist.Add(cB);
                this.Controls.Add(cB);
                nbox++;


            }
            
          
            panel1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xl.reader(Bdatabases, Bdt);
            xl.reader(Gdatabases, Gdt);
             List<string> Selected = new List<string>();
            List<CheckBox> select = boxlist.Where(cb => cb.Checked).ToList();
           foreach(var CheckBoc in select)
           {

               Selected.Add(CheckBoc.Name.ToString()); 

            }
          
           Form1 f1 =new Form1(Selected,Bdt,Gdt);
           f1.Show();
         


        }

        private void button10_Click(object sender, EventArgs e)
        {
        
        }

        private void button12_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible=false;
            panel1.Visible=true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
            splitContainer1.Visible=true;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            xl.open(Bdatabases);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xl.open(Gdatabases);
        }

        private void button9_Click(object sender, EventArgs e)
        {


            xl.delete(Bdatabases);
            if (!File.Exists(Bdatabases))
            {
                Check(Bdatabases, "BOYS");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xl.delete(Gdatabases);
            if (!File.Exists(Gdatabases))
            {
                Check(Gdatabases, "GIRLS");
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Move to next stage";
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Click to View file And then you can view / Edit";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Go to database";

        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void splitContainer1_Panel2_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void splitContainer1_Panel1_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips:Go Back to the previous Panel ";
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Click to View file And then you can view / Edit";
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Click to Delte Database And then you can update new database";
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Click to Delte Database And then you can update new database";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Back to previous panel";
        }
        public static bool allow = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
           
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
            label5.Text = "     Tips: Click to start application";
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < boxlist.Count(); i++)
                    boxlist[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < boxlist.Count(); i++)
                    boxlist[i].Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        }
    }
