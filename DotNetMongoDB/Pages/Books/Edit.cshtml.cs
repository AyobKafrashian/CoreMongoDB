using DotNetMongoDB.Models;
using DotNetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DotNetMongoDB.Pages.Books
{
    public class EditModel : PageModel
    {
        #region Constructor
        private readonly BookServices _bookServices;

        public EditModel(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        [BindProperty]
        public book Book { get; set; }

        public async Task OnGet(string Id)
        {
            Book = await _bookServices.GetAsync(Id);
        }

        public async Task<IActionResult> OnPost(string Id)
        {
            var oldBook = await _bookServices.GetAsync(Id);
            Book.CreateDate = oldBook.CreateDate;
            await _bookServices.UpdateAsync(Id, Book);

            return Redirect("/Books/Index");
        }
    }
}
