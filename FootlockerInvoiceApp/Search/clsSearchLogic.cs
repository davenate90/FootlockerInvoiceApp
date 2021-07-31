using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Search
{
    class clsSearchLogic
    {
        private clsSearchSQL sql = new clsSearchSQL();

        public List<SearchInvoice> GetInvoices()
        {
            try
            {
                int rowsReturned = 0;
                List<SearchInvoice> myList = new List<SearchInvoice>();
                string query = "SELECT Invoice.InvoiceID, Invoice.InvoiceDate, Customer.CustFirst_Name, Customer.CustLast_Name, Sum(Invoice_Items.Quantity) AS TotalItems, Sum(Invoice_Items.Line_Price) AS TotalCharge FROM(Customer INNER JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID) INNER JOIN Invoice_Items ON Invoice.InvoiceID = Invoice_Items.InvoiceID GROUP BY Invoice.InvoiceID, Invoice.InvoiceDate, Customer.CustFirst_Name, Customer.CustLast_Name";
                
                var ds = sql.ExecuteSQLStatement(query, ref rowsReturned);

                //make a list of flights
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var invoice = new SearchInvoice();
                    invoice.invoiceID = (int)row["InvoiceID"];
                    invoice.invoiceDate = (DateTime)row["InvoiceDate"];
                    invoice.customerName = (string)row["CustFirst_Name"] + " " + (string)row["CustLast_Name"];
                    invoice.totalItems = (int)row["TotalItems"];
                    invoice.totalCharge = (double)row["TotalCharge"];
                    myList.Add(invoice);
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
        public class SearchInvoice
        {
            /// <summary>
            /// the item code
            /// </summary>
            public int invoiceID { get; set; }
            /// <summary>
            /// name of the item
            /// </summary>
            public DateTime invoiceDate { get; set; }
            /// <summary>
            /// cost of the item
            /// </summary>
            public string customerName { get; set; }
            /// <summary>
            /// short description of the item
            /// </summary>
            public int totalItems { get; set; }
            /// <summary>
            /// short description of the item
            /// </summary>
            public double totalCharge { get; set; }

            //put in override for ToString() so combo box has just the name of the items.
        }

        internal void FilterResults(object selectedItem1, object selectedItem2, object selectedItem3)
        {
            throw new NotImplementedException();
        }
    }
}
