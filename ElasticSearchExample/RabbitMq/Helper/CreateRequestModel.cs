using ElasticSearchExample.Models;
using ElasticSearchExample.RabbitMq.Model;
using ElasticSearchExample.RabbitMq.Producer;
using System;
using System.Collections.Generic;
using Faker;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace ElasticSearchExample.RabbitMq.Helper
{
    public class CreateRequestModel
    {
        #region Single Section

        private static readonly Lazy<CreateRequestModel> _instance = new Lazy<CreateRequestModel>(() => new CreateRequestModel());

        private CreateRequestModel()
        {

        }
        public static CreateRequestModel Instance => _instance.Value;

        #endregion
        #region Methods

        Faker faker = new Faker("tr");

        public void CreateUserModel()
        {
            UserModel userModel = new UserModel()
            {
                Name = faker.Name.FirstName(),
                Surname = faker.Name.LastName(),
                Age = faker.Random.Number(18, 50).ToString()
            };
            RequestDataModel<UserModel> requestDataModel = new RequestDataModel<UserModel>()
            {
                Data = new List<UserModel>()
                {
                    userModel
                },
                Event = "Add"
            };
            RequestProducer.Instance.EnqueueData(requestDataModel, "User_Model");
        }

        public void CreateLogModel()
        {
            IndexModel indexModel = new IndexModel()
            {
                CreateDate = faker.Date.Past().ToShortDateString(),
                PublicName = faker.Person.FullName
            };
            RequestDataModel<IndexModel> requestDataModel = new RequestDataModel<IndexModel>()
            {
                Data = new List<IndexModel>()
                {
                    indexModel
                },
                Event = "Add"
            };
            RequestProducer.Instance.EnqueueData(requestDataModel, "Log_Model");
        }

        #endregion
    }
}
