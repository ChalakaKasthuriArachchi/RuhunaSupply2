using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;
using static cmlFunctions.CommonFunctions;
using Microsoft.AspNetCore.Routing;
using RuhunaSupply.Services;
using cmlFunctions;
using System.Security.Claims;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IAuthenticateService authenticateService;

        public UserAccountController(ApplicationDbContext context,
            IAuthenticateService authenticateService)
        {
            this._db = context;
            this.authenticateService = authenticateService;
        }

        [Route("SignUp")]
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(object useraccount)
        {
            JsonData jd = JsonMapper.ToObject(useraccount.ToString());
            UserAccount ua = new UserAccount()
            {
                Id = UserAccount.GetNextId(_db),
                FullName = jd["FullName"].ToString(),
                ShortName = jd["ShortName"].ToString(),
                Email = jd["Email"].ToString(),
                HashedPassword = ComputeSha256Hash(jd["HashedPassword"].ToString()),
                Type = (UserTypes)int.Parse(jd["Type"].ToString()),
                Privileges = ""
            };
            _db.UserAccounts.Add(ua);
            await _db.SaveChangesAsync();
            return CreatedAtAction("UseAccount",new { id = ua.Id},ua);
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(object formData)
        {
            JsonData jd = JsonMapper.ToObject(formData.ToString());
            var user = authenticateService.Authenticate(
                jd["Email"].ToString(), jd["Password"].ToString());

            if (user == null)
                return BadRequest(new { message = "Username or Password is Incorrect" });
            return Ok(user);
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
        [Route("GetUser")]
        [HttpGet]
        public UserAccount GetUserProfile()
        {
            int userId = int.Parse(Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value);
            return _db.UserAccounts.FirstOrDefault(u => u.Id == userId);
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
