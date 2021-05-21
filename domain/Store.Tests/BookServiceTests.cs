using Moq;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByISbn()
        {
            var bookRepository = new Mock<IBookRepository>();

            bookRepository.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepository.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });
            var bookServices = new BookSevice(bookRepository.Object);

            var validIsbn = "ISBN 12345-67890";

            var actual = bookServices.GetAllbyQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByTitleOrAuthor()
        {
            var bookRepository = new Mock<IBookRepository>();

            bookRepository.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepository.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });
            var bookServices = new BookSevice(bookRepository.Object);

            var invalidIsbn = "12345-67890";

            var actual = bookServices.GetAllbyQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

    }
}
