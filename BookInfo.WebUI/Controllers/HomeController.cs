using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookInfo.Domain.Entities;
using BookInfo.Domain.Concrete;
using BookInfo.Domain.Abstract;
using BookInfo.WebUI.Models;

// Written by Brian Bird, 1/27/14
// Demonstration of mock repositories and unit testing of controllers
// for CS296N, Lane Community College

namespace BookInfo.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IBook repo;

        public HomeController()     // called by MVC framework
        {
            // This is the real repository
            repo = new BookInfoRepository();

            // The mock repo is just for integration testing (testing via the browser)
            //repo = new FakeBookInfoRepository();
            /*
            // Mock data
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
            */
            List<Author> authors3 = new List<Author>();
            Author author3 = new Author() { Name = "Carl Skeel", Birthday = new DateTime(1904, 3, 2) };
            Author author4 = new Author() { Name = "Michelle P.", Birthday = new DateTime(1905, 3, 2) };
            authors3.Add(author3);
            authors3.Add(author4);
            Book book3 = new Book() { Title = "The Joys of MVC", Authors = authors3, Year = new DateTime(2014, 1, 1) };
            repo.AddBook(book3);

        }

        public HomeController(IBook bookRepo)   // called from unit test
        {
            repo = bookRepo;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            // TODO: Add Linq queries to get number of authors and books
            int numAuthors = 25;
            int numTitles = 100;
            Book book = repo.GetBook("Cat in the Hat");

            var frontPageInfo = new FrontPageViewModel()
                {
                    Stats = new StatisticsViewModel() { Authors = numAuthors, Titles = numTitles },
                    TheBook = book
                };


            //ViewBag.Authors = numAuthors;
            //ViewBag.Titles = numTitles;
            //var stats = new StatisticsViewModel() { Authors = numAuthors, Titles = numTitles };

            return View(frontPageInfo);
        }

        // invoke a view that shows a book from the database
        // invoke with URL: host/Home/ShowBook/?title=Crime%20and%20Punishment
        public ViewResult ShowBook(string title)
        {
            Book book = repo.GetBook(title);
            return View(book);
        }

        // When a user or a link sends the browser to host/Home/AddBook, the request will be routed here
        [HttpGet]
        public ViewResult AddBook()
        {
            return View();
        }

        // When the user submits the AddBook form, the post will be routed here
        [HttpPost]
        public ViewResult AddBook(Book bookData)
        {
            repo.AddBook(bookData);
            return View("ShowBook", bookData);
        }
    }
}
