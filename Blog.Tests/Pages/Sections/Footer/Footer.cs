namespace Blog.Tests.Pages.Sections.Footer
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public partial class Footer
    {
        private readonly IWebDriver _driver;

        public Footer(IWebDriver driver)
        {
            _driver = driver;
        }

        public WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
}
