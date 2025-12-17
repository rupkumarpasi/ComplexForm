using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class ParentsDetailsRepository: GenericRepository<ParentGuardianDetails>, IParentsDetails
    {
        public ParentsDetailsRepository(AppDbContext context) : base(context)
        {
        }
    }
   
}
