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

    [Fact]
    public void LoginWithInvalidUsername_Returns_ErrorMessage()
    {
        // Arrange
        var usernameField = _driver.FindElement(By.Id("user-name"));
        var passwordField = _driver.FindElement(By.Id("password"));
        var loginButton = _driver.FindElement(By.Id("login-button"));

        usernameField.SendKeys("invalid_username");
        passwordField.SendKeys("secret_sauce");

        // Act
        loginButton.Click();

        //Assert
        var errorMessage = _driver.FindElement(By.ClassName("error-message-container")).Text;
        Assert.Contains("Epic sadface", errorMessage);
    }

    [Fact]
    public void LoginWithInvalidPassword_Returns_ErrorMessage()
    {
        // Arrange
        var usernameField = _driver.FindElement(By.Id("user-name"));
        var passwordField = _driver.FindElement(By.Id("password"));
        var loginButton = _driver.FindElement(By.Id("login-button"));

        usernameField.SendKeys("standard_user");
        passwordField.SendKeys("invalid_password");

        // Act
        loginButton.Click();

        //Assert
        var errorMessage = _driver.FindElement(By.ClassName("error-message-container")).Text;
        Assert.Contains("Epic sadface", errorMessage);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}