using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbBooksRepository : IBookRepository
    {
        private const string DatabaseName = "catalog";
        private const string CollectionName = "books";
        
        private readonly IMongoCollection<Book> _booksCollection;
        
        public MongoDbBooksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _booksCollection = database.GetCollection<Book>(CollectionName);
        }
        
        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}