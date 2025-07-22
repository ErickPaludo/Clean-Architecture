using Financ.Application.Repository;
using Financ.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T?>> GetObjects(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<IQueryable<T>> Get()
        {
            var list = await _context.Set<T>().AsNoTracking().ToListAsync();
            return list.AsQueryable();
        }
        public bool ObjectAny(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Any(predicate);
        }
        public async Task<T?> Create(T userobject)
        {
           var objectCreated = await _context.Set<T>().AddAsync(userobject);
           return objectCreated.Entity;
        }
        public T? Update(T userobject)
        {
            _context.Set<T>().Update(userobject);
            return userobject;
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entity = _context.Set<T>().AsNoTracking().Where(predicate).ToList();
                _context.Set<T>().RemoveRange(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
