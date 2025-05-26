namespace chat.Resources.layout;

[Activity(Label = "Activity2")]
public class library : Activity
{
    private Button back;
    private Button home;
    private Button search;
    private Button proflie;

    private Button local_file;
    private LinearLayout music_list_layout;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.library);


        back = FindViewById<Button>(Resource.Id.back);
        home = FindViewById<Button>(Resource.Id.home);
        search = FindViewById<Button>(Resource.Id.search);
        proflie = FindViewById<Button>(Resource.Id.profile);
        local_file = FindViewById<Button>(Resource.Id.local_file);

        music_list_layout = FindViewById<LinearLayout>(Resource.Id.music_list_layout);




        back.Click += back_click;
        home.Click += home_click;
        search.Click += search_click;
        local_file.Click += local_file_click;
        proflie.Click += proflie_click;

       music_list_layout.Click += music_list_layout_click;



        // Create your application here
    }

    public override void OnBackPressed()
    {


        Finish();
        StartActivity(typeof(music));


        base.OnBackPressed();

    }
    private void back_click(object sender, EventArgs e)
    {
        Finish();
        StartActivity(typeof(music));
    }
    private void home_click(object sender, EventArgs e)
    {
        Finish();
        StartActivity(typeof(music));
    }
    private void search_click(object sender, EventArgs e)
    {

        Finish();
        StartActivity(typeof(music));
    }
    private void local_file_click(object sender, EventArgs e)
    {
        Toast.MakeText(this, " local file page_layout progress ", ToastLength.Short).Show();
    }

    private void proflie_click(object sender, EventArgs e)
    {

        Toast.MakeText(this, " profile page_layout progress ", ToastLength.Short).Show();
    }

    private void music_list_layout_click(object sender,EventArgs e)
    {
        Finish();
        StartActivity(typeof(play));
    }
}
