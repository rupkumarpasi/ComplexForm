using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class AcademicRepository: GenericRepository<AcademicHistory>,IAcademicHistory
    {
        public AcademicRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
