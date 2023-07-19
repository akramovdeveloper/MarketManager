using AutoMapper;
using FluentValidation;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;

public record GetAllPackagesQuery : IRequest<IEnumerable<GetAllPackagesQueryResponse>>;

public class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, IEnumerable<GetAllPackagesQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllPackagesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<IEnumerable<GetAllPackagesQueryResponse>> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Package> packages = _context.Packages;

       return  Task.FromResult(_mapper.Map<IEnumerable<GetAllPackagesQueryResponse>>(packages));

    }
}
public class GetAllPackagesQueryResponse
{   
    public Guid ProductId { get; set; }
    public double IncomingCount { get; set; }
    public double Count { get; set; }
    public Guid SupplierId { get; set; }
    public double IncomingPrice { get; set; }
    public double SalePrice { get; set; }

    public DateTime IncomingDate { get; set; }
}
