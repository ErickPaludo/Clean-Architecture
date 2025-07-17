using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Ports.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<IEnumerable<T?>> GetObjects(Expression<Func<T, bool>> predicate);
        T? Create(T userobject);
        T? Update(T userobject);
        bool Delete(Expression<Func<T, bool>> predicate);
        bool ObjectAny(Expression<Func<T, bool>> predicate);
    }
}
