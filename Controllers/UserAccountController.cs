using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : Controller
    {
        private ApplicationDbContext _db;

        public UserAccountController(ApplicationDbContext context)
        {
            this._db = context;
        }

        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(object useraccount)
        {
            JsonData jd = JsonMapper.ToObject(useraccount.ToString());

            UserAccount ua = new UserAccount()
            {
                FullName = jd["FullName"].ToString(),
                ShortName = jd["ShortName"].ToString(),
                Email = jd["Email"].ToString(),
                HashedPassword = jd["HashedPassword"].ToString(),
                Type = (UserTypes)int.Parse(jd["Type"].ToString())
            };
            _db.UserAccounts.Add(ua);
            await _db.SaveChangesAsync();
            return CreatedAtAction("UseAccount",new { id = ua.Id},ua);
        }

        [HttpPut]
        public IActionResult Edit(int Id, string Name, string HashedPassword, string Privileges, string Password)
        {
            _db.UserAccounts.Update(new UserAccount()
            {
                Id = Id,
                FullName = Name,
                HashedPassword = HashedPassword,
                Privileges = Privileges,
                Password = Password
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _db.UserAccounts.Remove(new UserAccount() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}
