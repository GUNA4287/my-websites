using Android.OS;
using Android.Views;
using Android.App;
using Android.Animation;
using Android.Views.Animations;
using Java.Lang;
using System.Diagnostics.Metrics;
using Org.Apache.Http.Impl.Conn;
using Task.Resources.layout;
using Android.Media;



namespace Task
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private LinearLayout animi;


        private Handler handler;
        private TextView tvText;
        private string text = "Wellcome To  ' TO-DO-LIST '    ";
        private int charIndex = 0;

        public MediaPlayer mediaPlayer2;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            animi = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            Animation animation = AnimationUtils.LoadAnimation(this, Resource.Animation.moving_animation);

            tvText = FindViewById<TextView>(Resource.Id.textView1);

            mediaPlayer2 = MediaPlayer.Create(this, Resource.Raw.sound2);

            animi.StartAnimation(animation);
            mediaPlayer2.Start();

            Handler handler = new Handler();
            handler.PostDelayed(MeterText, 800);
            new Handler().PostDelayed(() =>
            {
                StartActivity(typeof(Activity1));
            }, 4000);
        }
        private void MeterText()
        {
            var handler = new Handler();
            handler.PostDelayed(() =>
            {
                tvText.Text = text.Substring(0, charIndex);
                charIndex++;



                if (charIndex <= text.Length)
                {
                    MeterText();
                }
            }, 50);


        }
    }
}