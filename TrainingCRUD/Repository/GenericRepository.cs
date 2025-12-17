using TrainingCRUD.Models;

using TrainingCRUD.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Update(T entity)
        {
             _dbSet.Update(entity);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Delete(T entity)
        {
             _dbSet.Remove(entity);
           return await _context.SaveChangesAsync()>0;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<int> Count(T entity)
        {
            return await _dbSet.CountAsync();
        }
    }
}
 
