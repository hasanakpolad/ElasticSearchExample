using ElasticSearchExample.ELK.Enums;
using ElasticSearchExample.ELK.Model;
using ElasticSearchExample.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.ELK.Base
{
    public class Elastic
    {

        #region Single Section

        private static readonly Lazy<Elastic> _instance = new Lazy<Elastic>(() => new Elastic());
        public Elastic()
        {
            elasticUri = new Uri(Environment.GetEnvironmentVariable("ELASTIC_URI"));
            projectName = Environment.GetEnvironmentVariable("PROJECT_NAME");
        }
        public static Elastic Instance = _instance.Value;

        #endregion

        private Uri elasticUri { get; set; }
        private string projectName { get; set; }
        public ElasticClient Connect(ConnectionSettings settings)
        {
            return new ElasticClient(settings);
        }
        public ConnectionSettings Settings(ServicesNameEnum enums)
        {
            var indexName = string.Format($"{projectName}-{enums.ToString().ToLower()}-{DateTime.Now.ToShortDateString()}");
            return new ConnectionSettings(elasticUri).DefaultIndex(indexName);
        }
        public void InsertDocument(ElasticModel model)
        {
            var settings = Settings(model.Service);

            var client = Connect(settings);

            client.IndexDocument(model);
        }
    }
}
