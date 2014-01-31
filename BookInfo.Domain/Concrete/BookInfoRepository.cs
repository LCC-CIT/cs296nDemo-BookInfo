using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInfo.Domain.Abstract;

namespace BookInfo.Domain.Concrete
{
    public class BookInfoRepository : IBook
    {
        public void AddBook(Entities.Book book)
        {
            throw new NotImplementedException();
        }

        public Entities.Book GetBook(string title)
        {
            throw new NotImplementedException();
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
