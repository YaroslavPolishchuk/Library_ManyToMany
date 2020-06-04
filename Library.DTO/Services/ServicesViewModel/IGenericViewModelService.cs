namespace Library.DTO.ServicesViewModel
{
    public interface IGenericViewModelService<TViewModel, TKey>
    {
        TViewModel GetWithChilds(TKey id);
        TViewModel CreateWithChilds(TViewModel obj);
        TViewModel Delete(TKey id);
        TViewModel Update(TViewModel obj);

    }
}