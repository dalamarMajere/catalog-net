using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await Task.FromResult(_books);
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var book = _books.SingleOrDefault(book => book.Id == id);
            return await Task.FromResult(book);
        }

        public async Task CreateBookAsync(Book book)
        {
            _books.Add(book);
            
            await Task.CompletedTask;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var index = FindIndexOfBook(book);
            
            _books[index] = book;
            
            await Task.CompletedTask;
        }
        
        public async Task DeleteBookAsync(Book book)
        {
            var index = FindIndexOfBook(book);

            _books.RemoveAt(index);
            await Task.CompletedTask;
        }

        private int FindIndexOfBook(Book book)
        {
            return _books.FindIndex(existingBook => existingBook.Id == book.Id);
        }
    }
}