
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using TrainingCRUD.Dto;


namespace TrainingCRUD.Models
{
    public class Student : BaseEntity
    {

        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateOnly DateofBirth { get; set; }
        public Gendertype Gender { get; set; }

        public PersonalDetail personalDetail { get; set; }
        public Disablility disablility { get; set; }
        public Contact contact { get; set; }

        public ICollection<Address> addresses { get; set; } = new List<Address>();


        public virtual ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();

        //public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

        

        //public virtual Citizenship? Citizenship { get; set; }

      

        public  StudentDocument? Documents { get; set; }

        //public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

        //public  ICollection<EnrollmentDetail> Enrollments { get; set; } = new List<EnrollmentDetail>();

        //public virtual EthnicityInfo? EthnicityInfo { get; set; }

        public  ICollection<Extracurricular> Extracurriculars { get; set; } = new List<Extracurricular>();

        public  Financial? Financial { get; set; }

        public  ICollection<ParentGuardianDetails> parentDetails { get; set; } = new List<ParentGuardianDetails>();

        //public  PersonalDetail? PersonalDetail { get; set; }

        //public  ICollection<Scholarship> Scholarships { get; set; } = new List<Scholarship>();

        public  Transportation? Transportation { get; set; }

        public CitizenshipInfo CitizenshipInfo { get; set; }

        public Faculty Faculty { get; set; }

    }
    public enum Gendertype
    {
        male = 0,
        female = 1,
        other = 2
    }

    public class PersonalDetail : BaseEntity
    {
        public int StudentId { get; set; }
        public string BloodGroup { get; set; }
        public string religion { get; set; }
        public string caste { get; set; } = string.Empty;
        public string EthnicityType { get; set; } = string.Empty;


    }


    public class Disablility : BaseEntity
    {
        public int StudentId { get; set; }
        public string disability { get; set; } = string.Empty;
        public string disablilityType { get; set; } = string.Empty;
        public float disabilityPercentage { get; set; }
    }



    public class Contact : BaseEntity
    {
        public int StudentId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string primaryMobile { get; set; } = string.Empty;

        public string secondaryMobile { get; set; } = string.Empty;
        public string alternateEmail { get; set; } = string.Empty;
        public string contactName { get; set; }

        public string contactNumber { get; set; } = string.Empty;

    }
    public enum ContactNameType
    {
        father = 0, mother = 1, guardian = 2
    }



    public class Address : BaseEntity
    {
        public int StudentId { get; set; }
        public bool SameAsPermanent { get; set; }
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string MunicipalityVDC { get; set; } = string.Empty;
        public int WardNumber { get; set; }
        public string ToleStreet { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
    }




    public class ParentGuardianDetails : BaseEntity
    {
        public int StudentId { get; set; }

        [Required]
        public ContactNameType ParentType { get; set; }  // Father, Mother, Guardian

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Occupation { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public string Organization { get; set; } = string.Empty;

        [Required]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;



        public string? FamilyIncome { get; set; }
    }

    public class AcademicHistory : BaseEntity
    {
        public int StudentId { get; set; }
        public string Qualification { get; set; } = null!;

        public string? BoardUniversity { get; set; }

        public string? InstitutionName { get; set; }

        public int? PassedYear { get; set; }

        public string? GpaorDivision { get; set; }

        public string? MarksheetPath { get; set; }

        public DateTime? CreatedAt { get; set; }

    }


    public class StudentDocument : BaseEntity
    {
        public int? StudentId { get; set; }
        public string photoUrl { get; set; }

        public string? CitizenshipCopyPath { get; set; }
        public string? SignaturePath { get; set; }

        [Required]
        public string CitizenshipDocumentPath { get; set; }

        [Required]
        public string? CharacterCertificatePath { get; set; }

        [Required]
        public string? ProvisionalAdmitCardPath { get; set; }
    }




    public class CitizenshipInfo : BaseEntity
    {
        public int StudentId { get; set; }
        public string CitizenshipNumber { get; set; } = null!;

        public DateOnly? IssueDate { get; set; }

        public string? IssueDistrict { get; set; }

        
    }




    public class EnrollmentDetail 
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
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

        [JsonIgnore]
        public Faculty? Faculty { get; set; }
    }



    public class Faculty : BaseEntity
    {
        public int StudentId { get; set; }
        public string FacultyName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<EnrollmentDetail>? EnrollmentDetails { get; set; } = new List<EnrollmentDetail>();
    }




    public partial class Extracurricular : BaseEntity
    {
        public int StudentId { get; set; }

        public string? ActivityType { get; set; }

        public string? OtherDetails { get; set; }

        public DateTime? CreatedAt { get; set; }

    }


    public class Financial : BaseEntity
    {

        public int StudentId { get; set; }
        public string FeeCategory { get; set; } = null!;

        public string? AnnualFamilyIncome { get; set; }

        public string? BankAccountHolder { get; set; }

        public string? BankName { get; set; }

        public string? AccountNumber { get; set; }

        public string? Branch { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }

        public ICollection<Scholarship>? scholarship { get; set; } = new List<Scholarship>();
        }



    public class Scholarship 
    {
        [Key]
     public int Id { get; set; }
        public string? ScholarshipType { get; set; }

        public string? ProviderName { get; set; }


        [Precision(18, 2)]
        public decimal? ScholarshipAmount { get; set; }

        [ForeignKey("Financial")]
        public int FinancialId { get; set; }

        [JsonIgnore]
        public Financial? Financial { get; set; }

       
    }

    public class Transportation : BaseEntity
    {
        public int StudentId { get; set; }

        public bool? IsHosteller { get; set; }

        public string? TransportationMethod { get; set; }
    }


    }

