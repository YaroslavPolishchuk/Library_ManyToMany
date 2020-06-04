using GenericRepositories;
using Library.DAL.DbModels;
using Library.DTO.ModelsDTO;

namespace Library.DTO.ServicesDTO.BooksService
{
    public class BooksService : GenericService<Books, BooksDTO, int>
    {
        public BooksService(IGenericRepository<Books, int> repository) : base(repository)
        {
        }
    }
}
