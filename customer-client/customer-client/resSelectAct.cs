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
        //private int resSelect1 = 1;
        //private int resSelect2 = 2;
        private int resId;
        private string tableNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.resSelect);

            if (Intent.HasExtra("tableNumber"))
            {
                //GetTableActivity.Window.SetTitle
                tableNum=Intent.GetStringExtra("tableNumber");


            }


            


            


            RadioButton radio_res1 = FindViewById<RadioButton>(Resource.Id.radio_R1);
            RadioButton radio_res2 = FindViewById<RadioButton>(Resource.Id.radio_R2);
            Button selectBut = FindViewById<Button>(Resource.Id.selectResBut);

            selectBut.Enabled = false;


            radio_res1.Click += RadioRes1Click;
            radio_res2.Click += RadioRes2Click;




            selectBut.Click += delegate
            {



                //var orderactivity = new Android.Content.Intent(this, typeof(OrderActivity));
                var theOrderAct = new Android.Content.Intent(this, typeof(OrderActivity));
                //extras here

                theOrderAct.PutExtra("resId", resId);

                StartActivity(theOrderAct);
            };





            //butFunction();


           



        }


       public void RadioRes1Click(object sender, EventArgs e) {

           resId = 1;
            Button selectBut = FindViewById<Button>(Resource.Id.selectResBut);

            selectBut.Enabled = true;



         
        }




        public void RadioRes2Click(object sender, EventArgs e)
        {
            resId = 2;
            Button selectBut = FindViewById<Button>(Resource.Id.selectResBut);



            selectBut.Enabled = true;




        }



        //public void butFunction() {



        //}





        // Create your application here
    }
}