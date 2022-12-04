using Microsoft.AspNetCore.Mvc;
using Domain.Interface;
using Domain.Model;

namespace BackendLibrary.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookDomain librarianDomain;
        public BookController(IBookDomain librarianDomain)
        {
            this.librarianDomain = librarianDomain;
        }
        [HttpGet]
        public List<Book> GetBooks()
        {
            return librarianDomain.GetBooks();
        }
        [HttpGet]
        [Route("{title}")]
        public Book GetBookByTitle(string title)
        {
            return librarianDomain.GetBookByTitle(title);
        }
        [HttpPost]
        public CreateBookRequest CreateBook(CreateBookRequest book)
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
