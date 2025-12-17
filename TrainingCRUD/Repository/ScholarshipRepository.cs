using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class ScholarshipRepository : GenericRepository<Scholarship>, IScholarshipRepository
    {
        private readonly AppDbContext _context;
        public ScholarshipRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
  
}
