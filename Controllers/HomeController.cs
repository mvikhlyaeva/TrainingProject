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
        public Cell Index()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Cell c1 = new Cell() { Id = 11, Code="qw23", Position=2 };
                db.cells.Add(c1);
                db.SaveChanges();

                var c2 = db.cells.ToList();
                Cell res = c2[1];
                return res;
            }
        }
        
        [HttpGet("TestDb1")]
        public string TestDb1()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StoreDepartment SD = new StoreDepartment { DepartmentId = 3, StoreId = 5, Scheme = SchemeType.OnlyBack };
                Stand Stand1 = new Stand { Id = 10, Size = 2, DepartmentId = 3, StoreId = 5 };
                Cell Cell1 = new Cell { Id = 222, Code = "q123", StandId = 10 };
                db.storeDepartments.AddRange(SD);
                db.stands.AddRange(Stand1);
                db.cells.Add(Cell1);
                db.SaveChanges();
                var Cell2 = db.cells.ToList();
                return ($"Id = {Cell2[0].Id}, StandId = {Cell2[0].Stand.Id}, DepartmentId = {Cell2[0].Stand.StoreDepartment.DepartmentId} ");
                
            }
        }


        [HttpGet("TestDb")]
        public string TestDb()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StoreDepartment SD = new StoreDepartment { DepartmentId = 3, StoreId = 5, Scheme = SchemeType.OnlyBack };
                Stand Stand1 = new Stand { Id = 10, Size = 2, DepartmentId = 3, StoreId = 5 };
                db.storeDepartments.AddRange(SD);
                db.stands.AddRange(Stand1);
                db.SaveChanges();
                var Stand2 = db.stands.ToList();
                return ($"Id = {Stand2[0].Id}, DepartmentId = {Stand2[0].StoreDepartment.DepartmentId}");
            }
        }
        
    }
}
