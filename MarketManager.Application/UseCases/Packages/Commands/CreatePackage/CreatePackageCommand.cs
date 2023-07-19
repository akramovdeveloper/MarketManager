using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Commands.CreatePackage
{
    public class CreatePackageCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public double IncomingCount { get; set; }
        public Guid SupplierId { get; set; }
        public double IncomingPrice { get; set; }
        public double SalePrice { get; set; }

        public DateTime IncomingDate { get; set; }
    }
    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreatePackageCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            Package package = _mapper.Map<Package>(request);
            await _context.Packages.AddAsync(package, cancellationToken);
            await _context.SaveChangesAsync();
            return package.Id;
        }
    }
}
