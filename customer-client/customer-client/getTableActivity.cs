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
    [Activity(Label = "Hello, guest")]
    public class GetTableActivity : Activity
    {
        private Button tableSubmit;
        private EditText enterTableNumber;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.getTable);
            

                // Create your application here

                if (Intent.HasExtra("username"))
                {
                    //GetTableActivity.Window.SetTitle
                    this.Title = "Hello, " + Intent.GetStringExtra("username");

                }


            findViews();
            //clickHandler();
            tableSubmit.Click += delegate
            {
                //var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
                var resPick = new Android.Content.Intent(this, typeof(resSelectAct));
                //extras here

                string tableNumber = enterTableNumber.Text;
                resPick.PutExtra("tableNumber", tableNumber);
                StartActivity(resPick);
            };
        }

        private void findViews()
        {
            tableSubmit = FindViewById<Button>(Resource.Id.tableSubmit);
            enterTableNumber = FindViewById<EditText>(Resource.Id.enterTableNumber);
        }
    }
}