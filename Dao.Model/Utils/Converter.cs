using Domain.Model.Request;

namespace Dao.Model.Utils
{
    public class Converter
    {
        public BookDao toBookDao(Book book)
        {
            return new BookDao
            {
                Category = book.Category,
                Title = book.Title,
            };
        }
        public Book toBook(BookDao bookDao)
        {
            return new Book
            {
                Category = bookDao.Category,
                Title = bookDao.Title,
            };
        }
        public ClientDao toClientDao(Client client)
        {
            return new ClientDao
            {
                Id = client.Id,
                Name = client.Name,
            };
        }
        public Client toClient(ClientDao clientDao)
        {
            return new Client
            {
                Id = clientDao.Id,
                Name = clientDao.Name,
            };
        }
    }
}
