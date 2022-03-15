using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoDB.Models
{
    public class BookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";

        public string DatabaseName { get; set; } = "book";

        public string BooksCollectionName { get; set; } = "books";
    }
}
