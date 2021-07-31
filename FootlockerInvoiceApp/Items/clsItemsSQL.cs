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
    /// Constructor
    /// </summary>
    public clsItemsSQL() 
    {

    }

    /// <summary>
    /// creates SQL statement to add item.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cost"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public string AddItemSQL(string name, string cost, string description)

    {

        string sSQL = "Insert Into Item (ItemName, ItemCost, ItemDescription) Values (" + name + ", " + cost + ", " + description + ")";

        return sSQL;

    }

    /// <summary>
    /// creates SQL statment to edit an item.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cost"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public string EditItemSQL(string name, string cost, string description)
    {
        string sSQL = "Update Items Set ItemName = " + name + "ItemCost = " + cost + "ItemDescription = " + description;

        return sSQL;
    }
    /// <summary>
    /// used to create the SQL statment for deleting items.
    /// </summary>
    /// <param name="itemcode"></param>
    /// <returns></returns>
    public string DeleteItemSQL(string itemcode)
    {
        string sSQL = "Delete from Item Where ItemID = " + itemcode;

        return sSQL;
    }

}