using AutoMapper;
using Entities;
using Entities.DTO;

namespace Lesson
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Unit, CreateUnitDTO>();
            CreateMap<CreateUnitDTO, Unit>();

            CreateMap<Unit, UpdateUnitDTO>();
            CreateMap<UpdateUnitDTO, Unit>();
        }
    }
}
