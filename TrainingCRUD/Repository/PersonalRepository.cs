using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class PersonalRepository: GenericRepository<PersonalDetail>, IPersonalRepository
    {
        private readonly AppDbContext _context;
        public PersonalRepository(AppDbContext context) : base(context)
        { }
           
    }
}
