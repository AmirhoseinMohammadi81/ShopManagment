using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<TKey,T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(TKey id)
        {
            if (_context.Entry(GetBy(id)).State==EntityState.Detached)
            {
                _context.Attach(GetBy(id));
            }

            _context.Remove(GetBy(id));
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public T GetBy(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
