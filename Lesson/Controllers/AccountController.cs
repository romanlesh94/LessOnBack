using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;

namespace Lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {   
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            try
            {
                var result = _service.LogIn(username, password);
                
                return Ok(result);
            }
            catch(InvalidPasswordExc e)
            {
                return Unauthorized(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
 
        }   
    }
}
