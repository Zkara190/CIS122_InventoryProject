using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class Form1 : Form
    {   // Instantiated the InventoryManager class to manage inventory items
        InventoryManager inventoryManager = new InventoryManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for clicking a cell in the dataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Inventory
        {
            if (e.RowIndex >= 0) // Make sure that a valid row is selected
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Populate the form fields with the data from the selected row
                // So it can be edited or displayed
                textBoxName.Text = selectedRow.Cells["Name"].Value.ToString();
                textBoxSKU.Text = selectedRow.Cells["SKU"].Value.ToString();
                textBoxQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                comboBoxStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
            }
        }

        // Event handler for the "Add Item" button click
        private void button1_Click(object sender, EventArgs e) //AddItem
        {
            // Gets the values from the input fields to create a new item
            string name = itemNameTextBox.Text;
            string sku = itemSkuTextBox.Text;
            string status = itemStatusComboBox.Text;

            InventoryItem newItem = new InventoryItem(name, sku, status);
            inventory.AddToInventory(newItem); // Use Inventory class to add the item

            // Update the DataGridView to reflect the new item
            UpdateInventoryDisplay();
        }

        private void button2_Click(object sender, EventArgs e) // Remove Item
        {
            // Gets SKU from the input field for the item to be removed
            string sku = skuRemoveTextBox.Text;
            inventoryManager.stock.RemoveFromInventory(sku);

            UpdateInventoryDisplay(); // Refresh the DataGridView
        }

        private void button3_Click(object sender, EventArgs e) // Search for Item
        {
            string sku = skuSearchTextBox.Text;
            InventoryItem item = inventoryManager.FindItemBySku(sku);

            // Display the item information if found, otherwise show a "not-found" message
            if (item != null)
            {
                MessageBox.Show($"Item found: Name: {item.Name}, ID: {item.ID}, Status: {item.Status}");
            }
            else
            {
                MessageBox.Show("Item not found.");
            }
        }

        private void button4_Click(object sender, EventArgs e) // Update Item
        {
            // Get values from input fields to update an existing item
            int id = int.Parse(idTextBox.Text); 
            string? newName = nameTextBox.Text;
            string? newSku = skuTextBox.Text;
            string? newStatus = statusTextBox.Text;

            // Update the specified fields of the item
            inventoryManager.Modify(id, newStatus, newName, newSku);

            UpdateInventoryDisplay(); // Refresh the DataGridView
        }

        private void UpdateInventoryDisplay()
        {
            inventoryDataGridView.Rows.Clear(); // Clear Existing Rows

            // Add each item in the inventory to the DataGridView
            foreach (var item in inventoryManager.stock.GetList())
            {
                inventoryDataGridView.Rows.Add(item.ID, item.Name, item.SKU, item.Status);
            }
        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            string filePath = "inventory.csv";
            inventoryManager.LoadFromFile(filePath);
            UpdateInventoryDisplay();
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            string filePath = "inventory.csv";
            inventoryManager.SaveToFile(filePath);
        }

        // Event handler for changing the item status using the ComboBox selection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Item Status
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row's ID
                int selectedItemID = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

                // Get the selected status from the ComboBox
                string selectedStatus = comboBoxStatus.SelectedItem.ToString();

                // Call a method to update the status of the selected item
                inventoryManager.Modify(selectedItemID, selectedStatus, null, null);

                // Refresh the DataGridView to show the updated status
                LoadInventoryData();
            }
            else // Show a message if no item is selected
            {
                MessageBox.Show("Please select an item to update its status.");
            }
        }
    }
}
