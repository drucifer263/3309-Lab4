using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    //The class that I had to create with the required methods
    public class InvItem
    {
        private int itemNo;
        private string description;
        private decimal price; 
       public InvItem()
        {

        }

       public InvItem(int itemNo, string description, decimal price)
        {
            this.ItemNo = itemNo;
            this.Description = description;
            this.Price = price;
        }

        public int ItemNo
        {
            get
            {
                return itemNo;
            }
            
            set
            {
                itemNo = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;

            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string GetDisplayText()
        {
            return itemNo.ToString("d")+" " + description + " " + price.ToString("c");
        }

    }
}
