using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICore.DAL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetItem(int id);

        Task Create(TEntity item);

        Task Update(TEntity item);

        Task Delete(int id);

    }
}
