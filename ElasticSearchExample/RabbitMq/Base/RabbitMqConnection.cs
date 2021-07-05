using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchExample.RabbitMq.Base
{
    public class RabbitMqConnection
    {
        public RabbitMqConnection()
        {
            GetConnection();
        }

        public IConnection Connection { get; set; }

        public bool IsConnected { get; set; }
        public IConnection GetConnection()
        {
            if (IsConnected)
                return Connection;
            var conn = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            Connection = conn.CreateConnection();
            IsConnected = true;
           
            return Connection;
        }
        public IModel Channel(string queueName)
        {
            IModel channel = Connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);
            return channel;
        }
    }
}
