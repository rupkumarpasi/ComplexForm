using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class EnrollmentDetailRepository: GenericRepository<EnrollmentDetail>, IEnrollmentDetail
    {
        public EnrollmentDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
