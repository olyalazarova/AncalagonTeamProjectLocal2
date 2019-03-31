namespace Blog.Tests.Pages.Sections.Footer
{
    using OpenQA.Selenium;

    public partial class Footer
    {
        public IWebElement FooterMessage => Wait.
            Until(d => {return d.FindElement(By.XPath(@"/html/body/div[2]/footer/p"));});
    }
}
