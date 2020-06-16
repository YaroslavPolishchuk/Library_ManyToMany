using GenericRepositories;
using Library.DAL.DbModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Library.DAL.Repositories
{
    public class BookRepository : GenericRepository<Books, int>
    {
        private readonly DbSet<Books> dbSet;

        public BookRepository(DbContext context) : base(context)
        {
            dbSet = context.Set<Books>();
        } 
    }
}
