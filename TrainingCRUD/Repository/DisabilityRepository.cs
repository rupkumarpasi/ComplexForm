using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class DisabilityRepository : GenericRepository<Disablility>, IDisabilityRepository
    {
        private readonly AppDbContext _context;
        public DisabilityRepository(AppDbContext context) : base(context)
        { }
    }
}
