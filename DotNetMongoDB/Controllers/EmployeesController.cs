using DotNetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetMongoDB.Controllers
{
    public class EmployeesController : Controller
    {
        #region Constructor
        private readonly BookServices _bookServices;

        public EmployeesController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetEmployeeData()
        {
            var res = await _bookServices.GetAsync();
            return Ok(res);
        }
    }
}
