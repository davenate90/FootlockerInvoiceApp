using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FootlockerInvoiceApp.Main;

namespace FootlockerInvoiceApp.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// 
        /// </summary>
        clsSearchLogic logic = new clsSearchLogic();

        /// <summary>
        /// 
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            PopulateInvoices(true);
            PopulateFilters();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateFilters()
        {
            totalChargeCmb.ItemsSource = logic.GetCharges();
            dateCmb.ItemsSource = logic.GetDates();
            invoiceIDCmb.ItemsSource = logic.GetInvoiceIDs();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoices(bool clearFilters)
        {
            invoiceDataGrid.ItemsSource = logic.GetInvoices(clearFilters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (invoiceDataGrid.SelectedItem != null)
            {
                // pass through the invoice ID with which the main window will do a Scalar query on the invoice id to populate the invoice information.
                clsSearchLogic.Invoice invoice2 = (clsSearchLogic.Invoice)invoiceDataGrid.SelectedItem;
                ((wndMain)Application.Current.MainWindow).selectedInvoiceID = invoice2.invoiceID;
                this.Hide();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logic.FilterResults(invoiceIDCmb.SelectedItem, dateCmb.SelectedItem, totalChargeCmb.SelectedItem);
            this.PopulateInvoices(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            this.PopulateInvoices(true);
            dateCmb.SelectedIndex = -1;
            invoiceIDCmb.SelectedIndex = -1;
            totalChargeCmb.SelectedIndex = -1;
        }
    }
}
