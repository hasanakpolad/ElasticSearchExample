using ElasticSearchExample.ELK.Base;
using Nest;
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
        private ElasticLogger()
        {

        }

        public static ElasticLogger Instance => _instance.Value;

        #endregion

        ConnectionSettings settings = new ConnectionSettings(new Uri(""));

        public void Error(Exception ex, string message)
        {
            _log.Error(ex, message);
        }

        public void Info(string message, string serviceName)
        {
            _log.Information(message, serviceName);
        }
    }
}
