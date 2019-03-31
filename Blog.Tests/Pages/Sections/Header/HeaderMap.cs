namespace Blog.Tests.Pages.Sections.Header
{
    using OpenQA.Selenium;

    public partial class Header
    {
        public IWebElement SoftuniblogLink => Wait.Until(d => { return d.FindElement(By.ClassName("navbar-brand")); });
        public IWebElement RegisterLink => Wait.Until(d => { return d.FindElement(By.Id("registerLink")); });
        public IWebElement LoginLink => Wait.Until(d => { return d.FindElement(By.Id("loginLink")); });

        public IWebElement CreateLink => Wait.Until(d => { return d.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a")); });
        public IWebElement AccountLink => Wait.Until(d => { return d.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[2]/a")); });
        public IWebElement LogOffLink => Wait.Until(d => { return d.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[3]/a")); });
        
    }
}
