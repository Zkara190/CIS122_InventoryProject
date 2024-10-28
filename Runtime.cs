using System;
namespace InvManager;

public class Program
{
    public static void Main()
    {
        InventoryManager inventory = new InventoryManager(5);
        inventory.LoadFromFile("inventory.csv");

        //inventory.AddItem(new InventoryItem("Laptop", "SKU123", 10));
        //inventory.AddItem(new InventoryItem("Phone", "SKU456", 15));


        inventory.ListItems();
       // inventory.LookupItem("SKU123");


        //inventory.SaveToFile("inventory.csv");

        //InventoryManager loadedInventory = new InventoryManager(5);
        //loadedInventory.LoadFromFile("inventory.csv");
        //loadedInventory.ListItems();
    }
}
