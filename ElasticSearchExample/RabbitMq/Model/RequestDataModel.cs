using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.RabbitMq.Model
{
    public class RequestDataModel<T> 
    {
        public List<T> Data { get; set; }
        public string Event { get; set; }
    }
}
