﻿using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Services.Services
{
    public class Services<T> : IServices<T> where T : class
    {
        private readonly StoreContext _context;
        internal DbSet<T> dbSet;

        public Services(StoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity) => dbSet.Add(entity);
        public void Remove(int Id) => Remove(Id);
        public void RemoveRange(IEnumerable<T> entity) => dbSet.RemoveRange(entity);


        public T GetById(int Id) => dbSet.Find(Id);
        

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();

        }

    }
}
