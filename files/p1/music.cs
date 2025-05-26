using Android.Views.Animations;
using Android.Views;

namespace chat.Resources.layout;

[Activity(Label = "music")]
public class music : Activity
{
    private Button home;
    private Button search;
    private Button Library;
    private Button play;

    private Button bat;


    private Button All_menus;

    private RelativeLayout search_layout;
    private LinearLayout All_menu_layout;

    public Boolean All_menu = false;
    private Button chat;

    private RelativeLayout update_music;
    private RelativeLayout history_music;
    private RelativeLayout music_play;
    private Boolean search_item = false;




    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.music);

        home = FindViewById<Button>(Resource.Id.home);
        search = FindViewById<Button>(Resource.Id.search);
        Library = FindViewById<Button>(Resource.Id.Library);
        All_menus = FindViewById<Button>(Resource.Id.All_menu);
        chat = FindViewById<Button>(Resource.Id.chat);

        play = FindViewById<Button>(Resource.Id.play);




        search_layout = FindViewById<RelativeLayout>(Resource.Id.search_layout);
        All_menu_layout = FindViewById<LinearLayout>(Resource.Id.All_menu_layout);

        update_music = FindViewById<RelativeLayout>(Resource.Id.update_music);
        history_music = FindViewById<RelativeLayout>(Resource.Id.history_music);
        music_play = FindViewById<RelativeLayout>(Resource.Id.music_play_panel);

        bat = FindViewById<Button>(Resource.Id.bat);
        bat.Click += bat_click;





        home.Click += home_click;
        search.Click += search_click;
        Library.Click += Library_click;
        All_menus.Click += All_menu_click;
        chat.Click += chat_click;
        play.Click += play_click;

        update_music.Click += update_music_click;
        history_music.Click += history_music_click;
        music_play.Click += music_play_click;




        // Create your application here
    }


    public override void OnBackPressed()
    {


        
        if(search_item==true)

        {
            StartActivity(typeof(music));
        }
        else
        {

        }
        


        base.OnBackPressed();

    }
    private void  home_click(object sender,EventArgs e)
    {
        search_layout.Visibility = Android.Views.ViewStates.Invisible;
        search_item = false;
       

    }
    private void search_click(object sender, EventArgs e)
    {
        search_layout.Visibility = Android.Views.ViewStates.Visible;
        search_item = true;
       
    }
    private void Library_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(library));
    }
    public void All_menu_click(object sender, EventArgs e)
    {
        if (All_menu == false)
        {
            All_menu_layout.Visibility = ViewStates.Visible;
            All_menu = true;

            All_menu_layout.Animation = new TranslateAnimation(-900, 0, 0, 0);
            All_menu_layout.Animation.Duration = 900;
            All_menu_layout.StartAnimation(All_menu_layout.Animation);
        }
        else
        {
            All_menu_layout.Animation = new TranslateAnimation(0, -900, 0, 0);
            All_menu_layout.Animation.Duration = 500;
            All_menu_layout.StartAnimation(All_menu_layout.Animation);
            All_menu_layout.Visibility = ViewStates.Invisible;
            All_menu = false;
        }


    } 
    private void chat_click(object ender, EventArgs e)
    {
        Finish();
        StartActivity(typeof(Activity1));
    }

    private void update_music_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(library));
    }
    private void history_music_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(library));
    }
    private void music_play_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(play));
    }
    private void play_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(play));
    }

    private void bat_click(object sender, EventArgs e)
    {
        Finish();
        StartActivity(typeof(bot));
    }
}

