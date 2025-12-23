using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingCRUD.Data;
using TrainingCRUD.Models;

namespace TrainingCRUD.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
      
        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _dbSet.ToListAsync(); }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);

           
            return entity; 
        }

        public async Task Update(T entity)
        {
             _dbSet.Update(entity);
            
        }

        public async Task Delete(T entity)
        {
             _dbSet.Remove(entity);
          
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> Count(T entity)
        {
            return await _dbSet.CountAsync();
        }
    }
}
 
