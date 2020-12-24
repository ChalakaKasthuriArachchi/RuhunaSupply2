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
    [Route("api/[Controller]")]
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
        public async Task<ActionResult<User>> PostUser(object user)
        {
            JsonData jd = JsonMapper.ToObject(user.ToString());
            User u = new User()
            {
                FacultyId = int.Parse(jd["Faculty"].ToString()),
                DepartmentId = int.Parse (jd["Department"].ToString()),
                FullName = jd["FullName"].ToString(),
                ShortName = jd["ShortName"].ToString(),
                PermissionList = jd["PermissionList"].ToString(),
                Position = (UserPositions)int.Parse(jd["Position"].ToString()),
                Type = (UserTypes)int.Parse(jd["Type"].ToString()),
                MergedId = int.Parse(jd["UserAccount"].ToString())

            };
            _db.Users.Add(u);
            await _db.SaveChangesAsync();

            return CreatedAtAction("User", new { id = u.Id }, u);
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

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //_db.Users.Remove(new User { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}