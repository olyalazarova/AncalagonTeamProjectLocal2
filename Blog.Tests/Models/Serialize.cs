

namespace Blog.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public static class Serialize
    {
        public static string ToJson(this RegistrationUser self) => JsonConvert.SerializeObject(self, Convertor.Settings);

        public static string ToJson(this Article self) => JsonConvert.SerializeObject(self, Convertor.Settings);
      
    }
}
