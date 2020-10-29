using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class UserAccountController : Controller
    {
        private ApplicationDbContext _db;

        public UserAccountController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(string Name, string HashedPassword, string Privileges, string Password)
        {
            int max_id = 0;
            try
            {
                max_id = _db.UserAccounts.Max((userAccount) => userAccount.Id);
            }
            catch
            {
            }
            UserAccount userAccount = new UserAccount()
            {
                Id = max_id,
                Name = Name,
                HashedPassword = HashedPassword,
                Privileges = Privileges,
                Password = Password
            };
            _db.UserAccounts.Add(userAccount);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string HashedPassword, string Privileges, string Password)
        {
            _db.UserAccounts.Update(new UserAccount()
            {
                Id = Id,
                Name = Name,
                HashedPassword = HashedPassword,
                Privileges = Privileges,
                Password = Password
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.UserAccounts.Remove(new UserAccount() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}
