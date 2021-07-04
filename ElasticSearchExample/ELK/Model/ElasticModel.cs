using ElasticSearchExample.ELK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.ELK.Model
{
    public class ElasticModel
    {
        public ServicesNameEnum Service { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string ExceptionMessage { get; set; }
        public string WarningLevel { get; set; }
    }
}
