using ElasticSearchExample.ELK.Logger;
using ElasticSearchExample.Models;
using ElasticSearchExample.RabbitMq.Base;
using ElasticSearchExample.RabbitMq.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private IModel _userModel;
        private IModel _logModel;

        public void StartConsume()
        {
            _userModel = RabbitMqConnection.Channel("User_Model");
        }

        private void SaveRequestOnReceived<T>(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var data = GetData(typeof(T).Name, e);

                ElasticLogger.Instance.Info(data.Data, typeof(T).Name);
                BasicAck(typeof(T).Name, e);
            }
            catch (Exception ex)
            {
                BasicNack(typeof(T).Name, e);
                ElasticLogger.Instance.Error(ex, ex.Message);
            }
        }

        private void BasicAck(string type, BasicDeliverEventArgs e)
        {
            switch (type)
            {
                case "UserModel":
                    _userModel.BasicAck(e.DeliveryTag, false);
                    break;
                case "IndexModel":
                    _logModel.BasicAck(e.DeliveryTag, false);
                    break;
            }

        }

        private void BasicNack(string type, BasicDeliverEventArgs e)
        {
            switch (type)
            {
                case "UserModel":
                    _userModel.BasicNack(e.DeliveryTag, false, true);
                    break;
                case "IndexModel":
                    _logModel.BasicNack(e.DeliveryTag, false, true);
                    break;
            }
        }

        private RequestModel GetData(string type, BasicDeliverEventArgs e)
        {
            var requestData = string.Empty;
            var body = e.Body.ToArray();
            switch (type)
            {
                case "UserModel":
                    RequestDataModel<UserModel> user = JsonConvert.DeserializeObject<RequestDataModel<UserModel>>(Encoding.UTF8.GetString(body));
                    requestData = JsonConvert.SerializeObject(user.Data);
                    break;
                case "IndexModel":
                    RequestDataModel<IndexModel> index = JsonConvert.DeserializeObject<RequestDataModel<IndexModel>>(Encoding.UTF8.GetString(body));
                    requestData = JsonConvert.SerializeObject(index.Data);
                    break;
            }
            RequestModel model = new RequestModel()
            {
                Data = requestData
            };
            return model;
        }
        public void StopConsume()
        {

        }
    }
}
