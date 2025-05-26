using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
using Android.Animation;
using Android;




namespace Task.Resources.layout;

[Activity(Label = "profile")]
public class profile : Activity
{
    private Button cal;
    private Button task;
    private Button pro;
    private Button menu;

    private Button sub_menu;

    private RelativeLayout scr;

    private ImageView image;

    private RelativeLayout completed;
    private RelativeLayout completed2;


    private ImageView piechart;
    private TextView percentagetext;

    private ProgressBar progressBar;

    private RelativeLayout sub_menu_layout;
    private bool submenu = false;
                                     
    private Button category;
    private RelativeLayout category_layout;
    private bool check_menu = false;


    private MediaPlayer mediaPlayer1;
    private MediaPlayer mediaPlayer2;


    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.profile);

        cal = FindViewById<Button>(Resource.Id.cal);
        task = FindViewById<Button>(Resource.Id.task);
        pro = FindViewById<Button>(Resource.Id.pro);
        menu = FindViewById<Button>(Resource.Id.menu);

        sub_menu = FindViewById<Button>(Resource.Id.sub_menu);

        scr = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
        image = FindViewById<ImageView>(Resource.Id.image);

        completed = FindViewById<RelativeLayout>(Resource.Id.completed);
        completed2 = FindViewById<RelativeLayout>(Resource.Id.completed2);

        category = FindViewById<Button>(Resource.Id.category);
       // category_layout = FindViewById<RelativeLayout>(Resource.Id.category_layout);


        completed.Visibility = ViewStates.Visible;
        Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.completed);

        completed.StartAnimation(animation);

        completed.Visibility = ViewStates.Invisible;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        completed2.Visibility = ViewStates.Visible;
        Animation animation1 = AnimationUtils.LoadAnimation(this, Resource.Animation.completed2);

        sub_menu_layout = FindViewById<RelativeLayout>(Resource.Id.sub_menu_layout);


        completed2.StartAnimation(animation1);

        completed2.Visibility = ViewStates.Invisible;


        Handler handler;


        menu.Click += menu_click;

        cal.Click += cal_click;
        task.Click += task_click;
        pro.Click += pro_click;

        scr.Click += scr_click;

        sub_menu.Click += sub_menu_click;
        category.Click += category_click;


        piechart = FindViewById<ImageView>(Resource.Id.piechart);
        percentagetext = FindViewById<TextView>(Resource.Id.percentageText);

        float percentage = 75f;
        float angle = (percentage / 100f) * 360f;
        Drawpiechart(angle);
        percentagetext.Text = percentage + "%";

        //  image.SetBackgroundResource(Resource.Drawable.man);

        // Create your application here


        mediaPlayer1 = MediaPlayer.Create(this, Resource.Raw.sound);
        mediaPlayer2 = MediaPlayer.Create(this, Resource.Raw.sound2);
       


    }
    private void category_click(object sender,EventArgs e)
    {
        category_layout.Visibility = ViewStates.Visible;
    }

    private void sub_menu_click(object sender, EventArgs e)
    {

        /*Toast.MakeText(this, "working", ToastLength.Short).Show();
        
        ObjectAnimator bounceanimation = ObjectAnimator.OfFloat(sub_menu_layout,"scaleX",1.0f,1,2f,1.0f);
        bounceanimation.SetDuration(500);
        bounceanimation.Start();                 
        sub_menu_layout.TranslationY = -sub_menu_layout.Height;
        sub_menu_layout.Animate().TranslationY(0).SetDuration(500).Start();
        sub_menu_layout.Visibility = ViewStates.Visible;
        
           */



       
        

          new Handler().PostDelayed(() =>
          {
              pro.SetBackgroundResource(Resource.Drawable.hh);
              task.SetBackgroundResource(Resource.Drawable.hh);
              cal.SetBackgroundResource(Resource.Drawable.hh);
          }, 1);

          float rotaton = 0;
          task.Rotation = rotaton;

          cal.Animate().X(250).Y(1255).SetDuration(100).Start();

          task.Animate().X(290).Y(1325).SetDuration(100).Start();

          pro.Animate().X(325).Y(1255).SetDuration(100).Start();
          check_menu = false;

          menu.SetBackgroundResource(Resource.Drawable.main_menu);

        if (submenu == false)
        {
            mediaPlayer2.Start();

            sub_menu_layout.Animation = new AlphaAnimation(1, 0);
           // sub_menu_layout.Animation.Duration = 400; //0.5second


            // rrr.Visibility = ViewStates.Invisible;//////
            sub_menu_layout.Visibility = ViewStates.Visible;
            sub_menu_layout.Animation.Start();

           // sub_menu_layout.Visibility = ViewStates.visible;

            submenu = true;

            float menu_rotaton = 90;
            sub_menu.Rotation = menu_rotaton;


        }
        else
        {



            mediaPlayer1.Start();

            // rrr.Visibility = ViewStates.Invisible;//////
            sub_menu_layout.Visibility = ViewStates.Invisible;
            //sub_menu_layout.Animation.Start();
            submenu = false;

            float menu_rotaton = 0;
            sub_menu.Rotation = menu_rotaton;
        }





        /*
        sub_menu_layout.Animation = new AlphaAnimation(0, 1);
        sub_menu_layout.Animation.Duration = 500; //0.5second


       // rrr.Visibility = ViewStates.Invisible;//////
        sub_menu_layout.Visibility = ViewStates.Visible;
        sub_menu_layout.Animation.Start();
                                                */


    }


    private void menu_click(object sender, EventArgs e)
    {

        mediaPlayer2.Start();

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

            new Handler().PostDelayed(() =>
            {
                pro.SetBackgroundResource(Resource.Drawable.hh);
                task.SetBackgroundResource(Resource.Drawable.hh);
                cal.SetBackgroundResource(Resource.Drawable.hh);
            }, 1);

            float rotaton1 = 0;
            task.Rotation = rotaton1;

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
            Finish();

        }, 101);

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        float rotaton = 0;
        task.Rotation = rotaton;
        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        check_menu = false;
        mediaPlayer1.Start();

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

       

    }
    private void task_click(object sender, EventArgs e)
    {
        Finish();
        new Handler().PostDelayed(() =>
         {
             StartActivity(typeof(Activity1));
             
         }, 101);

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

        mediaPlayer1.Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

       



    }
    private void pro_click(object sender, EventArgs e)
    {

        /* new Handler().PostDelayed(() =>
         {
             // Intent intent = new Intent(this, typeof(profile));
             StartActivity(typeof(profile));
             // StartActivity(intent);
             // Finish();

         }, 100);

         */

         mediaPlayer1.Start();

        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        float rotaton = 0;
        task.Rotation = rotaton;

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

    }
    private void scr_click(object sender, EventArgs e)
    {
        new Handler().PostDelayed(() =>
        {
            pro.SetBackgroundResource(Resource.Drawable.hh);
            task.SetBackgroundResource(Resource.Drawable.hh);
            cal.SetBackgroundResource(Resource.Drawable.hh);
        }, 1);

        float rotaton = 0;
        task.Rotation = rotaton;

        cal.Animate().X(250).Y(1255).SetDuration(100).Start();

        task.Animate().X(290).Y(1325).SetDuration(100).Start();

        pro.Animate().X(325).Y(1255).SetDuration(100).Start();
        check_menu = false;

        menu.SetBackgroundResource(Resource.Drawable.main_menu);

        mediaPlayer1.Start();



        if (submenu == true)
        {

           
            sub_menu_layout.Visibility = ViewStates.Invisible;

            float menu_rotaton = 0;
            sub_menu.Rotation = menu_rotaton;
            submenu = false;

        }


    }


    /////////// volume contoler ///////////////////////////////

    public override bool OnKeyDown(Android.Views.Keycode keyCode, KeyEvent e)
    {
        float rotaton = 0;
        task.Rotation = rotaton;

        mediaPlayer2.Start();

        if (keyCode == Android.Views.Keycode.VolumeUp)
       {
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

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();
        }
        
        if (keyCode == Android.Views.Keycode.VolumeDown)
        {
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
                 Finish();
            }, 100);

            cal.Animate().X(250).Y(1255).SetDuration(100).Start();

            task.Animate().X(290).Y(1325).SetDuration(100).Start();

            pro.Animate().X(325).Y(1255).SetDuration(100).Start();
        }

        return base.OnKeyDown(keyCode, e);
    }
    private void Drawpiechart(float angle)
    {
        Bitmap bitmap = Bitmap.CreateBitmap(200, 200, Bitmap.Config.Argb8888);

        Canvas canvas = new Canvas(bitmap);
        Paint paint = new Paint();
        paint.Color = Color.ParseColor("#FFFFFF");

        paint.SetStyle(Android.Graphics.Paint.Style.Stroke);
        //paint.Style = paint.Style.Stroke;
        paint.StrokeWidth = 20;
        canvas.DrawArc(new RectF(10, 10, 190, 190), 0, angle, false, paint);
        piechart.SetImageBitmap(bitmap);

    }
}