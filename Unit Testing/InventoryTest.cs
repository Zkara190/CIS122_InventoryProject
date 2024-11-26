using Xunit;
using InvManager;

public class InventoryTests
{
    [Fact]
    public void AddToInventory_ShouldAddItem()
    {
        
        var inventory = new Inventory();
        var item = new InventoryItem("Item1", "SKU1", "In Stock");

        inventory.AddToInventory(item);

        Assert.Equal(1, inventory.inventory.Count);
        Assert.Equal("SKU1", inventory.GetItem(1).SKU);
    }

    [Fact]
    public void AddToInventory_BulkAdd_ShouldAddMultipleItems()
    {
      
        var inventory = new Inventory();
        var item = new InventoryItem("Item1", "SKU1", "In Stock");

        inventory.AddToInventory(item, 3);

        Assert.Equal(3, inventory.inventory.Count);
        Assert.Equal(1, inventory.GetItem(1).ID);
        Assert.Equal(2, inventory.GetItem(2).ID);
        Assert.Equal(3, inventory.GetItem(3).ID);
    }

    [Fact]
    public void RemoveFromInventory_ById_ShouldRemoveCorrectItem()
    {
        
        var inventory = new Inventory();
        var item = new InventoryItem("Item1", "SKU1", "In Stock");
        inventory.AddToInventory(item);

        inventory.RemoveFromInventory(1);

        Assert.Null(inventory.GetItem(1));
    }

    [Fact]
    public void RemoveFromInventory_BySku_ShouldRemoveAllMatchingItems()
    {
    
        var inventory = new Inventory();
        inventory.AddToInventory(new InventoryItem("Item1", "SKU1", "In Stock"));
        inventory.AddToInventory(new InventoryItem("Item2", "SKU1", "In Stock"));

        inventory.RemoveFromInventory("SKU1");

        Assert.Empty(inventory.inventory);
    }

    [Fact]
    public void GetList_ShouldReturnAllItems()
    {
        var inventory = new Inventory();
        inventory.AddToInventory(new InventoryItem("Item1", "SKU1", "In Stock"));
        inventory.AddToInventory(new InventoryItem("Item2", "SKU2", "In Stock"));

        var list = inventory.GetList();


        Assert.Equal(2, list.Length);
        Assert.Equal("SKU1", list[0].SKU);
        Assert.Equal("SKU2", list[1].SKU);
    }
}
