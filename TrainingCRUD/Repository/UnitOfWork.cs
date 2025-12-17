using TrainingCRUD.Data;

namespace TrainingCRUD.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

      public IStudentRepository students { get; }

        public IAddressRepository addresses { get; }
        public IPersonalRepository personals { get; }
        public IContactRepository contacts { get; }
        public IDisabilityRepository disabilities { get; }

      public  IParentsDetails parents { get; }
        public IAcademicHistory academics { get; }
        public IEnrollmentDetail enrollments { get; }

        public IFinancialRepository financials { get; }
        public IScholarshipRepository scholarships { get; }
        public ITransportation transportations { get; }
        public ICitizenshipsRepo citizenshipInfos { get; }
        public IExtracurricular extracurriculars { get; }
        public IFaculty faculties { get; }
        public IDocumentRepo documentinfos { get; }
        public UnitOfWork(AppDbContext context) {
            _context = context;
        students = new StudentRepository(_context);
            personals = new PersonalRepository(_context);
            contacts = new ContactRepository(_context);
            disabilities = new DisabilityRepository(_context);
            addresses = new AddressRepository(_context);
            parents = new ParentsDetailsRepository(_context);
            academics = new AcademicRepository(_context);
            enrollments = new EnrollmentDetailRepository(_context);
            financials = new FinancialRepository(_context);
            scholarships = new ScholarshipRepository(_context);
            transportations = new TransportationRepository(_context);
            citizenshipInfos = new CitizenShipRepo(_context);
            faculties = new FacultyRepository(_context);
            documentinfos = new DocumentRepository(_context);
            extracurriculars = new ExtraCurricularRepository(_context);

        }


        public async Task ExecuteTransactionAsync(Func<Task> Action,CancellationToken cancellationToken=default)
        {
            //cancellationToken -if we need to cancel the operation in between , default- no cancellation but it can be provided if needed
            using var Transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            // using var - to dispose the transaction object after use
            // BeginTransactionAsync - to start a new transaction asynchronously and hold the transaction object until committed or rolled back
            try
            {
                await Action();
                // this is the whole task that we are passing from the service layer
                await _context.SaveChangesAsync(cancellationToken);
                //all are saved in a single transaction
                await Transaction.CommitAsync(cancellationToken);
                // commit the transaction if all operations are successful
            }
            catch
            {
                await Transaction.RollbackAsync(cancellationToken);
                // rollback the transaction if any operation fails
                throw;
                // rethrow the exception to be handled by the calling code
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> commit(CancellationToken cancellationToken= default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
