
using Android.OS;
using Android.Widget;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Net;
using Android.Content;




namespace chat.Resources.layout;

[Activity(Label = "play")]
public class play : Activity
{
    private Button pause;
    private Boolean play_music = false;

    private Button backword;
    private Button forword;


    private Button back;


    private Handler handler;
    public MediaPlayer mediaPlayer;
    private int currentSongIndex = 0;
    private int[] songList = { Resource.Raw.s1, Resource.Raw.s2, Resource.Raw.s3, Resource.Raw.s4, Resource.Raw.s5, Resource.Raw.s6, Resource.Raw.s7, Resource.Raw.s8, Resource.Raw.s9, Resource.Raw.s10 };
    private bool isPlaying = true;

    private int[] imageList = { Resource.Drawable.n1, Resource.Drawable.n2, Resource.Drawable.n3,Resource.Drawable.n4,Resource.Drawable.n5,Resource.Drawable.n6, Resource.Drawable.n7, Resource.Drawable.n8, Resource.Drawable.n9, Resource.Drawable.n10 };

    private string[] songNames = { "Gold Sparrow", "Hey Minnale", "Spark", "Makkamishi", "Paiya Dei", "Sawadeeka","Rayya Rayya","Palaanadha Palaanadha","Thanjaoor Jilla Kari","Manasula Soora Kaathey" };
    private string[] authorName = { "G.V Prakash", "Harichran", "Yuvan Shankar", "Harris Jayaraj", "Anand Kashinath","Anthony Daasan","Javed Ali","vidyasygar","Mani Sharama","RR & Divya" };

    private RelativeLayout songImage;
    private TextView songname;
    private TextView authorname;



    public int i = 1;


    private AudioManager audioManager;


    // private ImageView imageView;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.play);

        pause = FindViewById<Button>(Resource.Id.pause);
        backword = FindViewById<Button>(Resource.Id.backword);
        forword = FindViewById<Button>(Resource.Id.forword);
        back = FindViewById<Button>(Resource.Id.back);

        songImage = FindViewById<RelativeLayout>(Resource.Id.songImage);
        songname = FindViewById<TextView>(Resource.Id.songname);
        authorname = FindViewById<TextView>(Resource.Id.authorname);

        mediaPlayer = MediaPlayer.Create(this, songList[currentSongIndex]);
        mediaPlayer.Start();
        UpdateUI();


        songImage.SetBackgroundResource(imageList[currentSongIndex]);



        

        pause.Click += pause_click;
        backword.Click += backword_click;
        forword.Click += forword_click;

        back.Click += back_click;




       
        // Create your application here
    }
   public void pause_click(object sender,EventArgs e)
    {
        

      
               
              if(mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                pause.Text = "play";
                isPlaying = false;
            }
              else
            {
                mediaPlayer.Start();
                pause.Text = "pause";
                isPlaying = true;
            }
           
            
            
       
            
           
            
        
       
     
    }
    
    private void backword_click(object sender,EventArgs e)
    {
        
        Handler handler = new Handler();
        new Handler().PostDelayed(() =>
        {
            backword.SetBackgroundResource(Resource.Drawable.backword);

        }, 100);
      
        new Handler().PostDelayed(() =>
        {
            backword.SetBackgroundResource(Resource.Drawable.backword1);
            
            play_music = true;
            PlaySong(-1);

        }, 400);
    }
    private void forword_click(object sender, EventArgs e)
    {
        Handler handler = new Handler();
        new Handler().PostDelayed(() =>
        {
            forword.SetBackgroundResource(Resource.Drawable.forwoard);

        }, 100);


        new Handler().PostDelayed(() =>
        {
            forword.SetBackgroundResource(Resource.Drawable.forwoard1);
           
            play_music = true;

            PlaySong(1);
        }, 400);
    }







    private void PlaySong(int direction)
    {
        if(mediaPlayer !=null)
        {
            mediaPlayer.Stop();
            mediaPlayer.Release();

        }

        currentSongIndex = (currentSongIndex + direction) % songList.Length;
        if (currentSongIndex < 0)
            currentSongIndex = songList.Length - 1;


        mediaPlayer = MediaPlayer.Create(this, songList[currentSongIndex]);
        mediaPlayer.Start();
        isPlaying = true;
        pause.Text = "pause";

        //songImage.SetBackgroundResource(imageList[currentSongIndex]);
        UpdateUI();

    }

   private void UpdateUI()
    {
        songImage.SetBackgroundResource(imageList[currentSongIndex]);
        songname.Text = songNames[currentSongIndex];
        authorname.Text = authorName[currentSongIndex];

    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if(mediaPlayer !=null)
        {
            mediaPlayer.Release();
            mediaPlayer = null;
        }
        base.OnDestroy();
    }






















    private void back_click(object sender,EventArgs e)
    {
         Finish();
         StartActivity(typeof(music));
        //var intent = new Intent(Android.Content.Intent.ActionView, Android.Net.Uri.Parse("geo:0,0? q=Google+Maps"));
       

       // StartActivity(intent);
        
         //StartActivity(intent);


       // audioManager.SetStreamVolume(Android.Media.Stream.Music, 0, 0);
    }
    public override void OnBackPressed()
    {


        Finish();
        StartActivity(typeof(music));


        base.OnBackPressed();

    }

    
}