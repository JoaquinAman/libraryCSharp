using Domain.Model;

namespace Domain.Interface
{
    public interface IBookDomain
    {
        Book GetBookByTitle(string title);
        List<Book> GetBooks();
        CreateBookRequest Create(CreateBookRequest book);

        Book Update(string title, Book book);
        void Delete(string title);
    }
}
