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

        public order( int assignedID)
        {
            sessionID = assignedID;
        }
        public void addItem(int orderId)
        {

        }
    }
}