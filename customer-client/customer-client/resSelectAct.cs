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

namespace customer_client.Resources.layout
{
    [Activity(Label = "Activity1")]
    public class resSelectAct : Activity
    {
        private int resSelect1 = 0;
        private int resSelect2 = 0;
        private int resId;
        protected override void OnCreate(Bundle savedInstanceState)
        {





            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.resSelect);






            RadioButton radio_res1 = FindViewById<RadioButton>(Resource.Id.radio_R1);
            RadioButton radio_res2 = FindViewById<RadioButton>(Resource.Id.radio_R2);
            Button selectBut = FindViewById<RadioButton>(Resource.Id.selectResBut);

            selectBut.Enabled = false;


            radio_res1.Click += RadioRes1Click;
            radio_res2.Click += RadioRes2Click;


           



        }


       public void RadioRes1Click(object sender, EventArgs e) {

           this.resSelect1 = 1;






         
        }




        public void RadioRes2Click(object sender, EventArgs e)
        {
            this.resSelect2 = 2;







        }









        // Create your application here
    }
}