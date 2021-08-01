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
        /// 
        /// </summary>
        /// <param name="rowsReturned"></param>
        /// <returns></returns>
        public DataSet GetInvoices(ref int rowsReturned)
        {
            try
            {
                string query = "select Invoice.InvoiceID, Invoice.InvoiceDate, Customer.CustFirst_Name, Customer.CustLast_Name, Sum(Invoice_Items.Line_Price) as TotalCharge, Sum(Invoice_Items.Quantity) AS TotalItems FROM (Customer INNER JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID) Inner Join Invoice_Items on Invoice.InvoiceId = Invoice_Items.InvoiceID Group by Invoice.InvoiceID, Invoice.InvoiceDate, Customer.CustFirst_Name, Customer.CustLast_Name";

                return clsDatabase.ExecuteSQLStatement(query, ref rowsReturned);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
