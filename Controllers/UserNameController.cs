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
    public class UserNameController : ControllerBase
    {
        private ApplicationDbContext _db;

        public UserNameController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(string Name, string Password, Tables Table)
        {
            int max_id = 0;
            try
            {
                max_id = _db.UserNames.Max((userName) => userName.Id);
            }
            catch
            {
            }
            UserName userName = new UserName()
            {
                Id = max_id,
                Name = Name,
                Password = Password,
                Table = Table
            };
            _db.UserNames.Add(userName);
            _db.SaveChanges();
            return Ok();
        }

            [HttpPost]
            public IActionResult Edit(int Id, string Name, string Password, Tables Table)
            {
                _db.UserNames.Update(new UserName()
                {
                    Id = Id,
                    Name = Name,
                    Password = Password,
                    Table = Table
                });
                _db.SaveChanges();
                return Ok();
            }

            [HttpPost]
            public IActionResult Delete(int Id)
            {
                _db.UserNames.Remove(new UserName() { Id = Id });
                _db.SaveChanges();
                return Ok();
            }
        
    }
}
