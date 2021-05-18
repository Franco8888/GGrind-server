using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GGrind_server.Models
{
    public static class Auth
    {
        public static class Claims
        {
            //TODO add claims that you put at the ClaimsIdentity

            /*public const string ID = "GT.ApiClaim.ID";
            public const string FirstName = "GT.ApiClaim.FirstName";
            public const string LastName = "GT.ApiClaim.LastName";
            public const string Email = "GT.ApiClaim.Email";*/
        }

        public static class Roles
        {
            public const string Unverified = "V, U, C, A";
            public const string User = "U, C, A";
            public const string Coach = "C, A";
            public const string Admin = "A";
        }

        public static class DatabaseAccountTypeNames
        {
            public const string Unverified = "V";
            public const string User = "U";
            public const string Coach = "C";
            public const string Admin = "A";

            public static string Map(AccountType type)
            {
                switch (type)
                {
                    case AccountType.Unverified: return Unverified;
                    case AccountType.User: return User;
                    case AccountType.Coach: return Coach;
                    case AccountType.Admin: return Admin;
                }
                return string.Empty;
            }
        }

        public static ClaimsIdentity CreateUserClaims(User user, bool verified)
        {
            var role = DatabaseAccountTypeNames.Map(user.AccountType);
            if (!verified)
                role = DatabaseAccountTypeNames.Unverified;

            return new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role),
                    //TODO add claims later
                });
        }
    }
}
