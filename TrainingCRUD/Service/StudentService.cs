using AutoMapper;

using TrainingCRUD.Dto;
using TrainingCRUD.Helpers;
using TrainingCRUD.Models;
using TrainingCRUD.Repository;


namespace TrainingCRUD.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IFileUploader _fileuploader;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork uow, IFileUploader fileuploader,IMapper mapper)

        {
            _uow = uow;
            _fileuploader = fileuploader;
            _mapper = mapper;
            
        }
        public async Task<Student> CreateStudent(StudentDto std, int documentId)
        {
            Student student = new Student
            {
                FirstName = std.FirstName,
                MiddleName = std.MiddleName,
                LastName = std.LastName,
                Gender = std.Gender,
                
                //photoUrl = std.photoUrl,
                DateofBirth = std.DateofBirth

            };

            await _uow.students.Add(student);
            await _uow.commit();

            //( async () => { }); - this return a function that returns a task eg: funct<task> action

            await _uow.ExecuteTransactionAsync(async () =>
            {
                //Contact contact = new Contact
                //{

                //    Email = std.contact.Email,
                //    primaryMobile = std.contact.primaryMobile,
                //    secondaryMobile = std.contact.secondaryMobile,
                //    alternateEmail = std.contact.alternateEmail,
                //    contactName = std.contact.contactName,
                //    contactNumber = std.contact.contactNumber,
                //    StudentId = student.Id
                //};

                var contact = _mapper.Map<Contact>(std.contact);
                contact.StudentId = student.Id;


                await _uow.contacts.Add(contact);


                //Disablility disability = new Disablility
                //{
                //    disability = std.disablility.disability,
                //    disablilityType = std.disablility.disablilityType,
                //    disabilityPercentage = std.disablility.disabilityPercentage,

                //    StudentId = student.Id
                //};

                var disability = _mapper.Map<Disablility>(std.disablility);

                // set foreign key manually
                disability.StudentId = student.Id;
                await _uow.disabilities.Add(disability);

                //PersonalDetail personalDetail = new PersonalDetail
                //{

                //    BloodGroup = std.personalDetail.BloodGroup,
                //    caste = std.personalDetail.caste,
                //    religion = std.personalDetail.religion,
                //    EthnicityType = std.personalDetail.EthnicityType,
                //    StudentId = student.Id
                //};

                var personalDetail = _mapper.Map<PersonalDetail>(std.personalDetail);
                personalDetail.StudentId = student.Id;


                await _uow.personals.Add(personalDetail);

                foreach (var addr in std.addresses)
                {
                    //Address address = new Address
                    //{
                    //    SameAsPermanent = addr.SameAsPermanent,
                    //    Province = addr.Province,
                    //    District = addr.District,
                    //    MunicipalityVDC = addr.MunicipalityVDC,
                    //    WardNumber = addr.WardNumber,
                    //    ToleStreet = addr.ToleStreet,
                    //    HouseNumber = addr.HouseNumber,
                    //    StudentId = student.Id
                    //};
                    var address = _mapper.Map<Address>(addr);
                    address.StudentId = student.Id;
                    await _uow.addresses.Add(address);
                }


                foreach (var academics in std.AcademicHistories)
                {
                    //AcademicHistory academicHistory = new AcademicHistory
                    //{
                    //    Qualification = academics.Qualification,
                    //    BoardUniversity = academics.BoardUniversity,
                    //    InstitutionName = academics.InstitutionName,
                    //    PassedYear = academics.PassedYear,
                    //    GpaorDivision = academics.GpaorDivision,
                    //    CreatedAt = academics.CreatedAt,
                    //    StudentId = student.Id
                    //};

                    var academicHistory = _mapper.Map<AcademicHistory>(academics);
                    academicHistory.StudentId = student.Id;
                    await _uow.academics.Add(academicHistory);
                }



                //StudentDocument document = new StudentDocument
                //{
                //    SignaturePath = _fileuploader.BaseString(std.Documents.SignaturePath, "signatures"),
                //    CitizenshipDocumentPath = _fileuploader.BaseString(std.Documents.CitizenshipDocumentPath, "Documents"),
                //    CharacterCertificatePath = _fileuploader.BaseString(std.Documents.CharacterCertificatePath, "charactercertificates"),
                //    ProvisionalAdmitCardPath = _fileuploader.BaseString(std.Documents.ProvisionalAdmitCardPath, "Provisional"),
                //    StudentId = student.Id
                //}
                //;
                //var document = _mapper.Map<StudentDocument>(std.Documents);
                //document.SignaturePath = _fileuploader.BaseString(std.Documents.SignaturePath, "signatures");
                //document.CitizenshipDocumentPath = _fileuploader.BaseString(std.Documents.CitizenshipDocumentPath, "Documents");
                //document.CharacterCertificatePath = _fileuploader.BaseString(std.Documents.CharacterCertificatePath, "charactercertificates");
                //document.ProvisionalAdmitCardPath = _fileuploader.BaseString(std.Documents.ProvisionalAdmitCardPath, "Provisional");
                //    document.StudentId = student.Id;

               var document = await _uow.documentinfos.GetById(documentId);
                document.StudentId = student.Id;

                await _uow.commit();


                //Faculty faculty = new Faculty
                //{
                //    FacultyName = std.faculty.FacultyName,
                //    Description = std.faculty.Description,
                //    StudentId = student.Id
                //};
                var faculty = _mapper.Map<Faculty>(std.faculty);
                faculty.StudentId = student.Id;

                await _uow.faculties.Add(faculty);


                foreach (var enroll in std.Enrollments)
                {
                    //EnrollmentDetail enrollDetail = new EnrollmentDetail
                    //{
                    //    Faculty = faculty,
                    //    CurrentProgramEnrollment = enroll.CurrentProgramEnrollment,
                    //    Program = enroll.Program,
                    //    CourseLevel = enroll.CourseLevel,
                    //    AcademicYear = enroll.AcademicYear,
                    //    SemesterOrClass = enroll.SemesterOrClass,
                    //    Section = enroll.Section,
                    //    RollNumber = enroll.RollNumber,
                    //    RegistrationNumber = enroll.RegistrationNumber,
                    //    EnrollDate = enroll.EnrollDate,
                    //    AcademicStatus = enroll.AcademicStatus,


                    //};

                    var enrollDetail = _mapper.Map<EnrollmentDetail>(enroll);
                    enrollDetail.Faculty = faculty;

                    _uow.enrollments.Add(enrollDetail);
                }


                foreach (var extra in std.Extracurriculars)
                {
                    //Extracurricular extracurricular = new Extracurricular
                    //{

                    //    ActivityType = extra.ActivityType,
                    //    OtherDetails = extra.OtherDetails,
                    //    CreatedAt = extra.CreatedAt,
                    //    StudentId = student.Id

                    //    //             public string? ActivityType { get; set; }

                    //    //public string? OtherDetails { get; set; }

                    //    //public DateTime? CreatedAt { get; set; }
                    //};

                    var extracurricular = _mapper.Map<Extracurricular>(extra);
                    extracurricular.StudentId = student.Id;
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

                //var financial = _mapper.Map<Financial>(std.Financial);
                //financial.StudentId = student.Id;

                await _uow.financials.Add(financial);


                foreach (var scholar in std.Scholarships)
                {
                    //Scholarship scholarship = new Scholarship
                    //{
                    //    Financial = financial,
                    //    ScholarshipType = scholar.ScholarshipType,
                    //    ProviderName = scholar.ProviderName,
                    //    ScholarshipAmount = scholar.ScholarshipAmount,
                    //    //FinancialStudentId = financial.Id,



                    //};

                    var scholarship = _mapper.Map<Scholarship>(scholar);
                   
                    scholarship.Financial = financial;

                    await _uow.scholarships.Add(scholarship);
                }



                foreach (var parent in std.parentDetails)
                {
                    //ParentGuardianDetails parentGuardian = new ParentGuardianDetails
                    //{
                    //    ParentType = Enum.Parse<ContactNameType>(parent.ParentType, true),

                    //    FullName = parent.FullName,
                    //    Occupation = parent.Occupation,
                    //    Designation = parent.Designation,
                    //    Organization = parent.Organization,
                    //    MobileNumber = parent.MobileNumber,
                    //    Email = parent.Email,
                    //    FamilyIncome = parent.FamilyIncome,
                    //    StudentId = student.Id

                    //};

                    var parentGuardian = _mapper.Map<ParentGuardianDetails>(parent);
                    parentGuardian.StudentId = student.Id;
                    await _uow.parents.Add(parentGuardian);
                }


                //Transportation transportation = new Transportation
                //{
                //    IsHosteller = std.Transportation.IsHosteller,
                //    TransportationMethod = std.Transportation.TransportationMethod,
                //    StudentId = student.Id

                //};

                var transportation = _mapper.Map<Transportation>(std.Transportation);
                transportation.StudentId = student.Id;
                await _uow.transportations.Add(transportation);


                //CitizenshipInfo citizenship = new CitizenshipInfo
                //{
                //    CitizenshipNumber = std.citizenshipInfo.CitizenshipNumber,
                //    IssueDate = std.citizenshipInfo.IssueDate,
                //    IssueDistrict = std.citizenshipInfo.IssueDistrict,
                //    CitizenshipCopyPath = std.citizenshipInfo.CitizenshipCopyPath,
                //    StudentId = student.Id,
                //};
                var citizenship = _mapper.Map<CitizenshipInfo>(std.citizenshipInfo);
                citizenship.StudentId = student.Id;
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
            var students = await _uow.students.GetStudentWithDetail(id);
            //var student = new responseStudentDto
            //{
            //    FirstName = students.FirstName,
            //    MiddleName = students.MiddleName,
            //    LastName = students.LastName,
            //    Gender = students.Gender,
            //    //photoUrl = students.photoUrl,
            //    DateofBirth = students.DateofBirth,
            //    disablility = _mapper.Map<DisablilityDto>(students.disablility),
            //    contact = _mapper.Map<ContactDto>(students.contact),
            //    addresses = _mapper.Map<List<AddressDto>>(students.addresses),
            //    parentDetails = _mapper.Map<List<ParentGuardianDetailsDto>>(students.parentDetails),
            //    AcademicHistories = _mapper.Map<List<AcademicHistoryDto>>(students.AcademicHistories),
            //    faculty = _mapper.Map<FacultyDto>(students.Faculty),
            //    Enrollments = _mapper.Map<List<EnrollmentDetailDto>>(students.Faculty.EnrollmentDetails),
            //    Financial = _mapper.Map<FinancialDto>(students.Financial),
            //    Scholarships = _mapper.Map<List<ScholarshipDto>>(students.Financial.scholarship),
            //    Transportation = _mapper.Map<TransportationDto>(students.Transportation),
            //    citizenshipInfo = _mapper.Map<CitizenshipInfoDto>(students.CitizenshipInfo),
            //    Extracurriculars = _mapper.Map<List<ExtracurricularDto>>(students.Extracurriculars),
            //    Documents = _mapper.Map<StudentDocumentDto>(students.Documents)

                //         public DbSet<PersonalDetail> personalDetails { get; set; }
                //public DbSet<Disablility> disablilities { get; set; }
                //public DbSet<Contact> contacts { get; set; }

                //public DbSet<Address> addresses { get; set; }

                //public DbSet<ParentGuardianDetails> parents { get; set; }
                //public DbSet<AcademicHistory> academics { get; set; }
                //public DbSet<EnrollmentDetail> enrollments { get; set; }
                //public DbSet<Financial> financials { get; set; }
                //public DbSet<Scholarship> scholarships { get; set; }
                //public DbSet<Transportation> transportations { get; set; }

                //public DbSet<CitizenshipInfo> citizenshipInfos { get; set; }

                //public DbSet<Extracurricular> extracurriculars { get; set; }

                //public DbSet<Faculty> faculties { get; set; }

                //public DbSet<StudentDocument> documentinfos { get; set; }


            //};
            return students;

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


        public async Task<StudentDocument> UploadPhoto(StudentDocumentDto dto)
        {
            var document = new StudentDocument
            {
                CitizenshipCopyPath = await _fileuploader.UploadAsync(dto.CitizenshipCopyPath, "Citizenship_Copies"),
                photoUrl = await _fileuploader.UploadAsync(dto.photoUrl, "Photos"),
                SignaturePath = await _fileuploader.UploadAsync(dto.SignaturePath, "signatures"),
                CitizenshipDocumentPath = await _fileuploader.UploadAsync(dto.CitizenshipDocumentPath, "Documents"),
                CharacterCertificatePath = await _fileuploader.UploadAsync(dto.CharacterCertificatePath, "charactercertificates"),
                ProvisionalAdmitCardPath = await _fileuploader.UploadAsync(dto.ProvisionalAdmitCardPath, "Provisional"),
                MarksheetPath = await _fileuploader.UploadAsync(dto.MarksheetPath, "Marksheets")
            };
            await _uow.documentinfos.Add(document);
            await _uow.commit();
            return document;
        }



        public async Task UpdateStudent(int id, UpdateStudentDto std)
        {
            var existingStudent = await _uow.students.GetStudentWithDetail(id);

            if (existingStudent == null)
                throw new Exception("Student not found");

            // ✅ Update Student
            existingStudent.FirstName = std.FirstName;
            existingStudent.MiddleName = std.MiddleName;
            existingStudent.LastName = std.LastName;
            existingStudent.Gender = std.Gender;
            //existingStudent.photoUrl = await _fileuploader.UploadAsync(std.photoUrl, "Photos"); ;
            existingStudent.DateofBirth = std.DateofBirth;

            await _uow.students.Update(existingStudent);

            // ✅ Remove old addresses
            //var oldAddresses = await _uow.addresses.GetByStudentId(id);
            var oldAddresses = await _uow.addresses.FindAsync(a => a.StudentId == id);  

            foreach (var addr in oldAddresses)
            {
                addr.isDeleted = true;
                await _uow.addresses.Delete(addr);
                // Soft delete
            }



            // ✅ Add new addresses
            foreach (var addr in std.addresses)
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
                await _uow.commit();
            }


            var existingContact = await _uow.contacts.FindOneAsync(c => c.StudentId == id);




            existingContact.Email = std.contact.Email;
            existingContact.primaryMobile = std.contact.primaryMobile;
            existingContact.secondaryMobile = std.contact.secondaryMobile;
            existingContact.alternateEmail = std.contact.alternateEmail;
            existingContact.contactName = std.contact.contactName;
            existingContact.contactNumber = std.contact.contactNumber;
            existingContact.StudentId = id;




            await _uow.contacts.Update(existingContact);

            var existingDisability = await _uow.disabilities.FindOneAsync(d => d.StudentId == id);



            existingDisability.disability = std.disablility.disability;
            existingDisability.disablilityType = std.disablility.disablilityType;
            existingDisability.disabilityPercentage = std.disablility.disabilityPercentage;

            existingDisability.StudentId = id;

            await _uow.disabilities.Update(existingDisability);


            var existingPersonalDetail = await _uow.personals.FindOneAsync(p => p.StudentId == id);
            existingPersonalDetail.BloodGroup = std.personalDetail.BloodGroup;
            existingPersonalDetail.caste = std.personalDetail.caste;
            existingPersonalDetail.religion = std.personalDetail.religion;
            existingPersonalDetail.EthnicityType = std.personalDetail.EthnicityType;
            existingPersonalDetail.StudentId = id;

            await _uow.personals.Update(existingPersonalDetail);




            var existingAcademicHistories = await _uow.academics.FindAsync(a => a.StudentId == id);
            if (existingAcademicHistories != null)
            {

                foreach (var academics in existingAcademicHistories)
                {


                     _uow.academics.Delete(academics);
                }

            }

            foreach (var academics in std.AcademicHistories)
            {
                AcademicHistory academicHistory = new AcademicHistory
                {
                    Qualification = academics.Qualification,
                    BoardUniversity = academics.BoardUniversity,
                    InstitutionName = academics.InstitutionName,
                    PassedYear = academics.PassedYear,
                    GpaorDivision = academics.GpaorDivision,
                
                    CreatedAt = academics.CreatedAt,
                    StudentId = id
                };
                await _uow.academics.Add(academicHistory);
                
                
            }


            var existingDocument = await _uow.documentinfos.FindOneAsync(d => d.StudentId == id);


            //existingDocument.SignaturePath = await _fileuploader.UploadAsync(std.Documents.SignaturePath, "SignaturePath");
            //existingDocument.CitizenshipDocumentPath = await _fileuploader.UploadAsync(std.Documents.CitizenshipDocumentPath, "Citizenship_Document");
            //existingDocument.CharacterCertificatePath = await _fileuploader.UploadAsync(std.Documents.CharacterCertificatePath, "Character_Certificate");
            //existingDocument.ProvisionalAdmitCardPath = await _fileuploader.UploadAsync(std.Documents.ProvisionalAdmitCardPath, "Provisional_Card");
            //existingDocument.StudentId = id;


            await _uow.documentinfos.Update(existingDocument);


            var existingFaculty = await _uow.faculties.FindOneAsync(f => f.StudentId == id);

            existingFaculty.FacultyName = std.faculty.FacultyName;
            existingFaculty.Description = std.faculty.Description;
            existingFaculty.StudentId = id; 


            await _uow.faculties.Update(existingFaculty);


            var existingEnrollments = await _uow.enrollments.FindAsync(e => e.FacultyId == existingFaculty.Id);
            foreach (var enroll in existingEnrollments)
            {
                 _uow.enrollments.Delete(enroll);
            }

            foreach (var enroll in std.Enrollments)
            {

                EnrollmentDetail enrollment = new EnrollmentDetail
                {
                    CurrentProgramEnrollment = enroll.CurrentProgramEnrollment,
                    Program = enroll.Program,
                    CourseLevel = enroll.CourseLevel,
                    AcademicYear = enroll.AcademicYear,
                    SemesterOrClass = enroll.SemesterOrClass,
                    Section = enroll.Section,
                    RollNumber = enroll.RollNumber,
                    RegistrationNumber = enroll.RegistrationNumber,
                    EnrollDate = enroll.EnrollDate,
                    AcademicStatus = enroll.AcademicStatus,
                    FacultyId = existingFaculty.Id

                };
                await _uow.enrollments.Add(enrollment);
              

            }



            var existingExtracurriculars = await _uow.extracurriculars.FindAsync(e => e.StudentId == id);
            foreach (var extra in existingExtracurriculars)
            {
                 _uow.extracurriculars.Delete(extra);
            }

            foreach (var extra in std.Extracurriculars)
            {
                Extracurricular extracurricular = new Extracurricular
                {

                    ActivityType = extra.ActivityType,
                    OtherDetails = extra.OtherDetails,
                    CreatedAt = extra.CreatedAt,
                    StudentId = id
                };
                await _uow.extracurriculars.Add(extracurricular);
                

            }


            var existingFinancial = await _uow.financials.FindOneAsync(f => f.StudentId == id);

            existingFinancial.FeeCategory = std.Financial.FeeCategory;
            existingFinancial.AnnualFamilyIncome = std.Financial.AnnualFamilyIncome;
            existingFinancial.BankAccountHolder = std.Financial.BankAccountHolder;
            existingFinancial.BankName = std.Financial.BankName;
            existingFinancial.AccountNumber = std.Financial.AccountNumber;
            existingFinancial.Branch = std.Financial.Branch;
               
                //public Scholarship? scholarship { get; set; }
        


            await _uow.financials.Update(existingFinancial);


            var existingScholarships = await _uow.scholarships.FindAsync(s => s.Financial.StudentId == id);

            foreach (var scholar in existingScholarships)
            {
                 _uow.scholarships.Delete(scholar);
            }


            foreach (var scholar in std.Scholarships)
            {
                Scholarship scholarship = new Scholarship
                {

                    ScholarshipType = scholar.ScholarshipType,
                    ProviderName = scholar.ProviderName,
                    ScholarshipAmount = scholar.ScholarshipAmount,
                    FinancialId = existingFinancial.Id,



                };
                await _uow.scholarships.Add(scholarship);
                
            }


            var existingParents = await _uow.parents.FindAsync(p => p.StudentId == id);
            foreach (var parent in existingParents)
            {
                 _uow.parents.Delete(parent);
            }

            foreach (var parent in std.parentDetails)
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
                    StudentId = id,

                };
                await _uow.parents.Add(parentGuardian);
                
            }

            var existingTransportation = await _uow.transportations.FindOneAsync(t => t.StudentId == id);

            existingTransportation.IsHosteller = std.Transportation.IsHosteller;
            existingTransportation.TransportationMethod = std.Transportation.TransportationMethod;
               

            
            await _uow.transportations.Update(existingTransportation);


            var existingCitizenship = await _uow.citizenshipInfos.FindOneAsync(c => c.StudentId == id);

            existingCitizenship.CitizenshipNumber = std.citizenshipInfo.CitizenshipNumber;
            existingCitizenship.IssueDate = std.citizenshipInfo.IssueDate;
            existingCitizenship.IssueDistrict = std.citizenshipInfo.IssueDistrict;
            //existingCitizenship.CitizenshipCopyPath = std.citizenshipInfo.CitizenshipCopyPath;
                
         
            await _uow.citizenshipInfos.Update(existingCitizenship);



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