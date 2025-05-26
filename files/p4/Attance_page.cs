using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CMS
{
    public partial class form6 : Form
    {
        public SqlConnection con;
        public string str;

        public int ds;    ////// ds mening is day starting..
        public int df;     ////// df meaing is data fist in the day order...


        //public string mydata;
        public int attpro = 0;
       // public string m;
      
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public int sno = 1;
        public string result;
        public string www = "working";
        public string done = "DONE";

        public int nn = 0;


        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public form6()
        {
            InitializeComponent();

            


            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//grammar.txt");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpeechRecognized);

            speech.SelectVoiceByHints(VoiceGender.Female);

            //////////////////////////////////////////////////////////////////////////////////////
            //textBox4.Text = dateTimePicker1.Value.ToShortDateString();

        }

        public void recEngne_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            /*string result = e.Result.Text;
            if (result == "Hi")
            {
                result = "Hello ,my name is,guna, how can i help you";

                Form2 a = new Form2();
                a.Show();

            }
            speech.SpeakAsync(result);
           
             * label3.Text = result;*/

        }

        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;


        private void form6_Load(object sender, EventArgs e)
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
            rjTexbox4.Texts = dateTimePicker1.Value.ToShortDateString();
            //textBox5.Text = dateTimePicker1.Value.ToLongTimeString();
            //textBox5.Text += DateTime.Now.ToString("HH:mm:ss");      **** this the 24 houres time formate:
            rjTexbox5.Texts += DateTime.Now.ToString("hh:mm:tt");


            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in FilterInfoCollection)
                comboBox1.Items.Add(device.Name);
            comboBox1.SelectedIndex = 0;

           

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            gunaButton3.BackColor = Color.Cyan;

            gunaButton4.BackColor = Color.Black;

            gunaButton5.BackColor = Color.Black;

            attpro = 0;


            try
            {
               
                //int sno = 1;

                ////////////////////////// day starting  first data with in data base .....

                con.Open();

                rjTexbox1.Texts = "=";
                rjTexbox2.Texts = "=";
                rjTexbox3.Texts = "=";
                rjTexbox4.Texts = "=";
                rjTexbox5.Texts = "=";

                string qry = "INSERT INTO attanes(name,reg_no,work,date,intime,outtime)VALUES('" + rjTexbox1.Texts + "','" + rjTexbox2.Texts + "','" + rjTexbox3.Texts + "','" + rjTexbox4.Texts + "','" + rjTexbox5.Texts + "','"+rjTexbox5.Texts+"')";


                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("day starting data stored....");

                rjTexbox1.Texts = "";
                rjTexbox2.Texts = "";
                rjTexbox3.Texts = "";
                rjTexbox4.Texts = "";
                rjTexbox5.Texts = "";

                rjTexbox2.Texts = "";
                // con.Close();

                
                con.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Error  :" + x.Message);
            }
            label12.Text = "";
            sno = 0;
            sno = sno + 1;
            label12.Text += sno;
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            gunaButton3.BackColor = Color.Black;

            gunaButton4.BackColor = Color.Cyan;

            gunaButton5.BackColor = Color.Black;

           
            MessageBox.Show(" 1 =  comming ");

            
            attpro = 1;

            

           
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            gunaButton3.BackColor = Color.Black;

            gunaButton4.BackColor = Color.Black;

            gunaButton5.BackColor = Color.Cyan;

           
            
            MessageBox.Show(" 2 =  outing ");

            
            attpro = 2;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
            videoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

            gunaButton2.Focus();
        }

       private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
               BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if(result!=null)
            {
                rjTexbox2.Invoke(new MethodInvoker(delegate ()
                {
                    rjTexbox2.Texts = result.ToString();

                    //MessageBox.Show("ok");

                }));
               
            }
            pictureBox1.Image = bitmap;

           // MessageBox.Show("ok");



        }

        private void form6_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (videoCaptureDevice != null)
                videoCaptureDevice.Stop();
           


        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            //videoCaptureDevice.Stop();
            try
            {
                if (attpro == 1)
                {




                    if (rjTexbox2.Texts == "")
                    {
                        MessageBox.Show("Input Eorr:" + "employe id is emtey:");
                    }
                    else if (rjTexbox1.Texts == "")
                    {
                        MessageBox.Show("Input Eorr:" + "employe name is emtey:");
                    }
                    else if (rjTexbox3.Texts == "")
                    {

                        MessageBox.Show("Input Eorr:" + "emp;loye job_tittle is emtey:");

                    }

                    else
                    {







                        /*
                            con.Open();
                             
                         string qry = "INSERT INTO attanes(sno,name,e_id,job_tittle,date)VALUES('"+label5.Text+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("data stored");
                            
                           
                        con.Close();

                        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Admin\Desktop\testing\shafty demo\savingimage\savingimage\Database1.mdf;Integrated Security=True;User Instance=True");
                        sda = new SqlDataAdapter(@"SELECT       sno AS SNO,date AS DATE,name AS NAME,e_id As E_ID FROM      attanes", connection);
                        dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;*/
                        con.Open();


                        string qry = "select reg_no,date from attanes where(date='" +rjTexbox4.Texts + "' AND reg_no='" + rjTexbox2.Texts + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("yes this is working:");

                            rjTexbox1.Texts = "";
                            rjTexbox2.Texts = "";
                            rjTexbox3.Texts = "";
                            pictureBox2.Image = null;

                            gunaButton2.Focus();
                        }
                        else
                        {
                            dr.Close();
                            MessageBox.Show("it is not  working:");
                            string qrry = "INSERT INTO attanes(name,reg_no,work,date,intime,outtime)VALUES('" + rjTexbox1.Texts + "','" + rjTexbox2.Texts + "','" + rjTexbox3.Texts + "','" + rjTexbox4.Texts + "','" + rjTexbox5.Texts + "','" + www + "')";

                            SqlCommand cmmd = new SqlCommand(qrry, con);
                            cmmd.ExecuteNonQuery();

                           // MessageBox.Show("data stored");
                            result = "wellcom to  " + "  " + rjTexbox1.Texts;

                            speech.SpeakAsync(result);

                            label12.Text = "";
                            sno = sno + 1;
                            label12.Text += sno;


                            //con.Close();

                            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                            sda = new SqlDataAdapter(@"SELECT       date AS DATE,name AS NAME,reg_no As REG_NO,intime As INTIME,outtime As OUTTIME,done AS DONE  FROM      attanes where(date='" + rjTexbox4.Texts + "')", connection);
                            dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                            rjTexbox5.Texts = "";

                            rjTexbox5.Texts += DateTime.Now.ToString("hh:mm:tt");
                            //rjTexbox5.Texts = dateTimePicker1.Value.ToLongTimeString();

                            rjTexbox1.Texts = "";
                            rjTexbox2.Texts = "";
                            rjTexbox3.Texts = "";
                            pictureBox2.Image = null;

                            gunaButton2.Focus();
                        }


                        con.Close();
                        ////////////////////// system voice//////////////////////


                        // string result;


                        // textBox1.Text += result;



                        rjTexbox1.Texts = "";
                        rjTexbox2.Texts = "";
                        rjTexbox3.Texts = "";
                        pictureBox2.Image = null;

                        gunaButton2.Focus();






                    }


                }

                else if (attpro == 2)
                {


                    if (rjTexbox2.Texts == "")
                    {
                        MessageBox.Show("Input Eorr:" + "employe id is emtey:");
                    }
                    else if (rjTexbox1.Texts == "")
                    {
                        MessageBox.Show("Input Eorr:" + "employe name is emtey:");
                    }
                    else if (rjTexbox3.Texts == "")
                    {

                        MessageBox.Show("Input Eorr:" + "emp;loye job_tittle is emtey:");

                    }

                    else
                    {

                        con.Open();

                        string qry = "select reg_no,outtime from attanes where(reg_no='" + rjTexbox2.Texts + "' AND outtime='" + www + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {

                            dr.Close();
                            string qrry = "UPDATE attanes SET outtime='" + rjTexbox5.Texts + "',done='" + done + "' WHERE(reg_no='" + rjTexbox2.Texts + "')";
                            SqlCommand cmmd = new SqlCommand(qrry, con);
                            cmmd.ExecuteNonQuery();
                            MessageBox.Show("This employe not exited:");



                            result = "thank you  " + "  " + rjTexbox1.Texts;

                            speech.SpeakAsync(result);

                            //MessageBox.Show("out time stored done");

                            rjTexbox5.Texts = "";

                            rjTexbox5.Texts += DateTime.Now.ToString("hh:mm:tt");

                            rjTexbox1.Texts = "";
                            rjTexbox2.Texts = "";
                            rjTexbox3.Texts = "";
                            pictureBox2.Image = null;

                            gunaButton2.Focus();

                            // rjTexbox5.Texts = dateTimePicker1.Value.ToLongTimeString();

                            //con.Close();

                        }

                        else
                        {
                            MessageBox.Show("This employe already exited:");

                            rjTexbox1.Texts = "";
                            rjTexbox2.Texts = "";
                            rjTexbox3.Texts = "";
                            pictureBox2.Image = null;

                            gunaButton2.Focus();
                        }
                        con.Close();



                        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\CMS\CMS\CMS\Database\Database1.mdf;Integrated Security=True");
                        sda = new SqlDataAdapter(@"SELECT      date AS DATE,name AS NAME,reg_no As REG_NO,intime As INTIME,outtime As OUTTIME,done AS DONE  FROM      attanes where(date='" + rjTexbox4.Texts + "')", connection);
                        dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;






                    }
                }
                else if (attpro == 0)
                {
                    MessageBox.Show("please click the 'comming ' or 'outing'  opction");
                }
            }
            catch (Exception X)
            {
                MessageBox.Show("Eorro" + X.Message);

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (rjTexbox2.Texts == "")
                {
                    MessageBox.Show("Input Erorr:" + "pleace enter the employe id");
                }
                else
                {
                    con.Open();
                    string qry = "SELECT        name,reg_no,work,photo FROM edata where(reg_no='" + rjTexbox2.Texts + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        rjTexbox1.Texts = (dr["name"].ToString());
                        rjTexbox3.Texts = (dr["work"].ToString());
                        //

                        //////image retive in datbase to pictuerbox //////


                        //byte[] imagebyte = (byte[])dr["image"];
                        // MemoryStream memorystream = new MemoryStream(imagebyte);

                        //pictureBox1.Image = Image.FromStream(memorystream);


                        con.Close();
                        rjTexbox4.Texts = dateTimePicker1.Value.ToShortDateString();

                        rjTexbox5.Texts = "";
                        rjTexbox5.Texts += DateTime.Now.ToString("hh:mm:tt");
                       // MessageBox.Show("done");
                        dr.Close();
                       // rjTexbox1.Texts = "";

                    }



                    else
                    {
                        MessageBox.Show("ivalid e id:");
                        rjTexbox2.Texts = "";
                        con.Close();

                        nn = 1;
                        gunaButton2.Focus();



                    }

                    //////////////////////////////////////

                    if (nn==0)
                    {

                        con.Open();
                        string qrry = "SELECT reg_no,photo FROM edata where(reg_no='" + rjTexbox2.Texts+ "')";
                        SqlCommand cmmd = new SqlCommand(qrry, con);
                        // cmmd.Parameters.AddWithValue("@ename", textBox1.Text);
                        using (SqlDataReader drr = cmmd.ExecuteReader())
                        {
                            if (drr.Read())
                            {

                                //textBox2.Text = dr["ename"].ToString();
                                byte[] imagebyte = (byte[])drr["photo"];
                                MemoryStream memorystream = new MemoryStream(imagebyte);
                                pictureBox2.Image = Image.FromStream(memorystream);
                                //pictureBox1.Image = Image.FromStream(memorystream);
                                drr.Close();
                                //MessageBox.Show("image printed");
                                con.Close();
                            }
                            else
                            {
                                MessageBox.Show("employe image not fond:");
                                con.Close();
                            }


                        }

                       
                        gunaButton6.Focus();

                    }

                }

            }
            catch (SqlException x)
            {
                MessageBox.Show("Erorr:" + x.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            rjTexbox4.Texts = "";
            rjTexbox4.Texts = dateTimePicker1.Value.ToShortDateString();


            rjTexbox5.Texts = "";
            rjTexbox5.Texts = dateTimePicker1.Value.ToLongTimeString();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            con.Close();
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.Stop();

        }
    }
}

 