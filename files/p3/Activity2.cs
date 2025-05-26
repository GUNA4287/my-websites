using Android.App;
using Android.OS;
using Android.Content;
using Android.Widget;
using Android.Content.PM;
using Java.Security.Spec;
using System.Text.RegularExpressions;
using System.Data;

namespace Obito.Resources.layout2;

[Activity]
public class Activity2 : Activity
{
    
    private bool isTitleHidden = false;


    private EditText edt1;

    private Button btnadd;
    private Button btnsub;
    private Button btnres;


    private Button btn1;
    private Button btn2;
    private Button btn3;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        try
        {






            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Layout2);

            

            
         
            // Create your application here

            RequestedOrientation = ScreenOrientation.Landscape;

            edt1 = FindViewById<EditText>(Resource.Id.edt1);

            btnadd = FindViewById<Button>(Resource.Id.btnadd);
            btnsub = FindViewById<Button>(Resource.Id.btnsub);
            btnres = FindViewById<Button>(Resource.Id.btnres);

            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn2 = FindViewById<Button>(Resource.Id.btn2);


            btnadd.Click += btnaddclick;
            btnsub.Click += btnsubclick;
            btnres.Click += btnresclick;
            btn1.Click += btnclick;
            btn2.Click += btn2click;

        }
        catch (Exception x)
        {
            Toast.MakeText(this, "Erorr : " + x.Message, ToastLength.Long).Show();
        }



    }
    private void btnresclick(object sender, EventArgs e)
    {
        try
        {
            /*string input = edt1.Text;
            string[] parts = input.Split('+');
            int sum = 0;
            foreach (string part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    sum += number;
                }
                else
                {
                    Toast.MakeText(this, "invalid input", ToastLength.Short).Show();
                    return;
                }
                edt1.Text = "";
                edt1.Text = sum.ToString();

                
            }*/

            ///$$$$$$$$$$$$$$$$$$############################################################################$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            string input = edt1.Text;
            input = Regex.Replace(input, @"\s+", " ");
            try
            {
                var table = new DataTable();
                var result = Convert.ToDecimal( table.Compute(input, string.Empty));
                edt1.Text = "";
                edt1.Text = result.ToString();
            }
            catch (Exception x)
            {
                Toast.MakeText(this, "invalid input " + x.Message, ToastLength.Long).Show();
            }
        }
        catch(Exception x)
        {
            Toast.MakeText(this, "Erorr : " + x.Message, ToastLength.Long).Show();
        }
    }
    private void btnaddclick(object sender, EventArgs e)
    {
        edt1.Text += "+";
    }
    private void btnsubclick(object sender, EventArgs e)
    {
        edt1.Text += "-";
    }
    private void btnclick(object sender,EventArgs e)
    {
        edt1.Text +="1";
    }
    private void btn2click(object sender, EventArgs e)
    {
        edt1.Text += "2";
    }
}