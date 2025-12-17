using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class ExtraCurricularRepository : GenericRepository<Extracurricular>, IExtracurricular
    {
        public ExtraCurricularRepository(AppDbContext context) : base(context)
        {
        }
    }
}
