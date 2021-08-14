using System;
using System.Collections;
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
        
        /// Sql class and List of search invoice objects.
        /// I wanted to differentiate between the invoice objects I'd be displaying on my screen and the one that will display more info on the main screen.
        private clsSearchSQL sql = new clsSearchSQL();
        private List<Invoice> myList = new List<Invoice>();

        /// <summary>
        /// Gets invoices
        /// </summary>
        /// <returns> List of invoices </returns>
        public List<Invoice> GetInvoices(bool clearFilters)
        {
            try
            {
                List<Invoice> list = new List<Invoice>();
                if (!clearFilters)
                {
                    return myList;
                }

                int rowsReturned = 0;
                var ds = sql.GetInvoices(ref rowsReturned);

                if (rowsReturned > 0)
                {
                    //make a list of flights
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var invoice = new Invoice();
                        invoice.invoiceID = (int)row["InvoiceID"];
                        invoice.invoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
                        invoice.totalCharge = (double)row["TotalCost"];
                        list.Add(invoice);
                    }
                    myList = list;
                }
                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the invoice IDs for the combo box
        /// </summary>
        /// <returns> List of IDs(int) </returns>
        public IEnumerable GetInvoiceIDs()
        {
            try
            {
                List<int> ids = myList.Select(x => x.invoiceID).ToList();
                ids.Sort();
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets invoice dates for combo box.
        /// </summary>
        /// <returns> List of dates (DateTime) </returns>
        public IEnumerable GetDates()
        {
            try
            {
                List<DateTime> dates = myList.Select(x => x.invoiceDate).ToList();
                dates.Sort();
                return dates;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets invoice total charges
        /// </summary>
        /// <returns> List of </returns>
        public IEnumerable GetCharges()
        {
            try
            {
                List<double> charges = myList.Select(x => x.totalCharge).ToList();
                charges.Sort();
                return charges;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Filters mylist based on selected filters
        /// </summary>
        /// <param name="invoiceID"> invoice id selected item.</param>
        /// <param name="date"> date selected item. </param>
        /// <param name="totalCharge"> total charge selected item. </param>
        public void FilterResults(object invoiceID, object date, object totalCharge)
        {
            try
            {
                if (invoiceID == null && date == null && totalCharge == null)
                {
                    this.GetInvoices(true);
                }
                else if (invoiceID == null && date == null)
                {
                    double charge = Convert.ToDouble(totalCharge);
                    this.FilterOnCharge(charge);
                }
                else if (invoiceID == null && totalCharge == null)
                {
                    DateTime dateTime = Convert.ToDateTime(date);
                    this.FilterOnDate(dateTime);
                }
                else if (date == null && totalCharge == null)
                {
                    int id = Convert.ToInt32(invoiceID);
                    this.FilterOnID(id);
                }
                else if (date == null)
                {
                    int id = Convert.ToInt32(invoiceID);
                    double charge = Convert.ToDouble(totalCharge);
                    this.FilterOnIDandCharge(id, charge);
                }
                else if (invoiceID == null)
                {
                    double charge = Convert.ToDouble(totalCharge);
                    DateTime dateTime = Convert.ToDateTime(date);
                    this.FilterOnDateandCharge(dateTime, charge);
                }
                else if (totalCharge == null)
                {
                    int id = Convert.ToInt32(invoiceID);
                    DateTime dateTime = Convert.ToDateTime(date);
                    this.FilterOnIDandDate(id, dateTime);
                }
                else 
                {
                    int id = Convert.ToInt32(invoiceID);
                    DateTime dateTime = Convert.ToDateTime(date);
                    double charge = Convert.ToDouble(totalCharge);
                    this.FilterOnAll(id, dateTime, charge);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Filters on all combo box filters
        /// </summary>
        /// <param name="id"> invoice id</param>
        /// <param name="date"> date </param>
        /// <param name="charge"> total charges </param>
        private void FilterOnAll(int id, DateTime date, double charge)
        {
            try
            {
                int rowsReturned = 0;
                sql.SearchInvoices(ref rowsReturned, id, date, charge);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> invoice id</param>
        /// <param name="dateTime"> date </param>
        private void FilterOnIDandDate(int id, DateTime dateTime)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"> date </param>
        /// <param name="charge"> total charges </param>
        private void FilterOnDateandCharge(DateTime dateTime, double charge)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> invoice id</param>
        /// <param name="charge"> total charges </param>
        private void FilterOnIDandCharge(int id, double charge)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> invoice id</param>
        private void FilterOnID(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"> date </param>
        private void FilterOnDate(DateTime dateTime)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charge"> total charges </param>
        private void FilterOnCharge(double totalCharge)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// class to hold objects of data passed in from the data base.
        /// </summary>
        public class Invoice
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
            /// short description of the item
            /// </summary>
            public double totalCharge { get; set; }

            //put in override for ToString() so combo box has just the name of the items.
        }
    }
}
