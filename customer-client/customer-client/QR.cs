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
    [Activity(Label = "QR")]
    public class QR : Activity
    {
        //Varibales
        private int restID;
        private int tableID;
        
        //Constructor
        public QR()
        {
            captureQR();

        }

        //Builds intent & calls it
        public void captureQR()
        {
            try
            {

                Intent intent = new Intent("com.google.zxing.client.android.SCAN");
                intent.PutExtra("SCAN_MODE", "QR_CODE_MODE"); // "PRODUCT_MODE for bar codes

                StartActivityForResult(intent, 0);

            }
            catch (Exception e)
            {

                /*Uri marketUri = Uri.parse("market://details?id=com.google.zxing.client.android");
                Intent marketIntent = new Intent(Intent.ACTION_VIEW, marketUri);
                startActivity(marketIntent);*/

            }


        }

        //Recieves intent
        protected void onActivityResult(int requestCode, int resultCode, Intent data)
        {
            /*super.onActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)
            {

                if (resultCode == RESULT_OK)
                {
                    String contents = data.getStringExtra("SCAN_RESULT");
                    resultParse(contents);
                }
                if (resultCode == RESULT_CANCELED)
                {
                    //handle cancel
                }
            }*/

            finishWithResult();
        }

        private void reaultParse(String input)
        {
            //Breaks the input string into 2 stings in array 'codes'
            /*string[] codes = input.Split(",");
            //Converts strings into ints, & saves them to the global vars
            restID = Int32.Parse(codes[0].Text);
            tableID = Int32.Parse(codes[1].Text);*/
        }

        public int getRestID()
        {
            return restID;
        }

        public int getTableID()
        {
            return tableID;
        }

        //Return to previous activity with resulting int codes
        private void finishWithResult()
        {
            Intent intent = new Intent();

            //Bundle conData = new Bundle();
            //conData.putString("results", "Thanks Thanks");
            //intent.putExtras(conData);

            /*intent.putExtras( "restID",getRestID() );
            intent.putExtras("tableID", getTableID());
            setResult(RESULT_OK, intent);
            finish();*/
        }
    }
}