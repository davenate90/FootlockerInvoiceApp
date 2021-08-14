using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

/// <summary>
/// Class used to access the database.
/// </summary>
public class clsItemsSQL
{
    /// <summary>
    /// Adds an Item to the item desc table
    /// </summary>
    /// <param name="itemCode">The item code number.</param>
    /// <param name="cost">Cost of the item.</param>
    /// <param name="description">item's description.</param>
    /// <returns></returns>
    public string AddItemSQL(string itemCode, string itemPrice, string description)
    {
        string sSQL = "Insert Into ItemDesc (ItemCode, ItemDescription, ItemPrice) Values (" + itemCode + ", " + description + ", " + itemPrice + ")";
        return sSQL;
    }

    /// <summary>
    /// creates SQL statment to edit an item.
    /// </summary>
    /// <param name="itemCode">The item code</param>
    /// <param name="cost">cost of the item.</param>
    /// <param name="description">Items Description.</param>
    /// <returns></returns>
    public string EditItemSQL(string itemCode, string cost, string description)
    {
        string sSQL = "Update ItemDesc Set ItemDescription = " + description + ", Cost = " + cost + " where ItemCode = " + itemCode;

        return sSQL;
    }
    /// <summary>
    /// used to create the SQL statment for deleting items.
    /// </summary>
    /// <param name="itemcode"></param>
    /// <returns></returns>
    public string DeleteItemSQL(string itemcode)
    {
        string sSQL = "Delete from ItemDesc Where ItemCode = " + itemcode;

        return sSQL;
    }

    /// <summary>
    /// Gets all item descriptions.
    /// </summary>
    /// <returns>sql string.</returns>
    public string GetItems()
    {
        string sSQL = "select * from ItemDesc";

        return sSQL;

    }

    /// <summary>
    /// gets invoice IDs.
    /// </summary>
    /// <param name="itemCode">Item code to filter on.</param>
    /// <returns>sql string.</returns>
    public string GetInvoiceIDs(string itemCode)
    {
        string sSQL = "select distinct(InvoiceID) from LineItems where ItemCode = " + itemCode;

        return sSQL;
    }

}