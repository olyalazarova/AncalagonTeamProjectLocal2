namespace Blog.Tests.Pages.LogInPage
{
    using OpenQA.Selenium;

    public partial class LogInPage
    {
        public IWebElement Email => Wait.Until(d => { return d.FindElement(By.Id("Email")); });
        public IWebElement Password => Wait.Until(d => { return d.FindElement(By.Id("Password")); });
        public IWebElement RememberMeCheckBox => Wait.Until(d => { return d.FindElement(By.Id("RememberMe")); });
        public IWebElement LoginButton => Wait.Until(d => { return d.FindElement(By.CssSelector("input.btn.btn-default")); });
    }
}
