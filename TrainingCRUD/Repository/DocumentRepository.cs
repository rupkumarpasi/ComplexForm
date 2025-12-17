using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class DocumentRepository : GenericRepository<StudentDocument>, IDocumentRepo
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
