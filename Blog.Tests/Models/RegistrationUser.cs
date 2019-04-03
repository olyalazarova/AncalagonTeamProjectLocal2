using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Configuration;

namespace Blog.Tests.Models
{
    public class RegistrationUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmpassword")]
        public string ConfirmPassword { get; set; }

        public static RegistrationUser UserFromJson(string json) => JsonConvert.DeserializeObject<RegistrationUser>(json, Convertor.Settings);

        public static List<RegistrationUser> ListFromJson(string json) => JsonConvert.DeserializeObject<List<RegistrationUser>>(json, Convertor.Settings);
    }
}
