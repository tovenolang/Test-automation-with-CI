namespace IntegrationTestProject.Test;

public class ProductTests
{
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
}