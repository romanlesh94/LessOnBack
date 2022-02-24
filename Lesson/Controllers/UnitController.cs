using Entities.DTO;
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
        public async Task<IActionResult> AddUnitAsync(CreateUnitDTO createUnitDTO)
        {
            var result = await _service.AddUnitAsync(createUnitDTO);

            return Ok(result);
        }

        [HttpPost("/update-unit")]
        public async Task<IActionResult> UpdateUnitAsync(UpdateUnitDTO updateUnitDTO)
        {
            var result = await _service.UpdateUnitAsync(updateUnitDTO);

            return Ok(result);
        }

        [HttpGet("/get-units")]
        public async Task<IActionResult> GetUnitsAsync()
        {
            var result = await _service.GetUnitsAsync();

            return Ok(result);
        }
        [HttpDelete("/delete-unit")]
        public async Task<IActionResult> DeleteUnitAsync(long id)
        {
            var result = await _service.DeleteUnitAsync(id);

            return Ok(result);
        }
    }
}
