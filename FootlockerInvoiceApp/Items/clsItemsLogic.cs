using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using FootlockerInvoiceApp.Main;
using FootlockerInvoiceApp.Search;
using FootlockerInvoiceApp.Shared;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Items
{
   public class clsItemsLogic
    {
        /// <summary>
        /// all of the logic classes that I can use.
        /// </summary>
        ///
        clsDatabase clsDatabase;
        clsItemsSQL clsItemsSQL;
        clsMainLogic clsMainLogic;
        clsSearchLogic clsSearchLogic;
        

        /// <summary>
        /// constructor
        /// </summary>
        public clsItemsLogic() 
        {
            //set up new object for item class
            clsItemsSQL = new clsItemsSQL();
            //set up new object for main class
            clsMainLogic = new clsMainLogic();
            //set up new object for search class
            clsSearchLogic = new clsSearchLogic();
            //set up new object for the database
            clsDatabase = new clsDatabase();
        }

        //Need to make a binding list so invoices and other UI is updated when items are changed.
        /// <summary>
        /// This method will be used to pass all items in the database as a list of objects. 
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems() 
        {
            try
            {
                int rowsReturned = 0;
                List<Item> myList = new List<Item>();
                var ds = clsItemsSQL.ExecuteSQLStatement("select * from item", ref rowsReturned);

                //make a list of Items
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Item();
                    item.ItemCode = (int)row["ItemCode"];
                    item.ItemName = (string)row["ItemName"];
                    item.ItemDescription = (string)row["ItemDescription"];
                    item.ItemPrice = (double)row["ItemPrice"];
                    myList.Add(item);
                }
                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// class to hold objects of data passed in from the data base.
        /// </summary>
        public class Item
        {
            /// <summary>
            /// the item code
            /// </summary>
            public int ItemCode { get; set; }
            /// <summary>
            /// name of the item
            /// </summary>
            public string ItemName { get; set; }
            /// <summary>
            /// cost of the item
            /// </summary>
            public double ItemPrice { get; set; }
            /// <summary>
            /// short description of the item
            /// </summary>
            public string ItemDescription { get; set; }

            //put in override for ToString() so combo box has just the name of the items.
        }

        //need a function to get a list of all invoices to see if an item being delted is on an exsisting invoice.
        /// <summary>
        /// this function will get a list of all invoices that can be used to refrence the invoices in the database.
        /// </summary>
        /// <returns></returns>
        //public List<clsMainLogic.Inovices> GetInovices() 
        // {

        // }

        //if the item is on an invoice tell the user the invoice id with the item. use a pop up


        /// <summary>
        /// will check the list of invoices for the item being edited. if found will give user a popup message.
        /// </summary>
        public void CheckInvoices(int itemCode) 
        {

        }

        //add items
        /// <summary>
        /// this method will add an item to the database. Will be called with the add button press.
        /// </summary>
        public void AddItem(string name, string cost, string description) 
        {

            //validate the user input
            isValidInput(name);

            //create the SQL statement and execute statement
            clsDatabase.ExecuteNonQuery(clsItemsSQL.AddItemSQL(name, cost, description));
        }

        //edit items (do not let the code be updated.)
        /// <summary>
        /// this class will edit items within the database if they are not on another invoice
        /// </summary>
        public void EditItem(Item item, string name, string cost, string description) 
        {
            //validate user input
            isValidInput(name);
            //check if item is on an invoice
            CheckInvoices(item.ItemCode);
            clsDatabase.ExecuteNonQuery(clsItemsSQL.EditItemSQL(name, cost, description));

        }

        //delete items
        /// <summary>
        /// this method will delete an item from the database.
        /// </summary>
        public void DeleteItem(Item item) 
        {
            //check to see if item is on an invoice.
            CheckInvoices(item.ItemCode);
            clsDatabase.ExecuteNonQuery(clsItemsSQL.DeleteItemSQL(item.ItemCode.ToString()));
        }

        /// <summary>
        /// used to validate all user input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool isValidInput(string input) 
        {
            return true;
        }

    }
}
