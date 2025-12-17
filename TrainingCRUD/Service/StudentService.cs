using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TrainingCRUD.Dto;
using TrainingCRUD.Models;
using TrainingCRUD.Repository;

namespace TrainingCRUD.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        public StudentService(IUnitOfWork uow) 
        
                 {
            _uow = uow;
       
                       }
        public async Task<Student> CreateStudent(StudentDto std)
        {
            Student student = new Student
            {
                FirstName = std.FirstName,
                MiddleName = std.MiddleName,
                LastName = std.LastName,
                Gender= std.Gender,

                photoUrl = std.photoUrl,
                DateofBirth = std.DateofBirth
                
            };
            await _uow.students.Add(student);
            await _uow.commit();

            //( async () => { }); - this return a function that returns a task eg: funct<task> action

            await _uow.ExecuteTransactionAsync(async () =>
            {
                Contact contact = new Contact
                {

                    Email = std.contact.Email,
                    primaryMobile = std.contact.primaryMobile,
                    secondaryMobile = std.contact.secondaryMobile,
                    alternateEmail = std.contact.alternateEmail,
                    contactName = std.contact.contactName,
                    contactNumber = std.contact.contactNumber,
                    StudentId = student.Id
                };


                await _uow.contacts.Add(contact);


                Disablility disability = new Disablility
                {
                    disability = std.disablility.disability,
                    disablilityType = std.disablility.disablilityType,
                    disabilityPercentage = std.disablility.disabilityPercentage,

                    StudentId = student.Id
                };
                await _uow.disabilities.Add(disability);

                PersonalDetail personalDetail = new PersonalDetail
                {

                    BloodGroup = std.personalDetail.BloodGroup,
                    caste = std.personalDetail.caste,
                    religion = std.personalDetail.religion,
                    EthnicityType = std.personalDetail.EthnicityType,
                    StudentId = student.Id
                };
                await _uow.personals.Add(personalDetail);

                foreach (var addr in std.addresses)
                {
                    Address address = new Address
                    {
                        SameAsPermanent = addr.SameAsPermanent,
                        Province = addr.Province,
                        District = addr.District,
                        MunicipalityVDC = addr.MunicipalityVDC,
                        WardNumber = addr.WardNumber,
                        ToleStreet = addr.ToleStreet,
                        HouseNumber = addr.HouseNumber,
                        StudentId = student.Id
                    };
                    await _uow.addresses.Add(address);
                }


                foreach(var academics in std.AcademicHistories)
                {
                    AcademicHistory academicHistory = new AcademicHistory
                    {
                            Qualification= academics.Qualification,
                            BoardUniversity=academics.BoardUniversity,
                            InstitutionName=academics.InstitutionName,
                            PassedYear = academics.PassedYear,
                            GpaorDivision = academics.GpaorDivision,
                            MarksheetPath= academics.MarksheetPath,
                            CreatedAt= academics.CreatedAt,
                            StudentId = student.Id
    };
                    await _uow.academics.Add(academicHistory);
                }



                StudentDocument document = new StudentDocument
                {
                    SignaturePath = std.Documents.SignaturePath,
                    CitizenshipDocumentPath = std.Documents.CitizenshipDocumentPath,
                    CharacterCertificatePath = std.Documents.CharacterCertificatePath,
                    ProvisionalAdmitCardPath = std.Documents.ProvisionalAdmitCardPath,
                    StudentId= student.Id
                };

                await _uow.documentinfos.Add(document);


                Faculty faculty = new Faculty
                {
                    FacultyName = std.faculty.FacultyName,
                    Description = std.faculty.Description,
                    StudentId = student.Id
                };
        
                await _uow.faculties.Add(faculty);


                foreach(var enroll in std.Enrollments)
                {
                    EnrollmentDetail enrollDetail = new EnrollmentDetail
                    {
                        Faculty =faculty,
                        CurrentProgramEnrollment = enroll.CurrentProgramEnrollment,
                        Program = enroll.Program,
                        CourseLevel=enroll.CourseLevel,
                        AcademicYear = enroll.AcademicYear,
                        SemesterOrClass = enroll.SemesterOrClass,
                        Section = enroll.Section,
                        RollNumber = enroll.RollNumber,
                        RegistrationNumber = enroll.RegistrationNumber,
                        EnrollDate = enroll.EnrollDate,
                        AcademicStatus = enroll.AcademicStatus,
                       
                        
    };
                    _uow.enrollments.Add(enrollDetail);
                }


                foreach(var extra in std.Extracurriculars)
                {
                    Extracurricular extracurricular = new Extracurricular
                    {

                        ActivityType = extra.ActivityType,
                        OtherDetails = extra.OtherDetails,
                        CreatedAt = extra.CreatedAt,
                        StudentId = student.Id

                        //             public string? ActivityType { get; set; }

                        //public string? OtherDetails { get; set; }

                        //public DateTime? CreatedAt { get; set; }
                    };
                    await _uow.extracurriculars.Add(extracurricular);


                }



                Financial financial = new Financial
                {
                    FeeCategory = std.Financial.FeeCategory,
                    AnnualFamilyIncome = std.Financial.AnnualFamilyIncome,
                    BankAccountHolder = std.Financial.BankAccountHolder,
                    BankName = std.Financial.BankName,
                    AccountNumber = std.Financial.AccountNumber,
                    Branch = std.Financial.Branch,
                    StudentId = student.Id
        //public Scholarship? scholarship { get; set; }
    };


                await _uow.financials.Add(financial);


                foreach(var scholar in std.Scholarships)
                {
                    Scholarship scholarship = new Scholarship
                    {
                        Financial = financial,
                        ScholarshipType = scholar.ScholarshipType,
                        ProviderName = scholar.ProviderName,
                        ScholarshipAmount= scholar.ScholarshipAmount,
                        //FinancialStudentId = financial.Id,
                       

                       
    };
                    await _uow.scholarships.Add(scholarship);
                }



                foreach(var parent in std.parentDetails)
                {
                    ParentGuardianDetails parentGuardian = new ParentGuardianDetails
                    {
                        ParentType = Enum.Parse<ContactNameType>(parent.ParentType, true),

                        FullName = parent.FullName,
                        Occupation = parent.Occupation,
                        Designation = parent.Designation,
                        Organization = parent.Organization,
                        MobileNumber = parent.MobileNumber,
                        Email = parent.Email,
                        FamilyIncome = parent.FamilyIncome,
                        StudentId = student.Id
                       
                    };
                    await _uow.parents.Add(parentGuardian);
                }


                Transportation transportation = new Transportation
                {
                    IsHosteller = std.Transportation.IsHosteller,
                    TransportationMethod = std.Transportation.TransportationMethod,
                    StudentId = student.Id
                 
                };
                await _uow.transportations.Add(transportation);


                CitizenshipInfo citizenship = new CitizenshipInfo
                {
                    CitizenshipNumber= std.citizenshipInfo.CitizenshipNumber,
                    IssueDate = std.citizenshipInfo.IssueDate,
                    IssueDistrict = std.citizenshipInfo.IssueDistrict,
                    CitizenshipCopyPath = std.citizenshipInfo.CitizenshipCopyPath,
                    StudentId = student.Id,
                };
await _uow.citizenshipInfos.Add(citizenship);


    });

            return student;

        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _uow.students.GetStudentWithDetail(id);
            if (student == null)
            {
                return false;
            }
            
            await _uow.students.Delete(student);
            await _uow.commit();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _uow.students.GetAllStudentsWithDetail();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _uow.students.GetStudentWithDetail(id);

            //var student = new Student
            //{
            //    FirstName = students.FirstName,
            //    personalDetail = new PersonalDetail
            //    {
            //        BloodGroup = students.personalDetail.BloodGroup
            //    },
            //    disablility = new Disablility
            //    {
            //        disability = students.disablility.disability
            //    },
            //    contact = new Contact
            //    {
            //        contactName = students.contact.contactName
            //    }
            //};

           
        }
        public async Task UpdateStudent(int id, UpdateStudentDto student)
        {
            var existingStudent = await _uow.students.GetStudentWithDetail(id);

            if (existingStudent == null)
                throw new Exception("Student not found");

            // ✅ Update Student
            existingStudent.FirstName = student.FirstName;
            existingStudent.MiddleName = student.MiddleName;
            existingStudent.LastName = student.LastName;
            existingStudent.Gender = student.Gender;
            existingStudent.photoUrl = student.photoUrl;
            existingStudent.DateofBirth = student.DateofBirth;

          await  _uow.students.Update(existingStudent);

            // ✅ Remove old addresses
            var oldAddresses = await _uow.addresses.GetByStudentId(id);

            foreach (var addr in oldAddresses)
            {
                addr.isDeleted = true;
                await _uow.addresses.Delete(addr);
                // Soft delete
            }

          

            // ✅ Add new addresses
            foreach (var addr in student.addresses)
            {
                var address = new Address
                {
                    StudentId = id,
                    SameAsPermanent = addr.SameAsPermanent,
                    Province = addr.Province,
                    District = addr.District,
                    MunicipalityVDC = addr.MunicipalityVDC,
                    WardNumber = addr.WardNumber,
                    ToleStreet = addr.ToleStreet,
                    HouseNumber = addr.HouseNumber
                };

                await _uow.addresses.Add(address);
            }

            await _uow.commit();
        }


    }
}





//public async Task<Student> CreateStudent(StudentDto student)
//{

//    var std = new Student
//    {
//        FirstName = student.FirstName,
//        MiddleName = student.MiddleName,
//        LastName = student.LastName,
//        Gender = student.Gender,
//        photoUrl = student.photoUrl,
//        DateofBirth = student.DateofBirth,
//        personalDetail = new PersonalDetail
//        {
//            BloodGroup = student.personalDetail.BloodGroup,
//            caste = student.personalDetail.caste,
//            religion = student.personalDetail.religion,
//            EthnicityType = student.personalDetail.EthnicityType,
//        },
//        disablility = new Disablility
//        {
//            disability = student.disablility.disability,
//            disablilityType = student.disablility.disablilityType,
//            disabilityPercentage = student.disablility.disabilityPercentage,
//        },
//        contact = new Contact
//        {
//            Email = student.contact.Email,
//            primaryMobile = student.contact.primaryMobile,
//            secondaryMobile = student.contact.secondaryMobile,
//            alternateEmail = student.contact.alternateEmail,
//            contactName = student.contact.contactName,
//            contactNumber = student.contact.contactNumber,
//        }

//    };
//    await _uow.students.Add(std);
//    //await _uow.commit();
//    return std;
//}