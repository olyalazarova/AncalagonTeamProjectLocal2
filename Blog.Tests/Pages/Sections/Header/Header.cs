namespace Blog.Tests.Pages.Sections.Header
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public partial class Header
    {
        private readonly IWebDriver _driver;

        public Header(IWebDriver driver)
        {
            _driver = driver;
        }

        public WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
}
