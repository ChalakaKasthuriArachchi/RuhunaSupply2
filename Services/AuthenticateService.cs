using cmlFunctions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RuhunaSupply.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private ApplicationDbContext Db;
        private readonly AppSettings appSettings;

        public AuthenticateService(ApplicationDbContext db,IOptions<AppSettings> appSettings)
        {
            Db = db;
            this.appSettings = appSettings.Value;
        }
        public UserAccount Authenticate(string email, string password)
        {
            string passwordHash = CommonFunctions.ComputeSha256Hash(password);
            var user = Db.UserAccounts.FirstOrDefault(
                u => u.Email.ToLower() == email.ToLower()
                    && u.HashedPassword == passwordHash);
            if (user == null)
                return null;

            //If user is Found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, ((int)user.Type).ToString()),
                    new Claim(ClaimTypes.GivenName , user.ShortName)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.HashedPassword = null;
            return user;
        }
    }
}
