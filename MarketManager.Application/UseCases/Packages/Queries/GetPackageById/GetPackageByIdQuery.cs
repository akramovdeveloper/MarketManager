using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetPackageById
{
    public record GetPackageByIdQuery(Guid Id) : IRequest<GetPackageByIdQueryResponse>;

    public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, GetPackageByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetPackageByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetPackageByIdQueryResponse> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            Package? package = await _context.Packages.FindAsync(request.Id);

            if (package is null)
                throw new NotFoundException(nameof(Package), request.Id);

            return _mapper.Map<GetPackageByIdQueryResponse>(package);
        }
    }
    public class GetPackageByIdQueryResponse
    {
        public Guid Id { get; set; }
    }
}
