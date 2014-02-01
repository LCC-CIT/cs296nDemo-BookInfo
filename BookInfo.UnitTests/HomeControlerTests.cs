using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookInfo.Domain.Concrete;
using BookInfo.Domain.Entities;
using BookInfo.WebUI.Controllers;

namespace BookInfo.UnitTests
{
    [TestClass]
    public class HomeControlerTests
    {
        [TestMethod]
        public void ShowBookTest()
        {
            // Arrange
            var repo = new FakeBookInfoRepository();
            Book book = new Book() { Title = "Crime and Punishment" };
            repo.AddBook(book);
            Book book2 = new Book() { Title = "War and Peace" };
            repo.AddBook(book2);
            Book book3 = new Book() { Title = "Brothers Karamazov" };
            repo.AddBook(book3);
            HomeController target = new HomeController(repo);

            // Act
            // Call the controller method that gets a book from the reposiotry and
            // get the Model property out of the view it returns
            Book returnedBook = (Book)target.ShowBook("War and Peace").Model;

            // Assert
            Assert.AreSame(book2, returnedBook);
        }
    }
}
