

namespace Blog.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using AutoFixture;
    using Blog.Tests.Models;
    using NUnit.Framework;

    using System.IO;
    using System.Net;
    using System.Collections;
    using Newtonsoft.Json;
    using Blog.Tests.HelperFiles;
    using Blog.Tests.Pages.HomePage;
    using System.Net.Sockets;
    using System.Linq;
    

    [TestFixture]
    public class IntegrationTests : BaseTests
    {
        static HttpClient client = new HttpClient();

        [Test]
        [Order(1)]
        public async Task GetHomePage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60634/Article/List");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseAsString.Contains("<!DOCTYPE html"));
          
        }

        [Test]
        [Order(2)]
        public async Task GetRegistrationPage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60634/Account/Register");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseAsString.Contains("Register"));
        }

        [Test]
        [Order(3)]
        public async Task GetLoginPage()
        {
            

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60634/Account/Login");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseAsString.Contains("Log in"));
        }

        [Test]
        [Order(4)]
        public async Task GetFirstArticlePage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60634/Article/Details/1");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseAsString.Contains("Hello World"));
        }

        [Test]
        [Order(5)]
        public async Task CreateUsers()
        {
                Random rnd = null;
                

                var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../Jsons/createuser.json");
                var users = RegistrationUser.ListFromJson(File.ReadAllText(path));
           

           
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:60634/Account/Register");
               
                request.Content = new StringContent(users[rnd.Next(0, 3)].ToJson(), Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

              
            
        }
    }
    }



