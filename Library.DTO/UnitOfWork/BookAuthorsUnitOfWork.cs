using Library.DTO.ModelsDTO;
using Library.DTO.ServicesDTO;
using Library.DTO.ServicesViewModel;
using Library.DTO.ViewModels;
using System;
using System.Transactions;

namespace Library.DTO.UnitOfWork
{
    public class BookAuthorsUnitOfWork : IBookAuthorsUnitOfWork
    {
        private bool _disposed;

        public BookAuthorsUnitOfWork(IGenericViewModelService<BookViewModel, int> bookViewModelService)
        {
            BookViewModelService = bookViewModelService;
            _disposed = false;
        }

        public IGenericViewModelService<BookViewModel, int> BookViewModelService { get; }
        public TransactionScope Transaction { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }      

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    Transaction.Dispose();
                }
                _disposed = true;
            }         

            _disposed = true;
        }
        public void Save()
        {
            Transaction.Complete();
        }
    }
}
