using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class Form2 : Form
    {
        public SqlConnection con;
        public string str;

        // public int lockml = 0;
        //public int lockal = 0;
        public Form2()
        {
            InitializeComponent();
            CustemizeDesign();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //MessageBox.Show("logo");
            btnLogo.BackColor = Color.Blue;
            btnLogo.BorderColor = Color.White;
            btnLogo.ForeColor = Color.White;


            Form5.locklm = "1";



        }
        private void CustemizeDesign()
        {
            panelLoginsubmenu.Visible = false;
            panelSigninsubmenu.Visible = false;
            //....

        }

        private void hideSubMenu()
        {

            if (panelLoginsubmenu.Visible == true)
                panelLoginsubmenu.Visible = false;
            if (panelSigninsubmenu.Visible == true)
                panelSigninsubmenu.Visible = false;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            btnHome.BackColor = Color.DimGray;
            btnHome.BorderColor = Color.DimGray;



            btnLogin.BackColor = Color.Blue;
            btnLogin.BorderColor = Color.White;


            btnSignin.BackColor = Color.DimGray;
            btnSignin.BorderColor = Color.DimGray;


            btnAdmin.BackColor = Color.DimGray;
            btnAdmin.BorderColor = Color.DimGray;

            btnClose.BackColor = Color.DimGray;
            btnClose.BorderColor = Color.DimGray;
            ////////////////////////////////////////////////////


            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            showSubMenu(panelLoginsubmenu);
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            hideSubMenu();

           // Form5.locklm = "0";

            Form4.lockla = "0";

            btnHome.BackColor = Color.DimGray;
            btnHome.BorderColor = Color.DimGray;



            btnLogin.BackColor = Color.DimGray;

            btnLogin.BorderColor = Color.DimGray;


            btnSignin.BackColor = Color.Blue;
            btnSignin.BorderColor = Color.White;


            btnAdmin.BackColor = Color.DimGray;
            btnAdmin.BorderColor = Color.DimGray;

            btnClose.BackColor = Color.DimGray;
            btnClose.BorderColor = Color.DimGray;

            /////////////////////////////////////////////////////

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;



            showSubMenu(panelSigninsubmenu);




        }

        /*private void btnLmanager_Click(object sender, EventArgs e)
        {

         
        }*/

        private void btnHome_Click(object sender, EventArgs e)
        {
            hideSubMenu();


            btnHome.BackColor = Color.Blue;
            btnHome.BorderColor = Color.White;



            btnLogin.BackColor = Color.DimGray;
            btnLogin.BorderColor = Color.DimGray;


            btnSignin.BackColor = Color.DimGray;
            btnSignin.BorderColor = Color.DimGray;


            btnAdmin.BackColor = Color.DimGray;
            btnAdmin.BorderColor = Color.DimGray;

            btnClose.BackColor = Color.DimGray;
            btnClose.BorderColor = Color.DimGray;
            ////////////////////////////////////////////
            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            ///////////////////////////////////////////////// 
            label3.Text = "";
            label3.Text = "HOME PAGE";

            Form5.locklm = "0";

            Form4.lockla = "0";

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            hideSubMenu();



            //Form5.locklm = "0";


            btnHome.BackColor = Color.DimGray;
            btnHome.BorderColor = Color.DimGray;



            btnLogin.BackColor = Color.DimGray;
            btnLogin.BorderColor = Color.DimGray;


            btnSignin.BackColor = Color.DimGray;
            btnSignin.BorderColor = Color.DimGray;


            btnAdmin.BackColor = Color.Blue;
            btnAdmin.BorderColor = Color.White;


            btnClose.BackColor = Color.DimGray;
            btnClose.BorderColor = Color.DimGray;

            /////////////////////////////////////
            ///
            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            //////////////////////////////////////////////////////

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            Form5.locklm = "0";

            if (Form4.lockla == "1")
            {

                // openChildForm(new Form4());

                label3.Text = "";
                label3.Text = "ADMIN PAGE";
                openChildForm(new Form10());
            }
            else
            {
                MessageBox.Show("frstofal login with in admin:");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            hideSubMenu();






            btnHome.BackColor = Color.DimGray;
            btnHome.BorderColor = Color.DimGray;



            btnLogin.BackColor = Color.DimGray;
            btnLogin.BorderColor = Color.DimGray;


            btnSignin.BackColor = Color.DimGray;
            btnSignin.BorderColor = Color.DimGray;


            btnAdmin.BackColor = Color.DimGray;
            btnAdmin.BorderColor = Color.DimGray;

            btnClose.BackColor = Color.Blue;
            btnClose.BorderColor = Color.White;




            //////////////////////////////////////////////////////

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            this.Close();

            //openChildForm(new Form5());
        }

        private void btnLadmin_Click(object sender, EventArgs e)
        {
            try
            {
                btnLmanager.BackColor = Color.DarkSlateGray;
                btnLmanager.BorderColor = Color.DarkSlateGray;

                btnLadmin.BackColor = Color.Blue;
                btnLadmin.BorderColor = Color.White;

                btnLattance.BackColor = Color.DarkSlateGray;
                btnLattance.BorderColor = Color.DarkSlateGray;

                btnSmanger.BackColor = Color.DarkSlateGray;
                btnSmanger.BorderColor = Color.DarkSlateGray;

                btnSadmin.BackColor = Color.DarkSlateGray;
                btnSadmin.BorderColor = Color.DarkSlateGray;

                btnSemploye.BackColor = Color.DarkSlateGray;
                btnSemploye.BorderColor = Color.DarkSlateGray;

                gunaButton1.BackColor = Color.DarkSlateGray;
                gunaButton1.BorderColor = Color.DarkSlateGray;

                label3.Text = "";
                label3.Text = "ADMIN LOGIN";

                Form5.locklm = "0";
                Form4.lockla = "0";

                openChildForm(new Form4());

            }
            catch (SqlException x)
            {

                MessageBox.Show("Erorr:" + x.Message);
            }

        }

        private void btnSmanger_Click(object sender, EventArgs e)
        {

            Form5.locklm = "0";
            Form4.lockla = "0";

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.Blue;
            btnSmanger.BorderColor = Color.White;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            ///////////////////////////////////////////////

            label3.Text = "";
            label3.Text = "MANAGER SIGIN";
            openChildForm(new Form7());
        }

        private void btnSadmin_Click(object sender, EventArgs e)
        {
            Form5.locklm = "0";
            Form4.lockla = "0";

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.Blue;
            btnSadmin.BorderColor = Color.White;

            btnSemploye.BackColor = Color.DarkSlateGray;
            btnSemploye.BorderColor = Color.DarkSlateGray;

            label3.Text = "";
            label3.Text = "ADMIN SINGIN";


            openChildForm(new Form9());
        }

        private void btnSemploye_Click(object sender, EventArgs e)
        {
            Form5.locklm = "0";
            Form4.lockla = "0";

            btnLmanager.BackColor = Color.DarkSlateGray;
            btnLmanager.BorderColor = Color.DarkSlateGray;

            btnLadmin.BackColor = Color.DarkSlateGray;
            btnLadmin.BorderColor = Color.DarkSlateGray;

            btnLattance.BackColor = Color.DarkSlateGray;
            btnLattance.BorderColor = Color.DarkSlateGray;

            gunaButton1.BackColor = Color.DarkSlateGray;
            gunaButton1.BorderColor = Color.DarkSlateGray;

            btnSmanger.BackColor = Color.DarkSlateGray;
            btnSmanger.BorderColor = Color.DarkSlateGray;

            btnSadmin.BackColor = Color.DarkSlateGray;
            btnSadmin.BorderColor = Color.DarkSlateGray;

            btnSemploye.BackColor = Color.Blue;
            btnSemploye.BorderColor = Color.White;

            //////////////////////////////////////////////////////////////////

            label3.Text = "";
            label3.Text = "EMPLOYE SINGIN";

            openChildForm(new Form8());

        }


        private Form activeForm = null;

        private void openChildForm(Form childform)
        {

            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childform);
            panelChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLattance_Click(object sender, EventArgs e)
        {
            if (Form5.locklm == "1")
            {



                btnLmanager.BackColor = Color.DarkSlateGray;
                btnLmanager.BorderColor = Color.DarkSlateGray;

                btnLadmin.BackColor = Color.DarkSlateGray;
                btnLadmin.BorderColor = Color.DarkSlateGray;

                btnLattance.BackColor = Color.Blue;
                btnLattance.BorderColor = Color.White;

                btnSmanger.BackColor = Color.DarkSlateGray;
                btnSmanger.BorderColor = Color.DarkSlateGray;

                btnSadmin.BackColor = Color.DarkSlateGray;
                btnSadmin.BorderColor = Color.DarkSlateGray;

                btnSemploye.BackColor = Color.DarkSlateGray;
                btnSemploye.BorderColor = Color.DarkSlateGray;

                gunaButton1.BackColor = Color.DarkSlateGray;
                gunaButton1.BorderColor = Color.DarkSlateGray;

                openChildForm(new form6());

                label3.Text = "";
                label3.Text = "ATTANCE FORM";
            }
            else
            {
                MessageBox.Show("fisteofal login with in  manager:");

            }
        }

        private void btnLmanager_Click_1(object sender, EventArgs e)
        {




            try
            {
                btnLmanager.BackColor = Color.Blue;
                btnLmanager.BorderColor = Color.White;

                btnLadmin.BackColor = Color.DarkSlateGray;
                btnLadmin.BorderColor = Color.DarkSlateGray;

                btnLattance.BackColor = Color.DarkSlateGray;
                btnLattance.BorderColor = Color.DarkSlateGray;

                btnSmanger.BackColor = Color.DarkSlateGray;
                btnSmanger.BorderColor = Color.DarkSlateGray;

                btnSadmin.BackColor = Color.DarkSlateGray;
                btnSadmin.BorderColor = Color.DarkSlateGray;

                btnSemploye.BackColor = Color.DarkSlateGray;
                btnSemploye.BorderColor = Color.DarkSlateGray;

                gunaButton1.BackColor = Color.DarkSlateGray;
                gunaButton1.BorderColor = Color.DarkSlateGray;

                label3.Text = "";
                label3.Text = "MANAGER LOGIN";

                Form5.locklm = "0";

                Form4.lockla = "0";


                openChildForm(new Form5());
            }

            catch (SqlException x)
            {

                MessageBox.Show("Erorr:" + x.Message);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {/*
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
               // MessageBox.Show("Database connected..");
                con.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
           */
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {

            if (Form5.locklm == "1")
            {


                try
                {
                    btnLmanager.BackColor = Color.DarkSlateGray;
                    btnLmanager.BorderColor = Color.DarkSlateGray;

                    btnLadmin.BackColor = Color.DarkSlateGray;
                    btnLadmin.BorderColor = Color.DarkSlateGray;

                    btnLattance.BackColor = Color.DarkSlateGray;
                    btnLattance.BorderColor = Color.DarkSlateGray;

                    btnSmanger.BackColor = Color.DarkSlateGray;
                    btnSmanger.BorderColor = Color.DarkSlateGray;

                    btnSadmin.BackColor = Color.DarkSlateGray;
                    btnSadmin.BorderColor = Color.DarkSlateGray;

                    btnSemploye.BackColor = Color.DarkSlateGray;
                    btnSemploye.BorderColor = Color.DarkSlateGray;

                    gunaButton1.BackColor = Color.Blue;
                    gunaButton1.BorderColor = Color.White;

                    label3.Text = "";
                    label3.Text = "ANOTHER LOGIN";

                    Form5.locklm = "0";

                    Form4.lockla = "0";


                    openChildForm(new Form11());
                }

                catch (SqlException x)
                {

                    MessageBox.Show("Erorr:" + x.Message);
                }
            }
            else
            {
                MessageBox.Show("fisteofal login with in  manager:");

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
