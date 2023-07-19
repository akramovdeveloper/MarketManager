using MarketManager.Application.UseCases.Packages.Commands.CreatePackage;
using MarketManager.Application.UseCases.Packages.Commands.UpdatePackage;
using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using MarketManager.Application.UseCases.Packages.Queries.GetPackageById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllPackagesQueryResponse>> GetAllPackages()
        {
            return await _mediator.Send(new GetAllPackagesQuery());
        }

        [HttpGet]
        public async ValueTask<GetPackageByIdQueryResponse> GetPackageById(Guid Id)
        {
            return await _mediator.Send(new GetPackageByIdQuery(Id));
        }

        [HttpPost]
        public async ValueTask<Guid> CreatePackage(CreatePackageCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdatePackage(UpdatePackageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletePackage(UpdatePackageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
