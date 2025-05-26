using Android.InputMethodServices;
using Android.OS;
using Android.Views;
using Android.App;
using Android.Widget;

using Android.Views.Animations;
using Android.Runtime;
using Android.Health.Connect;
using static Android.Provider.Telephony.Mms;
using Android.Icu.Number;
using Android.Content;
using Android.Views.InputMethods;
using System.Diagnostics.Metrics;
using Android.Content.Res;
using System.Drawing;
using Android.Graphics;
using Android.App.AppSearch;
using Android.Media;

using System.Data.OleDb;

namespace Task.Resources.layout;

[Activity(Label = "Activity1")]
public class Activity1 : Activity
{
    private Button cal;
    private Button task;
    private Button pro;
    private Button menu;



    private RelativeLayout completed;
    private RelativeLayout completed2;

    private int counter1 = 1;
    private int counter2 = 1;
    private int counter3 = 1;

    private ScrollView personal_layout;
    private ScrollView work_layout;
    private ScrollView health_layout;

    private RelativeLayout value_layout;
    private Button value_layout_close;


    private LinearLayout personal;
    private LinearLayout work;
    private LinearLayout health;


    private Button personalButton;
    private Button workButton;
    private Button healthButton;

    private Button add;

    public bool a_personal = true;
    public bool a_work = false;
    public bool a_health = false;

    private bool valu_visible = false;

    private EditText value;

    private Button enter;

    private Vibrator vibrator;

    public int m = 1;

    private RelativeLayout scr;

    private bool check_menu = false;

    public MediaPlayer mediaPlayer1;
    public MediaPlayer mediaPlayer2;



    protected override void OnCreate(Bundle savedInstanceState)
    {

        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.Layout1);
        //a_personal = true;

        cal = FindViewById<Button>(Resource.Id.cal);
        task = FindViewById<Button>(Resource.Id.task);
        pro = FindViewById<Button>(Resource.Id.pro);
        menu = FindViewById<Button>(Resource.Id.menu);

        

        personal_layout = FindViewById<ScrollView>(Resource.Id.personal_layout);
        work_layout = FindViewById<ScrollView>(Resource.Id.work_layout);
        health_layout = FindViewById<ScrollView>(Resource.Id.health_layout);

        value_layout = FindViewById<RelativeLayout>(Resource.Id.value_layout);
        value_layout_close = FindViewById<Button>(Resource.Id.value_layout_close);


        personal = FindViewById<LinearLayout>(Resource.Id.personal);
        work = FindViewById<LinearLayout>(Resource.Id.work);
        health = FindViewById<LinearLayout>(Resource.Id.health);

        personalButton = FindViewById<Button>(Resource.Id.personalButton);
        workButton = FindViewById<Button>(Resource.Id.workButton);
        healthButton = FindViewById<Button>(Resource.Id.healthButton);

        add = FindViewById<Button>(Resource.Id.add1);
        value = FindViewById<EditText>(Resource.Id.editText1);

        enter = FindViewById<Button>(Resource.Id.enter);

        completed = FindViewById<RelativeLayout>(Resource.Id.completed);
        completed2 = FindViewById<RelativeLayout>(Resource.Id.completed2);


