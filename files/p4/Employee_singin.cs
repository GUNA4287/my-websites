using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMS
{
    public partial class Form8 : Form
    {
        public SqlConnection con;
        public string str;
        public string imagelocation = "";
        public Form8()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
             gunaButton1.BorderColor = Color.White;


            try
            {

                //////////////////////////   image convert to byte array   /////////////////////////
                byte[] eimage = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        eimage = ms.ToArray();

                    }
                }
                ////////////////////////// barcode conver to byte array  ///////////////////////////

                /* byte[] ebarcode = null;
                 if (pictureBox2.Image != null)
                 {
                     using (MemoryStream mss = new MemoryStream())
                     {
                         pictureBox2.Image.Save(mss, pictureBox2.Image.RawFormat);
                         ebarcode = mss.ToArray();
                     }
                 }
                 */
                ////////////////////////////                   //////////////////////////////
                if (rjTexbox1.Texts == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe NAME:");
                }
                else if (rjTexbox2.Texts == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe REG_NO:");
                }
                else if (rjTexbox3.Texts == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe JOB:");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe GENDER:");
                }

                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe TRAVEL:");
                }
                else if (rjTexbox4.Texts == "")
                {
                    MessageBox.Show("pleace enter the " + " PHONE_NO:");
                }
                else if (rjTexbox5.Texts == "")
                {
                    MessageBox.Show("pleace enter the " + "Employe ADDRESS:");
                }
                else if (pictureBox1.Image == null)
                {
                    MessageBox.Show("pleace enter the " + "Employe image:");
                }

                else
                {
                    con.Open();
                    string qry = "INSERT INTO edata(name,reg_no,work,gender,travel,phone_no,address,photo)VALUES('" + rjTexbox1.Texts + "','" + rjTexbox2.Texts + "','" + rjTexbox3.Texts + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + rjTexbox4.Texts + "','" + rjTexbox5.Texts + "',@image)";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@image", eimage);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("data stored done:");
                    rjTexbox1.Texts = "";
                    rjTexbox2.Texts = "";
                    rjTexbox3.Texts = "";
                    rjTexbox4.Texts = "";
                    rjTexbox5.Texts = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    pictureBox1.Image = null;

                    rjTexbox1.Focus();
                    con.Close();
                }
            }
            catch (Exception X)
            {
                MessageBox.Show("Erorr:" + X.Message);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
             //   MessageBox.Show("Database connected..");
                con.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = @"Image Files(*.jpeg;*.bmp;*.png;*.pg)|*.jpeg;*.gif;*.png;*.jpg";


                if (open.ShowDialog() == DialogResult.OK)
                {
                    open.Multiselect = false;
                    open.RestoreDirectory = true;

                    imagelocation = open.FileName.ToString();
                    pictureBox1.ImageLocation = imagelocation;

                }

            }
            catch (SqlException x)
            {
                MessageBox.Show("erorr:" + x);
            }
        }
    }
}
