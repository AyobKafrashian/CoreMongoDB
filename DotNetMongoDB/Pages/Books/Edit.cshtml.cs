using DotNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace DotNetMongoDB.Pages.Books
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public book Book { get; set; }

        public void OnGet(string Id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _context = client.GetDatabase("bookShopDb");
            var _bookServes = _context.GetCollection<book>("books");

            Book = _bookServes.Find(e => e.Id == Id).Single();
        }

        public IActionResult OnPost(string Id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _context = client.GetDatabase("bookShopDb");
            var _bookServes = _context.GetCollection<book>("books");
            var oldBook = _bookServes.Find(e => e.Id == Id).Single();

            Book.CreateDate = oldBook.CreateDate;

            _bookServes.ReplaceOne(c => c.Id == Book.Id, Book);

            return Redirect("/Books/Index");
        }
    }
}
