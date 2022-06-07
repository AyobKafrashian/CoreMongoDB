using DotNetMongoDB.Models;
using DotNetMongoDB.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Threading.Tasks;
using DotNetMongoDB.Hubs;

namespace DotNetMongoDB.Pages.Books
{
    public class EditModel : PageModel
    {
        #region Constructor
        private readonly BookServices _bookServices;
        private readonly IHubContext<SignalRServer> _signalR;

        public EditModel(BookServices bookServices, IHubContext<SignalRServer> signalR)
        {
            _bookServices = bookServices;
            _signalR = signalR;
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

            //بعد از انجام عملیات ذخیره سازی این متد باید فراخانی شود
            await _signalR.Clients.All.SendAsync("LoadProdData");

            return Redirect("/Books/Index");
        }
    }
}
