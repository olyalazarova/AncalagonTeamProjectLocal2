namespace Blog.Tests.Pages.DeletePage
{
    using OpenQA.Selenium;

    public partial class DeletePage
    {
        public IWebElement CancelButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a")); });

        public IWebElement DeleteButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")); });

    }
}
