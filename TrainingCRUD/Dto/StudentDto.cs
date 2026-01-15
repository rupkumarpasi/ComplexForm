using System.ComponentModel.DataAnnotations;
using TrainingCRUD.Models;

namespace TrainingCRUD.Dto
{

    public class UpdateStudentDto:StudentDto
    {
        //public int Id { get; set; }
    }

    public class responseStudentDto : StudentDto
    {
        public int Id { get; set; }
        public StudentDocumentDto? Documents { get; set; }

    }
    public class StudentDto
    {
        
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public DateOnly DateofBirth { get; set; }
        public Gendertype Gender { get; set; }

        public PersonalDetailDto? personalDetail { get; set; }
        public DisablilityDto? disablility { get; set; }
        public ContactDto? contact { get; set; }

        public List<AddressDto>? addresses { get; set; }


        public List<AcademicHistoryDto>? AcademicHistories { get; set; }




        public List<EnrollmentDetailDto>? Enrollments { get; set; }



        public List<ExtracurricularDto>? Extracurriculars { get; set; }

        public FinancialDto? Financial { get; set; }

        public List<ParentGuardianDetailsDto>? parentDetails { get; set; }



        public List<ScholarshipDto>? Scholarships { get; set; }

        public TransportationDto? Transportation { get; set; }
        public CitizenshipInfoDto? citizenshipInfo { get; set; }

        public FacultyDto? faculty { get; set; }

        }



        public class PersonalDetailDto
        {

            public string BloodGroup { get; set; }
            public string religion { get; set; }
            public string caste { get; set; } = string.Empty;
            public string EthnicityType { get; set; } = string.Empty;


        }


        public class DisablilityDto
        {

            public string disability { get; set; } = string.Empty;
            public string disablilityType { get; set; } = string.Empty;
            public float disabilityPercentage { get; set; }
        }



        public class ContactDto
        {

            public string Email { get; set; } = string.Empty;
            public string primaryMobile { get; set; } = string.Empty;

            public string secondaryMobile { get; set; } = string.Empty;
            public string alternateEmail { get; set; } = string.Empty;
            public string? contactName { get; set; }

            public string contactNumber { get; set; } = string.Empty;
        }


        public class AddressDto
        {
            public bool SameAsPermanent { get; set; }
            public string Province { get; set; } = string.Empty;
            public string District { get; set; } = string.Empty;
            public string MunicipalityVDC { get; set; } = string.Empty;
            public int WardNumber { get; set; }
            public string ToleStreet { get; set; } = string.Empty;
            public string HouseNumber { get; set; } = string.Empty;
        }


        public class ParentGuardianDetailsDto
        {



            public string? ParentType { get; set; }  // Father, Mother, Guardian


            public string FullName { get; set; } = string.Empty;

            public string Occupation { get; set; } = string.Empty;


            public string Designation { get; set; } = string.Empty;


            public string Organization { get; set; } = string.Empty;


            public string MobileNumber { get; set; } = string.Empty;


            public string Email { get; set; } = string.Empty;



            public string? FamilyIncome { get; set; }
        }


        public class AcademicHistoryDto
        {

            public string Qualification { get; set; } = null!;

            public string? BoardUniversity { get; set; }

            public string? InstitutionName { get; set; }

            public int? PassedYear { get; set; }

            public string? GpaorDivision { get; set; }

            

            public DateTime? CreatedAt { get; set; }

        }


        public class StudentDocumentDto
        {

        public IFormFile? photoUrl { get; set; }

        public IFormFile? SignaturePath { get; set; }

        public IFormFile? CitizenshipCopyPath { get; set; }

        public IFormFile CitizenshipDocumentPath { get; set; }


            public IFormFile? CharacterCertificatePath { get; set; }


        //public string? MarksheetPath { get; set; }


        public IFormFile? ProvisionalAdmitCardPath { get; set; }


        public IFormFile? MarksheetPath { get; set; }
    }




        public class CitizenshipInfoDto
        {

            public string CitizenshipNumber { get; set; } = null!;

            public DateOnly? IssueDate { get; set; }

            public string? IssueDistrict { get; set; }

           
        }




        public class EnrollmentDetailDto
        {

            //public int FacultyId { get; set; }
            public string? CurrentProgramEnrollment { get; set; }

            public string? Program { get; set; }

            public string? CourseLevel { get; set; }

            public string? AcademicYear { get; set; }

            public string? SemesterOrClass { get; set; }

            public string? Section { get; set; }

            public string? RollNumber { get; set; }

            public string? RegistrationNumber { get; set; }

            public DateOnly? EnrollDate { get; set; }

            public string? AcademicStatus { get; set; }



        }



        public class FacultyDto
        {

            public string FacultyName { get; set; } = string.Empty;

            public string? Description { get; set; }

            public ICollection<EnrollmentDetailDto>? EnrollmentDetails { get; set; } = new List<EnrollmentDetailDto>();
        }




        public  class ExtracurricularDto
        {


            public string? ActivityType { get; set; }

            public string? OtherDetails { get; set; }

            public DateTime? CreatedAt { get; set; }

        }


        public class FinancialDto
        {


            public string FeeCategory { get; set; } = null!;

            public string? AnnualFamilyIncome { get; set; }

            public string? BankAccountHolder { get; set; }

            public string? BankName { get; set; }

            public string? AccountNumber { get; set; }

            public string? Branch { get; set; }

        public ICollection<ScholarshipDto> scholarships { get; set; } = new List<ScholarshipDto>();

        }



        public class ScholarshipDto
        {

            public string? ScholarshipType { get; set; }

            public string? ProviderName { get; set; }

            public decimal? ScholarshipAmount { get; set; }

            //public int? FinancialStudentId { get; set; }

        }

        public class TransportationDto
        {


            public bool? IsHosteller { get; set; }

            public string? TransportationMethod { get; set; }
        }
    }

