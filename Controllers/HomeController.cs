using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingProject.tables;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class HealthcheckController : Controller
    {
        [HttpGet("Ind")]
        public Cells Index()
        {
            //Cells c1 = new Cells();
            using (CellsAppContext db = new CellsAppContext())
            {
                Cells c1 = new Cells() { Id = 3, Code="qw23", Position=2 };
                db.cells.Add(c1);
                db.SaveChanges();

                var c2 = db.cells.ToList();
                Cells res = c2[0];
                return res;
            }
        }
        
        [HttpGet("Ind1")]
        public string Index1()
        {
            return "Код ответа - 400";
        }
    }
}
