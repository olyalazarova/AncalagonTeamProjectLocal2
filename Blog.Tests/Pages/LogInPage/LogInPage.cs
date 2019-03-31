namespace Blog.Tests.Pages.LogInPage
{
    using Blog.Tests.Models;
    using Blog.Tests.Pages.Sections.Footer;
    using Blog.Tests.Pages.Sections.Header;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public partial class LogInPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"http://localhost:60634/Account/Login";

        public LogInPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
            Footer = new Footer(_driver);
        }

        public Header Header { get; private set; }
        public Footer Footer { get; private set; }

        public WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        public void Navigate() => _driver.Navigate().GoToUrl(_url);

        public void FillLogInForm (RegistrationUser user)
        {
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            RememberMeCheckBox.Click();
            LoginButton.Click();
        }
    }
}
