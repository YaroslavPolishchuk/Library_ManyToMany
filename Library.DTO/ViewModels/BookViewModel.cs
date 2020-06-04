using Library.DTO.ModelsDTO;
using System.Collections.Generic;

namespace Library.DTO.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }
        public IEnumerable<AuthorsDTO> Authors { get; set; }
    }
}
