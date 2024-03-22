using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_10_C_
{
    internal class Inventory
    {
        private List<InventoryItem> items;

        public Inventory()
        {
           
            items = new List<InventoryItem>();
        }

        
        public void AddItem(InventoryItem item)
        {
            items.Add(item);
          
        }
        public void DeleteItem(InventoryItem item)
        {
            items.Remove(item);
        }
        public List<InventoryItem> GetAllItems()
        {
            return items;
        }

    }
}
