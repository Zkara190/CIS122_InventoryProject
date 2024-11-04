public static class InventoryManager
{
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