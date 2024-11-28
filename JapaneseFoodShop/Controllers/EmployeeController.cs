using JapaneseFoodShop.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace JapaneseFoodShop.Controllers
{
    public class EmployeeController(IEmployeeService _service) : Controller
    {
        [Route("employees")]
        public async Task<IActionResult> Index(int? size, int? num)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
