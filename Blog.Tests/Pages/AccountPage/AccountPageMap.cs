namespace Blog.Tests.Pages.AccountPage
{
    using OpenQA.Selenium;

    public partial class AccountPage
    {
        public IWebElement ChangePasswordLink => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/dl/dd/a")); });
    }
}
