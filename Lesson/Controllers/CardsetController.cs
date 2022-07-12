using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsetController : Controller
    {
        private readonly ICardsetService _service;

        public CardsetController(ICardsetService service)
        {
            _service = service;
        }

        [HttpPost("/add-cardset")]
        public async Task<IActionResult> AddCardsetAsync(AddCardsetDTO addCardsetDTO)
        {
            var result = await _service.AddCardsetAsync(addCardsetDTO);

            return Ok(result);
        }
    }
}
