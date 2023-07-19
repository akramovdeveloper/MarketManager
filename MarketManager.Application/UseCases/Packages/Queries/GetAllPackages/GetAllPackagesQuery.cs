using AutoMapper;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;

public record GetAllPackagesQuery : IRequest<GetAllPackagesQueryResponse>;

public class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, GetAllPackagesQueryResponse>
{
    public Task<GetAllPackagesQueryResponse> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class GetAllPackagesQueryResponse
{
    public List<Package> Packages { get; set; }
}
