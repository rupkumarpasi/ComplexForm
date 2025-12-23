using System.Linq.Expressions;

namespace TrainingCRUD.Repository
{
    public interface IGenericRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAllAsync();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);

        Task<int> Count(T entity);
    }
}
