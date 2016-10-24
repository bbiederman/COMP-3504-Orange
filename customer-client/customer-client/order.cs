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
    class order
    {
        int sessionID = 0;
        menuItem[] itemsOrdered;
        int menuCount = 0;

        public order( int assignedID)
        {
            sessionID = assignedID;
        }
        public void addItem(menuItem newItem)
        {
            itemsOrdered[menuCount] = new menuItem(newItem);
            menuCount = menuCount + 1;
        }
        public void removeItem(int removingItem)
        {
            itemsOrdered[removingItem].updateStatusCode(4);
            // need to add removing item possibly?
            //maybe use arraylist in place of array for an easier list
        }
        


    }
}