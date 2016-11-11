using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace customer_client
{
    [Activity(Label = "Orange Order", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button login;

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
                StartActivity (gettableactivity);
            };
        }

        private void findViews()
        {
            login = FindViewById<Button>(Resource.Id.login);
            //throw new NotImplementedException();
        }
    }
}

