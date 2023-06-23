using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate);


        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        Task Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}
