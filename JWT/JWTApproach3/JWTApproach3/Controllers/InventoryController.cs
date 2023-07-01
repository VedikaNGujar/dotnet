using JWTApproach3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTApproach3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        // GET: api/<InventoryController>
        [HttpGet("GetWorkForAdminAndUser")]
        [Authorize(Roles = "Admin,User")]
        public IEnumerable<string> GetWorkForAdminAndUser()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<InventoryController>
        [HttpGet("GetWorkForOnlyUser")]
        [Authorize(Roles = "User")]
        public IEnumerable<string> GetWorkForOnlyUser()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<InventoryController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] Inventory value)
        {
        }

    }
}
