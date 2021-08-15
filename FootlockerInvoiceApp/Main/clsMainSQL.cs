using FootlockerInvoiceApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Main
{
    public class clsMainSQL
    {
        /// <summary>
        /// Connection string to the database.
        /// </summary>
        clsDatabase clsDatabase = new clsDatabase();

        /// <summary>
        /// Gets specific invoice
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceNum">Invoice id number</param>
        /// <returns>Dataset</returns>
        public string GetInvoice(string invoiceID)
        {
            try
            {
                string query = "SELECT * From Invoices WHERE InvoiceID = " + invoiceID;

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string GetLineItems(string InvoiceID)
        {
            try
            {
                string query = "SELECT * FROM LineItems WHERE InvoiceID = " + InvoiceID;
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// search for a specific item.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public string SelectItem(string ItemCode)
        {
            try
            {
                string query = "SELECT * FROM ItemDesc WHERE ItemCode = " + ItemCode;
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the invoice ID of the last invoice that was created.
        /// </summary>
        /// <returns></returns>
        public string LastInvoiceAdded()
        {
            try
            {
                string query = "SELECT MAX(InvoiceID) FROM Invoices";
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// creates the invoice query
        /// </summary>
        /// <param name="totalCost">total cost.</param>
        /// <param name="invoiceDate">Invoice date.</param>
        /// <returns>DataSet</returns>
        public string AddInvoice(string invoiceDate, string totalCost)
        {
            try
            {
                string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + invoiceDate + "#, " + totalCost + ")";

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds a line item to invoice.
        /// </summary>
        /// <param name="invoiceNum">The invoice number.</param>
        /// <param name="itemCode">The item code.</param>
        /// <param name="lineItemNum">The line item number.</param>
        /// <returns>DataSet</returns>
        public string AddLineItem(string invoiceNum, string lineItemNum, string itemCode)
        {
            try
            {
                string query = "INSERT INTO LineItems (InvoiceID, LineItemNum, ItemCode) Values (" + invoiceNum + ", " + lineItemNum + ", " + itemCode + ")";

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a string to delete specific invoice.
        /// </summary>
        /// <param name="invoiceNum">Invoice number.a</param>
        public string DeleteInvoice(string invoiceNum)
        {
            try
            {
                string query = "DELETE From Invoices WHERE InvoiceID = " + invoiceNum;
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes a line item.
        /// </summary>
        /// <param name="invoiceNum">Invoice number.</param>
        /// <param name="lineItemNum">line item number.</param>
        public string DeleteLineItem(string invoiceNum)
        {
            try
            {
                string query = "DELETE From LineItems WHERE InvoiceID = " + invoiceNum;
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// updates the total cost of the invoice
        /// </summary>
        /// <param name="invoiceNum">invoice id number.</param>
        /// <param name="totalCost">total cost.</param>
        public string UpdateTotalCost(int invoiceID, double totalCost)
        {
            try
            {
                string query = "IF NOT EXISTS UPDATE Invoices SET TotalCost = " + totalCost + " WHERE InvoiceID = " + invoiceID;

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    }
}
