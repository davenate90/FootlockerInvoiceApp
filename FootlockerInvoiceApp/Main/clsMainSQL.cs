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
        /// Gets all invoices
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceNum">Invoice id number</param>
        /// <returns>Dataset</returns>
        public DataSet GetInvoice(ref int rowsReturned, int invoiceNum)
        {
            try
            {
                string query = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all invoices
        /// </summary>
        /// <param name="rowsReturned"></param>
        /// <returns>DataSet</returns>
        public DataSet GetItems(ref int rowsReturned)
        {
            try
            {
                string query = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches items in invoice.
        /// </summary>
        /// <param name="rowsReturned"></param>
        /// <param name="invoiceNum"></param>
        /// <returns>DataSet</returns>
        public DataSet SearchItems(ref int rowsReturned, int invoiceNum)
        {
            try
            {
                string query = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + invoiceNum;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds an invoice.
        /// </summary>
        /// <param name="totalCost">total cost.</param>
        /// <param name="invoiceDate">Invoice date.</param>
        /// <returns>DataSet</returns>
        public void AddInvoice(DateTime invoiceDate, double totalCost)
        {
            try
            {
                string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(" + invoiceDate + ", " + totalCost + ")";

                clsDatabase.ExecuteNonQuery(query);
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
        public void AddLineItem(int invoiceNum, int lineItemNum, int itemCode)
        {
            try
            {
                string query = "INSERT INTO Invoice_Items (InvoiceID, LineItemNum, ItemCode) Values (123, 1, 'AA')";

                clsDatabase.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes and invoice.
        /// </summary>
        /// <param name="invoiceNum">Invoice number.a</param>
        public void DeleteInvoice(int invoiceNum)
        {
            try
            {
                string query = "DELETE From Invoices WHERE InvoiceID = " + invoiceNum;

                clsDatabase.ExecuteNonQuery(query);
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
        public void DeleteLineItem(int invoiceNum, int lineItemNum)
        {
            try
            {
                string query = "DELETE From LineItems WHERE InvoiceID = " + invoiceNum + "AND LineItemNum = " + lineItemNum;

                clsDatabase.ExecuteNonQuery(query);
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
        public void UpdateTotalCost(int invoiceNum, double totalCost)
        {
            try
            {
                string query = "UPDATE Invoices SET TotalCost = " + totalCost + " WHERE InvoiceNum = " + invoiceNum;

                clsDatabase.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
