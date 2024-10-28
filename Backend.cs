using System;
using System.IO;
namespace InvManager;

public class InventoryItem
{
    public string Name { get; set; }
    public string SKU { get; set; }
    public int Quantity { get; set; }

    public InventoryItem(string name, string sku, int quantity)
    {
        Name = name;
        SKU = sku;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Name: {Name}, SKU: {SKU}, Quantity: {Quantity}";
    }

    public string ToCsv()
    {
        return $"{Name},{SKU},{Quantity}";
    }

    public string ReturnName()
    {
        return $"{Name}";
    }

    public string ReturnSKU()
    {
        return $"{SKU}";
    }

    public string ReturnQuantity()
    {
        return $"{Quantity}";
    }

    public static InventoryItem FromCsv(string csvLine)
    {
        var values = csvLine.Split(',');
        return new InventoryItem(values[0], values[1], int.Parse(values[2]));
    }
}
