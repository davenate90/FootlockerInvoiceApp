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

        public wndMain()
        {
            InitializeComponent();
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            wndItems.ShowDialog();
            this.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            wndSearch search = new wndSearch();
            search.Show();           
        }
    }
}
