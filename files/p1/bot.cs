using Android.OS;
using Android.Content;
using Android.Widget;
using Android.Database;
using Android.Views.Animations;
using Android.Views;
using Android.App;
using Android.Graphics;
using Android.Runtime;
using Android.Provider;
using System.IO;
using AndroidX.Core;
using Android.Content;


using Android.Locations;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Java.Nio.FileNio.Spi;
using AndroidX.Core.App;

using Android.Speech.Tts;
using Android.Speech;
using System.Net.Http;
using System.Threading.Tasks;


namespace chat.Resources.layout;

[Activity(Label = "bot")]
public class bot : Activity,TextToSpeech.IOnInitListener
{

    

    //string channelId = "notification_channel";

    private const string  ChannelId= "i.apps.notifications";
    private const int NotificationId = 1234;


    private static int REQUEST_CAMERA = 1;
    private Android.Net.Uri imageUri;

    private Button bot_chat_btn;

    private Button All_menus;
    public Boolean All_menu = false;

    private Button chat;
    private Button music;



    private Button map;
    private Button gmail;




    private LinearLayout All_menu_layout;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.bot);

        All_menus = FindViewById<Button>(Resource.Id.All_menu);

        chat = FindViewById<Button>(Resource.Id.chat);
        music = FindViewById<Button>(Resource.Id.music);
       
        All_menu_layout = FindViewById<LinearLayout>(Resource.Id.All_menu_layout);

        bot_chat_btn = FindViewById<Button>(Resource.Id.bot_chat_btn);

        All_menus.Click += All_menu_click;


        map = FindViewById<Button>(Resource.Id.map);
        gmail = FindViewById<Button>(Resource.Id.gmail);




        map.Click += map_click;
        gmail.Click += gmail_click;


        chat.Click += chat_click;
        music.Click += music_click;





        bot_chat_btn.Click += bot_chat_btn_click;


        // Create your application here


        CreateNotificationChannel();

       

    }
    

   
   

    public void OnInit(OperationResult status)
    {

    }
   
 

    

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////
    /// </summary>
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

        notificationLayout.SetTextViewText(Resource.Id.notification_title, "hello");

        notificationLayout.SetTextViewText(Resource.Id.notification_text,"guna na  guna ");

      

        var builder = new NotificationCompat.Builder(this, ChannelId).SetCustomContentView(notificationLayout).SetSmallIcon(Resource.Drawable.All_menu).SetContentIntent(pendingIntent).SetAutoCancel(true);



        //builder.SetContentIntent(pendingIntent);


        var notificationManager = NotificationManagerCompat.From(this);


        notificationManager.Notify(NotificationId , builder.Build());



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

    private void music_click(object sender, EventArgs e)
    {
        Finish();
        StartActivity(typeof(music));
    }
    public void bot_chat_btn_click(object sender,EventArgs e)
    {

        try
        {
            Finish();

            StartActivity(typeof(bot_chating));

        }
        catch(Exception x)
        {
            Toast.MakeText(this, " bot_chat_opening : " + x.Message, ToastLength.Short).Show();
        }
    }

    private void map_click(object sender, EventArgs e)
    {
        try
        {


            var googlemapIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("geo:0,0? q=1600+Amphitheatre+Parkway,+Mountain+View,+CA"));
            StartActivity(googlemapIntent);
        }
        catch (Exception x)
        {
            Toast.MakeText(this, " google map error : " + x.Message, ToastLength.Short).Show();
        }

    }
    private void gmail_click(object sender,EventArgs e)
    {
        try
        {
            /* //  gmail open
             var gmailIntent = new Intent();
             gmailIntent.SetAction(Intent.ActionMain);

             gmailIntent.AddCategory(Intent.CategoryAppEmail);

             StartActivity(gmailIntent);
            */



            /*     open the google drive

             var fileIntent = new Intent(Intent.ActionView);
             // browser opened  fileIntent.SetData(Android.Net.Uri.Parse("content://com.android.providers.downloads.documents/"));
             fileIntent.SetData(Android.Net.Uri.Parse("https://drive.google.com/drive/my-drive"));

             StartActivity(fileIntent);

             */


            /* open the  google
            var googleIntent = new Intent(Intent.ActionView);

            googleIntent.SetData(Android.Net.Uri.Parse("https://www.google.com"));

            StartActivity(googleIntent);

            
            
             /*
            /*

            Intent cameraIntent = new Intent(MediaStore.ActionImageCapture);
            string filePath = GetFilePath();
            
                 ////////////////////////////////////////////////////////////////////////////////////////////////////Z
            cameraIntent.PutExtra(MediaStore.ExtraOutput, imageUri);

            StartActivityForResult(cameraIntent, REQUEST_CAMERA);

            */
            SendHeadsUpNotification();





            Toast.MakeText(this, " notofi : " , ToastLength.Short).Show();




        }
        catch (Exception x)
        {
            Toast.MakeText(this, " g mail : " + x.Message, ToastLength.Short).Show();
        }


    }

  

   




    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if(requestCode==REQUEST_CAMERA && resultCode==Result.Ok)
        {

            Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, imageUri);
            MediaStore.Images.Media.InsertImage(ContentResolver, bitmap, "Image", "Image captured bt app");


         

            Toast.MakeText(this, "Image saved to gallery! ", ToastLength.Long).Show();
        }
    }
    private string GetFilePath()
    {
        string directory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
        string filePath = System.IO.Path.Combine(directory, "image.jpg");
        return filePath;
    }


}