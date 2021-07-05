using ElasticSearchExample.RabbitMq.Base;
using ElasticSearchExample.RabbitMq.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchExample.RabbitMq.Producer
{
    public class RequestProducer
    {
        private static readonly Lazy<RequestProducer> _instance = new Lazy<RequestProducer>(() => new RequestProducer());

        public RequestProducer()
        {

        }

        public static RequestProducer Instance => _instance.Value;

        private RabbitMqConnection _rabbitMqConnection;

        private RabbitMqConnection RabbitMqConnection
        {
            get
            {
                if (_rabbitMqConnection == null || !_rabbitMqConnection.IsConnected)
                    _rabbitMqConnection = new RabbitMqConnection();
                return _rabbitMqConnection;
            }
        }

        public void RabbitMqProducer<T>(string queueName, T model) where T : class
        {
            using (var _model = RabbitMqConnection.Channel(queueName))
            {
                var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
                _model.BasicPublish(exchange: "",
                    routingKey: queueName,
                    mandatory: false,
                    basicProperties: null,
                    body: message);
            }
        }

        public void EnqueueData<T>(RequestDataModel<T> model, string queueName) where T : class
        {
            RabbitMqProducer(queueName, model);
        }
    }
}
