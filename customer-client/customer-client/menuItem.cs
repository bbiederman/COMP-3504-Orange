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
    class menuItem
    {
        public string foodName;
        public string foodDescription;
        public decimal itemCost;
        private string imageurl;// possible method to get pictures for food
        /*Features to add
         * -Add additional item costs (eg. add mushrooms and onions to a steak-> +0.80/possibly just add to item view
         * Array/arraylist of benefits such as vegan, gluten, ocean friendly etc
        */

        public string getfoodName()
        {
            return foodName;
        }
        public string getDescription()
        {
            return foodDescription;
        }
        public decimal getItemCost()
        {
            return itemCost;
        }

        public void setfoodName(String foodName)
        {
            foodName = this.foodName;
        }
        public void setDescription(string foodDescription)
        {
            foodDescription = this.foodDescription;
        }
        public void setCost(decimal cost)
        {
            cost = this.itemCost;
        }
    }