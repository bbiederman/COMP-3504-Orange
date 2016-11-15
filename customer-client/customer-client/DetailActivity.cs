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
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        private TextView price;
        private TextView description;
        private Button addButton;
        private ImageView image;

        private dataAccess data = dataAccess.getInstance();
        //private adapter stAdapter; // data adapter for stored items
        //private adapter adapter;

        private menuItem item;

        //Extra Name Constants
        private const String ENAME = "menuItemName";
        private const String EDESCRIPTION = "foodDescription";
        private const String EIMAGE = "itemImage";
        private const String ECOST = "itemCost";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Build menuItem object to populate fields
            buildItem();

            //Set the main view
            SetContentView(Resource.Layout.detail);

            //Connect resource elements
            connectElements();

            //avoid automaticaly appear of android keyboard when activitry starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

        }

        /*
         * This builds a menu item out of the extras, to be used later to populate the fields for the activity
         */
        private void buildItem()
        {
            //Creates a new menu item from the item name
            item = new menuItem(Intent.GetStringExtra(ENAME) );

            //Adds additional information to the object where available
            //Adds food description
            if (Intent.HasExtra(EDESCRIPTION))
             {
                String foodDescription = Intent.GetStringExtra(EDESCRIPTION);
                item.setDescription(foodDescription);
             }
            //Adds item image
            if (Intent.HasExtra(EIMAGE))
            {
                String itemImage = Intent.GetStringExtra(EIMAGE);
                item.setDescription(itemImage);
            }
            //Adds item cost
            if (Intent.HasExtra(ECOST))
            {
                Decimal itemCost = decimal.Parse( Intent.GetStringExtra(ECOST) );
                item.setCost(itemCost);
            }
        }

        //Connects variables to the elements in the .axml
        private void connectElements()
        {
            price = FindViewById<TextView>(Resource.Id.price);

            description = FindViewById<TextView>(Resource.Id.description);

            addButton = FindViewById<Button>(Resource.Id.addButton);

            image = FindViewById<ImageView>(Resource.Id.image);
        }

        // action delagation, setting new adapter and sting up the views
        /*
        private void connectActions()
        {
            viewOrder.Click += ViewOrder_Click;

            ArrayAdapter<string> theAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, testFoodItems);



            itemListView.Adapter = theAdapter;
            itemListView.FastScrollEnabled = true;

            itemListView.ItemClick += itemListView_ItemClick;
            itemListView.ItemLongClick += itemListView_ItemLongClick;


            //addItemButton.Click += AddItemButton_Click;


            //set up addapter for list view 
            //stAdapter = new adapter(this);
            //if (stAdapter is adapter)
            //{
            //   itemNameEditText.Text = "True";
            //}
            //itemListView.Adapter = stAdapter;
            //itemListView.FastScrollEnabled = true;

            //itemListView.ItemClick += itemListView_ItemClick;
            //itemListView.ItemLongClick += itemListView_ItemLongClick;
        }
        */

        //Jordans Code
        private void AddButton_Click(object sender, EventArgs e)
        {
            data.addItem(item);    //updated item info
            //stAdapter.NotifyDataSetChanged(); //sends signal to list that it should refresh the data 

            //Start new activity
            var ordertableact = new Android.Content.Intent(this, typeof(OrderTableAct));

            //Extras
            Intent.PutExtra(ENAME, item.getFoodName());
            Intent.PutExtra(EDESCRIPTION, item.getDescription());
            Intent.PutExtra(EIMAGE, "placeholder");     //No image in menuItem object, placeholder string
            Intent.PutExtra(ECOST, item.getItemCost().ToString() );

            StartActivity(ordertableact);
        }
    }
}