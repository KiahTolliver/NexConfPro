using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NextConfPro.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
     [HttpPost("register")]
     public async Task<IActionResult> Register()
     {
         return Ok();
     }

     [HttpPost("login")]
     public async Task<IActionResult> Login()
     {
         return Ok();
     }
    }
}

