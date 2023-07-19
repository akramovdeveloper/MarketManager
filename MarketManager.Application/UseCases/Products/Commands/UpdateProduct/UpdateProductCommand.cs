using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FindAsync(request.Id);
            ProductType maybeProductType = await _dbContext.ProductTypes.FindAsync(request.ProductTypeId);

            entity.Description=request.Description;
            entity.Name=request.Name;
            entity.ProductType = maybeProductType;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
