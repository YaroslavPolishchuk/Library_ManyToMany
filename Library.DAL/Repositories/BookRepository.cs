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

        //public override void Delete(Books obj)
        //{
        //    foreach (var author in obj.Authors.ToList())
        //    {
        //        obj.Authors.Remove(author);                
        //    }
        //    dbSet.Remove(obj);
        //}       

        public override void Update(Books obj)
        {
            List<Authors> tmp = new List<Authors>(obj.Authors);
            obj.Authors.Clear();
            tmp.ForEach(x => obj.Authors.Add(x));
            //foreach (var author in obj.Authors.ToList())
            //{
            //    obj.Authors.Remove(author);
            //}
            dbSet.AddOrUpdate(obj);

        }
    }
}
