using Android.OS;                                     

using Android.App;
using Android.Views;
using Android.Widget;
using Android.Speech;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System;
using Android.App.AppSearch;
using Android.Health.Connect.DataTypes.Units;
using Org.Apache.Http.Util;

using System.Text;
using Newtonsoft.Json.Linq;
using Android.Text;
using SerpApi;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections;

using Java.Util;
using DE.Hdodenhof.Circleimageview;
using Android.Graphics.Drawables;
using Android.Views.InputMethods;



namespace chat.Resources.layout;

[Activity(Label = "bot_chating")]
public class bot_chating : Activity
{
    private Button mic;


    private TextView answerText;
    private Button btnAsk;
    private EditText inputQuestion;

    // const string apiKey = "";



    private int iii = 1;

    private Button chat_back;
    private RelativeLayout message_layout;
    private Button message;


    public int m = 1;
    public Boolean mes = false;

    private Handler handler;


    

   



    private ScrollView c_layout;
    private LinearLayout chat_layout;
    
    private Boolean message_panel = false;



    public string result;

    private InputMethodManager inputMethodManager;


    
    private Button bat_setting_btn;
    private bool bat_setting = false;
    private RelativeLayout bat_setting_layout;

    private TextView output_of_nwords;
    private EditText input_of_nwords;

