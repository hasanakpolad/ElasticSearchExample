using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.Models
{
    public class IndexModel
    {
        [JsonProperty("publicName")]
        public string PublicName { get; set; }
        [JsonProperty("createDate")]
        public string CreateDate { get; set; }
    }
}
