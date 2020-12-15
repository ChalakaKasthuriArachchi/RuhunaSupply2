using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;
namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializeDbController : ControllerBase
    {
        ApplicationDbContext db;
        public InitializeDbController(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        public IActionResult InitializeDb()
        {
            try
            {
                if (db.Faculties.Count() + db.Departments.Count() > 0)
                    return BadRequest("Unable to Re-Initialize Table");
                #region Add Faculties
                db.Faculties.AddRange(
                    new Faculty()
                    {
                        Location = "Wellamadama Complex",
                        Name = "Faculty of Science",
                    },
                    new Faculty()
                    {
                        Location = "Wellamadama Complex",
                        Name = "Faculty of Humanities & Social Sciences"
                    });
                db.SaveChanges();
                Faculty[] faculties = db.Faculties.ToArray();
                #endregion
                #region Add Departments
                db.Departments.AddRange(
                    //Science
                    new Department()
                    {
                        FacultyId = faculties[0].Id,
                        Location = faculties[0].Location,
                        Name = "Department of Computer Science"
                    },
                    new Department()
                    {
                        FacultyId = faculties[0].Id,
                        Location = faculties[0].Location,
                        Name = "Department of Mathematics"
                    },
                    //Art
                    new Department()
                    {
                        FacultyId = faculties[1].Id,
                        Location = faculties[1].Location,
                        Name = "Department of IT"
                    }
                 );
                db.SaveChanges();
                Department[] departments = db.Departments.ToArray();
                #endregion
                #region Add Users
                #region Deans
                foreach (var fac in faculties)
                    db.Users.Add(new User()
                    {
                        FacultyId = fac.Id,
                        FullName = "Dean , " + fac.Name,
                        PermissionList = "11111111",
                        Position = UserPositions.Dean,
                        ShortName = "Dean",
                        Type = UserTypes.Internal
                    });
                #endregion
                #region Heads
                foreach (var dep in departments)
                    db.Users.Add(new User()
                    {
                        FacultyId = dep.FacultyId,
                        FullName = "Head , " + dep.Name,
                        PermissionList = "11111111",
                        Position = UserPositions.Head,
                        ShortName = "Head",
                        Type = UserTypes.Internal
                    });
                #endregion
                db.SaveChanges();
                #endregion
                return Ok("Job Done");
            }
            catch(Exception ex)
            {
                return BadRequest("Error : " + ex.Message
                    + "\nStackTrace : " + ex.StackTrace);
            }
        }
    }
}
