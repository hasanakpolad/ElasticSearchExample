using ElasticSearchExample.ELK.Base;
using ElasticSearchExample.ELK.Logger;
using ElasticSearchExample.Models;
using ElasticSearchExample.RabbitMq.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace ElasticSearchExample.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IndexController : ControllerBase
    {
        [HttpPost(nameof(Index))]
        public IActionResult Index(IndexModel model)
        {
            try
            {
                Elastic.Instance.InsertDocument(new ELK.Model.ElasticModel()
                {
                    Date = DateTime.Now.ToShortDateString(),
                    ExceptionMessage = "test",
                    Location = "suite",
                    Message = "test",
                    Service = ELK.Enums.ServicesNameEnum.SUIT,
                    WarningLevel = "Info"
                });
                RabbitMqConnection connection = new RabbitMqConnection();
                connection.Channel("");

                ElasticLogger.Instance.Info("asd","name");
                return Ok(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                ElasticLogger.Instance.Error(ex, ex.Message);
                throw;
            }
        }
    }
}
