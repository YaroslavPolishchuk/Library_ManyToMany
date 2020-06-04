using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Library.DTO.ServicesDTO
{
    public interface IGenericService<TBEntity, Tkey> where TBEntity : class, new()
    {
        IEnumerable<TBEntity> GetAll();
        IEnumerable<TBEntity> FindBy(Expression<Func<TBEntity, bool>> predicate);
        TBEntity Get(Tkey id);
        TBEntity Add(TBEntity obj);
        TBEntity Update(TBEntity obj);
        //TBEntity Delete(Tkey id);
    }
}
