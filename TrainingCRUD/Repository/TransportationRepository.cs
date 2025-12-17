using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class TransportationRepository : GenericRepository<Transportation>, ITransportation
    {
        private readonly AppDbContext _context;
        public TransportationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
   
}
