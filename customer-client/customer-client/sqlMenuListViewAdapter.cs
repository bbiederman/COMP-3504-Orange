using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using System.Linq;

namespace customer_client
{
    public class sqlMenuListViewAdapter : BaseAdapter<string>
    {
        private dataAccess data = dataAccess.getInstance();
        Activity context;
        List<menuItem> list;

        public sqlMenuListViewAdapter(Activity _context)//, List<menuItem> _list)
		:base()
	{
            this.context = _context;
            //this.list = _list;
        }

        /*public sqlMenuListViewAdapter(Activity _context)
        :base()
        {
            this.context = _context;
        }*/

        public override int Count
        {
            get { return data.getAllItems().Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get {
                string theTest = data.getAllItemOrdered().ElementAt<string>(position); 
                //List<menuItem> something = data.getAllItemOrdered();
                //theTest.ElementAt<menuItem>(position);
                return theTest;//data.getAllItemOrdered().ElementAt<menuItem>(position);
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ListViewItemRow, parent, false);


             

            string item = this[position];

            char[] delimiterChar = { '@' };
            //string it = itemToInsert;
            string[] itemDelim = item.Split(delimiterChar);
            //gettableactivity.PutExtra("username", usernameDelim[0]);
            string theName = itemDelim[0];
            string theDesc = itemDelim[1];
            string stringTheCost = itemDelim[2];
            decimal theCost = System.Convert.ToDecimal(stringTheCost);
            string stringTheId = itemDelim[3];
            int theId = System.Int32.Parse(stringTheId);

            view.FindViewById<TextView>(Resource.Id.Title).Text = theName;//item.foodName;
            view.FindViewById<TextView>(Resource.Id.Description).Text = theDesc;//item.getDescription();//System.Convert.ToString(item.itemCost);//item.itemCost.ToString();


            //string price = "$" + item.itemCost.ToString();


            //view.FindViewById<TextView>(Resource.Id.Description).Text = price;//item.foodDescription;
            

            using (var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail))
            {
                //imageView.SetImageResource(item.imageID);
            }
            return view;
        }
    }
}