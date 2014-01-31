using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookInfo.Domain.Entities;
using BookInfo.Domain.Concrete;
using BookInfo.Domain.Abstract;

// Written by Brian Bird, 1/27/14
// Demonstration of mock repositories and unit testing of controllers
// for CS296N, Lane Community College

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        IBook repo;

        public HomeController()     // called by MVC framework
        {
            //repo = new BookInfoRepository();
            // Just for integration testing
            repo = new FakeBookInfoRepository();
            
            List<Author> authors1 = new List<Author>();
            Author author1 = new Author() { Name = "Dostoyevsky", Birthday = new DateTime(1821, 7, 11) };
            authors1.Add(author1);
            Book book1 = new Book() { Title = "Crime and Punishment", Authors=authors1, Year= new DateTime(1866, 1, 1)};
            repo.AddBook(book1);
            
            List<Author> authors2 = new List<Author>();
            Author author2 = new Author(){Name = "Dr. Seuss", Birthday = new DateTime(1904, 3, 2)};
            authors2.Add(author2);
            Book book2 = new Book(){Title = "Cat in the Hat", Authors = authors2, Year = new DateTime(1957, 1, 1)};
            repo.AddBook(book2);
        }

        public HomeController(IBook bookRepo)   // called from unit test
        {
            repo = bookRepo;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        // invoke a view that shows a book from the database
        // invoke with URL: localhost/Home/ShowBook/?title=Crime%20and%20Punishment
        public ViewResult ShowBook(string title)
        {
            Book book = repo.GetBook(title);
            return View(book);
        }

    }
}
