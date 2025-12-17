using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class FacultyRepository : GenericRepository<Faculty>, IFaculty
    {
        private readonly AppDbContext _context;
        public FacultyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
    
}
