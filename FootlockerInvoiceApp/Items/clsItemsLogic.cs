using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootlockerInvoiceApp.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// the item code
        /// </summary>
        public int ItemCode { get; set; }
        /// <summary>
        /// name of the item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// cost of the item
        /// </summary>
        public double ItemCost { get; set; }
        /// <summary>
        /// short description of the item
        /// </summary>
        public string ItemDescription { get; set; }

    }
}
