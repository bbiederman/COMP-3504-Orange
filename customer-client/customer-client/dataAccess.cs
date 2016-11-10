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
    class dataAccess
    {

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
            dbConnection.CreateTable<menuItem>(); // example table being created
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

        public void addItem(menuItem info)
        {
            dbConnection.Insert(info);
        }

        public Student geItemByID(int id)
        {
            return dbConnection.Get<Student>(id);
        }

        public void deleteItemByID(int id)
        {
            dbConnection.Delete<Student>(id);
        }

        public void updateItemInfo(Student info)
        {
            dbConnection.Update(info);
        }

        public List<Student> getAllItems()
        {
            //gets all elements in the Student table and packages it into a List
            return new List<menuItem>(dbConnection.Table<menuItem>());
        }


        public List<menuItem> getAllItemOrdered()
        {
            //gets all elements in the Student table and packages it into a List
            return new List<menuItem>(dbConnection.Table<menuItem>().OrderBy(st => st.name));
        }
    }
}