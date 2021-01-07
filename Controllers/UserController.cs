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
                    PermissionList = "1000000",
                    TimeStamp = Functions.DateTime
                };
                int temp;
                int.TryParse(jd["MergedId"].ToString(), out temp);
                u.MergedId = temp;
                _db.Users.Add(u);
                _db.SaveChanges();
                Cache.RefreshUsers(_db);
                Cache.RefreshUserAccounts(_db);
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
        [HttpGet("navbarlinks")]
        public NavbarLink[] GetNavbarLinks()
        {
            UserAccount userAccount = Functions.GetCurrentUserAccount(HttpContext, _db);
            User user = Functions.GetCurrentUser(HttpContext, _db);
            if (userAccount == null && user == null)
                return new NavbarLink[] { new NavbarLink() { title = "Login" , route = "/user/login" , comp = "/login"} ,
                   new NavbarLink() { title = "Sign Up" , route = "/user/signup" , comp = "/user-account"} };
            Supplier supplier = null;
            if (userAccount != null)
                supplier = _db.Suppliers.Find(userAccount.Id);
            if (supplier != null)
                return new NavbarLink[]
                    {   new NavbarLink(){ title = "Home" , route = "/" , comp = "dashboard" } ,
                        new NavbarLink(){ title = (userAccount.Type == UserTypes.Supplier ? "Register" : "Profile"),
                              comp = (userAccount.Type == UserTypes.Supplier ? "/register-supplier": "/add-user")
                            , route = (userAccount.Type == UserTypes.Supplier ? "/supplier/register" : "/user/register")},
                    };
            if (user == null)
                return new NavbarLink[] 
                    {   new NavbarLink() { title = "Home" , route = "/", comp = "dashboard"} ,
                        new NavbarLink() { title = (userAccount.Type == UserTypes.Supplier ? "Register" : "Profile"),
                              comp = (userAccount.Type == UserTypes.Supplier ? "/register-supplier": "/add-user")
                            , route = (userAccount.Type == UserTypes.Supplier ? "/supplier/register" : "/user/register")},
                    };
            if(user.Position == UserPositions.TEC)
                return new NavbarLink[]
                    {   new NavbarLink() { title = "Category1" , route = "/category1" , comp = "/category1" } ,
                        new NavbarLink() { title = "Category2" , route = "/category2" , comp = "/category2"  },
                        new NavbarLink() { title = "Category3" , route = "/category3" , comp = "/category3"  },
                        new NavbarLink() { title = "Specification Category" , route = "/specification-category" , comp = "/specification-category"  },
                        new NavbarLink() { title = "Specifications" , route = "/specification", comp = "/specification"  },
                        new NavbarLink() { title = "Items" , route = "/item", comp = "/item" }
                    };
            if (user.Position == UserPositions.SAB)
                return new NavbarLink[]
                    {   new NavbarLink()  { title = "Purchase Requests" , route = "/purchaserequest" , comp = "/purchaserequest" } ,
                        new NavbarLink()  { title = "Quotations" , route = "/quotation" , comp = "/quotation" },
                        new NavbarLink()  { title = "Suppliers" , route = "/supplier" , comp = "/supplier" },
                    };
            if (user.Position == UserPositions.Dean || user.Position == UserPositions.Head)
                return new NavbarLink[]
                    {   new NavbarLink() { title = "Purchase Requests" , route = "/purchaserequest" , comp = "/purchaserequest" } ,
                        new NavbarLink() { title = "Quotations" , route = "/view-quotation" , comp = "/view-quotation"  },
                        new NavbarLink() { title = "Users" , route = "/user", comp = "/user" },
                    };
            return new NavbarLink[]
                    {   new NavbarLink() { title = "Purchase Requests" , route = "/purchaserequest", comp = "/purchaserequest" } ,
                        new NavbarLink() { title = "Quotations" , route = "/quotation", comp = "/quotation"   }
                    };

        }
        public class NavbarLink
        {
            public string title { get; set; } = "";
            public string route { get; set; } = "";
            public string comp { get; set; } = "";
        }
    }
}