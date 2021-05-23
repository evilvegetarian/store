using System.Collections.Generic;

namespace Store
{
    public interface IBookRepository
    {

        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitleOrAuthor(string titlePartOrAuthor);
        Book GetById(int id);
        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
