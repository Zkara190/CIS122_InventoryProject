using System;
namespace InvManager
{


    public static class InventoryManager
    {
        static Inventory stock = new();

        // add a spesific ID lookup method
        static public void LookupItem(string sku)
        {
            foreach (var entry in stock.inventory.Values)           // fixed - CF
            {
                if (entry.SKU == sku)
                {
                    Console.WriteLine($"Item found: Name: {entry.Name}, ID: {entry.ID}");
                    return;
                }
            }

            Console.WriteLine("Item not found.");
        }

        public static List<InventoryItem> GetAllInventoryItems()
        {
            return new List<InventoryItem>(stock.inventory.Values);
        }

        public static void UpdateItemStatus(string sku, string newStatus)
        {
            foreach (var entry in stock.inventory.Values)
            {
                if (entry.SKU == sku)
                {
                    entry.Status = newStatus;
                    Console.WriteLine($"Status for item with SKU {sku} updated to: {newStatus}");
                    return;
                }
            }

            Console.WriteLine("Item not found.");
        }

        static public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<int, InventoryItem> entry in stock.inventory)
                {
                    writer.WriteLine(entry.Value.ToCsv());
                }
            }

            Console.WriteLine("Inventory saved to file.");
        }

        static public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            // stock.Clear(); // Clear existing data before loading new items // commenting out becuase stic

            foreach (var line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    InventoryItem item = InventoryItem.FromCsv(line);
                    stock.inventory[item.ID] = item; // Use item ID as the dictionary key
                }
            }

            Console.WriteLine("Inventory loaded from file.");
        }

        public static void UpdateItemName(string sku, string newName)
        {
            //Method to update the name of an item by sku

            foreach (var entry in stock.inventory.Values)           // fixed - CF
            {
                if (entry.SKU == sku)
                {
                    entry.Name = newName;
                }
            }
        }

        public static void AddItemToInventory(InventoryItem item)
        {
            stock.AddToInventory(item);
        }


        //commenting out the following block as it's calling undefined methods not in the files

        //    public static bool updateitemquantity(this inventorymanager manager , string sku, int newquantity)
        //{
        //    //method to update the quantity of an item by sku
        //    inventoryitem item = manager.finditembysku(sku);

        //    if(item != null)
        //    {
        //        item.quantity = newquantity;
        //        return true;
        //    }
        //    console.writeline("item not found");
        //    return false;
        //}
        //public static bool updateitemquantity(this inventorymanager manager, string sku, int newprice)
        //{
        //    //method to update the price of an item by sku
        //    inventoryitem item = manager.finditembysku(sku);

        //    if (item != null)
        //    {
        //        item.price = newprice;
        //        return true;
        //    }
        //    console.writeline("item not found");
        //    return false;
        //}

    }
}


