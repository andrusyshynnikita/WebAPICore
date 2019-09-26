using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.DAL.Interfaces;

namespace WebAPICore.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly WebAPICoreContext _context;
        public BaseRepository(WebAPICoreContext webAPICoreContext)
        {
            _context = webAPICoreContext;
            _dbSet = _context.Set<TEntity>();

        }
        public Task<TEntity> GetItem(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task Delete(int id)
        {
            var item = await GetItem(id);
            _dbSet.Remove(item);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
