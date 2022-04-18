using DotNetMongoDB.Models;
using DotNetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace DotNetMongoDB.Pages.Books
{
    public class CreateModel : PageModel
    {
        //step 1 : Download MongoDB
        //step 2 : Download MongoDb compass comminity
        //step 3 : install MongoDB and open to C:\Program Files\MongoDB\Server\3.4\bin and Open cmd
        //step 4 : type mongod and type mongo

        #region Constructor
        private readonly BookServices _bookServices;

        public CreateModel(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        [BindProperty]
        public book Book { get; set; }

        public async Task<IActionResult> OnPost()
        {
            Book.CreateDate = DateTime.Now;
            await _bookServices.CreateAsync(Book);
            return Redirect("/Books/Index");
        }
    }
}
