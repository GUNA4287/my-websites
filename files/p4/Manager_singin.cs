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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CMS
{
    public partial class Form7 : Form
    {
        public SqlConnection con;
        public string str;

        public Form7()
        {
            InitializeComponent();

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
                //MessageBox.Show("Database connected..");
                con.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rjTexbox1.Texts == "")
                {
                    MessageBox.Show("input error: enter the name:");
                }
                else if (rjTexbox2.Texts == "")
                {
                    MessageBox.Show("input error: enter the username:");
                }
                else if (rjTexbox3.Texts == "")
                {
                    MessageBox.Show("input error: enter the passowrd");
                }
                else if (rjTexbox4.Texts == "")
                {
                    MessageBox.Show("input error: Enter the admin password:");
                }
                else
                {
                    try
                    {
                        if (rjTexbox4.Texts == "admin")
                        {
                            con.Open();
                            string qry = "INSERT INTO mdata(name,username,password)VALUES('" + rjTexbox1.Texts + "','" + rjTexbox2.Texts + "','" + rjTexbox3.Texts + "')";
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
                            MessageBox.Show("admin password increted...");
                            rjTexbox4.Texts = "";
                        }
                    }
                    catch (Exception X)
                    {
                        MessageBox.Show("Eorro" + X.Message);

                    }
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            
        }
    }
}
