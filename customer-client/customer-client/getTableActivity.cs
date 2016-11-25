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
        private Button qrSubmit;

        public int restID { get; private set; }
        public int tableID { get; private set; }

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
            else {

                this.Title = "Hello, Guest";



            }


            findViews();

            //Init Barcode scanner
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);

            //clickHandler();
            tableSubmit.Click += delegate
            {
                //var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
                var resPick = new Android.Content.Intent(this, typeof(resSelectAct));
                //extras here

                string tableNumber = enterTableNumber.Text;
                resPick.PutExtra("tableNumber", tableNumber);
                StartActivity (resPick);
            };

            qrSubmit.Click += delegate
            {
                qr();
            };
        }

        private async void qr()
        {
            var scanPage = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanPage.Scan();
            resultParse( result.ToString() );

            Intent OrderAct = new Android.Content.Intent(this, typeof(OrderActivity));
            //extras here

            if (tableID != null)
            {
                OrderAct.PutExtra("tableNumber", tableID.ToString());
            }
            OrderAct.PutExtra("resId", restID);
            StartActivity(OrderAct);
        }
        private void resultParse(String input)
        {
            //Breaks the input string into 2 stings in array 'codes'
            string[] codes = input.Split(',');
            //Converts strings into ints, & saves them to the global vars
            restID = Int32.Parse(codes[0]);
            tableID = Int32.Parse(codes[1]);
        }

        private void findViews()
        {
            tableSubmit = FindViewById<Button>(Resource.Id.tableSubmit);
            enterTableNumber = FindViewById<EditText>(Resource.Id.enterTableNumber);
            qrSubmit = FindViewById<Button>(Resource.Id.getGRCode);
        }
    }
}