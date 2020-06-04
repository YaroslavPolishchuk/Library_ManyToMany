using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepositories
{
    public interface IGenericRepository<T, Tkey> where T : class, new()
    {
        IEnumerable<T> GetAllData();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(Tkey id);
        T Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Save();
    }
}
