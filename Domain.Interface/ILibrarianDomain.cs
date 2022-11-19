using Domain.Model;

namespace Domain.Interface
{
    public interface ILibrarianDomain
    {
        Book GetBookByTitle(string title);
        List<Book> GetBooks();
        Book Create(Book book);

        Book Update(string title, Book book);
        void Delete(string title);
    }
}
