using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db;

        public UserController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add(string Admin, string Branch, string FullName, string ShortName, string PermissionList, UserPositions Position, UserTypes Type, int MergedId)
        {
            int max_id = 0;

            try
            {
                max_id = _db.Users.Max((user) => user.Id);
            }
            catch
            {


            }

            User user = new User()
            {
                //Id = max_id + 1,
                //Admin = Admin,
                //Branch = Branch,
                //FullName = FullName,
                //ShortName = ShortName,
                //PermissionList = PermissionList,
                //Position = Position,
                //Type = Type,
                //MergedId = MergedId
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
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
            _db.Users.Remove(new User { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}