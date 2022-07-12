using Entities.DTO;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

namespace LessOn.Controllers
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


        [HttpPost("/log-in")]
        public async Task<IActionResult> LogInAsync(AuthDTO authDTO)
        {
            try
            {
                var result = await _service.LogInAsync(authDTO);
                
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
        [HttpPost("/sign-up")]
        public async Task<IActionResult> SignUpAsync(AuthDTO authDTO)
        {
            try
            {
                await _service.SignUpAsync(authDTO);

                var result = await _service.LogInAsync(authDTO);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Forbid(e.Message);
            }
        }
    }
}
