using Autofac;
using GenericRepositories;
using Library.DAL.DbModels;
using Library.DAL.Repositories;
using Library.DTO.ModelsDTO;
using Library.DTO.ServicesDTO;
using Library.DTO.ServicesDTO.AuthorsService;
using Library.DTO.ServicesDTO.BooksService;
using Library.DTO.ServicesViewModel;
using Library.DTO.UnitOfWork;
using Library.DTO.ViewModels;
using System.Data.Entity;

namespace Library.DAL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(BooksService)).As(typeof(IGenericService<BooksDTO, int>));
            builder.RegisterType(typeof(BookRepository)).As(typeof(IGenericRepository<Books, int>));
            builder.RegisterType(typeof(BookViewModelService)).As(typeof(IGenericViewModelService<BookViewModel, int>));
            builder.RegisterType<BookAuthorsUnitOfWorkHandler>().As< IBookAuthorsUnitOfWorkHandler>();
            builder.RegisterType<BookAuthorsUnitOfWork>().As<IBookAuthorsUnitOfWork>();            

            builder.RegisterType(typeof(AuthorsService)).As(typeof(IGenericService<AuthorsDTO, int>));
            builder.RegisterType(typeof(AuthorRepository)).As(typeof(IGenericRepository<Authors, int>));

            builder.RegisterType(typeof(DbModels.Library)).As(typeof(DbContext)).SingleInstance();

        }
    }
}
