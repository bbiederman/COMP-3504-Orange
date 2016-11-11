using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace customer_client
{
    [Activity(Label = "Let's Get You a Table")]
    public class GetTableActivity : Activity
    {
        private Button tableSubmit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.getTable);
            // Create your application here


            findViews();
            //clickHandler();
            tableSubmit.Click += delegate
            {
                var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
                //extras here
                StartActivity(orderactivity);
            };
        }

        private void findViews()
        {
            tableSubmit = FindViewById<Button>(Resource.Id.tableSubmit);
        }
    }
}