using DotNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System;

namespace DotNetMongoDB.Pages.Books
{
    public class CreateModel : PageModel
    {
        //step 1 : Download MongoDB
        //step 2 : Download MongoDb compass comminity
        //step 3 : install MongoDB and open to C:\Program Files\MongoDB\Server\3.4\bin and Open cmd
        //step 4 : type mongod and type mongo

        [BindProperty]
        public book Book { get; set; }

        public IActionResult OnPost()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _context = client.GetDatabase("bookShopDb");
            var _bookServes = _context.GetCollection<book>("books");

            Book.CreateDate = DateTime.Now;

            //Add To Database
            _bookServes.InsertOne(Book);


            return Redirect("/Books/Index");
        }
    }
}
