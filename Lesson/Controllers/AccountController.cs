﻿using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

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


        [HttpPost("/LogIn")]
        public async Task<IActionResult> LogInAsync(string username, string password)
        {
            try
            {
                var result = await _service.LogInAsync(username, password);
                
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
        [HttpPost("/SignUp")]
        public async Task<IActionResult> SignUpAsync(string username, string password)
        {
            try
            {
                var result = await _service.SignUpAsync(username, password);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Forbid(e.Message);
            }
        }
    }
}
