using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _booksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(book => book.Id, id);
            return await _booksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateBookAsync(Book book)
        {
            await _booksCollection.InsertOneAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var filter = _filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
            await _booksCollection.ReplaceOneAsync(filter, book);
        }

        public async Task DeleteBookAsync(Book book)
        {
            var filter = _filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
            await _booksCollection.DeleteOneAsync(filter);
        }
    }
}