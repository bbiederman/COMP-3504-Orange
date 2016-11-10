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
        private dataAccess data = dataAccess.getInstance();
        private ListView itemListView;
        private adapter stAdapter; // data adapter for stored items

        private Button additemtButton;
        private EditText itemNameEditText;





        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.homeScreen);
            //avoid automaticaly appear of android keyboard when activitry starts
            Window.SetSoftInputMode(SoftInput.StateHidden);


            loadViews();
            connectActions();



            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }




        //loading the views kidney had a text file a button and a list view, this need to be changed to our view 
        private void loadViews()
        {
            itemListView = FindViewById<ListView>(Resource.Id.itemListView);
            additemButton = FindViewById<Button>(Resource.Id.addItemButton);
            itemNameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
        }





        // action delagation, setting new adapter and sting up the views
        private void connectActions()
        {
            addItemButton.Click += AddItemButton_Click;

            //set up addapter for list view 
            stAdapter = new adapter(this);
            itemListView.Adapter = stAdapter;
            itemListView.FastScrollEnabled = true;

            menuListView.ItemClick += menuListView_ItemClick;
            menuListView.ItemLongClick += menuListView_ItemLongClick;
        }






        //Will just display an alert of all the student info
        private void menuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            menuItem selectedSt = stAdapter[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Menu Info");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.name);
            dialog.Show();

        }






        //Will ask if they want to remove the student
        private void menuItemListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Student selectedSt = stAdapter[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Delete menu item");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.name);
            dialog.SetPositiveButton("Delete",
                (senderAlert, args) =>
                { // action for this button
                    data.deleteStudentByID(selectedSt.ID);
                    stAdapter.NotifyDataSetChanged();
                    Toast.MakeText(this, "The menu item has been deleted", ToastLength.Short).Show();
                }
                );
            dialog.SetNegativeButton("cancel", (senderAlert, args) => { });

            dialog.Show();






        }



        private void AddItemButton_Click(object sender, EventArgs e)
        {
            data.addItem(new menuItem(itemNameEditText.Text));//change from addStudent
            itemNameEditText.Text = ""; //clear field after entering data
            stAdapter.NotifyDataSetChanged(); //sends signal to list that it should refresh the data 

            //Hide keyboard after use for our text field
            hideKeyBoard(itemNameEditText);

        }


        //this hides the key board
        private void hideKeyBoard(View element)
        {
            InputMethodManager im = (InputMethodManager)GetSystemService(Context.InputMethodService);
            im.HideSoftInputFromWindow(element.WindowToken, 0);

        }


    }
}