using GenericRepositories;
using Library.DAL.DbModels;
using System;
using System.Data.Entity;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Authors, int>
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }
    }
}
