using ElasticSearchExample.ELK.Base;
using ElasticSearchExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElasticSearchExample.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IndexController : ControllerBase
    {
        [HttpPost(nameof(Index))]
        public IActionResult Index(IndexModel model)
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
            return Ok(HttpStatusCode.OK);
        }
    }
}
