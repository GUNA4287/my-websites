using Android.App;
using Android.App.AppSearch;
using Android.Content.Res;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
using Android.Views.InputMethods;
using System.Diagnostics.Metrics;
using static Android.Renderscripts.Sampler;

namespace Task.Resources.layout;

[Activity(Label = "Activity2")]
public class calander : Activity
{
    private Button cal;
    private Button task;
    private Button pro;
    private Button menu;

    

    private RelativeLayout scr;
    private TextView calender_textView;

    private RelativeLayout completed;
    private RelativeLayout completed2;

    private CalendarView calendarView;

    private Button add;
    private Button value_layout_close;
    private RelativeLayout value_layout;
    private EditText value;
    private Button enter;

    public int m = 1;

    private int counter1;

    private bool valu_visible = false;

    private ScrollView calender_layout;
    private LinearLayout calender;

    private Vibrator vibrator;

    private bool check_menu = false;

    public MediaPlayer mediaPlayer1;
    public MediaPlayer mediaPlayer2;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.calander);


        cal = FindViewById<Button>(Resource.Id.cal);
        task = FindViewById<Button>(Resource.Id.task);
        pro = FindViewById<Button>(Resource.Id.pro);
        menu = FindViewById<Button>(Resource.Id.menu);

       

        scr = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
        value_layout = FindViewById<RelativeLayout>(Resource.Id.value_layout);

        calendarView = FindViewById<CalendarView>(Resource.Id.calendarView1);

        calender_textView = FindViewById<TextView>(Resource.Id.calender_textView);

        add = FindViewById<Button>(Resource.Id.add1);

        value_layout_close = FindViewById<Button>(Resource.Id.value_layout_close);
        value = FindViewById<EditText>(Resource.Id.editText1);
        enter = FindViewById<Button>(Resource.Id.enter);

        calender_layout = FindViewById<ScrollView>(Resource.Id.calender_layout);
        calender = FindViewById<LinearLayout>(Resource.Id.calender);


        completed = FindViewById<RelativeLayout>(Resource.Id.completed);
        completed2 = FindViewById<RelativeLayout>(Resource.Id.completed2);


        calendarView.DateChange += CalendarView_DateChange;

        Handler handler;

        menu.Click += menu_click;

        cal.Click += cal_click;
        task.Click += task_click;
        pro.Click += pro_click;

        scr.Click += scr_click;

        add.Click += add_click;

        value_layout_close.Click += value_layout_close_Click;

        enter.Click += enter_click;


        value.AfterTextChanged += EditTextchanger;



        mediaPlayer1 = MediaPlayer.Create(this, Resource.Raw.sound);
        mediaPlayer2 = MediaPlayer.Create(this, Resource.Raw.sound2);


        // Create your application here
    }


   

    private void add_click(object sender,EventArgs e)
    {
       // mediaPlayer2.Start();

        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);


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

        value_layout_close.SetBackgroundResource(Resource.Drawable.circle2);

        value_layout_close.Visibility = ViewStates.Visible;
        value_layout_close.Animation = new TranslateAnimation(0, 0, -800, 0);
        value_layout_close.Animation.Duration = 700;

        value_layout_close.StartAnimation(value_layout_close.Animation);

        valu_visible = true;


    }

    private void enter_click(object sender, EventArgs e)
    {
        mediaPlayer1.Start();

        if (value.Text == "")
        {
            Toast.MakeText(this, "Fill the Task name", ToastLength.Short).Show();
        } 
        else
        {
            if (calender_textView.Text == "")
            {
                Toast.MakeText(this, "Select a Date", ToastLength.Short).Show();
            }
            else
            {
                RadioButton radioButton1 = new RadioButton(this);
                // radioButton1.Text = $"Task {counter1++}  :  {create_Iteam1.Text}";

                radioButton1.Text = $"Task {counter1++} " +
                    $": {calender_textView.Text}  =>  {value.Text}";
                radioButton1.SetTextColor(Android.Graphics.Color.White);
                radioButton1.TextSize = 18;
                calender.AddView(radioButton1, 0);
                // create_Iteam1.Text = "";
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
        }
    }

        private void CalendarView_DateChange(object sender, CalendarView.DateChangeEventArgs e)
        {
        mediaPlayer1.Start();

            int year = e.Year;
            int month = e.Month;
            int day = e.DayOfMonth;


        // DateTime selectedDate = new DateTime(e.Year, e.Month, e.DayOfMonth);
        /// calender_textView.Text = "";

        ////// calender_textView.Text += selectedDate.ToString(" dd-MMM-yyy");
        // date += calender_textView.Text;

        calender_textView.Text = "";
            // Toast.MakeText(this, $"Selcted date : {e.DayOfMonth}-{e.Month}-{e.Year}", ToastLength.Short).Show();
            calender_textView.Text += $"{e.DayOfMonth}-{e.Month}-{e.Year}";
        }

    

    private void menu_click(object sender, EventArgs e)
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
        /*  new Handler().PostDelayed(() =>
          {
              StartActivity(typeof(calander));
              //  Finish();
          }, 100);
                   */
        mediaPlayer1.Start();
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
    }
    private void task_click(object sender, EventArgs e)
    {
        mediaPlayer1.Start();

        new Handler().PostDelayed(() =>
         {
             StartActivity(typeof(Activity1));
             Finish();

         }, 100);
        
        
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);


        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);


    }
    private void pro_click(object sender, EventArgs e)
    {
        mediaPlayer1.Start();

        new Handler().PostDelayed(() =>
        {
            // Intent intent = new Intent(this, typeof(profile));
            StartActivity(typeof(profile));
            // StartActivity(intent);
            Finish();

        }, 100);
        float rotaton = 0;
        task.Rotation = rotaton;

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);


        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

    }
    private void scr_click(object sender, EventArgs e)
    {
       // mediaPlayer1.Start();

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
    }


    public override bool OnKeyDown(Android.Views.Keycode keyCode, KeyEvent e)
    {
        

       if (keyCode == Android.Views.Keycode.VolumeUp)
       {
            mediaPlayer2.Start();
            new Handler().PostDelayed(() =>
            {
                pro.SetBackgroundResource(Resource.Drawable.hh);
                task.SetBackgroundResource(Resource.Drawable.hh);
                cal.SetBackgroundResource(Resource.Drawable.hh);
            }, 1);

            new Handler().PostDelayed(() =>
           {
               StartActivity(typeof(Activity1));
               Finish();
           }, 100);

            float rotaton = 0;
            task.Rotation = rotaton;

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        }
        mediaPlayer1.Start();
        /*
       if (keyCode == Android.Views.Keycode.VolumeDown)
       {
           //Toast.MakeText(this, "hello guna", ToastLength.Long).Show();

           new Handler().PostDelayed(() =>
           {
               StartActivity(typeof(calander));
                 Finish();
           }, 100);

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();


       }  */

        return base.OnKeyDown(keyCode, e);
    }

    private void value_layout_close_Click(object sender, EventArgs e)
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

       // mediaPlayer2.Start();

    }

    private void EditTextchanger(object sender, EventArgs e)
    {

      //  mediaPlayer1.Start();


        if (value.Text.Length > 18)
        {

            vibrator = (Vibrator)GetSystemService(VibratorService);


            Toast.MakeText(this, "Reached the maximum number of letters(13)!..", ToastLength.Short).Show();

            vibrator.Vibrate(250);

            value.Text = value.Text.Substring(0, 18
                );
            value.SetSelection(value.Text.Length);

        }
    }

}