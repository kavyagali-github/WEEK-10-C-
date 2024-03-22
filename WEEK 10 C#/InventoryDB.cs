using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEEK_10_C_
{
    internal class InventoryDB
    {
        private static readonly string Path = @"C:\Users\kavya\OneDrive\Desktop\C#.net\WEEK 10 C#\WEEK 10 C#\grocery_inventory_items.txt";
        private const char Delimiter = '|';


        public static List<InventoryItem> GetItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();


            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string row;
                while ((row = textIn.ReadLine()) != null)
                {
                    string[] columns = row.Split(Delimiter);


                    if (columns.Length == 3)
                    {
                        InventoryItem item = new InventoryItem
                        {
                            ItemNo = Convert.ToInt32(columns[0]),
                            Description = columns[1],
                            Price = Convert.ToDecimal(columns[2])
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }


        public static void SaveItems(List<InventoryItem> items)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Append, FileAccess.Write)))
            {
                foreach (InventoryItem item in items)
                {
                    //textOut.Write(item.ItemNo + Delimiter);
                    textOut.Write(item.ItemNo);
                    textOut.Write(Delimiter + item.Description + Delimiter);
                    textOut.WriteLine(item.Price);
                }
            }
        }

        public static void DeleteItemFile(string selectedItem)
        {
            List<string> lines = File.ReadAllLines(Path).ToList();
            lines.Remove(selectedItem);
            File.WriteAllLines(Path, lines);
        }

    }
}

