using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace LessOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpPost("/add-lesson")]
        public async Task<IActionResult> AddLessonAsync(AddLessonDTO addLessonDTO)
        {
            var result = await _service.AddLessonAsync(addLessonDTO);

            return Ok(result);
        }

        [HttpDelete("/delete-lesson")]
        public async Task<IActionResult> DeleteLessonAsync(long id)
        {
            var result = await _service.DeleteLessonAsync(id);

            return Ok(result);
        }

        [HttpGet("/get-lesson")]
        public async Task<IActionResult> GetLessonAsync(long id)
        {
            var result = await _service.GetLessonAsync(id);

            return Ok(result);
        }
    }
}
