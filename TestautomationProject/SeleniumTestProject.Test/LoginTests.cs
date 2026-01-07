namespace SeleniumTestProject.Test;

public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private const string BaseUrl = "https://www.saucedemo.com/";

    public LoginTests()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl(BaseUrl);
    }

    [Fact]
    public void LoginWithValidCredentials_Returns_LoggedInPage()
    {
        // Arrange
        var usernameField = _driver.FindElement(By.Id("user-name"));
        var passwordField = _driver.FindElement(By.Id("password"));
        var loginButton = _driver.FindElement(By.Id("login-button"));

        usernameField.SendKeys("standard_user");
        passwordField.SendKeys("secret_sauce");

        // Act
        loginButton.Click();

        // Assert
        Assert.Contains("inventory", _driver.Url);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}