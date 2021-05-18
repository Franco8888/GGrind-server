using GGrind_server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGrind_server.Controllers
{
    [Authorize(Roles = Auth.Roles.Coach)]
    [Route("api/coach")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // GET {FirstName}
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        [HttpGet("getUser/{firstName}")]
        public IActionResult GetUser(string firstName)
        {
            int myInt = 5;
            myInt = myInt + 4;



            return Ok(firstName);
        }
    }
}
