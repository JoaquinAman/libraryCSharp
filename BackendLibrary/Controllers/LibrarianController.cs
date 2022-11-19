using Microsoft.AspNetCore.Mvc;
using Domain.Interface;
using Domain.Model;

namespace BackendLibrary.Controllers
{
    [Route("api/v1/librarians")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianDomain librarianDomain;
        public LibrarianController(ILibrarianDomain librarianDomain)
        {
            this.librarianDomain = librarianDomain;
        }
        [HttpGet]
        public List<Book> GetBooks()
        {
            return librarianDomain.GetBooks();
        }
        [HttpGet]
        [Route("{ISBN}")]
        public Book GetBookByTitle(string title)
        {
            return librarianDomain.GetBookByTitle(title);
        }
        [HttpPost]
        public Book CreateBook(Book book)
        {
            return librarianDomain.Create(book);
        }
        [HttpPut]
        public Book UpdateBook(string title, Book book)
        {
            return librarianDomain.Update(title, book);
        }
        [HttpDelete]
        public void DeleteBook(string title)
        {
            librarianDomain.Delete(title);
        }
    }
}
