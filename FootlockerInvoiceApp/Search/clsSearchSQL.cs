using FootlockerInvoiceApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Search
{
    class clsSearchSQL
    {
        /// <summary>
        /// Connection string to the database.
        /// </summary>
        clsDatabase clsDatabase = new clsDatabase();

        /// <summary>
        /// Gets all invoices
        /// </summary>
        /// <param name="rowsReturned"></param>
        /// <returns></returns>
        public DataSet GetInvoices(ref int rowsReturned)
        {
            try
            {
                string query = "select * FROM Invoice";

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on invoice number
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceNum">the invoice id number.</param>
        /// <returns>dataset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, int invoiceNum)
        {
            try
            {
                string query = "select * FROM Invoice WHERE invoiceID = " + invoiceNum;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on invoice number and invoice date
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceNum">the invoice id number.</param>
        /// <param name="invoiceDate">the date of the invoice.</param>
        /// <returns>dateset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, int invoiceNum, DateTime invoiceDate)
        {
            try
            {
                string query = "select * FROM Invoice WHERE invoiceID = " + invoiceNum + "AND invoiceDate = " + invoiceDate;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on invoice number and invoice date and total cost.
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceNum">the invoice id number.</param>
        /// <param name="invoiceDate">the date of the invoice.</param>
        /// <param name="totalCost">The total cost of the invoice.</param>
        /// <returns>dateset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, int invoiceNum, DateTime invoiceDate, double totalCost)
        {
            try
            {
                string query = "select * FROM Invoice WHERE invoiceID = " + invoiceNum + "AND invoiceDate = " + invoiceDate + "AND totalCost = " + totalCost;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on invoice date and total cost.
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceDate">the date of the invoice.</param>
        /// <param name="totalCost">The total cost of the invoice.</param>
        /// <returns>dateset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, DateTime invoiceDate, double totalCost)
        {
            try
            {
                string query = "select * FROM Invoice WHERE invoiceDate = " + invoiceDate + "AND totalCost = " + totalCost;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on total cost.
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="totalCost">The total cost of the invoice.</param>
        /// <returns>dateset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, double totalCost)
        {
            try
            {
                string query = "select * FROM Invoice WHERE totalCost = " + totalCost;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches invoices based on invoice date and total cost.
        /// </summary>
        /// <param name="rowsReturned">rows returned.</param>
        /// <param name="invoiceDate">the date of the invoice.</param>
        /// <returns>dateset</returns>
        public DataSet SearchInvoices(ref int rowsReturned, DateTime invoiceDate)
        {
            try
            {
                string query = "select * FROM Invoice WHERE invoiceDate = " + invoiceDate;

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
