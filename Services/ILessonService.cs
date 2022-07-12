using Entities;
using Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ILessonService
    {
        Task<Lesson> AddLessonAsync(AddLessonDTO addLessonDTO);
        Task<Lesson> DeleteLessonAsync(long id);
        Task<GetLessonDTO> GetLessonAsync(long id);
    }
}
