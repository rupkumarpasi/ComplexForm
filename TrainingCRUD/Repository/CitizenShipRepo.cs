using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class CitizenShipRepo : GenericRepository<CitizenshipInfo>, ICitizenshipsRepo
    {
        public CitizenShipRepo(AppDbContext context) : base(context)
        {
        }
    }
   
}
