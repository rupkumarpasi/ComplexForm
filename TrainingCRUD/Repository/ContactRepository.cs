using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class ContactRepository: GenericRepository<Contact>, IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context) : base(context)
        { }
    }
}
