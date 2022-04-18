using DotNetMongoDB.Models;
using DotNetMongoDB.MongoSetting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetMongoDB.Services
{
    public class BookServices
    {
        private readonly IMongoCollection<book> _bookCollection;

        public BookServices(
            IOptions<bookDatabaseSetting> bookDataBaseSetting)
        {
            var mongoClient = new MongoClient(
                bookDataBaseSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookDataBaseSetting.Value.DatabaseName);

            _bookCollection = mongoDatabase.GetCollection<book>(
                    bookDataBaseSetting.Value.BooksCollectionName);
        }

        public async Task<List<book>> GetAsync() =>
            await _bookCollection.Find(_ => true).SortByDescending(c => c.CreateDate).ToListAsync();

        public async Task<book?> GetAsync(string id) =>
            await _bookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(book newBook) =>
            await _bookCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, book updatedBook) =>
            await _bookCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _bookCollection.DeleteOneAsync(x => x.Id == id);
    }
}