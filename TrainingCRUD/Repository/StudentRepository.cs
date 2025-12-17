using Microsoft.EntityFrameworkCore;
using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context) {
            _context = context;
        }
        public async Task<Student> GetStudentWithDetail(int id)
        {
            var student = await _context.students
                   .Include(s => s.personalDetail)
               .Include(s => s.contact)
               .Include(s => s.disablility)
               .Include(s => s.addresses)
               .Include(s => s.parentDetails)
               .Include(s => s.AcademicHistories)
               .Include(s => s.Financial)
               .ThenInclude(s=>s.scholarship)
               .Include(s => s.CitizenshipInfo)
               .Include(s => s.Extracurriculars)
               .Include(s => s.Faculty)
               .ThenInclude(e => e.EnrollmentDetails)
               .Include(s => s.Documents)
               .Include(s => s.Transportation)
               .FirstOrDefaultAsync(s => s.Id == id);


            return student;
        }

        public async Task<List<Student>> GetAllStudentsWithDetail()
        {
            var students = await _context.students
               .Include(s => s.personalDetail)
               .Include(s => s.contact)
               .Include(s => s.disablility)
               .Include(s => s.addresses)
               .Include(s=>s.parentDetails)
               .Include(s=>s.AcademicHistories)
               .Include(s => s.Financial)
               .ThenInclude(s=>s.scholarship)
               .Include(s => s.CitizenshipInfo)
               .Include(s => s.Extracurriculars)
               .Include(s => s.Faculty)
               .ThenInclude(e => e.EnrollmentDetails)
               .Include(s => s.Documents)
               .Include(s => s.Transportation)
               
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
               .ToListAsync();
            return students;
        }
    }

   
    }

