using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.DAL.Interfaces;

namespace WebAPICore.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly WebAPICoreContext _context;


        protected DbSet<TEntity> DbSet { get; private set; }
        public BaseRepository(WebAPICoreContext webAPICoreContext)
        {
            _context = webAPICoreContext;
            DbSet = _context.Set<TEntity>();

        }
        public Task<TEntity> GetItem(int id)
        {
            return DbSet.FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task Delete(int id)
        {
            var item = await GetItem(id);
            DbSet.Remove(item);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
