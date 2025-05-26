using Android.OS;
using Android.App;
using Android.Widget;
using Android.Views;
using DE.Hdodenhof.Circleimageview;
using Android.Graphics.Drawables;
using Android.Views.Animations;




namespace chat.Resources.layout;

[Activity(Label = "Activity1")]
public class Activity1 : Activity
{

    private Button add;
    private Button btn1;

    

    private Button chat;
    private Button group;
    private Button personal;
    private Button All_menus;

    private RelativeLayout menu;
    private LinearLayout status;

    private ScrollView c_layout;
    private ScrollView g_layout;
    private ScrollView p_layout;

    private LinearLayout chat_layout;
    private LinearLayout group_layout;
    private LinearLayout personal_layout;

    private LinearLayout All_menu_layout;

    private Button music;
    private Button bat;


    


    bool c_chack = true;
    bool g_chack = false;
    bool p_chack = false;




    private int i = 1;
    private int ii = 1;
    private int iii = 1;
    private int s_ii = 1;
    public Boolean All_menu = false;



    


    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.Layout1);



        add = FindViewById<Button>(Resource.Id.add);
        btn1 = FindViewById<Button>(Resource.Id.enter);
        All_menus = FindViewById<Button>(Resource.Id.All_menu);

        chat_layout = FindViewById<LinearLayout>(Resource.Id.chat_layout);


        chat = FindViewById<Button>(Resource.Id.chat);
        group = FindViewById<Button>(Resource.Id.group);
        personal = FindViewById<Button>(Resource.Id.personal);

        menu = FindViewById<RelativeLayout>(Resource.Id.menu);
        status = FindViewById<LinearLayout>(Resource.Id.status);

        chat_layout = FindViewById<LinearLayout>(Resource.Id.chat_layout);
        group_layout = FindViewById<LinearLayout>(Resource.Id.group_layout);
        personal_layout = FindViewById<LinearLayout>(Resource.Id.personal_layout);

        All_menu_layout = FindViewById<LinearLayout>(Resource.Id.All_menu_layout);


        c_layout = FindViewById<ScrollView>(Resource.Id.c_layout);
        g_layout = FindViewById<ScrollView>(Resource.Id.g_layout);
        p_layout = FindViewById<ScrollView>(Resource.Id.p_layout);

        music = FindViewById<Button>(Resource.Id.music);
        bat = FindViewById<Button>(Resource.Id.bat);

        bat.Click += bat_click;

        music.Click += music_click;

        add.Click +=add_click;
        btn1.Click += btn1_click;

        chat.Click += chat_click;
        group.Click += group_click;
        personal.Click += personal_click;
        All_menus.Click += All_menu_click;


       

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      /*
        try
        {

            for (int k = 0; k < 5; k++)
            {
                //Toast.MakeText(this, "naga sri", ToastLength.Short).Show();
                LinearLayout ll = new LinearLayout(this);
                ll.Orientation = Orientation.Vertical;

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GradientDrawable gd = new GradientDrawable();
                gd.SetShape(ShapeType.Rectangle);
                gd.SetCornerRadius(25);
                gd.SetStroke(4, Android.Graphics.Color.Red);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                ll.Background = gd;

                ll.LayoutParameters = new LinearLayout.LayoutParams(695, 170);
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 10;

                ll.Id = i++;

                ll.Click += (sender, args) =>
                {
                    // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                    guna(ll.Id);

                };
                CircleImageView cc = new CircleImageView(this);
                cc.SetImageResource(Resource.Drawable.woman);
                //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);

                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(150, 150);
                layoutParams.TopMargin = 10;
                layoutParams.LeftMargin = 5;
                cc.LayoutParameters = layoutParams;




                ll.AddView(cc);





                layout.AddView(ll,0);
            }

        }
        catch (Exception x)
        {
            Toast.MakeText(this, "ERROR : " + x.Message, ToastLength.Short).Show();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        */

        // Create your application here
    }

    private void chat_click(object sender, EventArgs e)
    {
        chat.SetTextColor(Android.Graphics.Color.ParseColor("#ffffff"));
        group.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));
        personal.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));

        menu.SetBackgroundResource(Resource.Drawable.chat);

        c_chack = true;
        g_chack = false;
        p_chack = false;

        c_layout.Visibility = ViewStates.Visible;
        g_layout.Visibility = ViewStates.Invisible;
        p_layout.Visibility = ViewStates.Invisible;

    }
    private void group_click(object sender, EventArgs e)
    {
        chat.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));
        group.SetTextColor(Android.Graphics.Color.ParseColor("#ffffff"));
        personal.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));

        menu.SetBackgroundResource(Resource.Drawable.group);

        c_chack = false;
        g_chack = true;
        p_chack = false;

        c_layout.Visibility = ViewStates.Invisible;
        g_layout.Visibility = ViewStates.Visible;
        p_layout.Visibility = ViewStates.Invisible;
    }
    private void personal_click(object sender, EventArgs e)
    {
        chat.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));
        group.SetTextColor(Android.Graphics.Color.ParseColor("#3f48cc"));
        personal.SetTextColor(Android.Graphics.Color.ParseColor("#ffffff"));

        menu.SetBackgroundResource(Resource.Drawable.personal);

        c_chack = false;
        g_chack = false;
        p_chack = true;

        c_layout.Visibility = ViewStates.Invisible;
        g_layout.Visibility = ViewStates.Invisible;
        p_layout.Visibility = ViewStates.Visible;
    }

    private void add_click(object sender,EventArgs e)
    {
       
        if (c_chack == true)
        {
            for(int k=1;k<9;k++)
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
                    // gd.SetStroke(4, Android.Graphics.Color.White); 3e6ade
                   // gd.SetColor(Android.Graphics.Color.ParseColor("#3f88c5"));
                    gd.SetColor(Android.Graphics.Color.ParseColor("#3e6ade"));
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                    ll.Background = gd;
                    

                    ll.LayoutParameters = new LinearLayout.LayoutParams(695, 125);
                    ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                    ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 10;

                    ll.Id = i++;

                    ll.Click += (sender, args) =>
                    {
                        // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                        guna(ll.Id);

                    };
                    CircleImageView cc = new CircleImageView(this);
                    if(k==1)
                    {
                        cc.SetImageResource(Resource.Drawable.female1);
                    }
                    else if(k==2)
                    {
                        cc.SetImageResource(Resource.Drawable.male1);
                    }
                    else if (k == 3)
                    {
                        cc.SetImageResource(Resource.Drawable.female2);
                    }
                    else if (k == 4)
                    {
                        cc.SetImageResource(Resource.Drawable.male2);
                    }
                    else if (k == 5)
                    {
                        cc.SetImageResource(Resource.Drawable.female3);
                    }
                    else if (k == 6)
                    {
                        cc.SetImageResource(Resource.Drawable.male3);
                    }
                    else if (k == 7)
                    {

                        cc.SetImageResource(Resource.Drawable.female4);
                    }
                    else if (k == 8)
                    {
                        cc.SetImageResource(Resource.Drawable.male4);
                    }
                    else 
                    {
                        
                    }



                    // cc.SetImageResource(Resource.Drawable.man);

                    //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);

                    /// cc for user image or dp    /////////////////////////////////
                    RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(105, 105);
                    layoutParams.TopMargin = 10;
                    layoutParams.LeftMargin =10;
                    cc.LayoutParameters = layoutParams;

                     /// name for user id name   //////////////////////
                    TextView name = new TextView(this);
                    RelativeLayout.LayoutParams layoutParams1 = new RelativeLayout.LayoutParams(RelativeLayout.MarginLayoutParams.WrapContent, 52);
                    layoutParams1.TopMargin =-108;
                    layoutParams1.LeftMargin = 150;
                    name.LayoutParameters = layoutParams1;
                   // name.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00a8f3"));
                   // name.SetBackgroundColor(Android.Graphics.Color.ParseColor("#000000"));
                    name.Text = "User_name";
                    name.SetTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
                    name.Gravity = GravityFlags.Start;
                    name.TextSize = 20;
                 
                    

                    /// noti for notificaton  of number in y=user chating   ////////
                    TextView noti = new TextView(this);
                    RelativeLayout.LayoutParams layoutParams3 = new RelativeLayout.LayoutParams(60, 60);
                    layoutParams3.TopMargin = -50;
                    layoutParams3.LeftMargin = 620;
                    noti.LayoutParameters = layoutParams3;
                    
                    if (k%3==1)
                    {
                        noti.Visibility = ViewStates.Visible;
                        noti.Background = Resources.GetDrawable(Resource.Drawable.circle_text_view1);
                        noti.Text = "";
                        noti.Text += k;
                        

                    }
                    else
                    {
                        noti.Visibility = ViewStates.Invisible;
                       // noti.Text = "5";
                       // noti.Background = Resources.GetDrawable(Resource.Drawable.circle_text_view);

                    }
                   
                   
                    noti.SetTextColor(Android.Graphics.Color.ParseColor("#000000"));
                    noti.TextSize = 22;
                    noti.Gravity = GravityFlags.Center;


                      /// chat for  user  frined and anothe  chating text   ////    ///////
                    TextView chat = new TextView(this);
                    RelativeLayout.LayoutParams layoutParams2 = new RelativeLayout.LayoutParams(410, 40);
                    layoutParams2.TopMargin =1;
                    layoutParams2.LeftMargin =150;
                    chat.LayoutParameters = layoutParams2;
                   // chat.SetBackgroundColor(Android.Graphics.Color.ParseColor("#f16cf3")); 
                    chat.Text = "This is the demo notification for chat ";
                   
                    chat.TextSize = 15;
                    if(k%3==1) 
                    {
                        chat.SetTextColor(Android.Graphics.Color.ParseColor("#05f248"));
                        
                    }
                    else
                    {
                        chat.SetTextColor(Android.Graphics.Color.ParseColor("#000000"));
                    }

                    chat.Gravity = GravityFlags.Top;




                    //chat.Background = Resources.GetDrawable(Resource.Drawable.circle_text_view);








                    ll.AddView(cc);
                    ll.AddView(name);
                    ll.AddView(noti);
                    ll.AddView(chat);



                    chat_layout.AddView(ll, 0);




                }
                catch (Exception x)
                {
                    Toast.MakeText(this, " chat_ERROR : " + x.Message, ToastLength.Short).Show();
                }
            }
            
        }

        if (g_chack == true)
        {   for(int h=1;h<10;h++)
            {
                try
                {

                    //Toast.MakeText(this, "One chat ADD", ToastLength.Short).Show();
                    LinearLayout ll = new LinearLayout(this);
                    ll.Orientation = Orientation.Vertical;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    GradientDrawable gd = new GradientDrawable();
                    gd.SetShape(ShapeType.Rectangle);
                    gd.SetCornerRadius(25);
                    gd.SetStroke(4, Android.Graphics.Color.White);

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                    ll.Background = gd;

                    ll.LayoutParameters = new LinearLayout.LayoutParams(695, 170);
                    ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                    ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 10;

                    ll.Id = ii++;

                    ll.Click += (sender, args) =>
                    {
                        // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                        guna(ll.Id);

                    };
                    CircleImageView cc = new CircleImageView(this);
                    cc.SetImageResource(Resource.Drawable.group_img);
                    //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);

                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(150, 150);
                    layoutParams.TopMargin = 10;
                    layoutParams.LeftMargin = 5;
                    cc.LayoutParameters = layoutParams;


                    TextView Groupname = new TextView(this);
                    LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(370, 80);
                    layoutParams1.TopMargin = -120;
                    layoutParams1.LeftMargin = 170;
                    Groupname.LayoutParameters = layoutParams1;
                   
                    Groupname.Text = "Group_name "+h;
                    Groupname.SetTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
                    Groupname.Gravity = GravityFlags.Start;
                    Groupname.TextSize = 23;


                    TextView noti = new TextView(this);
                    LinearLayout.LayoutParams layoutParams3 = new LinearLayout.LayoutParams(80, 80);
                    layoutParams3.TopMargin = -65;
                    layoutParams3.LeftMargin = 600;
                    noti.LayoutParameters = layoutParams3;

                    if (h % 2 == 0)
                    {
                        noti.Visibility = ViewStates.Visible;
                        noti.Background = Resources.GetDrawable(Resource.Drawable.circle_text_view1);
                        noti.Text = "";
                        noti.Text += h;


                    }
                    else
                    {
                        noti.Visibility = ViewStates.Invisible;
                        // noti.Text = "5";
                        // noti.Background = Resources.GetDrawable(Resource.Drawable.circle_text_view);

                    }


                    noti.SetTextColor(Android.Graphics.Color.ParseColor("#000000"));
                    noti.TextSize = 25;
                    noti.Gravity = GravityFlags.Center;


                    ll.AddView(cc);
                    ll.AddView(Groupname);
                    ll.AddView(noti);





                    group_layout.AddView(ll, 0);




                }
                catch (Exception x)



                {
                    Toast.MakeText(this, "group_ERROR : " + x.Message, ToastLength.Short).Show();
                }

            }
        }
        if (p_chack == true)
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
                gd.SetStroke(4, Android.Graphics.Color.White);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //  ll.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                ll.Background = gd;

                ll.LayoutParameters = new LinearLayout.LayoutParams(695, 170);
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).TopMargin = 10;
                ((ViewGroup.MarginLayoutParams)ll.LayoutParameters).LeftMargin = 10;

                ll.Id = iii++;

                ll.Click += (sender, args) =>
                {
                    // Toast.MakeText(this, $"clicker layout id : {ll.Id}", ToastLength.Short).Show();
                    guna(ll.Id);

                };
                CircleImageView cc = new CircleImageView(this);
                cc.SetImageResource(Resource.Drawable.female1);
                //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);

                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(150, 150);
                layoutParams.TopMargin = 10;
                layoutParams.LeftMargin = 5;
                cc.LayoutParameters = layoutParams;




                ll.AddView(cc);






                personal_layout.AddView(ll, 0);




            }
            catch (Exception x)
            {
                Toast.MakeText(this, "personal_ERROR : " + x.Message, ToastLength.Short).Show();
            }
        }






    }
    void guna( int i)
    {
        Toast.MakeText(this, $"show a chat id : {i}" , ToastLength.Short).Show();
        StartActivity(typeof(chat));


        //return i;
    }
    void kumaran(int i)
    {
        Toast.MakeText(this, $"show a status id : {i}", ToastLength.Short).Show();
        StartActivity(typeof(notes));
        //return i;
    }
    private void btn1_click(object sender, EventArgs e)
    {
        for (int g = 1; g < 9; g++)
        {
            CircleImageView ss = new CircleImageView(this);

            ss.SetImageResource(Resource.Drawable.female1);


            if (g == 1)
            {
                ss.SetImageResource(Resource.Drawable.female1);
            }
            else if (g == 2)
            {
               ss.SetImageResource(Resource.Drawable.male1);
            }
            else if (g == 3)
            {
                ss.SetImageResource(Resource.Drawable.female2);
            }
            else if (g == 4)
            {
                ss.SetImageResource(Resource.Drawable.male2);
            }
            else if (g == 5)
            {
                ss.SetImageResource(Resource.Drawable.female3);
            }
            else if (g == 6)
            {
                ss.SetImageResource(Resource.Drawable.male3);
            }
            else if (g == 7)
            {

                ss.SetImageResource(Resource.Drawable.female4);
            }
            else if (g == 8)
            {
                ss.SetImageResource(Resource.Drawable.male4);
            }
            else
            {

            }
            //  cc.LayoutParameters = new ViewGroup.LayoutParams(150, 150);

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(170, 170);
            // layoutParams.TopMargin = 10;
            layoutParams.LeftMargin = 10;
            ss.LayoutParameters = layoutParams;
            ss.Id = s_ii++;
            ss.Click += (sender, args) =>
            {
                kumaran(ss.Id);
            };
            status.AddView(ss);
        }


    }
   public void All_menu_click(object sender,EventArgs e)
    {
       if(All_menu==false)
        {
            All_menu_layout.Visibility = ViewStates.Visible;
            All_menu = true;

            All_menu_layout.Animation = new TranslateAnimation(-900, 0, 0, 0);
            All_menu_layout.Animation.Duration = 900;
            All_menu_layout.StartAnimation(All_menu_layout.Animation);
        }
       else
        {
            All_menu_layout.Animation = new TranslateAnimation(0, -900,0,0);
            All_menu_layout.Animation.Duration = 500;
            All_menu_layout.StartAnimation(All_menu_layout.Animation);
            All_menu_layout.Visibility = ViewStates.Invisible;
            All_menu = false;
        }
       
        
    }
    private void music_click(object sender,EventArgs e)
    {
        StartActivity(typeof(music));
    }
    private void bat_click(object sender, EventArgs e)
    {
        StartActivity(typeof(bot));

    }
}
