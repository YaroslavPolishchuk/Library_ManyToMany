using Library.DTO.ModelsDTO;
using Library.DTO.ViewModels;

namespace Library.DTO.UnitOfWork
{
    public interface IBookAuthorsUnitOfWorkHandler
    {
        BookViewModel AddBook(BookViewModel viewModel);
        BookViewModel RemoveBook(int id);
    }
}