using System;
namespace InvManager
{


    public class InventoryManager
    {
        //if we could set the size of the of InventoryItem array based on csv size (if one exists)
        //would be cool, not neccesary.
        Inventory stock = new();

        public InventoryManager()
        {
            // IDK what to have the constructor set?
        }

        // add a spesific ID lookup method
        public void LookupItem(string sku)
        {
            foreach (var entry in stock.Values)           // fixed - CF
            {
                if (entry.SKU == sku)
                {
                    Console.WriteLine($"Item found: Name: {entry.Name}, ID: {entry.ID}");
                    return;
                }
            }

            Console.WriteLine("Item not found.");
        }



        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach(KeyValuePair<int, InventoryItem> entry in stock)    // Inventroy Class needs enumorator
                {
                    writer.WriteLine(entry.Value.ToCsv());     
                }
            }

            Console.WriteLine("Inventory saved to file.");
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            stock.Clear(); // Clear existing data before loading new items

            foreach (var line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    InventoryItem item = InventoryItem.FromCsv(line);
                    stock[item.ID] = item; // Use item ID as the dictionary key
                }
            }

            Console.WriteLine("Inventory loaded from file.");
        }

        public void Modify(int ID, string? _status, string? _name,string? _sku) // Changed _sku to a string as we have it defined as a string property of InventoryItem
        {
            // given an ID, if any parameter is not null, overide that items field for corresponding parameter
        }
        
        public static bool UpdateItemQuantity(this InventoryManager manager , string sku, int newQuantity)
    {
        //Method to update the quantity of an item by sku
        InventoryItem item = manager.FindItemBySku(sku);

        if(item != null)
        {
            item.Quantity = newQuantity;
            return true;
        }
        Console.WriteLine("Item not found");
        return false;
    }
    public static bool UpdateItemQuantity(this InventoryManager manager, string sku, int newPrice)
    {
        //Method to update the price of an item by sku
        InventoryItem item = manager.FindItemBySku(sku);

        if (item != null)
        {
            item.Price = newPrice;
            return true;
        }
        Console.WriteLine("Item not found");
        return false;

    }
    public static bool UpdateItemName(this InventoryManager manager, string sku, string newName)
    {
        //Method to update the name of an item by sku
        InventoryItem item = manager.FindItemBySku(sku);

        if (item != null)
        {
            item.Name = newName;
            return true;
        }
        Console.WriteLine("Item not found");
        return false;

    }
        
    }
}
