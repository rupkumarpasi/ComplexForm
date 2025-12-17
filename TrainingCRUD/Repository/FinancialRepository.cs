using TrainingCRUD.Models;
using TrainingCRUD.Data;

namespace TrainingCRUD.Repository
{
    public class FinancialRepository : GenericRepository<Financial>,IFinancialRepository
    {
       
        public FinancialRepository(AppDbContext context) : base(context)
        { }
    }
    
}
