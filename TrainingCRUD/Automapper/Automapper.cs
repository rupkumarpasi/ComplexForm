using AutoMapper;
using TrainingCRUD.Dto;
using TrainingCRUD.Models;

namespace TrainingCRUD.Automapper
{
    public class Automapper : Profile
    {

        public Automapper() {
        CreateMap<Student,StudentDto>();
            CreateMap<StudentDto, Student>();


            CreateMap<DisablilityDto, Disablility>()
    .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<ParentGuardianDetailsDto, ParentGuardianDetails>()
                .ForMember(dest => dest.ParentType, opt => opt.MapFrom(src => Enum.Parse<ContactNameType>(src.ParentType, true)))
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            


        }
    }
}
