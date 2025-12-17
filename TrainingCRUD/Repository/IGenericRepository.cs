namespace TrainingCRUD.Repository
{
    public interface IGenericRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAllAsync();
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> GetById(int id);

        Task<int> Count(T entity);
    }
}
