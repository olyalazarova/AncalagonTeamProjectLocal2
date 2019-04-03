

namespace Blog.Tests.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Configuration;

    public class Article
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        public static List<Article> ListFromJson(string json) => JsonConvert.DeserializeObject<List<Article>>(json, Convertor.Settings);

        public static Article UserFromJson(string json) => JsonConvert.DeserializeObject<Article>(json, Convertor.Settings);
    }
}
