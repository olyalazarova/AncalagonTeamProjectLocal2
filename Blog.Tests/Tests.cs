namespace Blog.Tests
{
    using Blog.Tests.HelperFiles;
    using Blog.Tests.Models;
    using Blog.Tests.Pages.AccountPage;
    using Blog.Tests.Pages.BlogPage;
    using Blog.Tests.Pages.CreatePage;
    using Blog.Tests.Pages.DeletePage;
    using Blog.Tests.Pages.EditPage;
    using Blog.Tests.Pages.HomePage;
    using Blog.Tests.Pages.LogInPage;
    using Blog.Tests.Pages.PasswordPage;
    using Blog.Tests.Pages.RegisterPage;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        private HomePage HomePage;
        private RegisterPage RegisterPage;
        private LogInPage LogInPage;
        private CreatePage CreatePage;
        private AccountPage AccountPage;
        private PasswordPage PasswordPage;
        private BlogPage BlogPage;
        private DeletePage DeletePage;
        private EditPage EditPage;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HomePage = new HomePage(driver);
            RegisterPage = new RegisterPage(driver);
            LogInPage = new LogInPage(driver);
            CreatePage = new CreatePage(driver);
            AccountPage = new AccountPage(driver);
            PasswordPage = new PasswordPage(driver);
            BlogPage = new BlogPage(driver);
            DeletePage = new DeletePage(driver);
            EditPage = new EditPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void LoadHomePage()
        {
            //Load home page
            HomePage.Navigate();
            Thread.Sleep(2000);

            //Assert home page is loaded 
            IWebElement name = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            IWebElement registerLink = driver.FindElement(By.CssSelector("#registerLink"));
            IWebElement loginLink = driver.FindElement(By.CssSelector("#loginLink"));

            Assert.AreEqual("SOFTUNI BLOG", name.Text);
            Assert.AreEqual("Register", registerLink.Text);
            Assert.AreEqual("Log in", loginLink.Text);

        }

        [Test]
        public void RegistrtaionFormTest()
        {
            //Read user data from json file and convert to user object
            var registerUser = FileReader.GetFileContent("RegValidUser.json", "Jsons");
            var RegisterUser = JsonConvert.DeserializeObject<RegistrationUser>(registerUser);

            //Set up Register page and fill the form with the user's data
            RegisterPage.Navigate();
            RegisterPage.FillRegistrationForm(RegisterUser);
            Thread.Sleep(2000);

            //Assert registration is successfull
            IWebElement logoffLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[3]/a"));
            Assert.AreEqual("Log off", logoffLink.Text);

        }

        [Test]
        public void SampleLogInTest()
        {
            //Read user from json file and convert to user object
            var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
            var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

            //Set up LogIn page and fill the form with the user's data
            LogInPage.Navigate();
            LogInPage.FillLogInForm(ValidRegisteredUser);
            Thread.Sleep(2000);
            IWebElement result = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[1]/a"));
            
            //Assert Create link is availabe on Header
            Assert.AreEqual("Create",result.Text);
        }

        [Test]
        public void CreateArticleTest()
        {
            //Read user from json file and convert to user object
            var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
            var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

            //Set up LogIn page and fill the form with the user's data
            LogInPage.Navigate();
            LogInPage.FillLogInForm(ValidRegisteredUser);
            Thread.Sleep(2000);

            //Create an article successfully
            CreatePage.Navigate();
            var createArticle = FileReader.GetFileContent("ArticleCreate.json", "Jsons");
            var CreateArticle = JsonConvert.DeserializeObject<Article>(createArticle);
            CreatePage.CreateArticle(CreateArticle);

            var result = driver.Url;
            Assert.AreEqual("http://localhost:60634/Article/List", result);

        }

      
        [Test]
        public void OpenArticleTestAsUnregisteredUser()
        {
            //Load home page
            HomePage.Navigate();
            Thread.Sleep(2000);

            //Open successfully an article
            BlogPage.Navigate(1);
            Assert.AreEqual("http://localhost:60634/Article/Details/1", driver.Url);
        }

        [Test]
        public void AccountPageIsOpenedTest()
        {
            //Read user from json file and convert to user object
            var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
            var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

            //Set up LogIn page and fill the form with the user's data
            LogInPage.Navigate();
            LogInPage.FillLogInForm(ValidRegisteredUser);
            Thread.Sleep(2000);

            //Open account link and assert 
            IWebElement accountLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[2]/a"));
            accountLink.Click();
            var title = driver.FindElement(By.TagName("h2")).Text;

            Assert.AreEqual("Manage", title);
        }

        [Test]
        public void ChangePasswordPageIsOpenedTest()
        {
            //Read user from json file and convert to user object
            var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
            var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

            //Set up LogIn page and fill the form with the user's data
            LogInPage.Navigate();
            LogInPage.FillLogInForm(ValidRegisteredUser);
            Thread.Sleep(2000);

            //Open Change your password link and assert 
            IWebElement accountLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[2]/a"));
            accountLink.Click();
            IWebElement changePasswordLink = driver.FindElement(By.XPath("/html/body/div[2]/div/dl/dd/a"));
            changePasswordLink.Click();

            var title = driver.FindElement(By.TagName("h2")).Text;

            Assert.AreEqual("Change Password", title);
        }

        [Test]
        public void ChangePasswordTest()
        {
            //Read user from json file and convert to user object
            var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
            var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

            //Set up LogIn page and fill the form with the user's data
            LogInPage.Navigate();
            LogInPage.FillLogInForm(ValidRegisteredUser);
            Thread.Sleep(2000);

            //Open Change your password link and fill in new one
            IWebElement accountLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[2]/a"));
            accountLink.Click();
            IWebElement changePasswordLink = driver.FindElement(By.XPath("/html/body/div[2]/div/dl/dd/a"));
            changePasswordLink.Click();

            IWebElement oldPassword = driver.FindElement(By.Id("OldPassword"));
            oldPassword.SendKeys("123456");
            IWebElement newPassword = driver.FindElement(By.Id("NewPassword"));
            newPassword.SendKeys("123456");
            IWebElement confirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
            confirmPassword.SendKeys("123456");
            IWebElement changePasswordButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div/input"));
            changePasswordButton.Click();

            Assert.AreEqual("http://localhost:60634/Manage?Message=ChangePasswordSuccess", driver.Url);
        }

        [Test]
        public void FooterTest()
        {
            //Load home page
            HomePage.Navigate();
            Thread.Sleep(2000);

            //Find footer and assert
            var footer = driver.FindElement(By.XPath("/html/body/div[2]/footer/p")).Text;

            Assert.AreEqual("© 2019 - SoftUni Blog", footer);
        }

        //[Test]
        //public void DeleteArticle()
        //{
        //    //Read user from json file and convert to user object
        //    var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
        //    var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

        //    //Set up LogIn page and fill the form with the user's data
        //    LogInPage.Navigate();
        //    LogInPage.FillLogInForm(ValidRegisteredUser);
        //    Thread.Sleep(2000);

        //    //Delete article successfully
        //    DeletePage.Navigate(9);
        //    IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
        //    deleteButton.Click();

        //    Thread.Sleep(6000);

        //    IWebElement deleteButtonSecond = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));

        //    deleteButton.Click();



        //    Assert.AreEqual("http://localhost:60634/Article/List", driver.Url);
        //}

        //[Test]
        //public void EditArticle()
        //{
        //    //Read user from json file and convert to user object
        //    var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
        //    var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);

        //    //Set up LogIn page and fill the form with the user's data
        //    LogInPage.Navigate();
        //    LogInPage.FillLogInForm(ValidRegisteredUser);
        //    Thread.Sleep(2000);

        //    //Edit article successfully
        //    DeletePage.Navigate(10);
        //    IWebElement editButton = driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
        //    editButton.Click();

        //    Thread.Sleep(6000);

        //    IWebElement editButtonSecond = driver.FindElement(By.ClassName("btn-success"));

        //    editButton.Click();

        //    Assert.AreEqual("http://localhost:60634/Article/List", driver.Url);
        //}




        //[Test]
        //public void SampleSignInTest()
        //{
        //    //Read user from json file and convert to user object
        //    var dt = DateTime.UtcNow;
        //    var email = $"johnDoe{new TimeSpan(dt.Hour, dt.Minute, dt.Second).TotalMilliseconds}@mysite.com";
        //    var validRegisteredUser = FileReader.GetFileContent("ValidRegisteredUser.json", "Jsons");
        //    var ValidRegisteredUser = JsonConvert.DeserializeObject<RegistrationUser>(validRegisteredUser);
        //    ValidRegisteredUser.Email = email;
        //    //Set up Register page and fill the form with the user's data
        //    RegisterPage.Navigate();
        //    RegisterPage.FillRegistrationForm(ValidRegisteredUser);
        //    Thread.Sleep(2000);
        //
        //    //Write Asserts...
        //}
        //

    }
}
