using Android.App;
using Android.OS;
using Android.Test;
using Android.Widget;
using Android.Media;
using Android.Content;
using Obito.Resources.layout2;
using System.Data;
using System.Text.RegularExpressions;
using static Android.Webkit.WebSettings;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Net;
using Java.Net;
using Android;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;







namespace Obito.Resources.layout1;

[Activity (Label ="guna")]
public class Activity1 : Activity
{
    private MediaPlayer mediaPlayer;

    public int vv = 0;
  

    private EditText edt1;
    private EditText edt2;

    private EditText edtresult;

    private TextView texview1;


    private Button btn0;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btn5;
    private Button btn6;
    private Button btn7;
    private Button btn8;
    private Button btn9;
    private Button btnresult;


    private Button btnac;
    private Button btnRemove;
    private Button btnwork;

    private Button btndev;
    private Button btnmul;
    private Button btnadd;
    private Button btnsub;
    private Button btni;
    private Button btnclose;

    private Vibrator vibrator;
  

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.Layout1);

       
        

        edt1 = FindViewById<EditText>(Resource.Id.editText1);
        edt2 = FindViewById<EditText>(Resource.Id.editText2);
        //edtresult = FindViewById<EditText>(Resource.Id.editText4);

        texview1 = FindViewById<TextView>(Resource.Id.textView1);

        btn0 = FindViewById<Button>(Resource.Id.btn0);
        btn1 = FindViewById<Button>(Resource.Id.btn1);
        btn2 = FindViewById<Button>(Resource.Id.btn2);
        btn3 = FindViewById<Button>(Resource.Id.btn3);
        btn4 = FindViewById<Button>(Resource.Id.btn4);
        btn5 = FindViewById<Button>(Resource.Id.btn5);

        btn6 = FindViewById<Button>(Resource.Id.btn6);
        btn7 = FindViewById<Button>(Resource.Id.btn7);
        btn8 = FindViewById<Button>(Resource.Id.btn8);
        btn9 = FindViewById<Button>(Resource.Id.btn9);
        btnresult = FindViewById<Button>(Resource.Id.btnmain);

        btnac = FindViewById<Button>(Resource.Id.btnAC);
        btnRemove = FindViewById<Button>(Resource.Id.btnRm);
        btnwork = FindViewById<Button>(Resource.Id. btnnot);

        btndev = FindViewById<Button>(Resource.Id.btndev);
        btnmul = FindViewById<Button>(Resource.Id.btnmul);
        btnadd = FindViewById<Button>(Resource.Id.btnadd);
        btnsub = FindViewById<Button>(Resource.Id.btnsub);
        btni = FindViewById<Button>(Resource.Id.btni);
        btnclose = FindViewById<Button>(Resource.Id.btnclose);


        edt1.AfterTextChanged += EditText1Changed;
        edt2.AfterTextChanged += EditText2Changed;

        texview1.AfterTextChanged += EditText3Changed;

        vibrator = (Vibrator)GetSystemService(VibratorService);
        
        btn0.Click += btn0_click; 
        btn1.Click += btn1_click;
        btn2.Click += btn2_click;
        btn3.Click += btn3_click;
        btn4.Click += btn4_click;
        btn5.Click += btn5_click;
        btn6.Click += btn6_click;
        btn7.Click += btn7_click;
        btn8.Click += btn8_click;
        btn9.Click += btn9_click;
        btnresult.Click += btnresult_click;

        btnac.Click += btnAC_click;
        btnRemove.Click += btnRemove_click;
        btnwork.Click += btnwork_click;

        btndev.Click += btndev_click;
        btnmul.Click += btnmul_click;
        btnadd.Click += btnadd_click;
        btnsub.Click += btnsub_click;
        btni.Click += btni_click;
        btnclose.Click += btnclose_click;

        edt1.Click += edt1_click;
        edt2.Click += edt2_click;
        // edt3.Click += edt3_click;

        // Create your application here

    }
   
    private void EditText1Changed(object sender,EventArgs e)
    {
        int txtsize1;
        txtsize1 = 49;

        int txtsize2;
        txtsize2 = 36;

        int txtsize3;
        txtsize3 = 30;



        if (edt1.Text.Length>12)
        {

            
            
            edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            //Toast.MakeText(this, "Reached the maximum number of digits(12)!..", ToastLength.Short).Show();
            // edt1.Text = edt1.Text.Substring(0, 12);
            //edt1.SetSelection(edt1.Text.Length);
            
        }
        if (edt1.Text.Length <=12)
        {
            edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize1);
        }
        if (edt1.Text.Length > 16)
        {

            edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize3);
         
        }
        if (edt1.Text.Length > 19)
        {



            //edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            Toast.MakeText(this, "Reached the maximum number of digits(19)!..", ToastLength.Short).Show();
            vibrator.Vibrate(250);
            edt1.Text = edt1.Text.Substring(0, 19);
            edt1.SetSelection(edt1.Text.Length);

        }
    }
    private void EditText2Changed(object sender, EventArgs e)
    {
        int txtsize1;
        txtsize1 = 49;

        int txtsize2;
        txtsize2 = 36;

        int txtsize3;
        txtsize3 = 30;



        if (edt2.Text.Length > 12)
        {



            edt2.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            //Toast.MakeText(this, "Reached the maximum number of digits(12)!..", ToastLength.Short).Show();
            // edt1.Text = edt1.Text.Substring(0, 12);
            //edt1.SetSelection(edt1.Text.Length);

        }
        if (edt2.Text.Length <= 12)
        {
            edt2.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize1);
        }
        if (edt2.Text.Length > 16)
        {

            edt2.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize3);

        }
        if (edt2.Text.Length > 19)
        {



            //edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            Toast.MakeText(this, "Reached the maximum number of digits(19)!..", ToastLength.Short).Show();
            vibrator.Vibrate(250);
            // edt1.Text = edt1.Text.Substring(0, 12);
            //edt1.SetSelection(edt1.Text.Length);

        }
    }
    private void EditText3Changed(object sender, EventArgs e)
    {
        int txtsize1;
        txtsize1 = 49;

        int txtsize2;
        txtsize2 = 36;

        int txtsize3;
        txtsize3 = 30;



        if (texview1.Text.Length > 12)
        {



            texview1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            //Toast.MakeText(this, "Reached the maximum number of digits(12)!..", ToastLength.Short).Show();
            // edt1.Text = edt1.Text.Substring(0, 12);
            //edt1.SetSelection(edt1.Text.Length);

        }
        if (texview1.Text.Length <= 12)
        {
            texview1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize1);
        }
        if (texview1.Text.Length > 16)
        {

            texview1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize3);

        }
        if (texview1.Text.Length > 19)
        {



            //edt1.SetTextSize(Android.Util.ComplexUnitType.Dip, txtsize2);
            Toast.MakeText(this, "Reached the maximum number of digits(19)!..", ToastLength.Short).Show();
            vibrator.Vibrate(250);
            texview1.Text = texview1.Text.Substring(0, 19);
            ///texview1.SetSelection(texview1.Text.Length);

        }
    }
    private void btn0_click(object sender, EventArgs e)
    {

       
                edt1.Text += "0";
        vibrator.Vibrate(90);//vibrated 500 millisecondes

        
        
    }
    private void btn1_click(object sender, EventArgs e)
    {
        edt1.Text += "1";
        vibrator.Vibrate(90);
    }
    private void btn2_click(object sender, EventArgs e)
    {

        edt1.Text += "2";
        vibrator.Vibrate(90);
    }
    private void btn3_click(object sender, EventArgs e)
    {

        edt1.Text += "3";
        vibrator.Vibrate(90);
    }
    private void btn4_click(object sender, EventArgs e)
    {

        edt1.Text += "4";
        vibrator.Vibrate(90);
    }
    private void btn5_click(object sender, EventArgs e)
    {

        edt1.Text += "5";
        vibrator.Vibrate(90);
    }
    private void btn6_click(object sender, EventArgs e)
    {

        edt1.Text += "6";
        vibrator.Vibrate(90);
    }
    private void btn7_click(object sender, EventArgs e)
    {

        edt1.Text += "7";
        vibrator.Vibrate(90);
    }
    private void btn8_click(object sender, EventArgs e)
    {

        edt1.Text += "8";
        vibrator.Vibrate(90);
    }
    private void btn9_click(object sender, EventArgs e)
    {

        edt1.Text += "9";
        vibrator.Vibrate(90);
    }
    
    /// ///////////////////////////////////////////////////////////////////////////////////////
    
    private void btnAC_click(object sender, EventArgs e)
    {

        edt1.Text = string.Empty;
        edt2.Text = string.Empty;
        texview1.Text = String.Empty;
        vibrator.Vibrate(90);
    }
    private void btnRemove_click(object sender,EventArgs e)
    {
        vibrator.Vibrate(90);
       
            if (edt1.Text.Length > 0)
            {
                edt1.Text = edt1.Text.Substring(0, edt1.Text.Length - 1);
                edt1.SetSelection(edt1.Text.Length);
            }
        
    }

    private void btnwork_click(object sender,EventArgs e)
    {
        ////Intent intent = new Intent(this, typeof(Activity2));
        //StartActivity(intent);
        //Toast.MakeText(this, "This layout working stage!..", ToastLength.Long).Show();
        StartActivity(typeof(Activity2));
    }
    private void btndev_click(object sender, EventArgs e)
    {
        edt1.Text += "/";
        vibrator.Vibrate(90);
    }
    private void btnmul_click(object sender, EventArgs e)
    {
        edt1.Text += "*";
        vibrator.Vibrate(90);
    }
    private void btnadd_click(object sender, EventArgs e)
    {
        edt1.Text += "+";
        vibrator.Vibrate(90);

    }
    private void btnsub_click(object sender, EventArgs e)
    {
        edt1.Text += "-";
        vibrator.Vibrate(90);
    }
    private void btni_click(object sender, EventArgs e)
    {

        edt1.Text += ".";
        vibrator.Vibrate(90);
    }
    private void btnclose_click(object sender, EventArgs e)
    {
        //this command usage for closed all layout and full aplication wil be cosed function ....
        FinishAffinity();
        vibrator.Vibrate(500);
    }

    private void edt1_click(object sender, EventArgs e)
    {
       
       
    }
    private void edt2_click(object sender, EventArgs e)
    {

        if (edt2.Text=="ERROR")
        {
            edt1.Text = "";
        }
        else
        {
            edt1.Text = "";
            edt1.Text += edt2.Text;
        }
    }

    ///////////////////////////////////////////////////
    private void btnresult_click(object sender, EventArgs e)
    { try
        {
            edt2.SetTextColor(Android.Graphics.Color.ParseColor("#0088CC"));
            vibrator.Vibrate(90);
            string input = edt1.Text;
            string intputtem = edt1.Text;
            input = Regex.Replace(input, @"\s+", " ");
             try
             {
                 var table = new DataTable();
                decimal result = Convert.ToDecimal(table.Compute(input, string.Empty));
                 edt2.Text = "";
                 //decimal tot;
                 //string tem;
                 // tot = result;
                 edt2.Text += result;
                // edt2.Text = edt1.Text;
                 //tem = edt1.Text.ToString();
                 
                 //texview1.Text += input;
                 edt1.Text = "";
             }
             catch (Exception x)
             {
                
                // Toast.MakeText(this, "INVALID INPUT FORMET ", ToastLength.Long).Show();
                if(1==1)
                {
                    edt2.Text = "";
                    edt2.Text += "ERROR";
                    edt2.SetTextColor(Android.Graphics.Color.ParseColor("#FF0000"));
                }
             }
            texview1.Text = "";
            texview1.Text = intputtem;
        }
        catch (Exception x)
        {
            Toast.MakeText(this, "Erorr : " + x.Message, ToastLength.Long).Show();
        }



    }
}   
 
