using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using RuhunaSupply.Common;
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
                        Name = Faculties.Faculty_Of_Science.ToString().Replace("_"," "),
                    },
                    new Faculty()
                    {
                        Location = "Wellamadama Complex",
                        Name = Faculties.Faculty_Of_Humanities_and_Social_Sciences.ToString().Replace("_", " ")
                    },
                    new Faculty()
                    {
                        Location = "Wellamadama Complex",
                        Name = Faculties.Admin.ToString().Replace("_", " ")
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
                        Name = DepartmentsSC.Department_Of_Computer_Science.ToString().Replace("_", " ")
                    },
                    new Department()
                    {
                        FacultyId = faculties[0].Id,
                        Location = faculties[0].Location,
                        Name = DepartmentsSC.Department_Of_Mathematics.ToString().Replace("_", " ")
                    },
                    //Art
                    new Department()
                    {
                        FacultyId = faculties[1].Id,
                        Location = faculties[1].Location,
                        Name = DepartmentsHSS.Department_Of_IT.ToString().Replace("_", " ")
                    },
                    //Admin
                    new Department()
                    {
                        FacultyId = faculties[2].Id,
                        Location = faculties[1].Location,
                        Name = DepartmentsAdmin.Supply_Branch.ToString().Replace("_", " ")
                    }
                 );
                db.SaveChanges();
                Department[] departments = db.Departments.ToArray();
                #endregion
                #region Add Users
                #region Deans
                int uId = UserAccount.GetNextId(db);
                foreach (var fac in faculties)
                {
                    if (fac.Name == Faculties.Admin.ToString())
                    {
                        db.Users.Add(new User()
                        {
                            Id = uId++,
                            FacultyId = fac.Id,
                            FullName = "Vice Chancellor",
                            PermissionList = "11111111",
                            Position = UserPositions.VC,
                            ShortName = "VC",
                            Type = UserTypes.Internal
                        });
                    }
                    else
                    {
                        db.Users.Add(new User()
                        {
                            Id = uId++,
                            FacultyId = fac.Id,
                            FullName = "Dean , " + fac.Name,
                            PermissionList = "11111111",
                            Position = UserPositions.Dean,
                            ShortName = "Dean",
                            Type = UserTypes.Internal
                        });
                    }
                }
                #endregion
                #region Heads
                foreach (var dep in departments)
                {
                    if (dep.Name == "Supply Branch")
                    {
                        db.Users.Add(new User()
                        {
                            Id = uId++,
                            FacultyId = dep.FacultyId,
                            DepartmentId = dep.Id,
                            FullName = "Senior Assistant Bursar , " + dep.Name,
                            PermissionList = "11111111",
                            Position = UserPositions.SAB,
                            ShortName = "SAB",
                            Type = UserTypes.Internal
                        });
                    }
                    else
                    {
                        db.Users.Add(new User()
                        {
                            Id = uId++,
                            FacultyId = dep.FacultyId,
                            DepartmentId = dep.Id,
                            FullName = "Head , " + dep.Name,
                            PermissionList = "11111111",
                            Position = UserPositions.Head,
                            ShortName = "Head",
                            Type = UserTypes.Internal
                        });
                    }
                }
                #endregion
                #region VC
                
                #endregion
                using(IDbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SaveChanges();
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
                
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
