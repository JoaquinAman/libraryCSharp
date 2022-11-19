
using System.Reflection.Metadata.Ecma335;

namespace Domain.Model
{
    public class Library
    {
        Book book1 = new Book();
        Book book2 = new Book();

        public Library()
        {
            book1.ISBN = "ISBN 1";
            book1.Title = "Title 1";
            book2.ISBN = "ISBN 2";
            book2.Title = "Title 2";
            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            ListOfBooks = books;
        }

        public List<Book> ListOfBooks { get; set; }
    }
}
