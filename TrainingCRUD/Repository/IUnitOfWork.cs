using Microsoft.EntityFrameworkCore;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        
        IStudentRepository students { get;}
        IAddressRepository addresses { get; }

        IPersonalRepository personals { get; }   
        IContactRepository contacts { get; }
        IDisabilityRepository disabilities { get; }

        IParentsDetails parents { get; }
        IAcademicHistory academics { get; }
        IEnrollmentDetail enrollments { get; }

        IFinancialRepository financials { get; }
        IScholarshipRepository scholarships { get; }
        ITransportation transportations { get; }
        ICitizenshipsRepo citizenshipInfos { get; }
        IExtracurricular extracurriculars { get; }
        IFaculty faculties { get; }
        IDocumentRepo documentinfos { get; }
       
        Task<int> commit(CancellationToken cancellationToken=default);
        Task ExecuteTransactionAsync( Func<Task> action,CancellationToken cancellationToken = default);
       
    }
}
