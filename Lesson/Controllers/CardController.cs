using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessOn.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _service;

        public CardController(ICardService service)
        {
            _service = service;
        }

        [HttpPost("/cardset")]
        public async Task<IActionResult> AddCardAsync(AddCardDTO addCardDTO)
        {
            var result = await _service.AddCardAsync(addCardDTO);

            return Ok(result);
        }
    }
}
