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
        clsSearchLogic logic = new clsSearchLogic();
        clsSearchSQL sql = new clsSearchSQL();

        public wndSearch()
        {
            InitializeComponent();            
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //// pass null through as a parameter. If null is passed through as a parameter then main will populate not invoice information.
            wndMain mainWnd = new wndMain();
            mainWnd.Show();
            this.Close();
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            //// pass through the invoice ID with which the main window will do a Scalar query on the invoice id to populate the invoice information.
            wndMain mainWnd = new wndMain();
            mainWnd.Show();
            this.Close();
        }
    }
}
