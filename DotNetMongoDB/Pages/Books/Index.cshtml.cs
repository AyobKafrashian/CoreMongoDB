using DotNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DotNetMongoDB.Pages.Books
{
    public class IndexModel : PageModel
    {

        public List<book> Book { get; set; }

        public void OnGet()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _context = client.GetDatabase("bookShopDb");
            var _bookServes = _context.GetCollection<book>("books");

            Book = _bookServes.Find(t => true).SortByDescending(c => c.CreateDate).ToList();

        }
    }
}
