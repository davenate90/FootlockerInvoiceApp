using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Items
{
   public class clsItemsLogic
    {

        /// <summary>
        /// constructor
        /// </summary>
        public clsItemsLogic() 
        {

        }

        //Need to make a binding list so invoices and other UI is updated when items are changed.
        /// <summary>
        /// This method will be used to pass all items in the database as a list of objects. 
        /// </summary>
        /// <returns></returns>
        public List<Items> GetItems() 
        {
            List<Items> myList = new List<Items>();
            return myList;
        }

        /// <summary>
        /// class to hold objects of data passed in from the data base.
        /// </summary>
        public class Items
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
            public double ItemCost { get; set; }
            /// <summary>
            /// short description of the item
            /// </summary>
            public string ItemDescription { get; set; }
        }

        //need a function to get a list of all invoices to see if an item being delted is on an exsisting invoice.

        //if the item is on an invoice tell the user the invoice id with the item. use a pop up

        //add items

        //edit items (do not let the code be updated.)

        //delete items

    }
}
