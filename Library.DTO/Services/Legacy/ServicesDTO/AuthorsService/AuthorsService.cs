using GenericRepositories;
using Library.DAL.DbModels;
using Library.DTO.ModelsDTO;

namespace Library.DTO.ServicesDTO.AuthorsService
{
    public class AuthorsService : GenericService<Authors, AuthorsDTO, int>
    {
        public AuthorsService(IGenericRepository<Authors, int> repository) : base(repository)
        {
        }
    }
}
