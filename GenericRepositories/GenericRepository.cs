using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepositories
{
    public abstract class GenericRepository<T, Tkey> : IGenericRepository<T, Tkey> where T : class, new()
    {
        public DbContext context { get; set; }

        private readonly IDbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public T Add(T obj)
        {
            return dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAllData()
        {
            return dbSet;
        }

        public T Get(Tkey id)
        {
            return dbSet.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            dbSet.AddOrUpdate(obj);
        }
    }
}
