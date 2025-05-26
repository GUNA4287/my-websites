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
using System.IO;

namespace CMS
{
    public partial class Form10 : Form
    {
        public SqlConnection connection;
        public SqlConnection con;
        public string str;

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public int del = 0;
        public int de = 0;
        public int delanother = 0;

        public int da = 0;
        public Form10()
        {
            InitializeComponent();
            CustemizeDesign();
        }

        private void CustemizeDesign()
        {
            //panelLoginsubmenu.Visible = false;
            //panelSigninsubmenu.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            //....

        }
        private void hideSubMenu()
        {

            /* if (panelLoginsubmenu.Visible == true)
                 panelLoginsubmenu.Visible = false;
             if (panelSigninsubmenu.Visible == true)
                 panelSigninsubmenu.Visible = false;
             */
            if (panel2.Visible == true)
                panel2.Visible = false;
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
        }

        private void showSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
               // MessageBox.Show("Database connected...");
                con.Close();
               
            }
            catch(SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panel2);
            del = 0;
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;


                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,username AS USERNAME,password AS PASSWORD FROM  adata ", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Eror:" + x.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;

                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,username AS USERNAME,password AS PASSWORD FROM  mdata ", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Eror:" + x.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;

                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,gender AS GENDER,travel AS TRAVEL,phone_no AS PHONE_NO,address AS ADDRESS FROM  edata", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;

                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,work AS WORK,date AS DATE,time AS TIME,mobile_no AS MOBLIE_NO,address AS ADDRESS FROM another", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;

                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,gender AS GENDER,travel AS TRAVEL,phone_no AS PHONE_NO,address AS ADDRESS FROM  edata", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;
                if (comboBox1.Text == "ALL")
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                    sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,gender AS GENDER,travel AS TRAVEL,phone_no AS PHONE_NO,address AS ADDRESS FROM edata ", connection);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    pictureBox1.Image = null;

                }
                else if(comboBox1.Text == "ONE")
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                    sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,gender AS GENDER,travel AS TRAVEL,phone_no AS PHONE_NO,address AS ADDRESS FROM edata where(reg_no='" + rjTexbox1.Texts + "')", connection);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Open();
                    string qrry = "SELECT reg_no,photo FROM edata where(reg_no='" + rjTexbox1.Texts + "')";
                    SqlCommand cmmd = new SqlCommand(qrry, con);
                    // cmmd.Parameters.AddWithValue("@ename", textBox1.Text);
                    using (SqlDataReader drr = cmmd.ExecuteReader())
                    {
                        if (drr.Read())
                        {

                            //textBox2.Text = dr["ename"].ToString();
                            byte[] imagebyte = (byte[])drr["photo"];
                            MemoryStream memorystream = new MemoryStream(imagebyte);
                            pictureBox1.Image = Image.FromStream(memorystream);
                            //pictureBox1.Image = Image.FromStream(memorystream);
                            drr.Close();
                            MessageBox.Show("image printed");
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("employe image not fond:");
                            con.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("selcted the 'one'  AND 'all' information:");
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                del = 0;
                if (comboBox1.Text == "ALL")
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                    sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,date AS DATE,intime AS INTIME,outtime AS OUTTIME,done AS DONE FROM  attanes ", connection);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    pictureBox1.Image = null;
                }
                else if(comboBox1.Text=="ONE")
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                    sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,date AS DATE,intime AS INTIME,outtime AS OUTTIME,done AS DONE FROM  attanes where(reg_no='" + rjTexbox1.Texts + "')", connection);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Open();
                    string qrry = "SELECT reg_no,photo FROM edata where(reg_no='" + rjTexbox1.Texts + "')";
                    SqlCommand cmmd = new SqlCommand(qrry, con);
                    // cmmd.Parameters.AddWithValue("@ename", textBox1.Text);
                    using (SqlDataReader drr = cmmd.ExecuteReader())
                    {
                        if (drr.Read())
                        {

                            //textBox2.Text = dr["ename"].ToString();
                            byte[] imagebyte = (byte[])drr["photo"];
                            MemoryStream memorystream = new MemoryStream(imagebyte);
                            pictureBox1.Image = Image.FromStream(memorystream);
                            //pictureBox1.Image = Image.FromStream(memorystream);
                            drr.Close();
                            MessageBox.Show("image printed");
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("employe image not fond:");
                            con.Close();
                        }

                    }
                }
                else
                {

                    MessageBox.Show("selcted the 'one'  AND 'all' information:");
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panel3);
            del = 0;
            pictureBox1.Image = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panel4);
            del = 1;
            pictureBox1.Image = null;
            MessageBox.Show("importend tis the admin ==>> delected  page  so, carfuly handeled   ........");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,gender AS GENDER,travel AS TRAVEL,phone_no AS PHONE_NO,address AS ADDRESS FROM edata ", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                de = 1;

                da = 0;

                delanother = 0;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (del == 1)
                {
                    if (da == 1)//////delected the attacnce data
                    {
                        if (comboBox1.Text == "ALL")
                        {
                            con.Open();
                            string qry = "DELETE FROM attanes";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("delected all data with in attance...");

                            con.Close();
                            
                        }
                        else if (comboBox1.Text == "ONE")
                        {
                            if (rjTexbox1.Texts == "")
                            {
                                MessageBox.Show("Fill the reg_no:");
                            }
                            else
                            {
                                con.Open();
                                string qry = "DELETE FROM attanes WHERE(reg_no='"+rjTexbox1.Texts+"')";
                                SqlCommand cmd = new SqlCommand(qry, con);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("delected one data with in attance...");
                                rjTexbox1.Texts = "";

                                con.Close();
                            }
                        }
                        else
                        {

                            MessageBox.Show("selcted the 'one'  AND 'all' information:");
                        }
                    }
                    else if(de==1)//////delected the  employe data
                    {
                        if (comboBox1.Text == "ALL")
                        {
                            con.Open();
                            string qry = "DELETE  FROM edata";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("delected all data with in employe..");

                            con.Close();
                        }
                        else if (comboBox1.Text == "ONE")
                        {
                            if (rjTexbox1.Texts == "")
                            {
                                MessageBox.Show("Fill the reg_no:");
                            }
                            else
                            {
                                con.Open();
                                string qry = "DELETE FROM edata WHERE(reg_no='" + rjTexbox1.Texts + "')";
                                SqlCommand cmd = new SqlCommand(qry, con);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("delected one data with in employe...");

                                rjTexbox1.Texts = "";

                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("selcted the 'one'  AND 'all' information:");
                        }
                    }
                    else if(delanother==1)
                    {
                        if (comboBox1.Text == "ALL")
                        {
                            con.Open();
                            string qry = "DELETE  FROM another";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("delected all data with in employe..");

                            con.Close();
                        }
                        else if (comboBox1.Text == "ONE")
                        {
                            if (rjTexbox1.Texts == "")
                            {
                                MessageBox.Show("Fill the name for register number texbox..:");
                            }
                            else
                            {
                                con.Open();
                                string qry = "DELETE FROM another WHERE(name='" + rjTexbox1.Texts + "')";
                                SqlCommand cmd = new SqlCommand(qry, con);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("delected one data with in employe...");

                                rjTexbox1.Texts = "";

                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("selcted the 'one'  AND 'all' information:");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Erorr:" + "  This option only used in  deleted menu actions:....");
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,reg_no AS REG_NO,work AS WORK,date AS DATE,intime AS INTIME,outtime AS OUTTIME,done AS DONE FROM  attanes ", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                da = 1;
                de = 0;
                delanother = 0;
            }
            catch(SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this page workking............ stage...");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this page workking............ stage...");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            con.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                sda = new SqlDataAdapter(@"SELECT name AS NAME,work AS WORK,date AS DATE,time AS TIME,mobile_no AS MOBLIE_NO,address AS ADDRESS FROM another", connection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                da = 0;
                de = 0;
                delanother = 1;
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }
    }
}
