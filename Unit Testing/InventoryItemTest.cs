using Xunit;

using InvManager;

public class InventoryItemTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        var item = new InventoryItem("Test", "123890", "In Stock");

        Assert.Equal("Test Item", item.Name);
        Assert.Equal("123890", item.SKU);
        Assert.Equal("In Stock", item.Status);
    }

    [Fact]
    public void ToCsv_ShouldReturnCsvRepresentation()
    {
        var item = new InventoryItem("Test ", "123890", "In Stock") { ID = 1 };


        var csv = item.ToCsv();

       
        Assert.Equal("1, Test, 123890, In Stock", csv);
    }

    [Fact]
    public void FromCsv_ShouldParseCsvAndCreateInventoryItem()
    {
      
        var csvLine = "1, Test, 123890, In Stock";

   
        var item = InventoryItem.FromCsv(csvLine);

     
        Assert.Equal(1, item.ID);
        Assert.Equal("Test", item.Name);
        Assert.Equal("123890", item.SKU);
        Assert.Equal("In Stock", item.Status);
    }

    [Fact]
    public void ReturnID_ShouldReturnIDAsString()
    {
      
        var item = new InventoryItem("Test", "123890", "In Stock") { ID = 1 };

  
        var idString = item.ReturnID();

      
        Assert.Equal("1", idString);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
      
        var item = new InventoryItem("Test Item", "123890", "In Stock") { ID = 1 };

    
        var result = item.ToString();

     
        Assert.Equal("$ID: 1, Name: Test Item, SKU: 123890, Status: In Stock", result);
    }
}
