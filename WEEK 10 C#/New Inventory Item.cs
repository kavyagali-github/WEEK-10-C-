using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WEEK_10_C_
{
    public partial class Nwe_Inventory_Item : Form
    {
        public Nwe_Inventory_Item()
        {
            InitializeComponent();
        }
       
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click_1(object sender, EventArgs e)
        {

            try
            {
                int itemNo = int.Parse(itemNoTextBox.Text);
                string description = descriptionTextBox.Text;
                decimal price = decimal.Parse(priceTextBox.Text);

                // Create a new InventoryItem object
                InventoryItem newItem = new InventoryItem
                {
                    ItemNo = itemNo,
                    Description = description,
                    Price = price
                };

                // Declare a list of InventoryItem objects
                List<InventoryItem> itemList = new List<InventoryItem>();
                // Add the new item to the list
                itemList.Add(newItem);
                // Save the new item to the text file
                InventoryDB.SaveItems(new List<InventoryItem> { newItem });

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid data for item number and price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}