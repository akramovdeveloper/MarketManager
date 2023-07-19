using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Commands.UpdatePackage;

public class UpdatePackageCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public double IncomingCount { get; set; }
    public double ExistCount { get; set; }
    public Guid SupplierId { get; set; }
    public double IncomingPrice { get; set; }
    public double SalePrice { get; set; }

    public DateTime IncomingDate { get; set; }
}
public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public UpdatePackageCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
    {
        Package? package = await _context.Packages.FindAsync(request.Id);
        _mapper.Map(package, request);

        if (package is null)
            throw new NotFoundException(nameof(Package), request.Id);

        var product = await _context.Products.FindAsync(request.ProductId);
        if (product is null)
            throw new NotFoundException(nameof(Product), request.ProductId);
        //package.ProductId = product.Id;

        var supplier = await _context.Packages.FindAsync(request.SupplierId);
        if (supplier is null)
            throw new NotFoundException(nameof(Supplier), request.SupplierId);
        // package.SupplierId = supplier.Id;

        //_context.Packages.Update(package);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
