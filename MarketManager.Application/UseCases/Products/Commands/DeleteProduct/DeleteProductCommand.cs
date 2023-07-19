using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketManager.Application.Common.Interfaces;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : IRequest;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FindAsync(new object[] { request.ProductId }, cancellationToken);

            _context.Products.Remove(entity);

            entity.AddDomainEvent(new ProductDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
