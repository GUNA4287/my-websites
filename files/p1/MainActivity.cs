using Android.OS;
using Android.Widget;
using Android.App;

using chat.Resources.layout;


namespace chat
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private Handler handler;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Handler handler = new Handler();
            new Handler().PostDelayed(() =>
            {
                StartActivity(typeof(Activity1));
            }, 600);


        }
    }
}