        scr = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);



        Handler hander;

        menu.Click += menu_click;

        cal.Click += cal_click;
        task.Click += task_click;
        pro.Click += pro_click;



        scr.Click += scr_click;

       

        ///  scr2.Click += scr2_click;
        //scr3.Click += scr3_click;




        personalButton.Click += personalButton_click;
        workButton.Click += workButton_click;
        healthButton.Click += healthButton_click;

        add.Click += add_click;
        enter.Click += enter_click;
        value_layout_close.Click += value_layout_close_Click;

        value.AfterTextChanged += EditTextchanger;

        mediaPlayer1 = MediaPlayer.Create(this, Resource.Raw.sound);
        mediaPlayer2 = MediaPlayer.Create(this, Resource.Raw.sound2);





        // Create your application here
    }


    private void menu_click(object sender,EventArgs e)
    {
        

        if (check_menu == false)
        {
            mediaPlayer2.Start();

            //RotateAnimation rotateAnimation = new RotateAnimation(0,180, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);
            // rotateAnimation.Duration = 2200;
            float rotaton = 180;
            task.Rotation = rotaton;
            //task.StartAnimation(rotateAnimation);

            pro.Animate().X(pro.TranslationX + 480).Y(1180).SetDuration(300).Start();


            task.Animate().X(task.TranslationX + 300).Y(1050).SetDuration(200).Start();

            cal.Animate().X(cal.TranslationX + 90).Y(1180).SetDuration(100).Start();


            //menu.SetBackgroundResource(Resource.Drawable.close_menu);




            // menu.SetHeight(120);
            //menu.SetWidth(120);


            //StartActivity(typeof(calander));
            //  Finish();
            new Handler().PostDelayed(() =>
            {
                cal.SetBackgroundResource(Resource.Drawable.cal);
            }, 300);
            new Handler().PostDelayed(() =>
            {
                task.SetBackgroundResource(Resource.Drawable.task);
            }, 400);
            new Handler().PostDelayed(() =>
            {
                pro.SetBackgroundResource(Resource.Drawable.pro);
            }, 500);

            check_menu = true;
            menu.SetBackgroundResource(Resource.Drawable.close_menu);

        }

        else
        {
            mediaPlayer1.Start();

            float rotaton1 = 0;
            task.Rotation = rotaton1;

            new Handler().PostDelayed(() =>
            {
                pro.SetBackgroundResource(Resource.Drawable.hh);
                task.SetBackgroundResource(Resource.Drawable.hh);
                cal.SetBackgroundResource(Resource.Drawable.hh);
            }, 1);

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();

            check_menu = false;

            menu.SetBackgroundResource(Resource.Drawable.main_menu);
        }


    }

    private void cal_click(object sender, EventArgs e)
    {

        new Handler().PostDelayed(() =>
        {
            StartActivity(typeof(calander));
          //  Finish();
        }, 100);

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);
        mediaPlayer1.Start();

        float rotaton = 0;
        task.Rotation = rotaton;
        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);


    }
    private void task_click(object sender, EventArgs e)
    {
        /* new Handler().PostDelayed(() =>
         {
             StartActivity(typeof(Activity1));
         }, 100);
        */
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);
        mediaPlayer1.Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);


    }
    private void pro_click(object sender, EventArgs e)
    {

        new Handler().PostDelayed(() =>
        {
           // Intent intent = new Intent(this, typeof(profile));
           StartActivity(typeof(profile));
           // StartActivity(intent);
           // Finish();
            
        }, 100);
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        mediaPlayer1.Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        check_menu = false;


        menu.SetBackgroundResource(Resource.Drawable.main_menu);


    }

   
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
   /*
    private void scr1_click(object sender, EventArgs e)
    {

        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();


    }
    private void scr3_click(object sender, EventArgs e)
    {

        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();


    }
    private void scr2_click(object sender, EventArgs e)
    {

        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

    }  */
       
    /////////// volume contoler ///////////////////////////////

    public override bool OnKeyDown(Android.Views.Keycode keyCode, KeyEvent e)
    {

        /*   
       if (keyCode == Android.Views.Keycode.VolumeUp)
       {
           new Handler().PostDelayed(() =>
           {
               StartActivity(typeof(profile));
               //  Finish();
           }, 100);

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();

       }
        */
        if (keyCode == Android.Views.Keycode.VolumeDown)
        {
            mediaPlayer2.Start();
            //
            //Toast.MakeText(this, "hello guna", ToastLength.Long).Show();

            new Handler().PostDelayed(() =>
            {
                pro.SetBackgroundResource(Resource.Drawable.hh);
                task.SetBackgroundResource(Resource.Drawable.hh);
                cal.SetBackgroundResource(Resource.Drawable.hh);
            }, 1);

            new Handler().PostDelayed(() =>
            {
                StartActivity(typeof(calander));
               //  Finish();
            }, 100);
            float rotaton = 0;
            task.Rotation = rotaton;

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        }
        else
        {
            mediaPlayer1.Start();
        }

        return base.OnKeyDown(keyCode, e);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 



    private void personalButton_click(object snedr,EventArgs e)
    {
        personalButton.SetTextColor(Android.Graphics.Color.White);
        workButton.SetTextColor(Android.Graphics.Color.Black);
        healthButton.SetTextColor(Android.Graphics.Color.Black);

        personal_layout.Visibility = ViewStates.Visible;


        work_layout.Visibility = ViewStates.Invisible;
        health_layout.Visibility = ViewStates.Invisible;

        mediaPlayer1.Start();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;


        menu.SetBackgroundResource(Resource.Drawable.main_menu);
        
        

        a_personal = true;
        a_work = false;
        a_health = false;


    }
    private void workButton_click(object sender,EventArgs e)
    {
         workButton.SetTextColor(Android.Graphics.Color.White);
         personalButton.SetTextColor(Android.Graphics.Color.Black);
        healthButton.SetTextColor(Android.Graphics.Color.Black);

        work_layout.Visibility = ViewStates.Visible;

        personal_layout.Visibility = ViewStates.Invisible;
         health_layout.Visibility= ViewStates.Invisible;

        mediaPlayer1.Start();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        float rotaton = 0;
        task.Rotation = rotaton; 

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);


        a_personal = false;
        a_work = true;
        a_health = false;



    }
    private void healthButton_click(object sender, EventArgs e)
    {
         healthButton.SetTextColor(Android.Graphics.Color.White);
         personalButton.SetTextColor(Android.Graphics.Color.Black);
         workButton.SetTextColor(Android.Graphics.Color.Black);

        mediaPlayer1.Start();

        health_layout.Visibility = ViewStates.Visible;

        work_layout.Visibility = ViewStates.Invisible;
        personal_layout.Visibility = ViewStates.Invisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

        a_personal = false;
        a_work = false;
        a_health = true;




    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    private void add_click(object sender, EventArgs e)
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

      //  mediaPlayer2.Start();



        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

        value.RequestFocus();
        enter.SetBackgroundResource(Resource.Drawable.send);

        InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
        im.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.None);

        if (m == 1)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.None);
            m = 2;

        }//(add, ShowFlags.Forced);

        /* value_layout.Animation = new TranslateAnimation(0, 100, 0, 0);
         value_layout.StartAnimation(value_layout.Animation);      */

        value_layout.Visibility = ViewStates.Visible;

        value_layout.Animation = new TranslateAnimation(-1000, 0, 0, 0);

        value_layout.Animation.Duration = 600;

        value_layout.StartAnimation(value_layout.Animation);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /*  value_layout_close.BackgroundTintMode = PorterDuff.Mode.SrcAtop;
          value_layout_close.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#ff0000"));
         */

        value_layout_close.SetBackgroundResource(Resource.Drawable.circle);

        value_layout_close.Visibility = ViewStates.Visible;
        value_layout_close.Animation = new TranslateAnimation(0, 0, -800, 0);
        value_layout_close.Animation.Duration = 700;

          value_layout_close.StartAnimation(value_layout_close.Animation);

        valu_visible = true;
            
                   
     

    }
    private void enter_click(object sender,EventArgs e)
    {
        mediaPlayer1.Start();

        if (value.Text == "")
        {
            Toast.MakeText(this, "Fill the Task name", ToastLength.Short).Show();
        }
        else
        {
            /* value_layout.Animation = new TranslateAnimation(0,1000,0,0);

             value_layout.Animation.Duration = 500;

             value_layout.StartAnimation(value_layout.Animation);

             value_layout.Visibility = ViewStates.Invisible;   */


            if (a_personal == true)
            {

                // Toast.MakeText(this, "hello guna", ToastLength.Long).Show();

                //   InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

                // imm.HideSoftInputFromWindow(create_Iteam1.WindowToken, 0);
                // create_layout1.Visibility = ViewStates.Invisible;

                RadioButton radioButton1 = new RadioButton(this);
                // radioButton1.Text = $"Task {counter1++}  :  {create_Iteam1.Text}";

                radioButton1.Text = $"Task {counter1++}  :  {value.Text}";
                radioButton1.SetTextColor(Android.Graphics.Color.White);
                radioButton1.TextSize = 24;
                personal.AddView(radioButton1, 0);
                // create_Iteam1.Text = "";
                value.Text = "";


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

             /*   string databasepath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Admin\\Desktop\\Database11.accdb";
                string connectionString=$"Provider=Microsoft.ACE.OLEDB.12.0;DataSource={databasepath};";
                string query = "SELECT name FROM Table1";
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Toast.MakeText(this, "hello guna", ToastLength.Short).Show();

                    string name = reader["name"].ToString();
                    value.Text = name;
                }
                connection.Close();
             */ 
                
                 
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                radioButton1.CheckedChange += (sender2, e2) =>
                {
                    if (e2.IsChecked)
                    {
                        Toast.MakeText(this, $"You selected {radioButton1.Text}", ToastLength.Short).Show();
                        radioButton1.ButtonTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#ffffff"));
                        radioButton1.SetTextColor(Android.Graphics.Color.Black);

                        if (valu_visible == true)
                        {
                            value.Text = "";

                            value_layout.Animation = new TranslateAnimation(0, 1000, 0, 0);
                            value_layout.Animation.Duration = 500;
                            value_layout.StartAnimation(value_layout.Animation);
                            value_layout.Visibility = ViewStates.Invisible;


                            value_layout_close.Animation = new TranslateAnimation(0, 0, 0, -800);
                            value_layout_close.Animation.Duration = 550;
                            value_layout_close.StartAnimation(value_layout_close.Animation);
                            value_layout_close.Visibility = ViewStates.Invisible;

                            InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
                            im.HideSoftInputFromWindow(enter.WindowToken, HideSoftInputFlags.None);

                            valu_visible = false;

                            /*  Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.moving_animation);

                              animi.StartAnimation(animation);     */
                            
                            
                              /*  completed.Visibility = ViewStates.Visible;
                                Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.completed);

                                completed.StartAnimation(animation);
                             completed.Visibility = ViewStates.Invisible;            */

                            

                        }
                        if (radioButton1.CurrentTextColor == Android.Graphics.Color.ParseColor("#000000"))
                        {
                            completed.Visibility = ViewStates.Visible;
                            Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.completed);

                            completed.StartAnimation(animation);

                            completed.Visibility = ViewStates.Invisible;

                            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            completed2.Visibility = ViewStates.Visible;
                            Animation animation1 = AnimationUtils.LoadAnimation(this, Resource.Animation.completed2);

                            completed2.StartAnimation(animation1);

                            completed2.Visibility = ViewStates.Invisible;


                        }


                    }
                };
            }
            if (a_work == true)
            {
                
                //Toast.MakeText(this, "hello guna", ToastLength.Long).Show();

                // InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

                // imm.HideSoftInputFromWindow(create_Iteam1.WindowToken, 0);
                // create_layout1.Visibility = ViewStates.Invisible;

                RadioButton radioButton1 = new RadioButton(this);
                // radioButton1.Text = $"Task {counter1++}  :  {create_Iteam1.Text}";
                radioButton1.Text = $"Task {counter2++}  :  {value.Text}";

                radioButton1.SetTextColor(Android.Graphics.Color.White);
                radioButton1.TextSize = 24;
                work.AddView(radioButton1, 0);
                value.Text = "";


                radioButton1.CheckedChange += (sender2, e2) =>
                {
                    if (e2.IsChecked)
                    {
                        Toast.MakeText(this, $"You selected {radioButton1.Text}", ToastLength.Short).Show();
                        radioButton1.ButtonTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#ffffff"));
                        radioButton1.SetTextColor(Android.Graphics.Color.Black);

                        if (valu_visible == true)
                        {

                            value.Text = "";

                            value_layout.Animation = new TranslateAnimation(0, 1000, 0, 0);
                            value_layout.Animation.Duration = 500;
                            value_layout.StartAnimation(value_layout.Animation);
                            value_layout.Visibility = ViewStates.Invisible;


                            value_layout_close.Animation = new TranslateAnimation(0, 0, 0, -800);
                            value_layout_close.Animation.Duration = 550;
                            value_layout_close.StartAnimation(value_layout_close.Animation);
                            value_layout_close.Visibility = ViewStates.Invisible;

                            InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
                            im.HideSoftInputFromWindow(enter.WindowToken, HideSoftInputFlags.None);

                            valu_visible = false;
                        }

                        if (radioButton1.CurrentTextColor == Android.Graphics.Color.ParseColor("#000000"))
                        {
                            completed.Visibility = ViewStates.Visible;
                            Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.completed);

                            completed.StartAnimation(animation);

                            completed.Visibility = ViewStates.Invisible;



                            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            completed2.Visibility = ViewStates.Visible;
                            Animation animation1 = AnimationUtils.LoadAnimation(this, Resource.Animation.completed2);

                            completed2.StartAnimation(animation1);

                            completed2.Visibility = ViewStates.Invisible;


                        }
                    }
                };
            }
            if (a_health == true)
            {
                //int counter1 = 1;
                //Toast.MakeText(this, "hello guna", ToastLength.Long).Show();

                //InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

                // imm.HideSoftInputFromWindow(create_Iteam1.WindowToken, 0);
                // create_layout1.Visibility = ViewStates.Invisible;

                RadioButton radioButton1 = new RadioButton(this);
                // radioButton1.Text = $"Task {counter1++}  :  {create_Iteam1.Text}";
                radioButton1.Text = $"Task {counter3++}  :  {value.Text}";

                radioButton1.SetTextColor(Android.Graphics.Color.White);
                radioButton1.TextSize = 24;

                health.AddView(radioButton1, 0);
                value.Text = "";



                radioButton1.CheckedChange += (sender2, e2) =>
                {
                    if (e2.IsChecked)
                    {
                        Toast.MakeText(this, $"You selected {radioButton1.Text}", ToastLength.Short).Show();
                        radioButton1.ButtonTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#ffffff"));
                        radioButton1.SetTextColor(Android.Graphics.Color.Black);

                        if (valu_visible == true)
                        {
                            value.Text = "";

                            value_layout.Animation = new TranslateAnimation(0, 1000, 0, 0);
                            value_layout.Animation.Duration = 500;
                            value_layout.StartAnimation(value_layout.Animation);
                            value_layout.Visibility = ViewStates.Invisible;


                            value_layout_close.Animation = new TranslateAnimation(0, 0, 0, -800);
                            value_layout_close.Animation.Duration = 550;
                            value_layout_close.StartAnimation(value_layout_close.Animation);
                            value_layout_close.Visibility = ViewStates.Invisible;

                            InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
                            im.HideSoftInputFromWindow(enter.WindowToken, HideSoftInputFlags.None);

                            valu_visible = false;

                        }
                        if (radioButton1.CurrentTextColor == Android.Graphics.Color.ParseColor("#000000"))
                        {
                            completed.Visibility = ViewStates.Visible;
                            Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.completed);

                            completed.StartAnimation(animation);

                            completed.Visibility = ViewStates.Invisible;


                            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            completed2.Visibility = ViewStates.Visible;
                            Animation animation1 = AnimationUtils.LoadAnimation(this, Resource.Animation.completed2);

                            completed2.StartAnimation(animation1);

                            completed2.Visibility = ViewStates.Invisible;

                        }

                    }
                };
            }

        }

    }

    private void value_layout_close_Click(object sender, EventArgs e)
    {

       // mediaPlayer2.Start();


        value.Text = "";

        value_layout.Animation = new TranslateAnimation(0, 1000, 0, 0);
        value_layout.Animation.Duration = 500;
        value_layout.StartAnimation(value_layout.Animation);
        value_layout.Visibility = ViewStates.Invisible;


        value_layout_close.Animation = new TranslateAnimation(0, 0, 0, -800);
        value_layout_close.Animation.Duration = 550;
        value_layout_close.StartAnimation(value_layout_close.Animation);
        value_layout_close.Visibility = ViewStates.Invisible;

        InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
        im.HideSoftInputFromWindow(enter.WindowToken, HideSoftInputFlags.None);

        valu_visible = false;

    }

    private void EditTextchanger(object sender,EventArgs e)
    {

       // mediaPlayer1.Start();
        if (value.Text.Length > 13)
        {

            vibrator = (Vibrator)GetSystemService(VibratorService);

           
            Toast.MakeText(this, "Reached the maximum number of letters(13)!..", ToastLength.Short).Show();
            
            vibrator.Vibrate(250);

            value.Text = value.Text.Substring(0, 13
                );
            value.SetSelection(value.Text.Length);


        }
    }

    private void scr_click(object sender, EventArgs e)
    {

        float rotaton = 0;
        task.Rotation = rotaton;
        //mediaPlayer1.Start();

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);
    }

}