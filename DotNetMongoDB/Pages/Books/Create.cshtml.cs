using DotNetMongoDB.Hubs;
using DotNetMongoDB.Models;
using DotNetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace DotNetMongoDB.Pages.Books
{
    public class CreateModel : PageModel
    {
        #region Constructor
        private readonly BookServices _bookServices;
        private readonly IHubContext<SignalRServer> _signalR;

        public CreateModel(BookServices bookServices, IHubContext<SignalRServer> signalR)
        {
            _bookServices = bookServices;
            _signalR = signalR;
        }
        #endregion

        [BindProperty]
        public book Book { get; set; }

        public async Task<IActionResult> OnPost()
        {
            Book.CreateDate = DateTime.Now;
            await _bookServices.CreateAsync(Book);
            
            //بعد از انجام عملیات ذخیره سازی این متد باید فراخانی شود
            await _signalR.Clients.All.SendAsync("LoadProdData");
            
            return Redirect("/Books/Index");
        }
    }
}
