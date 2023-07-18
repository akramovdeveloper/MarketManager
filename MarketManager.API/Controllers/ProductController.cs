using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseCore<List<Product>>>> GetAll()
        {
            return Ok();
        }
    }
}
