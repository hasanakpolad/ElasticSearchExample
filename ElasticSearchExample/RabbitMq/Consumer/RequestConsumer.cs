using ElasticSearchExample.RabbitMq.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchExample.RabbitMq.Consumer
{
    public class RequestConsumer
    {
        #region Single Section

        private static readonly Lazy<RequestConsumer> _instance = new Lazy<RequestConsumer>(() => new RequestConsumer());

        private RequestConsumer()
        {

        }

        public static RequestConsumer Instance => _instance.Value;
        #endregion

        #region Property

        private RabbitMqConnection _rabbitMqConnection;

        public RabbitMqConnection RabbitMqConnection
        {
            get
            {
                if (_rabbitMqConnection == null || !_rabbitMqConnection.IsConnected)
                    _rabbitMqConnection = new RabbitMqConnection();
                return _rabbitMqConnection;
            }
        }

        #endregion

        public void StartConsume()
        {
            RabbitMqConnection.Channel("deneme");
        }

        public void StopConsume()
        {

        }
    }
}
