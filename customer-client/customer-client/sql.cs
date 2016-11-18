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
    public class sql
    {
        //Variables
        private List<menuItem> list;

        //Constructor
        public sql()
        {
            createList();
        }

        //Create List
        private void createList()
        {
            list = new List<menuItem>();

            /*
             * Loads .csv
             * Format: name, description, cost, imageID, itemID, status
             */
            

        }

        private menuItem buildItem(string name, string description, decimal itemCost, int imageId, int itemId, int status)
        {
            menuItem item = new customer_client.menuItem(name, description, itemCost, imageId);

            item.itemStatus = status;
            //item.setStatus(status);           This doesn't exist right now

            return item;
        }

    }
}