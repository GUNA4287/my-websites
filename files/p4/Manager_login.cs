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
    public partial class Form5 : Form
    {
        public static string locklm = "0";

        public SqlConnection con;
        public string str;
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void rjTexbox2__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {

                if (rjTexbox1.Texts == "")
                {
                    MessageBox.Show("input error: enter the username:");
                }
                else if (rjTexbox2.Texts == "")
                {
                    MessageBox.Show("input error: enter the passowrd:");
                }


                else
                {
                    con.Open();
                    string qry = "select username,password from mdata where(username='" + rjTexbox1.Texts + "' and password='" + rjTexbox2.Texts + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("login successfully:...");

                        locklm = "1";

                        con.Close();


                    }
                    else
                    {
                        MessageBox.Show("invalde login");
                        rjTexbox1.Texts = "";
                        rjTexbox2.Texts = "";
                        rjTexbox1.Focus();
                    }
                    con.Close();

                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void rjTexbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTexbox1__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void rjTexbox1__TextChanged_2(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
              //  MessageBox.Show("Database connected..");
                con.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void rjTexbox2__TextChanged_1(object sender, EventArgs e)
        {


        }
    }
}
