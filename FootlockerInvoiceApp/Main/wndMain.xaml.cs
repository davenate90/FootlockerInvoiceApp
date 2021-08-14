using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FootlockerInvoiceApp.Items;
using FootlockerInvoiceApp.Search;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace FootlockerInvoiceApp.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        wndItems wndItems = new wndItems();
        wndSearch wndSearch = new wndSearch();

        public wndMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// opens up the item window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            wndItems.ShowDialog();
            this.Show();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            wndSearch.ShowDialog();
            this.Show();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.invoiceIDlbl.Content = "TBD";
        }
    }
}
