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
        [HttpGet("api/[Controller]/positionlist")]
        public string[] GetPositionList()
        {
            return Enum.GetNames(typeof(MyEnum.UserPositions));
        }
        [HttpPost]
        public IActionResult PostUser(object user)
        {
            try
            {
                Functions.GetCurrentUserId(HttpContext, _db);
                JsonData jd = JsonMapper.ToObject(user.ToString());
                User u = new User()
                {
                    Id = Functions.GetCurrentUserId(HttpContext, _db),
                    FacultyId = int.Parse(jd["Faculty"].ToString()),
                    DepartmentId = int.Parse(jd["Department"].ToString()),
                    FullName = jd["FullName"].ToString(),
                    ShortName = jd["ShortName"].ToString(),
                    Position = (UserPositions)int.Parse(jd["Position"].ToString()),
                    MergedId = int.Parse(jd["MergedId"].ToString())

                };
                _db.Users.Add(u);
                _db.SaveChanges();

                return Ok();
            }
            catch(Exception e) { return BadRequest(); }
        }
            
            

        [HttpPut]
        public IActionResult Edit(int Id, string Admin, string Branch, string FullName, string ShortName, string PermissionList, UserPositions Position, UserTypes Type, int MergedId)
        {
            _db.Users.Update(new User()
            {
                //Id = Id,
                //Admin = Admin,
                //Branch = Branch,
                //FullName = FullName,
                //ShortName = ShortName,
                //PermissionList = PermissionList,
                //Position = Position,
                //Type = Type,
                //MergedId = MergedId
            });
            _db.SaveChanges();
            return Ok();
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