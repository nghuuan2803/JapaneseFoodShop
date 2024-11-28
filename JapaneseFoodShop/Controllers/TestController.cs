using JapaneseFoodShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JapaneseFoodShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(AppDbContext _db) : ControllerBase
    {
        [HttpGet("hello-world")]
        public async Task<ActionResult> Get()
        {
            return StatusCode(statusCode: 234, new MyClass()
            {
                MyValue = "ABC",
                Succeed = false
            });

        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoleList()
        {
            var roles = await _db.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpPost("get-role")]
        public async Task<IActionResult> GetById([FromBody] string name)
        {
            var roles = _db.Roles.FirstOrDefault(p=>p.Name == name);
            return Ok(roles);
        }
    }

    public class MyClass
    {
        public string MyValue { get; set; } = "Hello";
        public bool Succeed { get; set; } = true;
    }
}
