using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGrind_server.Models
{
    public enum AccountType { Unverified = 0, User, Coach, Admin }

    public class User
    {

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // TODO remove constructor (Maybe
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        public User(string userName, string passworrd, AccountType type)
        {
            UserName = userName;
            Password = passworrd;
            AccountType = type;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string GamerNick { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AccountType AccountType { get; set; }

        public bool EmailVerified { get; set; } //add this feature later

        public Game Game { get; set; }  //this must be a REF so that users can have multiple games. make UserGames model which will be games of users


    }
}
