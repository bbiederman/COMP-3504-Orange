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
using SQLite;

namespace customer_client
{
    class dataAccess
    {

        public override string() { } //needed for SQLite

        //Code for singlton design pattern setup
        private static dataAccess data = null;
        public static dataAccess getInstance()
        {
            if (data == null)
                data = new dataAccess();

            return data;
        }

        //Regular class data and methods
        private SQLiteConnection dbConnection = null;

        /*=====================================================================
        * Constructor
        =====================================================================*/
        private dataAccess()
        {
            setUpDB();
        }

        /*=====================================================================
         * Deconstructor (Called when the object is destroyed)
         * closes connection to the database
          =====================================================================*/
        ~dataAccess()
        {
            shutDown();
        }

        /*=====================================================================
        * Deconstructor (Called when the object is destroyed);
         =====================================================================*/
        private void shutDown()
        {
            if (dbConnection != null)
                dbConnection.Close();
        }

        /*=====================================================================
         * Initial setup of tables in the database
         =====================================================================*/
        private void setUpTables()
        {
            dbConnection.CreateTable<string>(); // example table being created
            //dbConnection.CreateTable<menu>();

        }
        /*=====================================================================
         * Initial connection to the database
         =====================================================================*/
        private void setUpDB()
        {
            //get the path to where the application can store internal data 
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string dbFileName = "AppData.db"; // name we want to give to our db file
            string fullDBPath = System.IO.Path.Combine(folderPath, dbFileName); // properly formate the path for the system we are on

            //if file does not already exist it will be created for us
            dbConnection = new SQLiteConnection(fullDBPath);
            setUpTables(); // this happens very time.
        }

        public void addItem(string info)
        {
            dbConnection.Insert(info);
            int b = 5;
        }
        
        /*public void addMenu(menu aMenu)
        {
            dbConnection.Insert(aMenu);
        }

        public menu getMenu(int id)
        {
            return dbConnection.Get<menu>(id);
        }*/


        public string geItemByID(int id)
        {
            return dbConnection.Get<string>(id);
        }

        public void deleteItemByID(int id)
        {
            dbConnection.Delete<string>(id);
        }

        public void updateItemInfo(string info)
        {
            dbConnection.Update(info);
        }

        public List<string> getAllItems()
        {
            //gets all elements in the menuItem table and packages it into a List
            return new List<string>(dbConnection.Table<string>());
        }


        public List<string> getAllItemOrdered()
        {
            //gets all elements in the menuItem table and packages it into a List
            return new List<string>(dbConnection.Table<string>());//.OrderBy(st => st.foodName));
        }
        //test method for removal/clear of order
        public void clearItems()
        {
            dbConnection.DeleteAll<string>();
        }
    }
}