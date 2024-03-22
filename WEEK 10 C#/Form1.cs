using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEEK_10_C_
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();

        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Instance of the new nventory item form
            Nwe_Inventory_Item newInventoryItem = new Nwe_Inventory_Item();

            // When click on add it will display the new form 
            newInventoryItem.Show();
            
        }
        // to delete the selected data
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (List.SelectedItem != null)
            {
                string selectedItem = List.SelectedItem.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    List.Items.Remove(selectedItem);
                    InventoryDB.DeleteItemFile(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            // Loading items from file
            List<InventoryItem> items = InventoryDB.GetItems();

            // Adding to ListBox
            foreach (InventoryItem item in items)
            {
                string displayText = $"{item.ItemNo}|{item.Description}|{item.Price}";
                List.Items.Add(displayText);
            }
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}