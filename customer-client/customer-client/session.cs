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
    class session
    {
        private int session_id;
   
        private int table_id;
        
        public session(){
            session_id = 0;
           
            table_id = 0;


        }


   


        Java.Util.ArrayList customerList = new Java.Util.ArrayList();
        //calling owner to add and remve
        private void removeCustomer(customer_id) {

            customerList.Remove(customer_id);
        }

        private void addCustomer() {
            customerList.Add(customer_id);
      }


        public void getSid() {
            return session_id;

        }



        







        public order(session_id) { }









    }
}