using DotNetMongoDB.Models;
using DotNetMongoDB.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetMongoDB.Pages.Books
{
    public class IndexModel : PageModel
    {
        #region Constructor
        private readonly BookServices _bookServices;

        public IndexModel(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        public List<book> Book { get; set; }

        public async Task OnGet()
        {
            Book = await _bookServices.GetAsync();
        }
    }
}
