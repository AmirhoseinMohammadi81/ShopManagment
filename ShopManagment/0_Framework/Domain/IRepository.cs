using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey,T> where T : class
    {
        void Create(T entity);
        IEnumerable<T> Get();
        T GetBy(TKey id);
        void Delete(TKey id);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();

    }
}
