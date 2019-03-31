namespace Blog.Tests.Pages.PasswordPage
{
    using OpenQA.Selenium;

    public partial class PasswordPage
    {
        public IWebElement CurrentPassword => Wait.
            Until(d => { return d.FindElement(By.Id("OldPassword")); });

        public IWebElement NewPassword => Wait.
            Until(d => { return d.FindElement(By.Id("NewPassword")); });

        public IWebElement ConfirmPassword => Wait.
            Until(d => { return d.FindElement(By.Id("ConfirmPassword")); });

        public IWebElement ChangePasswordButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div/input")); });
    }
}
