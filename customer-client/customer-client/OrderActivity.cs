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

using Xamarin.Forms;

namespace customer_client
{
    [Activity(Label = "Activity1")]
    public class OrderActivity : Activity
    {
        //private List 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //Xamarin.Forms.ListView menuListView = new Xamarin.Forms.ListView;

            //ItemSource = testList;    
        }
    }
}