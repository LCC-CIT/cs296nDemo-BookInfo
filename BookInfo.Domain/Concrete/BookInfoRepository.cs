using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInfo.Domain.Abstract;
using BookInfo.Domain.Entities;

namespace BookInfo.Domain.Concrete
{
    public class BookInfoRepository : IBook
    {
        public void AddBook(Entities.Book book)
        {
            var db = new BookInfoDbContext();
            db.Books.Add(book);
            db.SaveChanges();

        }

        public Entities.Book GetBookByTitle(string title)
        {
            var db = new BookInfoDbContext();
            return (from b in db.Books
                    where b.Title == title
                    select b).FirstOrDefault();
        }

        public IQueryable<Entities.Book> GetBooks()
        {
            var db = new BookInfoDbContext();
            return db.Books;
        }

        public void DeleteBook(string title)
        {
            throw new NotImplementedException();
        }
    }

    public class BookInfoDbContext : DbContext 
    { 
        public DbSet<Book> Books { get; set; } 
        public DbSet<Author> Authors { get; set; } 
    } 

}
