using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.Models
{
    public class UserModel
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Surname { get; set; }
        [JsonProperty]
        public string Age { get; set; }
    }
}
