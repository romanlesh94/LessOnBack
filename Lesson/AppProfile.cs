using AutoMapper;
using Entities;
using Entities.DTO;

namespace LessOn
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Unit, CreateUnitDTO>();
            CreateMap<CreateUnitDTO, Unit>();

            CreateMap<Unit, GetUnitsDTO>().ReverseMap();

            CreateMap<Unit, UpdateUnitDTO>();
            CreateMap<UpdateUnitDTO, Unit>();

            CreateMap<Person, AuthDTO>();
            CreateMap<AuthDTO, Person>();

            CreateMap<Lesson, AddLessonDTO>();
            CreateMap<AddLessonDTO, Lesson>();

            CreateMap<Cardset, AddCardsetDTO>().ReverseMap();
            CreateMap<Cardset, CardsetDTO>().ReverseMap();

            CreateMap<Card, AddCardDTO>().ReverseMap();

            CreateMap<Lesson, GetLessonDTO>().ReverseMap();



            CreateMap<Lesson, LessonDTO>().ReverseMap();
        }
    }
}
