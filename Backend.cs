﻿using System;
using System.IO;
namespace InvManager;

public class InventoryItem
{
    // add item ID (int), and Status (string)
    // Protected instead of public?
    public int ID { get; set; } // Unique Item ID
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
        return $"$"ID: {ID}, Name: {Name}, SKU: {SKU}, Quantity: {Quantity}";
    }

    public string ToCsv()
    {
        return $"{ID}, {Name}, {SKU}, {Quantity}";
    }

    public string ReturnID()
    {
        return $"{ID}";
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

    //what is this doing?
    public static InventoryItem FromCsv(string csvLine)
    {
        var values = csvLine.Split(',');
        return new InventoryItem(values[0], values[1], int.Parse(values[2]));
    }
}
