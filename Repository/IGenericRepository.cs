using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IQueryable<TEntity> Query();
        Task RemoveAsync(TEntity item);
        void Update(TEntity item);
    }
}
