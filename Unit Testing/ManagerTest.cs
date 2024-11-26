using Xunit;
using System.Collections.Generic;
using System.IO;
using InvManager;

public class InventoryManagerTests
{
    [Fact]
    public void AddItemToInventory_ShouldAddItem()
    {
        var item = new InventoryItem("Item1", "SKU1", "In Stock") { ID = 1 };

        
        InventoryManager.AddItemToInventory(item);

       
        var allItems = InventoryManager.GetAllInventoryItems();
        Assert.Contains(allItems, i => i.SKU == "SKU1" && i.Name == "Item1");
    }

    [Fact]
    public void LookupItem_ShouldFindItemBySku()
    {

        var item = new InventoryItem("Item2", "SKU2", "In Stock") { ID = 2 };
        InventoryManager.AddItemToInventory(item);

   
        using var output = new StringWriter();
        Console.SetOut(output);

 
        InventoryManager.LookupItem("SKU2");


        Assert.Contains("Item found", output.ToString());
    }

    [Fact]
    public void LookupItem_ShouldHandleItemNotFound()
    {
        using var output = new StringWriter();
        Console.SetOut(output);

   
        InventoryManager.LookupItem("NonExistentSKU");

    
        Assert.Contains("Item not found", output.ToString());
    }

    [Fact]
    public void UpdateItemStatus_ShouldChangeItemStatus()
    {
 
        var item = new InventoryItem("Item3", "SKU3", "In Stock") { ID = 3 };
        InventoryManager.AddItemToInventory(item);


        InventoryManager.UpdateItemStatus("SKU3", "Out of Stock");

    
        var updatedItem = InventoryManager.GetAllInventoryItems().Find(i => i.SKU == "SKU3");
        Assert.NotNull(updatedItem);
        Assert.Equal("Out of Stock", updatedItem.Status);
    }

    [Fact]
    public void SaveToFileAndLoadFromFile_ShouldPersistInventory()
    {
    
        var tempFile = Path.GetTempFileName();
        var item = new InventoryItem("Item4", "SKU4", "In Stock") { ID = 4 };
        InventoryManager.AddItemToInventory(item);

        InventoryManager.SaveToFile(tempFile);
        InventoryManager.LoadFromFile(tempFile);

      
        var loadedItems = InventoryManager.GetAllInventoryItems();
        Assert.Contains(loadedItems, i => i.SKU == "SKU4");

     
        File.Delete(tempFile);
    }

    [Fact]
    public void UpdateItemName_ShouldUpdateNameCorrectly()
    {
        var item = new InventoryItem("Old Name", "SKU5", "In Stock") { ID = 5 };
        InventoryManager.AddItemToInventory(item);

        InventoryManager.UpdateItemName("SKU5", "New Name");

        var updatedItem = InventoryManager.GetAllInventoryItems().Find(i => i.SKU == "SKU5");
        Assert.NotNull(updatedItem);
        Assert.Equal("New Name", updatedItem.Name);
    }
}
