using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetByStudentId(int studentId);
    }
}
