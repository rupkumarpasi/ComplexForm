using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>

    {
        Task<Student> GetStudentWithDetail(int id);
        Task<List<Student>> GetAllStudentsWithDetail();
    }
}
