using ElasticSearchExample.ELK.Base;
using Nest;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.ELK.Logger
{
    public class ElasticLogger
    {
        private static Serilog.Core.Logger _log;
        #region Single Section

        private static readonly Lazy<ElasticLogger> _instance = new Lazy<ElasticLogger>(() => new ElasticLogger());
        ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"));
        private ElasticLogger()
        {
            Configure();
        }

        public static ElasticLogger Instance => _instance.Value;

        #endregion


        public void Error(Exception ex, string message)
        {
            _log.Error(ex, message);
        }

        public void Info(string message, string serviceName)
        {
            _log.Information(message, serviceName);
        }

        private void Configure ()
        {
            var loggerConfiguration = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Elasticsearch(
                   new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                   {
                       AutoRegisterTemplate = true,
                       AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                       TemplateName = "serilog-events-template",
                       IndexFormat = "serilog-{0:yyyy.MM.dd}"
                   });
            _log = loggerConfiguration.CreateLogger();
        }
    }
}
