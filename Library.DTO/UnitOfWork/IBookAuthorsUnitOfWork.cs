using Library.DTO.ModelsDTO;
using Library.DTO.ServicesDTO;
using Library.DTO.ServicesViewModel;
using Library.DTO.ViewModels;
using System.Transactions;

namespace Library.DTO.UnitOfWork
{
    public interface IBookAuthorsUnitOfWork : IUnitOfWork
    {
        IGenericViewModelService<BookViewModel, int> BookViewModelService { get; }
        TransactionScope Transaction { get; set; }
    }
}