using AutoMapper;
using Microsoft.EntityFrameworkCore;
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


             CreateMap<ContactDto, Contact>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<PersonalDetailDto, PersonalDetail>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<AcademicHistoryDto, AcademicHistory>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<EnrollmentDetailDto, EnrollmentDetail>()
                .ForMember(dest => dest.FacultyId, opt => opt.Ignore());

            CreateMap<FinancialDto, Financial>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<ScholarshipDto, Scholarship>()
                .ForMember(dest => dest.FinancialId, opt => opt.Ignore());

            CreateMap<TransportationDto, Transportation>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());

            CreateMap<CitizenshipInfoDto, CitizenshipInfo>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());
            CreateMap<ExtracurricularDto, Extracurricular>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());
            CreateMap<FacultyDto, Faculty>()
                .ForMember(dest=>dest.StudentId,opt=>opt.Ignore());
            CreateMap<StudentDocumentDto, StudentDocument>()
                .ForMember(dest => dest.SignaturePath, opt => opt.Ignore())
                .ForMember(dest => dest.CitizenshipDocumentPath, opt => opt.Ignore())
                .ForMember(dest => dest.CharacterCertificatePath, opt => opt.Ignore())
                .ForMember(dest => dest.SignaturePath, opt => opt.Ignore())
                .ForMember(dest => dest.ProvisionalAdmitCardPath, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore());



    }
    }
}
