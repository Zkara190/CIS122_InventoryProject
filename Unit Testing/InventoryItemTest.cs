using Xunit;

using InvManager;

public class InventoryItemTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange & Act
        var item = new InventoryItem("Test", "123890", "In Stock");

        // Assert
        Assert.Equal("Test Item", item.Name);
        Assert.Equal("123890", item.SKU);
        Assert.Equal("In Stock", item.Status);
    }

    [Fact]
    public void ToCsv_ShouldReturnCsvRepresentation()
    {
        // Arrange
        var item = new InventoryItem("Test ", "123890", "In Stock") { ID = 1 };

        // Act
        var csv = item.ToCsv();

        // Assert
        Assert.Equal("1, Test, 123890, In Stock", csv);
    }

    [Fact]
    public void FromCsv_ShouldParseCsvAndCreateInventoryItem()
    {
        // Arrange
        var csvLine = "1, Test, 123890, In Stock";

        // Act
        var item = InventoryItem.FromCsv(csvLine);

        // Assert
        Assert.Equal(1, item.ID);
        Assert.Equal("Test", item.Name);
        Assert.Equal("123890", item.SKU);
        Assert.Equal("In Stock", item.Status);
    }

    [Fact]
    public void ReturnID_ShouldReturnIDAsString()
    {
        // Arrange
        var item = new InventoryItem("Test", "123890", "In Stock") { ID = 1 };

        // Act
        var idString = item.ReturnID();

        // Assert
        Assert.Equal("1", idString);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var item = new InventoryItem("Test Item", "123890", "In Stock") { ID = 1 };

        // Act
        var result = item.ToString();

        // Assert
        Assert.Equal("$ID: 1, Name: Test Item, SKU: 123890, Status: In Stock", result);
    }
}
