using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace customer_client
{
    [Activity(Label = "Quick Byte", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button login;
        private EditText emailAddress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            //Test

            findViews();
            //clickHandler();
            login.Click += delegate
            {
                var gettableactivity = new Android.Content.Intent(this, typeof(GetTableActivity));
                //extras here
                char[] delimiterChar = { '@' };
                string username = emailAddress.Text;
                string[] usernameDelim = username.Split(delimiterChar);
                gettableactivity.PutExtra("username", usernameDelim[0]);
                Console.WriteLine(usernameDelim);
                StartActivity (gettableactivity);
                
            };
        }

        private void findViews()
        {
            login = FindViewById<Button>(Resource.Id.login);
            emailAddress = FindViewById<EditText>(Resource.Id.emailAddress);
            //throw new NotImplementedException();//
        }
    }
}

