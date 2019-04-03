using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using AutoFixture;

namespace Blog.Tests
{
    public class BaseTests
    {
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:60634");
           
        }

        public Fixture Fixture => new Fixture();

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}

