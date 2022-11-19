using Domain.Interface;
using Domain.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace Domain.Service
{
    public class LibrarianDomainService : ILibrarianDomain
    {
        MyConnection connection = new MyConnection();
        
        public Book Create(Book book)
        {
            
            string query = "insert into book (isbn, title, category)" + "values('" + book.ISBN + "','" +
                book.Title + "','" + book.Category + "');";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
            return book;
        }
        public void Delete(string title)
        {

            string query = "delete from book where book.title=" + title + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            connection.cerrarConexion();
        }

        public Book GetBookByTitle(string title)
        {
            string query = "select * from book where book.title =" +  title + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            
            Book book = null;
            
            if (myDataReader.Read())
            {
                book = new Book
                {
                    ISBN = myDataReader["isbn"].ToString(),
                    Title = myDataReader["title"].ToString(),
                    Category = myDataReader["category"].ToString()
                };
            }
            connection.cerrarConexion();
            return book;
        }

        public List<Book> GetBooks()
        {
            
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from book;", connection.establecerConexion());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "books");
            
            var booksList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Book
                {
                    ISBN = dataRow.Field<string>("isbn"),
                    Title = dataRow.Field<string>("title"),
                    Category = dataRow.Field<string>("category")
                }).ToList();
            
            connection.cerrarConexion();
            
            return booksList;
        }

        public Book Update(string title, Book book)
        {
            string isbn = book.ISBN;
            string titleStr = book.Title;
            string category = book.Category;
            string query = "UPDATE `book` SET `isbn`='" + isbn + "' , `title`='" + titleStr + "' , `category`='" + 
                category + "' where book.title=" + title  + ";";
            MySqlCommand myCommand = new MySqlCommand(query, connection.establecerConexion());
            myCommand.ExecuteNonQuery();
           
            connection.cerrarConexion();
            return book;
        }
    }
}
