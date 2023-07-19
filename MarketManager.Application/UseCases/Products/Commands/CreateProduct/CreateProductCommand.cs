using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductType maybeProductType =
                await _dbContext.ProductTypes.FindAsync(request.ProductTypeId);

            if (maybeProductType == null)
            {
                throw new NotFoundException("Product type not found.");
            }

            var newProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                ProductType=maybeProductType

            };

            _dbContext.Products.Add(newProduct);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return newProduct.Id;
        }
    }
}
