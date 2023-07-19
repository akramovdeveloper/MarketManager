using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<string> GetAll()
        {
            await _mediator.Send(new GetAllPackagesQuery());
        }
    }
}
