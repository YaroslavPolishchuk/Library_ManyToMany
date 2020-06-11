using AutoMapper;
using Library.DAL.DbModels;
using Library.DTO.ModelsDTO;
using Library.DTO.ViewModels;

namespace Library.DTO.UnitOfWork
{
    public class BookAuthorsUnitOfWorkHandler : IBookAuthorsUnitOfWorkHandler
    {
        private IBookAuthorsUnitOfWork _unitOfWork;

        public BookAuthorsUnitOfWorkHandler(IBookAuthorsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BookViewModel AddBook(BookViewModel viewModel)
        {
            BookViewModel result = null;
            using (_unitOfWork.Transaction=new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                result=_unitOfWork.BookViewModelService.CreateWithChilds(viewModel);
                _unitOfWork.Save();
            }
            return result;
        }
        public BookViewModel RemoveBook(int id)
        {
            BookViewModel result = null;
            using (_unitOfWork.Transaction = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                result = _unitOfWork.BookViewModelService.Delete(id);
                _unitOfWork.Save();
            }
            return result;
        }
    }
}