using System;
using System.Collections.Generic;
using FootlockerInvoiceApp.Search;
using FootlockerInvoiceApp.Items;
using FootlockerInvoiceApp.Shared;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Main
{

    public class clsMainLogic
    {
        clsMainSQL mainSQL;
        clsDatabase database;
        
        /// <summary>
        /// constructor
        /// </summary>
        public clsMainLogic() 
        {
            mainSQL = new clsMainSQL();
            database = new clsDatabase();
        }
        /// <summary>
        /// gets the total price for the main menu
        /// </summary>
        /// <param name="myList"></param>
        /// <returns></returns>
        public double getTotalCost(BindingList<clsItemsLogic.Item> myList)
        {
            try
            {
                double total = 0;

                foreach (var item in myList)
                {
                    total += item.ItemPrice;
                }
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// creates a new invoice and all of the line items for the invoice. Then returns the new invoice ID
        /// </summary>
        /// <param name="myList"></param>
        /// <param name="totalCost"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string createInvoice(BindingList<clsItemsLogic.Item> myList, double totalCost, DateTime date)
        {
            try
            { 
                //create a new invoice
                database.ExecuteNonQuery(mainSQL.AddInvoice(date.ToString(), totalCost.ToString()));
                //set string for max invoice ID
                string lastInvoiceID = database.ExecuteScalarSQL(mainSQL.LastInvoiceAdded());
                //create new line items
                int i = 1;
                foreach (var item in myList)
                { 
                    database.ExecuteNonQuery(mainSQL.AddLineItem(lastInvoiceID, i.ToString(), item.ItemCode.ToString()));
                    i++;
                }
                return lastInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// this will delete the selected invoice from the database as well as all line items with same invoice ID.
        /// </summary>
        /// <param name="invoiceID"></param>
        public void deleteInvoice(string invoiceID)
        {
            //deletes the invoice with the seleted ID
            database.ExecuteNonQuery(mainSQL.DeleteInvoice(invoiceID));

            //deletes the invoice line items with the selected invoice ID.
            database.ExecuteNonQuery(mainSQL.DeleteLineItem(invoiceID));
        }

        /// <summary>
        /// returns an invoice item with specific invoiceID
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public clsSearchLogic.Invoice getInvoice(string InvoiceID)
        {
            try
            {
                int iRet = 0;
                clsSearchLogic.Invoice invoice2 = new clsSearchLogic.Invoice();

                //get sql to find all line items.
                string sSQL = mainSQL.GetInvoice(InvoiceID);

                var ds = database.ExecuteSQLStatement(sSQL, ref iRet);

                //make a list of flights
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    invoice2.invoiceID = (int)row["InvoiceID"];
                    invoice2.invoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
                    invoice2.totalCharge = (double)row["TotalCost"];
                }
                return invoice2;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get all line items for a specific invoice
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public BindingList<clsItemsLogic.Item> getLineItems(string invoiceID)
        {
            try
            {
                int iRet = 0;
                BindingList<clsItemsLogic.Item> myList = new BindingList<clsItemsLogic.Item>();

                //get sql to find all line items.
               string sSQL = mainSQL.GetLineItems(invoiceID);

                var ds = database.ExecuteSQLStatement(sSQL, ref iRet);

                //make a list of flights
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //create new item
                    var Item = new clsItemsLogic.Item();
                    //find the item code
                    string itemCode = row["ItemCode"].ToString();
                    //get the item from database
                    var specificItem = database.ExecuteSQLStatement(mainSQL.SelectItem(itemCode), ref iRet);
                    foreach (DataRow row1 in specificItem.Tables[0].Rows)
                    {
                        Item.ItemCode = (int)row1["ItemCode"];
                        Item.ItemName = (string)row1["ItemName"];
                        Item.ItemDescription = (string)row1["ItemDescription"];
                        Item.ItemPrice = (double)row1["ItemPrice"];
                    }
                    myList.Add(Item);
                }
                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// updates the invoice in the database
        /// </summary>
        /// <param name="invoice"></param>
        public void updateInvoice(clsSearchLogic.Invoice invoice, BindingList<clsItemsLogic.Item> myList)
        {
            string sSQL;
            //get the sql statement
            sSQL = mainSQL.UpdateTotalCost(invoice.invoiceID, invoice.totalCharge);
            //execute statement
            database.ExecuteNonQuery(sSQL);
            //update all of the line items by deleteing and then adding them back to database
            sSQL = mainSQL.DeleteLineItem(invoice.invoiceID.ToString());
            //create new line items
            int i = 1;
            foreach (var item in myList)
            {
                database.ExecuteNonQuery(mainSQL.AddLineItem(invoice.invoiceID.ToString(), i.ToString(), item.ItemCode.ToString()));
                i++;
            }

        }

    }
}
