using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetBooks();

        public Book GetBook(Guid id);

        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(Book book);
    }
}