using AutoMapper;
using Entities;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LessonService : ILessonService
    {
        private readonly IGenericRepository<Lesson> _genericRepository;
        private readonly IMapper _mapper;

        public LessonService(IGenericRepository<Lesson> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Lesson> AddLessonAsync(AddLessonDTO addLessonDTO)
        {
            Lesson lesson = _mapper.Map<AddLessonDTO, Lesson>(addLessonDTO);

            var count = (await _genericRepository.QueryAsync()).Where(l => l.UnitId == addLessonDTO.UnitId).Count();

            lesson.Number = count + 1;

            await _genericRepository.CreateAsync(lesson);

            return lesson;
        }

        public async Task<GetLessonDTO> GetLessonAsync(long id)
        {
           
            var lesson = (await _genericRepository.QueryAsync())
                .Include(l => l.Cardsets)
                .FirstOrDefault(l => l.Id == id);

            var getLessonDTO = _mapper.Map<GetLessonDTO>(lesson);

            return getLessonDTO;
        }

        public async Task<Lesson> DeleteLessonAsync(long id)
        {
            var lessonToDelete = await _genericRepository.FindByIdAsync(id);

            await _genericRepository.RemoveAsync(lessonToDelete);

            return lessonToDelete;
        }
    }
}
