using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<IEnumerable<T?>> GetObjects(Expression<Func<T, bool>> predicate);
        Task<T?> Create(T userobject);
        T? Update(T userobject);
        bool Delete(Expression<Func<T, bool>> predicate);
        Task<bool> ObjectAny(Expression<Func<T, bool>> predicate);
    }
}
