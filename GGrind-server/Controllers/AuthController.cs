using GGrind_server.Models;
using GGrind_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGrind_server.Controllers
{
    [Authorize]
    [Route("auth")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // GET 
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public class DATA_IN_AuthenticateCred
        {
            public string Username { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

        }

        [AllowAnonymous]
        [HttpPost("authme")]
        public IActionResult Authenticate([FromBody] DATA_IN_AuthenticateCred userCred)
        {
            //TODO remove this and then the Authenticate will get the user from the DB or use a DTO_IN
            var user = new User(userCred.Username, userCred.Password, AccountType.Coach);

            var token = _authenticationService.Authenticate(user);
            if (token == null)
                return Unauthorized("Incorrect Username or Password");

            return Ok(token);
        }

    }
}
