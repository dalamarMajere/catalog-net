using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book
            {
                Id = Guid.NewGuid(), Name = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling",
                PageCount = 223
            },
            new Book
            {
                Id = Guid.NewGuid(), Name = "Harry Potter and the Chamber of Secrets", Author = "J. K. Rowling",
                PageCount = 251
            },
            new Book
            {
                Id = Guid.NewGuid(), Name = "Harry Potter and the Prisoner of Azkaban", Author = "J. K. Rowling",
                PageCount = 317
            }
        };

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBook(Guid id)
        {
            return _books.SingleOrDefault(book => book.Id == id);
        }

        public void CreateBook(Book book)
        {
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var index = FindIndexOfBook(book);
            
            _books[index] = book;
        }

        private int FindIndexOfBook(Book book)
        {
            return _books.FindIndex(existingBook => existingBook.Id == book.Id);
        }

        public void DeleteBook(Book book)
        {
            var index = FindIndexOfBook(book);

            _books.RemoveAt(index);
        }
    }
}