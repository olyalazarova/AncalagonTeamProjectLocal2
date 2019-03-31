namespace Blog.Tests.Pages.RegisterPage
{
    using OpenQA.Selenium;

    public partial class RegisterPage
    {
        public IWebElement Email => Wait.Until(d => {return d.FindElement(By.Id("Email"));});
        public IWebElement FullName => Wait.Until(d => {return d.FindElement(By.Id("FullName")) ;});
        public IWebElement Password => Wait.Until(d => { return d.FindElement(By.Id("Password")); });
        public IWebElement ConfirmPassword => Wait.Until(d => { return d.FindElement(By.Id("ConfirmPassword")); });
        public IWebElement RegisterButton => Wait.Until(d => { return d.FindElement(By.CssSelector("input.btn.btn-default")); });
    }
}
