using Microsoft.EntityFrameworkCore;
using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class AddressRepository: GenericRepository<Address>, IAddressRepository
    {

        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<List<Address>> GetByStudentId(int studentId)
        {
            return await _context.addresses
                .Where(a => a.StudentId == studentId)
                .ToListAsync();
        }

    }
}
