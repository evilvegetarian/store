using System;

namespace Store
{
    public class BookSevice
    {
        private readonly IBookRepository bookRepository;

        public BookSevice(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book[] GetAllbyQuery (string query)
        {
            if (Book.IsIsbn(query))
                return bookRepository.GetAllByIsbn(query);

            return bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}
