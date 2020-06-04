using AutoMapper;
using AutoMapper.EquivalencyExpression;
using GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DTO.ServicesDTO
{
    public abstract class GenericService<Entity, EntityDTO, Tkey> : IGenericService<EntityDTO, Tkey> where EntityDTO : class, new()
                                                                                                where Entity : class, new()
    {
        private readonly IGenericRepository<Entity, Tkey> repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity, Tkey> repository)
        {
            this.repository = repository;
            _mapper = GetMapper();
        }
        public virtual IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddCollectionMappers();
                cfg.CreateMap<Entity, EntityDTO>();
                cfg.CreateMap<EntityDTO, Entity>();
            }).CreateMapper();
        }
        public EntityDTO Add(EntityDTO obj)
        {
            Entity dbEntity = _mapper.Map<Entity>(obj);
            repository.Add(dbEntity);
            repository.Save();
            return _mapper.Map<EntityDTO>(dbEntity);
        }

        //public EntityDTO Delete(Tkey id)
        //{
        //    var dbEntity=repository.Get(id);
        //    repository.Delete(id);
        //    repository.Save();
        //    return _mapper.Map<EntityDTO>(dbEntity);
        //}

        public IEnumerable<EntityDTO> FindBy(Expression<Func<EntityDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public EntityDTO Get(Tkey id)
        {
            Entity dbEntity = repository.Get(id);
            EntityDTO Entity = _mapper.Map<EntityDTO>(dbEntity);

            return _mapper.Map<EntityDTO>(dbEntity);
        }

        public IEnumerable<EntityDTO> GetAll()
        {
            IEnumerable<EntityDTO> collection = repository.GetAllData().Select(e => _mapper.Map<EntityDTO>(e));
            return collection;
        }

        public EntityDTO Update(EntityDTO obj)
        {
            Entity dbEntity = _mapper.Map<Entity>(obj);
            repository.Update(dbEntity);
            repository.Save();
            return _mapper.Map<EntityDTO>(dbEntity);
        }
    }
}
