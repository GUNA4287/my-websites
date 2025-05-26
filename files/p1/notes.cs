using Android.OS;
using Android.Widget;
using Android.Util;
using Android.Media;

namespace chat.Resources.layout;

[Activity(Label = "Activity2")]
public class notes : Activity
{
    private Button chat;
    private Button chat_back;
    private Button like;
    private Button l_next;
    private Button r_next;
    private Button setting;
    private RelativeLayout setting_layout;
    private Button block;


    private Boolean set = false;

    public MediaPlayer mediaPlayer;





    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.notes);

        chat = FindViewById<Button>(Resource.Id.chat);
        chat_back = FindViewById<Button>(Resource.Id.chat_back);
        like=FindViewById<Button>(Resource.Id.like);
        l_next = FindViewById<Button>(Resource.Id.l_next);
        r_next = FindViewById<Button>(Resource.Id.r_next);

        setting = FindViewById<Button>(Resource.Id.setting);
        setting_layout = FindViewById<RelativeLayout>(Resource.Id.setting_layout);

        block = FindViewById<Button>(Resource.Id.block);




        block.Click += block_click;


        chat_back.Click += chat_back_click;

        chat.Click += chat_click;
        like.Click += like_click;

        l_next.Click += l_click;
        r_next.Click += r_click;

        setting.Click += setting_click;
        mediaPlayer = MediaPlayer.Create(this, Resource.Raw.notesgk);

        mediaPlayer.Start();
        // Create your application here
    }
    public void chat_click(object sender, EventArgs e)
    {
        mediaPlayer.Stop();
        Finish();
        StartActivity(typeof(chat));

    }
    private void chat_back_click(object snder,EventArgs e)
    {
        Finish();
        mediaPlayer.Stop();
        //StartActivity(typeof(chat));
    }
    private void like_click(object sender,EventArgs e)
    {
        Toast.MakeText(this, " this like a notes a username notes" , ToastLength.Short).Show();

    }
    private void l_click(object sender,EventArgs e)
    {
        Toast.MakeText(this, " prives notes loading", ToastLength.Short).Show();
    }
    private void r_click(object sender, EventArgs e)
    {
        Toast.MakeText(this, " next noted loading", ToastLength.Short).Show();
    }
    private void setting_click(object sender,EventArgs e)
    {
         if(set==false)
        {
            setting_layout.Visibility = Android.Views.ViewStates.Visible;
            set = true;
        }
         else
        {
            setting_layout.Visibility = Android.Views.ViewStates.Invisible;
            set = false;
        }
    }

    public override void OnBackPressed()
    {

        mediaPlayer.Stop();
        Finish();
        


        base.OnBackPressed();

    }
    private void block_click(object sender,EventArgs e)
    {
        mediaPlayer.Stop();
        Finish();
    }


}