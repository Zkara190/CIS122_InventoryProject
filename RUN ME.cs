using System;
using InvManager;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=== Inventory Management System: Console Edition ===");
            Console.WriteLine("1. Add Item to Inventory");
            Console.WriteLine("2. Lookup Item by SKU");
            Console.WriteLine("3. Update Item Name by SKU");
            Console.WriteLine("4. Update Item Status by SKU"); 
            Console.WriteLine("5. Save Inventory to File");
            Console.WriteLine("6. Load Inventory from File");
            Console.WriteLine("7. List All Inventory Items");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option (1-8): ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                AddItem();
            }
            else if (input == "2")
            {
                LookupItem();
            }
            else if (input == "3")
            {
                UpdateItemName();
            }
            else if (input == "4")
            {
                UpdateItemStatus(); 
            }
            else if (input == "5")
            {
                SaveInventory();
            }
            else if (input == "6")
            {
                LoadInventory();
            }
            else if (input == "7")
            {
                ListAllItems();
            }
            else if (input == "8")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

            Console.WriteLine();
        }
    }

    static void AddItem()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();
        Console.Write("Enter item SKU: ");
        string sku = Console.ReadLine();
        Console.Write("Enter item status (i.e In Transit, In Inventory, etc): ");
        string status = Console.ReadLine();

        InventoryItem item = new InventoryItem(name, sku, status);
        InventoryManager.AddItemToInventory(item);
        Console.WriteLine("Item added successfully.");
    }

    static void LookupItem()
    {
        Console.Write("Enter item SKU to lookup: ");
        string sku = Console.ReadLine();
        InventoryManager.LookupItem(sku);
    }

    static void UpdateItemName()
    {
        Console.Write("Enter item SKU to update: ");
        string sku = Console.ReadLine();
        Console.Write("Enter new name for the item: ");
        string newName = Console.ReadLine();

        InventoryManager.UpdateItemName(sku, newName);
        Console.WriteLine("Item name updated successfully.");
    }

    static void UpdateItemStatus()
    {
        Console.Write("Enter item SKU to update: ");
        string sku = Console.ReadLine();
        Console.Write("Enter new status for the item: ");
        string newStatus = Console.ReadLine();

        InventoryManager.UpdateItemStatus(sku, newStatus); // calls to new method in invmanager
        Console.WriteLine("Item status updated successfully.");
    }

    static void SaveInventory()
    {
        Console.Write("Enter file path to save inventory: ");
        string filePath = Console.ReadLine();
        InventoryManager.SaveToFile(filePath);
    }

    static void LoadInventory()
    {
        Console.Write("Enter file path to load inventory: ");
        string filePath = Console.ReadLine();
        InventoryManager.LoadFromFile(filePath);
    }

    static void ListAllItems()
    {
        Console.WriteLine("=== Inventory Items ===");
        var items = InventoryManager.GetAllInventoryItems();
        if (items.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, SKU: {item.SKU}, Status: {item.Status}");
            }
        }
    }
}
