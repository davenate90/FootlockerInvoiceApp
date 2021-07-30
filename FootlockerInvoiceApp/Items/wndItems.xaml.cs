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

namespace FootlockerInvoiceApp.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// itemlogic class
        /// </summary>
        clsItemsLogic itemLogic;

        /// <summary>
        /// constructor for window
        /// </summary>
        public wndItems()
        {
            InitializeComponent();
            //set up new itemlogic item
            itemLogic = new clsItemsLogic();
        }

        /// <summary>
        /// when the page loads the datagrid will be populated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //testing the database
            ItemDataGrid.ItemsSource = itemLogic.GetItems();
        }

        /// <summary>
        /// event to be handled when the add button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add button
        }

        /// <summary>
        /// event to be handled when the edit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// event to be handeled when the delete button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
