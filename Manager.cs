using System;
namespace InvManager;


public class InventoryManager
{
    private InventoryItem[] items;
    private int count;

    public InventoryManager(int capacity)
    {
        items = new InventoryItem[capacity];
        count = 0;
    }

    public bool AddItem(InventoryItem item)
    {
        if (count >= items.Length)
        {
            Console.WriteLine("Inventory is full, cannot add more items.");
            return false;
        }

        items[count++] = item;
        Console.WriteLine("Item added successfully.");
        return true;
    }

    public bool RemoveItem(string sku)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].SKU == sku)
            {
                items[i] = items[--count];
                items[count] = null;
                Console.WriteLine("Item removed successfully.");
                return true;
            }
        }

        Console.WriteLine("Item not found.");
        return false;
    }

    public void ListItems()
    {
        Console.WriteLine("Current Inventory:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }

    public void LookupItem(string sku)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].SKU == sku)
            {
                Console.WriteLine($"Item found: Name: {items[i].Name}, Quantity: {items[i].Quantity}");
                return;
            }
        }

        Console.WriteLine("Item not found.");
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(items[i].ToCsv());
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

        count = 0;
        foreach (var line in File.ReadLines(filePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                items[count++] = InventoryItem.FromCsv(line);
            }
        }

        Console.WriteLine("Inventory loaded from file.");
    }
}

