namespace Blog.Tests.Pages.EditPage
{
    using OpenQA.Selenium;

    public partial class EditPage
    {
        public IWebElement Title => Wait.
            Until(d => { return d.FindElement(By.Id("Title")); });

        public IWebElement Content => Wait.
            Until(d => { return d.FindElement(By.Id("Content")); });

        public IWebElement CancelButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a")); });

        public IWebElement EditButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")); });
    }
}
