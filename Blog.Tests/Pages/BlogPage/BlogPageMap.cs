namespace Blog.Tests.Pages.BlogPage
{
    using OpenQA.Selenium;

    public partial class BlogPage
    {
        public IWebElement ArticleTitle => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/header/h2")); });

        public IWebElement ArticleContent => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/p")); });

        public IWebElement ArticleAuthor => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/small")); });

        public IWebElement EditButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]")); });

        public IWebElement DeleteButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]")); });

        public IWebElement BackButton => Wait.
            Until(d => { return d.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[3]")); });
    }
}
