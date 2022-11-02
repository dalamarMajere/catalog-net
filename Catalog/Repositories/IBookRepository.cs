using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<Book> GetBookAsync(Guid id);

        public Task CreateBookAsync(Book book);
        public Task UpdateBookAsync(Book book);
        public Task DeleteBookAsync(Book book);
    }
}