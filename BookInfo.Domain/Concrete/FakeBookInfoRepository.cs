using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInfo.Domain.Abstract;
using BookInfo.Domain.Entities;

namespace BookInfo.Domain.Concrete
{
    public class FakeBookInfoRepository : IBook
    {
        List<Book> books = new List<Book>();

        public List<Book> Books { get{ return books;}}

        public void AddBook(Entities.Book book)
        {
 	        books.Add(book);
        }

        public Book GetBook(string title)
        {
            return (from b in books
                   where title == b.Title
                   select b).FirstOrDefault<Book>();
        }

        public IQueryable<Entities.Book> GetBooks(Entities.Author author)
        {
 	        throw new NotImplementedException();
        }

        public void DeleteBook(string title)
        {
 	        throw new NotImplementedException();
        }
    }
}
