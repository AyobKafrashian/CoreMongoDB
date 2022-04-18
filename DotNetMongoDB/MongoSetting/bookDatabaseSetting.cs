using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMongoDB.MongoSetting
{
    public class bookDatabaseSetting
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";

        public string DatabaseName { get; set; } = "bookShopDb";

        public string BooksCollectionName { get; set; } = "books";
    }
}
