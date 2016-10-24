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
        public int itemStatus;
        /*
         * status code 0: not initialized
         * status code 1: ordered
         * status code 2: in Progress
         * status code 3: delivered to table
         * status code 4: canceled
         * */
        private string imageurl;// possible method to get pictures for food
        /*Features to add
         * -Add additional item costs (eg. add mushrooms and onions to a steak-> +0.80/possibly just add to item view
         * Array/arraylist of benefits such as vegan, gluten, ocean friendly etc
        */

        /*Constructors*/
        public menuItem(menuItem addingItem)
        {
            setFoodName(addingItem.getFoodName());
            setDescription(addingItem.getDescription());
            setCost(addingItem.getItemCost());
        }


        /*getters*/
        public string getFoodName()
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
        public int getStatusCode()
        {
            return itemStatus;
        }
        /*setters*/
        public void setFoodName(String foodName)
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
        public void updateStatusCode(int newStatusCode)
        {
            itemStatus = newStatusCode;
        }
    }
}