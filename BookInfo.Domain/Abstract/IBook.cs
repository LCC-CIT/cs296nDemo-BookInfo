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
        Book GetBook(string title);
        IQueryable<Book> GetBooks(Author author);
        void DeleteBook(string title);
    }
}
