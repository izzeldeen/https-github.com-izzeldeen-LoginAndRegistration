using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Services.IServices
{
    public interface IServices<T> where  T : class
    {
        public void Add(T entity);

        public void Remove(int Id);

        public void RemoveRange(IEnumerable<T> entity);

       IEnumerable<T> GetAll(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       string includeProperties = null
       );

        T GetById(int Id);
    }
}
