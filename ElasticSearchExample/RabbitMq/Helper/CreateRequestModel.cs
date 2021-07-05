using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void CreateUserModel()
        {

        }

        public void CreateLogModel()
        {

        }

        #endregion
    }
}
