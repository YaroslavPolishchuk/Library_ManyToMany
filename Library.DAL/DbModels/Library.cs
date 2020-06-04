namespace Library.DAL.DbModels
{
    using System.Data.Entity;

    public partial class Library : DbContext
    {
        public Library()
            : base("name=Library")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("BooksAuthors").MapLeftKey("AuthorId").MapRightKey("BookId"));
        }
    }
}
