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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                StoreDepartment SD = new StoreDepartment { DepartmentId = 10, StoreId = 15, Scheme = SchemeType.OnlyBack };
                Stand Stand1 = new Stand { Id = 20, Size = 2, DepartmentId = 10, StoreId = 15 };
                Cell Cell1 = new Cell { Id = 888, Code = "q123", StandId = 20 };
                db.storeDepartments.AddRange(SD);
                db.stands.AddRange(Stand1);
                db.cells.Add(Cell1);
                db.SaveChanges();
                var Cell2 = db.cells.ToList();
                int len = Cell2.Count-1;
                return ($"Id = {Cell2[len]?.Id}, StandId = {Cell2[len]?.Stand.Id}, DepartmentId = {Cell2[len]?.Stand?.StoreDepartment?.DepartmentId} ");
                
            }
        }


        [HttpGet("TestDb")]
        public string TestDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                StoreDepartment SD = new StoreDepartment { DepartmentId = 7, StoreId = 8, Scheme = SchemeType.OnlyBack };
                Stand Stand1 = new Stand { Id = 15, Size = 2, DepartmentId = 7, StoreId = 8 };
                db.storeDepartments.AddRange(SD);
                db.stands.AddRange(Stand1);
                db.SaveChanges();
                var Stand2 = db.stands.ToList();
                int len = Stand2.Count-1;
                return ($"Id = {Stand2[len].Id}, DepartmentId = {Stand2[len].StoreDepartment.DepartmentId}");
            }
        }
        
    }
}
