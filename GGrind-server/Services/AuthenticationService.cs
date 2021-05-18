using GGrind_server.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GGrind_server.Services
{
    public interface IAuthenticationService
    {
        string Authenticate(User user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // ctor
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //TODO Change this so that it fetches the data from the DB
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        { { "test1", "pass1"},
                { "test2", "pass2"}, };

        public string Authenticate(User user)
        {
            //check here if userName and password match it in DB and if no then return null
            if (!users.Any(u => u.Key == user.UserName && u.Value == user.Password))
            {
                return null;
            }

            var token = GenerateJwtToken(user);
         
            return token;
         }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var JwtTokenKey = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings").GetValue<string>("JwtTokenKey"));
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = Auth.CreateUserClaims(user, true),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtTokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return ((JwtSecurityToken)token).RawData;
        }

    }
}
