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
    [Activity(Label = "Pick a Restaurant")]
    public class resSelectAct : Activity
    {
        private int resId;
        private string tableNum = "";
        private Button select_res1;
        private Button select_res2;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.resSelect);
           

            if (Intent.HasExtra("tableNumber"))
            {

                if (Intent.GetStringExtra("tableNumber") != null)
                {
                    //GetTableActivity.Window.SetTitle

                    tableNum = Intent.GetStringExtra("tableNumber");
                }
                else {

                    tableNum = "Unknown";
                }
         }
            else if(Intent.GetStringExtra("tableNumber")=="") { tableNum = "Unknown"; }

            loadViews();


            select_res1.Click += Res1Click;
            select_res2.Click += Res2Click;

            //butFunction();

        }


        public void Res1Click(object sender, EventArgs e)
        {
            resId = 1;

            //var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
            var OrderAct = new Android.Content.Intent(this, typeof(OrderActivity));
            //extras here

            if (tableNum != null)
            {
                OrderAct.PutExtra("tableNumber", tableNum);
            }
            OrderAct.PutExtra("resId", resId);
            StartActivity(OrderAct);

        }




        public void Res2Click(object sender, EventArgs e)
        {
            resId = 2;
            //var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
            var OrderAct = new Android.Content.Intent(this, typeof(OrderActivity));
            //extras here
            OrderAct.PutExtra("tableNumber", tableNum);
            OrderAct.PutExtra("resId", resId);
            StartActivity(OrderAct);


        }


        private void loadViews()
        {
            select_res1 = FindViewById<Button>(Resource.Id.res1But);
            select_res2 = FindViewById<Button>(Resource.Id.res2But);
        }

    }
}