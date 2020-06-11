using AutoMapper;
using GenericRepositories;

namespace Library.DTO.ServicesViewModel
{
    public abstract class GenericViewModelService<TEntity, TViewModel, TKey> : IGenericViewModelService<TViewModel, TKey> where TEntity : class, new()
    {
        protected IGenericRepository<TEntity, TKey> _repository;
        protected IMapper _mapper;

        protected GenericViewModelService(IGenericRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        protected abstract IMapper GetMapper();

        public TViewModel GetWithChilds(TKey id)
        {
            return _mapper.Map<TEntity, TViewModel>(_repository.Get(id));
        }
        public abstract TViewModel CreateWithChilds(TViewModel obj);

        public abstract TViewModel Delete(TKey id);

        public abstract TViewModel Update(TViewModel obj);
        
    }
}
