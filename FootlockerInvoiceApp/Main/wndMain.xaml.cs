using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FootlockerInvoiceApp.Items;
using FootlockerInvoiceApp.Search;
using System.Windows.Controls;
using System.Reflection;
using System.ComponentModel;
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
        #region Class Attributes
        /// <summary>
        /// item window
        /// </summary>
        wndItems ItemWindow;
        /// <summary>
        /// search window
        /// </summary>
        wndSearch SearchWindow;
        /// <summary>
        /// main window logic class
        /// </summary>
        clsMainLogic MainLogic;
        /// <summary>
        /// Item Logic
        /// </summary>
        clsItemsLogic ItemLogic;
        /// <summary>
        /// Search Logic Class
        /// </summary>
        clsSearchLogic SearchLogic;
        /// <summary>
        /// and Item object form the itemlogic class
        /// </summary>
        public clsItemsLogic.Item item1;
        /// <summary>
        /// a list of items.
        /// </summary>
        BindingList<clsItemsLogic.Item> itemList;
        /// <summary>
        /// and invoice item
        /// </summary>
        clsSearchLogic.Invoice invoice1;
        /// <summary>
        /// list of invoices
        /// </summary>
        BindingList<clsSearchLogic.Invoice> invoiceList;
        //used to know if a invoice is being changed.
        private bool editingInvoice;
        //used to make sure that pice has been updated.
        bool priceupdated;
        /// <summary>
        /// this can be set from the search window to select the correct invoice
        /// </summary>
        public int selectedInvoiceID;
        #endregion

        /// <summary>
        /// consturctor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();

            //initialize all of the windows and classes
            ItemWindow = new wndItems();
            SearchWindow = new wndSearch();
            MainLogic = new clsMainLogic();
            ItemLogic = new clsItemsLogic();
            SearchLogic = new clsSearchLogic();
            item1 = new clsItemsLogic.Item();
            invoice1 = new clsSearchLogic.Invoice();
            itemList = new BindingList<clsItemsLogic.Item>();
            invoiceList = new BindingList<clsSearchLogic.Invoice>();
            priceupdated = false;
            editingInvoice = false;
            selectedInvoiceID = 0;

            //fill up the item combo box with items.
            cmbItems.ItemsSource = ItemLogic.GetItems();
            
        }


        /// <summary>
        /// opens up the item window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ItemWindow.ShowDialog();
            this.Show();

        }
        /// <summary>
        /// opens the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                SearchWindow.ShowDialog();
                this.Show();
                
                if(selectedInvoiceID != 0)
                {
                    //set price updated to false
                    priceupdated = false;
                    //set invoice ID label
                    txtInvoiceID.Text = selectedInvoiceID.ToString();
                    //get invoice
                    invoice1 = MainLogic.getInvoice(selectedInvoiceID.ToString());
                    //set invoice GUI items
                    txtInvoiceCost.Text = "$" + invoice1.totalCharge.ToString("N2");
                    //set date
                    datepickerInvoiceDate.SelectedDate = invoice1.invoiceDate;

                    // search database for line item list.
                    itemList = MainLogic.getLineItems(selectedInvoiceID.ToString());
                    //set data grid
                    invoiceDataGrid.ItemsSource = itemList;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Adds a new invoice to the data base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datepickerInvoiceDate.SelectedDate != null)
                {
                    //reset error label
                    lblError.Content = "";
                    // set edititng to true
                    editingInvoice = true;
                    //disable other buttons
                    editBtn.IsEnabled = false;
                    deleteBtn.IsEnabled = false;
                    btnCreate.IsEnabled = false;
                    txtInvoiceID.Text = "TBD";
                    txtInvoiceCost.Text = "";
                    invoice1.invoiceDate = (DateTime)datepickerInvoiceDate.SelectedDate;
                    //create a new list
                    itemList = new BindingList<clsItemsLogic.Item>();
                    //set datagrid to be bound to new list.
                    invoiceDataGrid.ItemsSource = itemList;

                }
                else
                {
                    lblError.Content = "Please select a date for the new invoice!";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method handles when a new item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                item1 = (clsItemsLogic.Item)cmbItems.SelectedItem;
                txtItemPrice.Text = "$" + item1.ItemPrice.ToString();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// helps print out error messsages when and exception is thrown
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// handles adding an item to the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editingInvoice == true)
                {
                    item1 = (clsItemsLogic.Item)cmbItems.SelectedItem;
                    itemList.Add(item1);
                    invoiceDataGrid.ItemsSource = itemList;
                    txtInvoiceCost.Text = "$" + MainLogic.getTotalCost(itemList).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// handles the remove button click. It will remove the selected item from the invoice listing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editingInvoice == true)
                {
                    itemList.Remove((clsItemsLogic.Item)invoiceDataGrid.SelectedItem);
                    invoiceDataGrid.ItemsSource = itemList;
                    txtInvoiceCost.Text = "$" + MainLogic.getTotalCost(itemList).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// saves all items on the data grid to the database and creates a new invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editingInvoice == true)
                {
                    if (txtInvoiceID.Text != "TBD")
                    {
                        if (priceupdated == true)
                        {
                            //make sure that invoice 1 is totally updated
                            invoice1.invoiceDate = (DateTime)datepickerInvoiceDate.SelectedDate;
                            invoice1.totalCharge = MainLogic.getTotalCost(itemList);
                            invoice1.invoiceID = Int32.Parse(txtInvoiceID.Text);
                            //call method to update database
                            MainLogic.updateInvoice(invoice1, itemList);
                        }
                        //set editing to false
                        editingInvoice = false;
                        //reenable all of the buttons
                        editBtn.IsEnabled = true;
                        deleteBtn.IsEnabled = true;
                        btnCreate.IsEnabled = true;
                    }
                    if (txtInvoiceID.Text == "TBD")
                    {
                        //add items to invoice/database
                        txtInvoiceID.Text = MainLogic.createInvoice(itemList, MainLogic.getTotalCost(itemList), (DateTime)datepickerInvoiceDate.SelectedDate);
                        //set editing to false
                        editingInvoice = false;
                        //reenable all of the buttons
                        editBtn.IsEnabled = true;
                        deleteBtn.IsEnabled = true;
                        btnCreate.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// handles the delete button. Deletes selected invoice and all associated line items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editingInvoice == false && txtInvoiceID.Text != "")
                {
                    MainLogic.deleteInvoice(txtInvoiceID.Text);
                    //clear GUI
                    txtInvoiceCost.Text = "";
                    txtInvoiceID.Text = "";
                    datepickerInvoiceDate.SelectedDate = DateTime.Now;
                    //create new empty list for datagrid.
                    itemList = new BindingList<clsItemsLogic.Item>();
                    //set datagrid to be bound to new list.
                    invoiceDataGrid.ItemsSource = itemList;
                    //reenable all buttons
                    btnCreate.IsEnabled = true;

                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// handles the edit button being pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editingInvoice == false && txtInvoiceID.Text != "")
                {
                    //reset error label
                    lblError.Content = "";
                    // set edititng to true
                    editingInvoice = true;
                    //disable other buttons
                    editBtn.IsEnabled = false;
                    deleteBtn.IsEnabled = false;
                    btnCreate.IsEnabled = false;

                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// keeps track of if price has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvoiceCost_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            priceupdated = true;
        }
    }
 
}
