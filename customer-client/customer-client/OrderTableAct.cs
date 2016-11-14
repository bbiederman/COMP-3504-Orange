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
using Android.Views.InputMethods;
using Android.Media;

namespace customer_client
{
    [Activity(Label = "OrderTableAct")]
    public class OrderTableAct : Activity
    {

        private dataAccess data = dataAccess.getInstance();
        private ListView itemTable;
        private adapter stAdapter; // data adapter for stored items
        private EditText total;
        private Button dingbutton;
        //private EditText itemNameEditText;









        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.menuOrder);
            //avoid automaticaly appear of android keyboard when activitry starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            // Create your application here
            

            loadViews();
            //connectActions();

            


        }






        private void loadViews()
        {   //the list view with all data get from sqlite
            itemTable = FindViewById<ListView>(Resource.Id.orderTable);
            //button plays a sound
            dingbutton = FindViewById<Button>(Resource.Id.dingBut);
            //calc total from item price
            total = FindViewById<EditText>(Resource.Id.total);
        }






        //Will just display an alert of all the student info
        private void itemTable_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            menuItem selectedSt = stAdapter[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Item Info");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.foodName);
            dialog.Show();

        }




        //Will ask if they want to remove the item
        private void itemTable_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            menuItem selectedSt = stAdapter[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Delete menu item");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.foodName);
            dialog.SetPositiveButton("Delete",
                (senderAlert, args) =>
                { // action for this button
                    data.deleteItemByID(selectedSt.ID);
                    stAdapter.NotifyDataSetChanged();
                    Toast.MakeText(this, "The menu item has been deleted", ToastLength.Short).Show();
                }
                );
            dialog.SetNegativeButton("cancel", (senderAlert, args) => { });

            dialog.Show();

            
        }


        //this hides the key board
        private void hideKeyBoard(Android.Views.View element)
        {
            InputMethodManager im = (InputMethodManager)GetSystemService(Context.InputMethodService);
            im.HideSoftInputFromWindow(element.WindowToken, 0);

        }





        //this method does the total sum of item ordered, incomplete
        private void itemTotal() {
             int tot = 0;

            //loop into sqlite and get menuItem prices




            total.Text = "your total is " + tot;


        }

        MediaPlayer _player; //Soundplaying class variable
        //press the button plays the sound and provides the total, incomplete 
        private void finish() {

            dingbutton.Click += delegate
            {
                _player = MediaPlayer.Create(this, Resource.Drawable.AlsoBasicDing);
                _player.Start();


                //play sound

                //calculate the total



            };




        }









    }
}