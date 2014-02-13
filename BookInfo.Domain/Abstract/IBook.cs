using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInfo.Domain.Entities;

namespace BookInfo.Domain.Abstract
{
    public interface IBook
    {
        void AddBook(Book book);
        Book GetBookByTitle(string title);
        IQueryable<Book> GetBooks();
        void DeleteBook(string title);
    }
}
