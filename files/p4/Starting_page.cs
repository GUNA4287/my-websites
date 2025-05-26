using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Data.SqlClient;

namespace CMS
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();

        public SqlConnection con;
        public string str;

        public Form1()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;

            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//grammar.txt");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpeechRecognized);

            speech.SelectVoiceByHints(VoiceGender.Male);

        }

        private void recEngne_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            /*string result = e.Result.Text;
            if (result == "Hi")
            {
                result = "Hello ,my name is,guna, how can i help you";

                Form2 a = new Form2();
                a.Show();

            }
            speech.SpeakAsync(result);
            label3.Text = result;*/
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = "";
            label2.Text = "";
            label2.Text = "LOADING...";
            circularProgressBar1.Value += 1;
            //circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";
            label1.Text = circularProgressBar1.Value.ToString() + "%";
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                Form2 a = new Form2();
                a.Show();
                this.Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
            label3.Text = "welcome to comeback";
            string result;
            result = "wellcome to , comeback sir  .  my name is   , shikamaru version 4.8 .  This application develaped by  ,   GUNALAKSHMANAN";
            speech.SpeakAsync(result);

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
