using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class HealthcheckController : Controller
    {
        [HttpGet("Ind")]
        public string Index()
        {
            return "Код ответа - 300";
        }
        [HttpGet("Ind1")]
        public string Index1()
        {
            return "Код ответа - 400";
        }
    }
}
