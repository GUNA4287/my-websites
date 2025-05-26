using Android.OS;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Net;
using Android.Views.InputMethods;
using Android.Graphics.Drawables;
using DE.Hdodenhof.Circleimageview;
using Android.Content;
using AndroidX.Core.App;



namespace chat.Resources.layout;


[Activity(Label = "chat")]
public class chat : Activity
{
    private int iii = 1;

    private Button chat_back;
    private RelativeLayout message_layout;
    private Button message;


    public int m=1;
    public Boolean mes = false;

    private Handler handler;

   
    private EditText edit_text;

    private CircleImageView v_call;
    private CircleImageView call;



    private ScrollView c_layout;
    private LinearLayout chat_layout;
    private Button send;
    private Boolean message_panel=false;

    private Button user;



    private const string ChannelId = "i.apps.notifications";
    private const int NotificationId = 1234;
    string notitext = "";








    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        SetContentView(Resource.Layout.chat);
        
          start_page();
        chat_back = FindViewById<Button>(Resource.Id.chat_back);
        message_layout = FindViewById<RelativeLayout>(Resource.Id.message_layout);
        message = FindViewById<Button>(Resource.Id.message);

       
        edit_text = FindViewById<EditText>(Resource.Id.editText1);

        c_layout = FindViewById<ScrollView>(Resource.Id.c_layout);
        chat_layout = FindViewById<LinearLayout>(Resource.Id.chat_layout);
        send = FindViewById<Button>(Resource.Id.send);

        user = FindViewById<Button>(Resource.Id.user);

        v_call = FindViewById<CircleImageView>(Resource.Id.v_call);
        call = FindViewById<CircleImageView>(Resource.Id.call);








        v_call.Click += v_call_click;
        call.Click += call_click;



      
        user.Click += user_click;


        send.Click += send_click;



        chat_layout.Click += message_close_click;

        chat_back.Click += chatback;
        message.Click += message_move;


        // Create your application here

        CreateNotificationChannel();


    }

    private void CreateNotificationChannel()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var channel = new NotificationChannel(ChannelId, "Heads_ip Notification", NotificationImportance.High);

            channel.EnableLights(true);
            channel.EnableVibration(true);

            var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);



        }
    }


    private void SendHeadsUpNotification()
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        var intent = new Intent(this, typeof(Activity1));
        var pendingIntent = PendingIntent.GetActivities(this, 0, new Intent[] { intent }, PendingIntentFlags.Mutable);

        var notificationLayout = new RemoteViews(PackageName, Resource.Layout.custom_notification);

        notificationLayout.SetTextViewText(Resource.Id.notification_title, "Kousi. ");

        notificationLayout.SetTextViewText(Resource.Id.notification_text,notitext);///notitext is a notificaton user send a  message stord in string variable



        var builder = new NotificationCompat.Builder(this, ChannelId).SetCustomContentView(notificationLayout).SetSmallIcon(Resource.Drawable.All_menu).SetContentIntent(pendingIntent).SetAutoCancel(true);



        //builder.SetContentIntent(pendingIntent);


        var notificationManager = NotificationManagerCompat.From(this);


        notificationManager.Notify(NotificationId, builder.Build());



    }





    public override void OnBackPressed()
    {
        
            message_layout.Visibility = ViewStates.Invisible;
        
        
        


        base.OnBackPressed();

    }
    public void chatback(object sender, EventArgs e)
    {

         Finish();
        //move_message_layout();
        //message_layout.Animate().TranslationY(0).SetDuration(300).Start();

    }
     public void message_move(object sender, EventArgs e)
     {



        

        Handler handler = new Handler();
        new Handler().PostDelayed(() =>
        {
            message_layout.Visibility = ViewStates.Visible;

            InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
            im.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.None);
        }, 200);

        edit_text.RequestFocus();
        message.Visibility = ViewStates.Invisible;
        message_panel = true;

        c_layout.LayoutParameters.Height =535;
        c_layout.RequestLayout();

        c_layout.Post(() =>
        {
            c_layout.FullScroll(FocusSearchDirection.Down);

        });


    }
    public void message_close_click(object sender, EventArgs e)
    {   if (message_panel == true)
        {
            InputMethodManager im = (InputMethodManager)GetSystemService(InputMethodService);
            im.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.None);
            message_layout.Visibility = ViewStates.Invisible;
            message.Visibility = ViewStates.Visible;

            c_layout.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
            c_layout.RequestLayout();
            message_panel = false;
        }
    else
        {

        }
    }




   public void send_click(object sender,EventArgs e)
    {
        if (edit_text.Text =="") 
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

                cc.Text += edit_text.Text;
                cc.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3f48cc"));
                cc.SetTextColor(Android.Graphics.Color.Black);

                cc.Gravity = GravityFlags.Center;
                cc.TextSize = 20;
                cc.SetPadding(20,20,20,20);
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

                edit_text.Text = "";



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
    private void user_click(object sender,EventArgs e)
    {
        if(edit_text.Text=="")
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
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 300;
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

                cc.Text += edit_text.Text;
                cc.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3f48cc"));
                cc.SetTextColor(Android.Graphics.Color.White);


                  notitext = "";
                  notitext = cc.Text;
                SendHeadsUpNotification();

                cc.Gravity = GravityFlags.Center;
                cc.TextSize = 20;
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

                edit_text.Text = "";



            }
            catch (Exception x)
            {
                Toast.MakeText(this, "personal_ERROR : " + x.Message, ToastLength.Short).Show();
            }
        }
       

    }

    private void v_call_click(object sender,EventArgs e)
    {
        Toast.MakeText(this, "Video call work progress ", ToastLength.Short).Show();

    }
    private void call_click(object sender,EventArgs e)
    {
        Toast.MakeText(this, " call work progress ", ToastLength.Short).Show();

    }







}