using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookInfo.Domain.Concrete;
using BookInfo.Domain.Entities;
using System.Collections.Generic;

namespace BookInfo.UnitTests
{
    [TestClass]
    public class BookRepoTests
    {
        [TestMethod]
        public void AddBookTest()
        {
            // Arrange
            var target = new FakeBookInfoRepository();
          /*  List<Author> authors = new List<Author>();
            Author author = new Author() { Name = "Dr. Seuss", 
                Birthday = new DateTime(1904, 3, 2) };
            authors.Add(author);
            Book book = new Book() { Title = "Cat in Hat", Authors= authors, 
                Year = new DateTime(1957, 1, 1) };
            */
            Book book = new Book();
            // Act
            target.AddBook(book);

            // Assert
            Assert.AreSame(book, target.Books[0]);
        }

        [TestMethod]
        public void GetBookTest()
        { 
            // Arrange
            var target = new FakeBookInfoRepository();
            Book book = new Book() { Title = "Crime and Punishment" };
            target.AddBook(book);
            Book book2 = new Book() { Title = "War and Peace" };
            target.AddBook(book2);
            Book book3 = new Book() { Title = "Brothers Karamazov" };
            target.AddBook(book3);

            //Act
            Book retrievedBook = target.GetBookByTitle("War and Peace");

            // Assert
            Assert.AreSame(retrievedBook, book2);
        }
    }
}
