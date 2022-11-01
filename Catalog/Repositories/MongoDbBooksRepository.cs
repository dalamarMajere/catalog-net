using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Catalog.Entities;
using Microsoft.AspNetCore.Http.Features;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbBooksRepository : IBookRepository
    {
        private const string DatabaseName = "catalog";
        private const string CollectionName = "books";
        
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly FilterDefinitionBuilder<Book> _filterBuilder = Builders<Book>.Filter;
        
        public MongoDbBooksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _booksCollection = database.GetCollection<Book>(CollectionName);
        }
        
        public IEnumerable<Book> GetBooks()
        {
            return _booksCollection.Find(new BsonDocument()).ToList();
        }

        public Book GetBook(Guid id)
        {
            var filter = _filterBuilder.Eq(book => book.Id, id);
            return _booksCollection.Find(filter).SingleOrDefault();
        }

        public void CreateBook(Book book)
        {
            _booksCollection.InsertOne(book);
        }

        public void UpdateBook(Book book)
        {
            var filter = _filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
            _booksCollection.ReplaceOne(filter, book);
        }

        public void DeleteBook(Book book)
        {
            var filter = _filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
            _booksCollection.DeleteOne(filter);
        }
    }
}