    private Button done_input_of_nwords;


    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.bot_chating);

        ////////////////////////////////////////


        mic = FindViewById<Button>(Resource.Id.mic);
      

        inputQuestion = FindViewById<EditText>(Resource.Id.questioneditText);
        btnAsk = FindViewById<Button>(Resource.Id.searchbutton);
        answerText = FindViewById<TextView>(Resource.Id.text1);
        
        btnAsk.Click += async (sender, e) =>
        {
            
            string question = inputQuestion.Text;
            if(!string.IsNullOrWhiteSpace(question))
            {
                if (message_panel == true)
                {
                    if (inputMethodManager.IsAcceptingText)
                    {
                        inputMethodManager.HideSoftInputFromWindow(inputQuestion.WindowToken, HideSoftInputFlags.None);
                    }

                    message_layout.Visibility = ViewStates.Invisible;
                    message.Visibility = ViewStates.Visible;
                    message_panel = false;
                    c_layout.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
                    c_layout.RequestLayout();


                }
                else
                {

                }
                answerText.Text = "thinking";
                send_click(sender, e);
                 result = await GetSmartAnswer(question);
               // answerText.Text = result;
                user_click(sender, e);

                
                // TypeText(result);
            }
        };

        bat_setting_btn = FindViewById<Button>(Resource.Id.bat_setting_btn);
        bat_setting_layout = FindViewById<RelativeLayout>(Resource.Id.bat_setting_layout);

        output_of_nwords = FindViewById<TextView>(Resource.Id.output_of_nwords);
        input_of_nwords = FindViewById<EditText>(Resource.Id.input_of_nwords);
        done_input_of_nwords = FindViewById<Button>(Resource.Id.done_input_of_nwords);


        bat_setting_btn.Click += bat_setting_btn_click;
        done_input_of_nwords.Click += done;




        mic.Click += mic_click;

       




        // Create your application here /////////////////
        //////////////////////////////
        /////////////////////////






        start_page();
        chat_back = FindViewById<Button>(Resource.Id.chat_back);
        message_layout = FindViewById<RelativeLayout>(Resource.Id.message_layout);
        message = FindViewById<Button>(Resource.Id.message);


       

        c_layout = FindViewById<ScrollView>(Resource.Id.c_layout);
        chat_layout = FindViewById<LinearLayout>(Resource.Id.chat_layout);
       

    


        



        chat_layout.Click += message_close_click;

        chat_back.Click += chatback;
        message.Click += message_move;

        inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);


    }


    public void bat_setting_btn_click(object sender, EventArgs e)
    {   if(bat_setting==false)
        {
            bat_setting_layout.Visibility = ViewStates.Visible;
            bat_setting = true;
        }
        else
        {
            bat_setting_layout.Visibility = ViewStates.Invisible;
            bat_setting = false;
        }
       
    }




    /////////////////////////////////////////////////////////////////////////////////////
    ///




    public override void OnBackPressed()
    {
        
        message_layout.Visibility = ViewStates.Invisible;





        base.OnBackPressed();

    }
    public void chatback(object sender, EventArgs e)
    {

        Finish();
        StartActivity(typeof(bot));
        //move_message_layout();
        //message_layout.Animate().TranslationY(0).SetDuration(300).Start();

    }
    public void message_move(object sender, EventArgs e)
    {





        Handler handler = new Handler();
        new Handler().PostDelayed(() =>
        {
            message_layout.Visibility = ViewStates.Visible;
            inputQuestion.RequestFocus();
            inputMethodManager.ShowSoftInput(inputQuestion, ShowFlags.Implicit);
        }, 200);

       // inputQuestion.RequestFocus();
        message.Visibility = ViewStates.Invisible;
        message_panel = true;

        c_layout.LayoutParameters.Height = 535;
        c_layout.RequestLayout();



        c_layout.Post(() =>
        {
            c_layout.FullScroll(FocusSearchDirection.Down);

        });

        if(bat_setting==true)
        {
            bat_setting_layout.Visibility = ViewStates.Invisible;
            bat_setting = false;

        }


    }
    public void message_close_click(object sender, EventArgs e)
    {
        if (message_panel == true)
        {
            if(inputMethodManager.IsAcceptingText)
            {
                inputMethodManager.HideSoftInputFromWindow(inputQuestion.WindowToken, HideSoftInputFlags.None);
            }
           
            message_layout.Visibility = ViewStates.Invisible;
            message.Visibility = ViewStates.Visible;
          

            c_layout.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
            c_layout.RequestLayout();
            message_panel = false;
        }
        else
        {

        }
        if (bat_setting == true)
        {
            bat_setting_layout.Visibility = ViewStates.Invisible;
            bat_setting = false;

            if (inputMethodManager.IsAcceptingText)
            {
                inputMethodManager.HideSoftInputFromWindow(inputQuestion.WindowToken, HideSoftInputFlags.None);
            }

        }
        if (bat_setting == true)
        {
            bat_setting_layout.Visibility = ViewStates.Invisible;
            bat_setting = false;
        }


    }











 











  




    public void send_click(object sender, EventArgs e)
    {
        if (inputQuestion.Text == "")
        {

        }
        else
        {
            try
            {

                // Toast.MakeText(this, "One chat ADD", ToastLength.Short).Show();
                LinearLayout ll = new LinearLayout(this);
                ll.Orientation = Orientation.Vertical;

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GradientDrawable gd = new GradientDrawable();
                gd.SetShape(ShapeType.Rectangle);
                gd.SetCornerRadius(25);
                gd.SetColor(Android.Graphics.Color.White);
                gd.SetStroke(4, Android.Graphics.Color.Black);



                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                //  ll.Background = gd;
                // ll.SetBackgroundResource(Resource.Drawable.text_of_notes);
                ll.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 30;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).RightMargin = 250;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).BottomMargin = 55;



                //ll.Id = iii++;

                //// ll.Click += (sender, args) =>
                //{
                // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                //   guna(ll.Id);

                // };
                // CircleImageView cc = new CircleImageView(this);
                // cc.SetImageResource(Resource.Drawable.female1);
                //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);
                TextView cc = new TextView(this);

                cc.Text += inputQuestion.Text;
                cc.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3f48cc"));
                cc.SetTextColor(Android.Graphics.Color.White);

                cc.Gravity = GravityFlags.Center;
                cc.TextSize = 20;
                cc.SetTextColor(Android.Graphics.Color.Black);
                cc.SetPadding(20, 20, 20, 20);
                cc.Background = gd;


                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                layoutParams.TopMargin = 10;
                layoutParams.LeftMargin = 10;
                layoutParams.RightMargin = 10;
                cc.LayoutParameters = layoutParams;
                //  cc.SetBackgroundResource(Resource.Drawable.text_of_notes);





                ll.AddView(cc);






                chat_layout.AddView(ll);


                c_layout.Post(() =>
                {
                    c_layout.FullScroll(FocusSearchDirection.Down);

                });

                inputQuestion.Text = "";



            }
            catch (Exception x)
            {
                Toast.MakeText(this, "personal_ERROR : " + x.Message, ToastLength.Short).Show();
            }
        }



        void guna(int i)
        {
            Toast.MakeText(this, $"show a chat id : {i}", ToastLength.Short).Show();
            StartActivity(typeof(chat));


            //return i;
        }

    }



    public void start_page()
    {
    }
    private async void user_click(object sender, EventArgs e)
    {

        
        if (inputQuestion.Text == "1")
        {

        }
        else
        {
            try
            {

                // Toast.MakeText(this, "One chat ADD", ToastLength.Short).Show();
                LinearLayout ll = new LinearLayout(this);
                ll.Orientation = Orientation.Vertical;

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GradientDrawable gd = new GradientDrawable();
                gd.SetShape(ShapeType.Rectangle);
                gd.SetCornerRadius(25);
                gd.SetColor(Android.Graphics.Color.Black);
                gd.SetStroke(4, Android.Graphics.Color.White);



                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                //  ll.Background = gd;
                // ll.SetBackgroundResource(Resource.Drawable.text_of_notes);
                ll.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 140;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).RightMargin = 30;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).BottomMargin = 55;

                ll.SetGravity(GravityFlags.Right);

                //ll.Id = iii++;

                //// ll.Click += (sender, args) =>
                //{
                // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                //   guna(ll.Id);

                // };
                // CircleImageView cc = new CircleImageView(this);
                // cc.SetImageResource(Resource.Drawable.female1);
                //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);
                TextView cc = new TextView(this);

               // await TypeText(result);
                cc.Text +=result;
                //cc.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3f48cc"));
                cc.SetTextColor(Android.Graphics.Color.White);

                cc.Gravity = GravityFlags.Center;
                cc.TextSize = 14;
                cc.SetPadding(20, 20, 20, 20);
                cc.Background = gd;


                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                layoutParams.TopMargin = 10;

                layoutParams.RightMargin = 10;
                cc.LayoutParameters = layoutParams;
                //  cc.SetBackgroundResource(Resource.Drawable.text_of_notes);





                ll.AddView(cc);






                chat_layout.AddView(ll);


                c_layout.Post(() =>
                {
                    c_layout.FullScroll(FocusSearchDirection.Down);

                });

                inputQuestion.Text = "";
                answerText.Text = "";


            }
            catch (Exception x)
            {
                Toast.MakeText(this, "personal_ERROR : " + x.Message, ToastLength.Short).Show();
            }
        }


    }

  














    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="text"></param>
    /// 



   
    private async Task<string>GetSmartAnswer(string query)
    {
        string apiKey = "21eb49bf08cde53986b7d3b9a755f8128209c135e87e716c7218227c291c195b";
       System.Collections.Hashtable ht = new System.Collections.Hashtable { { "q", query } };
       
        try
        {

            GoogleSearch search = new GoogleSearch(ht, apiKey);
            JObject data = await Task.Run(() => search.GetJson());

            //////////////////////////////////////

           /* 
            if (data["answer_box"]!=null && data["answer_box"]["answer"]!=null)
            {
                return CleanText(data["answer_box"]["answer"].ToString());
            }
            else if (data["text_blocks"]is JArray textBlocks)
            {
                return FormatTextBlocks(textBlocks);
            }
            else if (data["organic_results"] is JArray organic && organic.Count>0)
            {
                return CleanText(organic[0]["snippet"].ToString());
            }
            else
            {
                return "sorry, no answer found.";

            }

            */

            string result = "";

            if (data["organic_results"] is JArray organic && organic.Count>0)
            {
                foreach(var item in organic)
                {
                    if(item["snippet"]!=null)
                    {
                        result += CleanText(item["snippet"].ToString()) + "\n\n";
                    }
                    int num = Int32.Parse(output_of_nwords.Text);
                    if(result.Length>=num)
                    {
                        break;
                    }
                }
            }

            if(string.IsNullOrEmpty(result))
            {
                return "sorry , no answer foind";

            }


            return result;

            //////////////////////////////////
            ///



           

            

        }
        catch (Exception ex)
        {
            return "NetWork Connection Problem solved the Problem";
        }
         
    }

    
    private string CleanText(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }
            

        string noHtml = Regex.Replace(input, "<.*?>", string.Empty);
        return System.Net.WebUtility.HtmlDecode(noHtml).Trim(); ;



    }



    
   /// <summary>
   /// /////////////////////////////////////////////////////////////////////
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
 



    private void mic_click(object sender,EventArgs e)
    {
        if (inputMethodManager.IsAcceptingText)
        {
            inputMethodManager.HideSoftInputFromWindow(inputQuestion.WindowToken, HideSoftInputFlags.None);
        }
        var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
        voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
        voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

        StartActivityForResult(voiceIntent, 500);
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if(requestCode ==500 && resultCode==Result.Ok)
        {
            var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
            if(matches.Count>0)
            {
                inputQuestion.Text = matches[0];
            }
            Toast.MakeText(this, "compledted", ToastLength.Short).Show();
            inputQuestion.SetSelection(inputQuestion.Text.Length);
            inputMethodManager.ShowSoftInput(inputQuestion, ShowFlags.Implicit);



        }
    }

    public void done(object sender,EventArgs e)
    {
        try
        {

            if (input_of_nwords.Text != "")
            {

                double nn = Int32.Parse(input_of_nwords.Text);
                if (nn > 2000)
                {
                    Toast.MakeText(this, "maximum 2000 Words Per Result", ToastLength.Short).Show();
                    input_of_nwords.Text = "";
                }
                else
                {
                    output_of_nwords.Text = "";
                    output_of_nwords.Text += input_of_nwords.Text;
                    input_of_nwords.Text = "";

                    Toast.MakeText(this, "sucessfully change", ToastLength.Short).Show();


                    Handler handler = new Handler();
                    new Handler().PostDelayed(() =>
                    {

                        if (inputMethodManager.IsAcceptingText)
                        {
                            inputMethodManager.HideSoftInputFromWindow(inputQuestion.WindowToken, HideSoftInputFlags.None);
                        }

                        bat_setting_layout.Visibility = ViewStates.Invisible;
                        bat_setting = false;
                       
                    }, 200);
                }
            }
            else
            {
                Toast.MakeText(this, "enter the number of words on Reduly", ToastLength.Short).Show();
            }
        }
        catch(ArithmeticException ex)
        {
            Toast.MakeText(this, "input Error: "+ex.Message, ToastLength.Long).Show();
        }
        
    }
}     