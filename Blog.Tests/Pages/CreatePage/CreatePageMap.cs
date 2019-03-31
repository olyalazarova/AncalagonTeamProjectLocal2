namespace Blog.Tests.Pages.CreatePage
{
    using OpenQA.Selenium;

    public partial class CreatePage
    {
        public IWebElement Title => Wait.
            Until(d => { return d.FindElement(By.Id("Title")); });

        public IWebElement Content => Wait.
            Until(d => { return d.FindElement(By.Id("Content")); });

        public IWebElement CancelButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a")); });

        public IWebElement CreateButton => Wait.
            Until(d => { return d.FindElement(By.CssSelector("input.btn.btn-success")); });
    }
}
