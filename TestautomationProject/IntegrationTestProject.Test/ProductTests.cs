namespace IntegrationTestProject.Test;

public class ProductTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task GetProducts_Returns_SuccessStatusCode()
    {
        // Arrange
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://fakestoreapi.com/");

        // Act
        var response = await client.GetAsync("products");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetProducts_Returns_CorrectProductData()
    {
        // Arrange
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://fakestoreapi.com/");
        var productId = 1;

        // Act
        var response = await client.GetAsync($"products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        var product = JsonSerializer.Deserialize<Product>(content, JsonOptions);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(productId, product.Id);
        Assert.Equal("Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops", product.Title);
        Assert.Equal("men's clothing", product.Category);
    }

    [Fact]
    public async Task GetProduct_Returns_ExpectedCount()
    {
        // Arrange
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://fakestoreapi.com/");

        // Act
        var response = await client.GetAsync($"products");
        var content = await response.Content.ReadAsStringAsync();
        var products = JsonSerializer.Deserialize<List<Product>>(content, JsonOptions);

        // Assert
        Assert.NotNull(products);
        Assert.Equal(20, products.Count());
    }
}
