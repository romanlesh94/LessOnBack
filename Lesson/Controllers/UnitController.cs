using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly IUnitService _service;
        public UnitController(IUnitService service)
        {
            _service = service;
        }

        [HttpPost("/add-unit")]
        public async Task<IActionResult> AddUnitAsync(string name, string description, string imagePath)
        {
            var result = await _service.AddUnitAsync(name, description, imagePath);

            return Ok(result);
        }

        [HttpPost("/get-units")]
        public async Task<IActionResult> GetUnitsAsync()
        {
            var result = await _service.GetUnitsAsync();

            return Ok(result);
        }
    }
}
