using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CMS
{
    public partial class Form9 : Form
    {
        public SqlConnection con;
        public string str;
        public Form9()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rjTexbox1.Texts == "")
                {
                    MessageBox.Show("Input Erorr: Enter the name:");
                }
                else if (rjTexbox2.Texts == "")
                {
                    MessageBox.Show("Input Erorr: Enter the username");
                }
                else if (rjTexbox3.Texts == "")
                {
                    MessageBox.Show("Input Erorr: Enter the passowrd");
                }
                else 
                {
                    if(rjTexbox4.Texts=="guna4287.")
                    {
                        con.Open();
                        string qry = "INSERT INTO adata(name,username,password)VALUES('" + rjTexbox1.Texts + "','" + rjTexbox2.Texts + "','" + rjTexbox3.Texts + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("data stored");

                        rjTexbox1.Texts = "";
                        rjTexbox2.Texts = "";
                        rjTexbox3.Texts = "";
                        rjTexbox4.Texts = "";


                    }
                    else
                    {
                        MessageBox.Show("pass key not maching:");
                        rjTexbox4.Texts = "";
                        rjTexbox4.Focus();

                    }
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr: " + x.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form9_Load(object sender, EventArgs e)
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
    }
}
