using TrainingCRUD.Dto;
using TrainingCRUD.Models;

namespace TrainingCRUD.Service
{
    public interface IStudentService
    {
       Task<IEnumerable<Student>> GetAllStudents();
         Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(StudentDto student);
        Task UpdateStudent(int id, UpdateStudentDto student);
        Task<bool> DeleteStudent(int id);
    }
}
