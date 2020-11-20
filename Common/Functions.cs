using Microsoft.AspNetCore.Http;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RuhunaSupply.Common
{
    public static class Functions
    {
        #region Object
        public static UserAccount GetCurrentUser(HttpContext httpContext,ApplicationDbContext _db)
        {
            int userId = int.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value);
            return _db.UserAccounts.FirstOrDefault(u => u.Id == userId);
        }
        public static int GetCurrentUserId(HttpContext httpContext, ApplicationDbContext _db)
        {
            int userId;
            if (int.TryParse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value, out userId))
                return userId;
            throw new Exception("Authentication Failed");
        }
        #endregion
    }
}
