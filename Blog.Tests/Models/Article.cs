using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Tests.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        List<Article> articles;
    }
}
