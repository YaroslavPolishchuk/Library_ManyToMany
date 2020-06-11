using AutoMapper;
using GenericRepositories;
using Library.DAL.DbModels;
using Library.DTO.ModelsDTO;
using Library.DTO.ViewModels;
using System.Data.Entity;
using System.Linq;

namespace Library.DTO.ServicesViewModel
{
    public class BookViewModelService : GenericViewModelService<Books, BookViewModel, int>
    {
        private readonly IGenericRepository<Authors, int> repositoryAuthors;

        public BookViewModelService(IGenericRepository<Books, int> repository, IGenericRepository<Authors, int> repositoryAuthors) : base(repository)
        {
            _mapper = GetMapper();
            this.repositoryAuthors = repositoryAuthors;
        }

        public override BookViewModel CreateWithChilds(BookViewModel obj)
        {
            Books book = _mapper.Map<Books>(obj);
            _repository.Add(book);
            _repository.Save();
            Books entityBook = _repository.GetAllData().SingleOrDefault(b => b.BookId == book.BookId);
            foreach (AuthorsDTO author in obj.Authors)
            {
                entityBook.Authors.Add(repositoryAuthors.GetAllData().SingleOrDefault(a => a.AuthorId == author.AuthorId));
            }
            _repository.Save();
            return _mapper.Map<BookViewModel>(book);
        }

        public override BookViewModel Delete(int id)
        {
            Books model = _repository.Get(id);
            DbSet<Books> books = _repository.GetAllData() as DbSet<Books>;
            Books removed = books.Include(a => a.Authors).Where(e => e.BookId == id).FirstOrDefault();
            _repository.Delete(removed);
            _repository.Save();
            return _mapper.Map<BookViewModel>(model);
        }

        protected override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Books, BookViewModel>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(s => s.BookName))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(s => s.PublishYear))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(s => s.Authors.Select(e => new AuthorsDTO
                {
                    AuthorId = e.AuthorId,
                    AuthorName = e.AuthorName,
                    AuthorLastName = e.AuthorLastName
                })));
                cfg.CreateMap<BookViewModel, Books>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(s => s.BookName))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(s => s.PublishYear))
                .ForMember(dest => dest.Authors, opt => opt.Ignore());
            }).CreateMapper();
        }
    }
}
