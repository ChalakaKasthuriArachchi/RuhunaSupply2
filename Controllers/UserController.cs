using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private ApplicationDbContext _db;

        public UserController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public User[] GetUsers()
        {
            return _db.Users.Where(cat => !cat.IsDeleted).ToArray();
        }
        [HttpGet("getcurrentuser")]
        public User GetUser()
        {
            return Functions.GetCurrentUser(HttpContext, _db);
        }
        [HttpPost]
        public IActionResult PostUser(object user)
        {
            try
            {
                JsonData jd = JsonMapper.ToObject(user.ToString());
                User u = new User()
                {
                    Id = Functions.GetCurrentUserAccount(HttpContext,_db).Id,
                    FacultyId = int.Parse(jd["Faculty"].ToString()),
                    DepartmentId = int.Parse(jd["Department"].ToString()),
                    FullName = jd["FullName"].ToString(),
                    ShortName = jd["ShortName"].ToString(),
                    Position = (UserPositions)int.Parse(jd["Position"].ToString()),
                };
                int temp;
                int.TryParse(jd["MergedId"].ToString(), out temp);
                u.MergedId = temp;
                _db.Users.Add(u);
                _db.SaveChanges();

                return Ok();
            }
            catch (Exception e) { return BadRequest(); }
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            //_db.Users.Remove(new User { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}