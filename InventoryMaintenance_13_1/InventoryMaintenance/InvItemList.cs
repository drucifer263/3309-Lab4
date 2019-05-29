using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class InvItemList
    {
        private List<InvItem> invItems;

        public delegate void ChangeHandler(InvItemList invItems);

        public event ChangeHandler Changed;

        public InvItemList()
        {
            invItems = new List<InvItem>();
        }

        public int Count => invItems.Count;

        public InvItem this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer >= invItems.Count)
                {
                    throw new ArgumentOutOfRangeException(indexer.ToString());
                }
                return invItems[indexer];
            }

            set
            {
                invItems[indexer] = value;
                Changed(this);
            }
        }
        public void Add(InvItem invItem)
        {
            invItems.Add(invItem);
            Changed(this);
        }

        public void Add(int itemNo, string description, decimal price)
        {
            InvItem i = new InvItem(itemNo, description, price);
            invItems.Add(i);
            Changed(this);
        }

        public void Remove(InvItem invItem)

        {
            invItems.Remove(invItem);
            Changed(this);
        }
        public void Fill() => invItems = InvItemDB.GetItems();

        public void Save() => InvItemDB.SaveItems(invItems);
        
        public static InvItemList operator + (InvItemList invItems, InvItem invItem )
        {
            invItems.Add(invItem);
            return invItems;
            
        }

        public static InvItemList operator - (InvItemList invItems, InvItem invItem)
        {
            invItems.Remove(invItem);
            return invItems;
        }

        
    }
}
