using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
