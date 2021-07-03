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
            return Ok(HttpStatusCode.OK);
        }
    }
}
