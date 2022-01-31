using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        TEntity FindById(int id);
        IQueryable<TEntity> Query();
        Task RemoveAsync(TEntity item);
        Task UpdateAsync(TEntity item);
    }
}
