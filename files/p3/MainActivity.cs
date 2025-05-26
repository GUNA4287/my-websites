
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Android.Text;

using Obito.Resources.layout1;
namespace Obito
{
    [Activity(Label = "OBITO ", MainLauncher =true)]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            new Handler().PostDelayed(() =>
            {
                StartActivity(typeof(Activity1));
            }, 2000);

           
        }
        
    }
}