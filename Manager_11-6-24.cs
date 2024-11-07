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
            foreach (InventoryItem entry in stock)           // inventory class don't have enumorator so this line dosnt work properly
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

            foreach (var line in File.ReadLines(filePath))
            {
                // need to change to load with dictionary data structor. not sure on how "File" works
                // if (!string.IsNullOrWhiteSpace(line))
                // {
                //     items[count++] = InventoryItem.FromCsv(line);
                // }
            }

            Console.WriteLine("Inventory loaded from file.");
        }

        public void Modify(int ID, string? _status, string? _name,int? _sku)
        {
            // given an ID, if any parameter is not null, overide that items field for corresponding parameter
        }
        
    }
}
